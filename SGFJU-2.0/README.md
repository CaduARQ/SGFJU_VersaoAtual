# SGFJU 2.0: Next.js + API .NET 10

Tudo da nova versão fica **nesta pasta (`SGFJU-2.0/`)**. O código original, na raiz do repositório, **não é alterado**: ele continua sendo a base de referência e o site antigo segue rodando. As duas versões usam o mesmo banco.

```
SGFJU-2.0/
├── src/          bibliotecas de domínio (cópia do original, migrada para .NET 10) + SGFJU.Api
├── web/          front em Next.js 16, React 19, Tailwind 4
├── dados/        arquivos de execução da API (caches, logs); fora do Git
└── SGFJU2.slnx   solução da nova versão

Navegador ──► web/ ──(/api/*, proxy do Next)──► src/SGFJU.Api ──► Facade ─► NHibernate ─► MySQL
                                                                                        ▲
Site antigo (raiz do repositório, .NET 4.7.2, intocado) ────────────────────────────────┘
```

**Regra:** mudanças só dentro de `SGFJU-2.0/`. Se precisar comparar com o comportamento antigo, consulte o código da raiz, sem editá-lo.

## Como rodar

### 1. API (.NET 10)

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download).

```bash
cd SGFJU-2.0/src/SGFJU.Api
dotnet user-secrets set "ConnectionStrings:banco" "Server=...;Port=3306;Database=SGFJU_DEV;Uid=...;Pwd=..."
dotnet run            # http://localhost:5080  (teste: http://localhost:5080/health)
```

Em produção, use a variável de ambiente `ConnectionStrings__banco`. **Nenhuma senha fica no código.**

`Sgfju:PastaConteudoLegado` (appsettings.json) aponta para a pasta de arquivos de execução (`Serializeds/`, `LogWebApp/`...). Por padrão é `SGFJU-2.0/dados/`. Veja `dados/LEIA-ME.md`.

### 2. Front (Next.js)

Pré-requisito: Node.js 20.9 ou superior.

```bash
cd SGFJU-2.0/web
cp .env.example .env.local   # SGFJU_API_URL=http://localhost:5080
npm install
npm run dev                  # http://localhost:3000
```

Build de produção: `npm run build && npm run start`.

## O que mudou

### Bibliotecas de domínio (`src/`, cópia do original)
- As 11 bibliotecas e os 2 projetos de teste foram copiados da raiz e migrados para **`net10.0`**. As originais continuam como estavam.
- `ConfigurationManager` (web.config) foi trocado por `SgfjuConfig`, que a API preenche a partir do `appsettings.json`/variáveis de ambiente.
- **Desempenho:** a `SessionFactory` do NHibernate era recriada a cada repositório instanciado (várias vezes por requisição). Agora ela é criada uma única vez.
- Testes migrados de .NET Core 3.1 para .NET 10.

### API (`SGFJU.Api`)
- Os **27 controllers** do Web API 2 foram portados com as **mesmas rotas** (`api/...`) e o mesmo formato JSON (PascalCase).
- `formLogin.aspx` virou `POST /api/auth/login`, com cookie HttpOnly. Também há `GET /api/auth/me` e `POST /api/auth/logout`.
- `Session` do IIS → `SessaoLegada` (memória, expira em 2h). Assim como o InProc do IIS, ela supõe **um único servidor** ou sticky sessions.
- Toda a API exige login, exceto `/api/auth/login` e `/health`.
- Erros viram JSON. Em produção a resposta não expõe stack trace.

### Correções encontradas na migração
| Problema | Correção |
|---|---|
| NHibernate 5.2 no .NET moderno recusa todas as entidades ("MemberwiseClone should be virtual") | `use_proxy_validator=false` |
| MySql.Data no .NET moderno falha ao ler palavras reservadas ao criar a SessionFactory | `hbm2ddl.keywords=none` |
| Duas actions na mesma rota `api/Relatorios/TotaisDashboardNacional` (o Web API 2 dava erro de ambiguidade) | a de blocos agora é `api/RelatorioBlocos/TotaisDashboardNacional` |
| Listas de usuários devolviam a **senha em texto puro** para o navegador | na nova API a senha não é mais devolvida |
| Senhas do banco no código | a nova versão não tem nenhuma; tudo vem de configuração |
| 5 actions POST sem `[FromBody]` | corrigido |

### Front (`web/`)
Telas prontas: **login**, **dashboard nacional**, **dashboard estadual**, **jovens** (filtros encadeados, busca, paginação, exportar CSV, link do WhatsApp), **ficha do jovem**, **igrejas/blocos/regiões** e **usuários**. O layout é responsivo e funciona no celular.

O menu segue os mesmos perfis do sistema antigo (`menu*.txt`). Itens ainda não migrados aparecem como **"em breve"** e mostram qual página antiga usar.

## Ações urgentes (fora do código)

1. **Trocar as senhas do MySQL** (`root` e `iurd` em `34.202.180.165`). Elas continuam nos arquivos do código original (`web.config`, `App.config`, `ConsoleTester`) e no histórico do Git. Como o original fica intocado, a proteção é trocar as senhas no servidor e passar a informá-las só por configuração.
2. O site antigo continua devolvendo as senhas dos usuários nas listas, porque não foi alterado. O motivo é mais um para desligá-lo assim que as telas novas cobrirem o uso.
3. **As senhas dos usuários estão em texto puro no banco** (`SGFJU_TBL_USUARIO.Senha`). Próximo passo recomendado: hash com PBKDF2/BCrypt e migração no próximo login de cada usuário.
4. As queries SQL usam o nome do schema fixo (`SGFJU_DEV.` / `sgfju_dev.`, 342 ocorrências). Isso já era assim. Em MySQL no Linux, mantenha `lower_case_table_names=1`.

## Como isto foi testado

- Todos os projetos de `SGFJU-2.0/src` compilam em `net10.0`.
- A API foi executada contra um MySQL 8 com o schema gerado a partir dos mapeamentos do NHibernate. Funcionaram ponta a ponta: login (senha certa e errada), cookie, `/me`, logout (401 depois), menus, blocos, regiões, igrejas, usuários (sem senha) e pesquisa de jovens.
- O front foi compilado (`next build`), passou no lint e foi navegado num Chrome headless (login, estrutura, jovens, usuários, celular).
- **Não testado aqui:** dashboards e ficha completa do jovem. Eles dependem de *stored procedures* (`ATUALIZA_TOTAIS_DASHBOARD_ESTADO` etc.) e de dados relacionados que só existem no banco de produção e não estão no repositório. **Valide contra uma cópia do banco real antes de publicar.**
- Pacotes NuGet mantidos nas versões atuais (só o Newtonsoft.Json foi para 13.0.3 por segurança). Atualizar NHibernate (5.5), FluentNHibernate (3.x) e MySql.Data (9.x) é o próximo passo, com testes contra o banco.

## Checklist das telas restantes

As rotas da API já existem. Falta só a tela em React.

- [ ] Novo jovem / Altera jovem (`RegistraJovem.aspx`, `AlteraJovem.aspx`): o maior formulário. Usa a sessão para idiomas, habilidades e cursos
- [ ] Consulta geral (`ConsultaGeral*.html`)
- [ ] Autorizações e dashboard de camisas
- [ ] Árvore da Vida (dashboards, associar/desassociar, obreiros, acompanhamento)
- [ ] Altar Jovem (nacional/estadual, levantados, relatório)
- [ ] Coordenadores e panorama do estado
- [ ] Relatórios de reunião FJU
- [ ] Instituições de ensino (Help)
- [ ] Patrimônio e despesas
- [ ] Testemunho (busca especializada)
- [ ] Painel de controle (Secretaria BR) e log de ações
- [ ] Cadastro e edição de igreja/bloco/região e de usuário (os endpoints já existem)
- [ ] Transferência de jovens e igrejas
