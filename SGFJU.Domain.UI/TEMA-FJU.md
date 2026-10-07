# Tema FJU para o Inspinia

Tema visual do SGFJU com a identidade da Força Jovem Universal, aplicado **por cima do Inspinia** sem mudar o HTML das páginas.

- **Arquivo:** `css/fju-tema.css`, carregado logo depois de `css/style.css` em todas as páginas.
- **Vitrine:** `TemaFJU.html` mostra todos os componentes do Inspinia já com o tema. É estática e não chama a API.
- **Logos:** `img/fju-logo-claro.png` (para o menu marinho) e `img/fju-logo-marinho.png` (para fundos claros).
- **Para desligar:** remova a linha `<link href="css/fju-tema.css" rel="stylesheet">` da página (ou de todas).

## Paleta

| Token | Cor | Uso |
|---|---|---|
| `--marinho` | `#1a2135` | Cor do logo FJU. Menu lateral, tooltips. |
| `--chama` | `#ffbf1f` | Destaque: item ativo do menu, widget principal, contadores. Texto sobre ela: `--on-chama`. |
| `--primaria` | `#2350d1` | Ação: `btn-primary`, links, paginação, aba ativa, foco. |
| `--sucesso` | `#1b7346` | Ativo, entregue, autorizado. |
| `--info` | `#1f6493` | Em acompanhamento, em andamento. |
| `--alerta` | `#9a4f00` | Pendente, aguardando. |
| `--perigo` | `#b42826` | Erro, exclusão, desligado. |
| `--fundo` / `--superficie` / `--linha` | `#f5f6fa` / `#ffffff` / `#d9dde8` | Fundo da página, cards, bordas. |

Todos os pares de texto e fundo passam no contraste WCAG AA (4,5:1).

## O que mudou em relação ao Inspinia

| Inspinia | Tema FJU |
|---|---|
| Menu `#2f4050` com faixa verde no item ativo | Menu marinho com logo FJU no topo e faixa amarela (`chama`) no item ativo |
| `btn-primary` verde-água `#1ab394` | Azul de ação `--primaria` |
| `btn-success` / `label-success` **azul** `#1c84c6` (peculiaridade do Inspinia) | Verde de verdade (`--sucesso`) |
| `btn-warning` laranja | Amarelo `chama` com texto marinho |
| Labels sólidos e quadrados | Pílulas com fundo suave e texto forte |
| `ibox` reto, com borda superior cinza | Card com cantos de 16px, borda fina e sombra leve |
| Abas com "caixa" | Abas com sublinhado azul |
| Cabeçalho de tabela comum | Cabeçalho em caixa alta, fundo `--superficie-2` |
| Open Sans | Rubik nos títulos e Figtree no texto (Google Fonts) |

## Regras de uso ao criar telas novas

1. **Uma ação principal por tela ou por ibox** (`btn-primary`). O resto é `btn-white`.
2. **Status sempre com palavra**: `label-success` "Ativo", `label-warning` "Pendente". Não use a cor sozinha.
3. **Use a cor pelo significado, não pela aparência**: `label-success` = positivo, `label-danger` = problema.
4. **Amarelo `chama` é raro**: um widget de destaque por dashboard (`yellow-bg`) e o menu.
5. **Evite cores fixas no `<style>` da página** (como `border-color: #1C84C6`). Use as variáveis: `var(--primaria)`, `var(--linha)`.
6. Botões com verbo + objeto: "Salvar cadastro", "Registrar jovem", "Exportar planilha".

## Fontes

As fontes vêm do Google Fonts via `@import` no topo de `css/fju-tema.css`. Se o servidor não tiver acesso à internet, o tema usa automaticamente Trebuchet MS (títulos) e Segoe UI (texto).

## Próximos passos sugeridos

- Centralizar o menu lateral e a barra superior em um único arquivo (hoje estão repetidos em cerca de 63 páginas).
- Remover os `<style>` locais que fixam cores antigas (ex.: `PainelControle.html`).
- Avaliar o tema escuro: os tokens já estão prontos no design system.
