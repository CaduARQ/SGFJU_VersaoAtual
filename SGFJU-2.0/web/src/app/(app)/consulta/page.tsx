"use client";

import { useEffect, useMemo, useState, type FormEvent, type ReactNode } from "react";
import { Plus, RotateCcw, Search, ShieldAlert, Trash2 } from "lucide-react";
import { api } from "@/lib/api";
import type { JovemResumo } from "@/lib/types";
import { OPCOES } from "@/lib/opcoes-cadastro";
import { useAuth } from "@/components/auth-provider";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { TabelaJovens } from "@/components/tabela-jovens";
import { Badge, Button, Card, cx, Empty, ErrorBox, Field, Input, Loading, PageHeader, Select } from "@/components/ui";

// ---------------------------------------------------------------- modelo
type T3 = "" | "S" | "N"; // indiferente | sim | não

const SIM_NAO = {
  obra: [
    ["EhObreiro", "Obreiro(a)"], ["EhColaborador", "Colaborador(a)"], ["EhCPO", "Cursando CPO"], ["EhMembroFJU", "Membro da FJU"],
    ["EhCoordenadorFJU", "Coordenador(a) FJU"], ["EhLiderTribo", "Líder de tribo"], ["EhLiderProjeto", "Líder de projeto"],
    ["EhAltarJovem", "Altar Jovem"], ["EhAltarJovem318", "Altar Jovem 318"], ["DesejaSerObreiro", "Deseja ser obreiro"],
    ["DesejaFazerObraAltar", "Deseja fazer a obra"], ["FoiObreiro", "Já foi obreiro"], ["FoiPastor", "Já foi pastor(a)"],
    ["PertenceIntellimen", "Intellimen"], ["DesafiosConcluidos", "Concluiu desafios"],
  ],
  espiritual: [
    ["EhMembroIURD", "Membro da Universal"], ["EhBatizadoAguas", "Batizado nas águas"], ["EhBatizadoEspiritoSanto", "Batizado no Espírito Santo"],
    ["JaSeAfastou", "Já se afastou"], ["TemFamiliaresIURD", "Tem familiares na Universal"], ["PossuiBiblia", "Tem Bíblia"],
    ["LeuTodaBiblia", "Leu a Bíblia toda"],
  ],
  vida: [
    ["TrabalhaAtualmente", "Trabalha"], ["EstudaAtualmente", "Estuda"], ["PossuiNivelSuperior", "Faz/fez faculdade"],
    ["DesejaCursarNivelSuperior", "Deseja fazer faculdade"], ["PossuiTituloEleitor", "Tem título de eleitor"],
    ["ConjugeEhIURD", "Cônjuge na Universal"], ["PertenceGrupoMulheresIURD", "Grupo de mulheres"],
  ],
  redes: [
    ["EhSeguidorOficialFJU", "Segue a FJU oficial"], ["EhSeguidorYoutube", "Segue no YouTube"], ["EhSeguidorTelegram", "Segue no Telegram"],
    ["EhAssinanteUNIVER", "Assina Univer Vídeo"], ["EhLeitorBlogBM", "Lê o blog do Bispo"], ["EhLeitorUniversalorg", "Lê universal.org"],
    ["PossuiCelularComInternet", "Celular com internet"], ["PossuiComputador", "Tem computador"],
  ],
  sensiveis: [
    ["SofreuComDepressao", "Já sofreu com depressão"], ["SofreuAutomutilacao", "Já se automutilou"], ["SofreuVicio", "Já teve vício"],
    ["TentouSuicidio", "Já tentou tirar a própria vida"],
  ],
} as const;

type ChaveSN = (typeof SIM_NAO)[keyof typeof SIM_NAO][number][0];

type Filtros = {
  estrutura: FiltroValor;
  Nome: string; Sexo: "" | "M" | "F"; ClassificacaoJovem: string; IdadeInicial: number; IdadeFinal: number;
  IdTipoEstadoCivil: number; IdTipoMoradia: number; EhParaListarFichasExpiradas: boolean;
  Escolaridade: string; Profissao: string; NomeCursoSuperior: string;
  IdReuniaoFJU: number; IdIdiomaFalado: number; IdNivelIdiomaFalado: number;
  Projetos: number[]; Departamentos: number[]; Tons: number[];
  Habilidades: { IdHabilidade: number; IdNivel: number; rotulo: string }[];
  CadastroDe: string; CadastroAte: string; AtualizacaoDe: string; AtualizacaoAte: string;
  sn: Partial<Record<ChaveSN, T3>>;
};

const vazio = (u: { EhAdm: boolean; IdEstado: number }): Filtros => ({
  estrutura: { idEstado: u.EhAdm ? 0 : u.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 },
  Nome: "", Sexo: "", ClassificacaoJovem: "", IdadeInicial: 0, IdadeFinal: 0, IdTipoEstadoCivil: 0, IdTipoMoradia: 0,
  EhParaListarFichasExpiradas: false, Escolaridade: "", Profissao: "", NomeCursoSuperior: "",
  IdReuniaoFJU: 0, IdIdiomaFalado: 0, IdNivelIdiomaFalado: 0, Projetos: [], Departamentos: [], Tons: [], Habilidades: [],
  CadastroDe: "", CadastroAte: "", AtualizacaoDe: "", AtualizacaoAte: "", sn: {},
});

function paraApi(f: Filtros) {
  const faixa = (de: string, ate: string) => (de && ate ? { DataInicial: de, DataFinal: ate } : null);
  return {
    IdEstado: f.estrutura.idEstado, IdBlocoJovem: f.estrutura.idBloco, IdRegiao: f.estrutura.idRegiao, IdIgreja: f.estrutura.idIgreja,
    Nome: f.Nome.trim() || null, Sexo: f.Sexo, ClassificacaoJovem: f.ClassificacaoJovem,
    IdadeInicial: f.IdadeInicial, IdadeFinal: f.IdadeFinal, IdTipoEstadoCivil: f.IdTipoEstadoCivil, IdTipoMoradia: f.IdTipoMoradia,
    EhParaListarFichasExpiradas: f.EhParaListarFichasExpiradas ? "S" : "",
    Escolaridade: f.Escolaridade || null, Profissao: f.Profissao.trim() || null, NomeCursoSuperior: f.NomeCursoSuperior.trim() || null,
    IdReuniaoFJU: f.IdReuniaoFJU, IdIdiomaFalado: f.IdIdiomaFalado, IdNivelIdiomaFalado: f.IdIdiomaFalado ? f.IdNivelIdiomaFalado : 0,
    IdsProjetosSelecionadosParaPesquisa: f.Projetos, DepartamentosSelecionados: f.Departamentos, TonsDeVozSelecionados: f.Tons,
    ParametrosHabilidade: f.Habilidades.map(({ IdHabilidade, IdNivel }) => ({ IdHabilidade, IdNivel })),
    RangeDataCadastro: faixa(f.CadastroDe, f.CadastroAte), RangeDataUltimaAtualizacao: faixa(f.AtualizacaoDe, f.AtualizacaoAte),
    ...Object.fromEntries(Object.entries(f.sn).map(([k, v]) => [k, v || ""])),
  };
}

function contarAtivos(f: Filtros) {
  return [
    f.estrutura.idBloco, f.estrutura.idRegiao, f.estrutura.idIgreja, f.Nome.trim(), f.Sexo, f.ClassificacaoJovem, f.IdadeInicial || f.IdadeFinal,
    f.IdTipoEstadoCivil, f.IdTipoMoradia, f.EhParaListarFichasExpiradas, f.Escolaridade, f.Profissao.trim(), f.NomeCursoSuperior.trim(),
    f.IdReuniaoFJU, f.IdIdiomaFalado, f.CadastroDe && f.CadastroAte, f.AtualizacaoDe && f.AtualizacaoAte,
  ].filter(Boolean).length + f.Projetos.length + f.Departamentos.length + f.Tons.length + f.Habilidades.length + Object.values(f.sn).filter(Boolean).length;
}

type Resultado = { Total: number; Truncado: boolean; Jovens: JovemResumo[] };
const CHAVE = "sgfju:ultima-consulta";

// ---------------------------------------------------------------- componentes
function Grupo({ titulo, ativos, children, aberto = false, alerta }: { titulo: string; ativos: number; children: ReactNode; aberto?: boolean; alerta?: ReactNode }) {
  return (
    <details open={aberto} className="group rounded-lg border border-slate-200">
      <summary className="flex cursor-pointer list-none items-center justify-between px-4 py-3 text-sm font-semibold text-slate-800">
        <span>{titulo}</span>
        <span className="flex items-center gap-2">
          {ativos > 0 && <Badge tone="blue">{ativos} {ativos === 1 ? "filtro" : "filtros"}</Badge>}
          <span className="text-slate-400 transition group-open:rotate-180">▾</span>
        </span>
      </summary>
      <div className="space-y-4 border-t border-slate-100 p-4">
        {alerta}
        {children}
      </div>
    </details>
  );
}

/** Pílula de três estados: indiferente → Sim → Não → indiferente. */
function Pilula({ rotulo, valor, onChange }: { rotulo: string; valor: T3; onChange: (v: T3) => void }) {
  const prox: Record<T3, T3> = { "": "S", S: "N", N: "" };
  return (
    <button
      type="button"
      onClick={() => onChange(prox[valor])}
      title="Clique para alternar: indiferente → Sim → Não"
      className={cx(
        "rounded-full border px-3 py-1 text-sm transition",
        valor === "S" && "border-emerald-600 bg-emerald-50 font-medium text-emerald-800",
        valor === "N" && "border-red-400 bg-red-50 font-medium text-red-700 line-through decoration-1",
        valor === "" && "border-slate-300 text-slate-600 hover:bg-slate-50",
      )}
    >
      {valor === "S" ? "✓ " : valor === "N" ? "✕ " : ""}
      {rotulo}
    </button>
  );
}

function Chips({ opcoes, selecionados, onChange }: { opcoes: readonly { id: number; nome: string }[]; selecionados: number[]; onChange: (v: number[]) => void }) {
  return (
    <div className="flex flex-wrap gap-2">
      {opcoes.map((o) => {
        const ativo = selecionados.includes(o.id);
        return (
          <button key={o.id} type="button" aria-pressed={ativo}
            onClick={() => onChange(ativo ? selecionados.filter((x) => x !== o.id) : [...selecionados, o.id])}
            className={cx("rounded-full border px-3 py-1 text-sm transition", ativo ? "border-brand bg-brand/10 font-medium text-brand" : "border-slate-300 text-slate-600 hover:bg-slate-50")}>
            {o.nome}
          </button>
        );
      })}
    </div>
  );
}

// ---------------------------------------------------------------- página
export default function ConsultaGeral() {
  const { usuario } = useAuth();
  const [f, setF] = useState<Filtros>(() => vazio(usuario));
  const [resultado, setResultado] = useState<Resultado | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);
  const [area, setArea] = useState<keyof typeof OPCOES.habilidades>("Dança");
  const [hab, setHab] = useState(0);
  const [nivelHab, setNivelHab] = useState(0);

  // Restaura a última consulta ao voltar da ficha de um jovem (como a tela antiga fazia).
  useEffect(() => {
    try {
      const salvo = sessionStorage.getItem(CHAVE);
      if (salvo) {
        const { filtros, resultado } = JSON.parse(salvo) as { filtros: Filtros; resultado: Resultado };
        queueMicrotask(() => { setF(filtros); setResultado(resultado); });
      }
    } catch { /* sem armazenamento: começa do zero */ }
  }, []);

  const set = <K extends keyof Filtros>(k: K, v: Filtros[K]) => setF((x) => ({ ...x, [k]: v }));
  const setSn = (k: ChaveSN, v: T3) => setF((x) => ({ ...x, sn: { ...x.sn, [k]: v } }));
  const ativosDe = (lista: readonly (readonly [ChaveSN, string])[]) => lista.filter(([k]) => f.sn[k]).length;
  const total = useMemo(() => contarAtivos(f), [f]);

  async function consultar(e?: FormEvent) {
    e?.preventDefault();
    setCarregando(true);
    setErro(null);
    try {
      const r = await api.post<Resultado>("v2/jovens/consulta", paraApi(f));
      setResultado(r);
      try { sessionStorage.setItem(CHAVE, JSON.stringify({ filtros: f, resultado: r })); } catch { /* resultado grande demais: segue sem guardar */ }
    } catch (err) {
      setErro((err as Error).message);
    } finally {
      setCarregando(false);
    }
  }

  function limpar() {
    setF(vazio(usuario));
    setResultado(null);
    try { sessionStorage.removeItem(CHAVE); } catch { /* ignora */ }
  }

  function addHabilidade() {
    if (!hab) return;
    const nome = OPCOES.habilidades[area].find((h) => h.id === hab)?.nome ?? "";
    const nivel = OPCOES.niveis.find((n) => n.id === nivelHab)?.nome;
    if (f.Habilidades.some((h) => h.IdHabilidade === hab && h.IdNivel === nivelHab)) return;
    set("Habilidades", [...f.Habilidades, { IdHabilidade: hab, IdNivel: nivelHab, rotulo: `${area}: ${nome}${nivel ? ` (${nivel})` : ""}` }]);
    setHab(0);
  }

  const lista = (grupo: readonly (readonly [ChaveSN, string])[]) => (
    <div className="flex flex-wrap gap-2">
      {grupo.map(([k, rot]) => <Pilula key={k} rotulo={rot} valor={f.sn[k] ?? ""} onChange={(v) => setSn(k, v)} />)}
    </div>
  );

  return (
    <>
      <PageHeader title="Consulta geral" subtitle="Combine filtros para encontrar jovens. Nas pílulas, clique para alternar entre indiferente, Sim (✓) e Não (✕)." />
      <form onSubmit={consultar}>
        <Card>
          <div className="space-y-3">
            <Grupo titulo="Quem e onde" ativos={[f.estrutura.idBloco, f.estrutura.idRegiao, f.estrutura.idIgreja, f.Nome.trim(), f.Sexo, f.ClassificacaoJovem, f.IdadeInicial || f.IdadeFinal, f.IdTipoEstadoCivil, f.IdTipoMoradia, f.EhParaListarFichasExpiradas].filter(Boolean).length} aberto>
              <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4">
                <FiltroEstrutura valor={f.estrutura} onChange={(v) => set("estrutura", v)} />
                <Field label="Nome"><Input value={f.Nome} onChange={(e) => set("Nome", e.target.value)} placeholder="Parte do nome" /></Field>
                <Field label="Sexo">
                  <Select value={f.Sexo} onChange={(e) => set("Sexo", e.target.value as Filtros["Sexo"])}>
                    <option value="">Todos</option><option value="M">Masculino</option><option value="F">Feminino</option>
                  </Select>
                </Field>
                <Field label="Classificação">
                  <Select value={f.ClassificacaoJovem} onChange={(e) => set("ClassificacaoJovem", e.target.value)}>
                    <option value="">Todas</option>
                    {OPCOES.classificacoes.map((c) => <option key={c.id} value={c.id}>{c.nome}</option>)}
                    <option value="O">Sem classificação</option>
                  </Select>
                </Field>
                <Field label="Idade">
                  <div className="grid grid-cols-2 gap-2">
                    <Input type="number" min={0} max={120} placeholder="De" value={f.IdadeInicial || ""} onChange={(e) => set("IdadeInicial", Number(e.target.value) || 0)} />
                    <Input type="number" min={0} max={120} placeholder="Até" value={f.IdadeFinal || ""} onChange={(e) => set("IdadeFinal", Number(e.target.value) || 0)} />
                  </div>
                </Field>
                <Field label="Estado civil">
                  <Select value={f.IdTipoEstadoCivil} onChange={(e) => set("IdTipoEstadoCivil", Number(e.target.value))}>
                    <option value={0}>Todos</option>{OPCOES.estadosCivis.map((o) => <option key={o.id} value={o.id}>{o.nome}</option>)}
                  </Select>
                </Field>
                <Field label="Mora com">
                  <Select value={f.IdTipoMoradia} onChange={(e) => set("IdTipoMoradia", Number(e.target.value))}>
                    <option value={0}>Todos</option>{OPCOES.tiposMoradia.map((o) => <option key={o.id} value={o.id}>{o.nome}</option>)}
                  </Select>
                </Field>
                <label className="flex items-end gap-2 pb-2 text-sm text-slate-600">
                  <input type="checkbox" checked={f.EhParaListarFichasExpiradas} onChange={(e) => set("EhParaListarFichasExpiradas", e.target.checked)} /> Só fichas expiradas
                </label>
              </div>
            </Grupo>

            <Grupo titulo="Na obra" ativos={ativosDe(SIM_NAO.obra)}>{lista(SIM_NAO.obra)}</Grupo>

            <Grupo titulo="Vida espiritual" ativos={ativosDe(SIM_NAO.espiritual) + (f.IdReuniaoFJU ? 1 : 0)}>
              {lista(SIM_NAO.espiritual)}
              <Field label="Frequenta a reunião">
                <Select value={f.IdReuniaoFJU} onChange={(e) => set("IdReuniaoFJU", Number(e.target.value))} className="sm:w-72">
                  <option value={0}>Qualquer</option>{OPCOES.reunioes.map((r) => <option key={r.id} value={r.id}>{r.nome}</option>)}
                </Select>
              </Field>
            </Grupo>

            <Grupo titulo="Projetos, habilidades e idiomas" ativos={f.Projetos.length + f.Departamentos.length + f.Tons.length + f.Habilidades.length + (f.IdIdiomaFalado ? 1 : 0)}>
              <Field label="Participa de algum destes projetos"><Chips opcoes={OPCOES.projetos} selecionados={f.Projetos} onChange={(v) => set("Projetos", v)} /></Field>
              <Field label="Departamentos"><Chips opcoes={OPCOES.departamentos} selecionados={f.Departamentos} onChange={(v) => set("Departamentos", v)} /></Field>
              <Field label="Tom de voz"><Chips opcoes={OPCOES.tonsDeVoz} selecionados={f.Tons} onChange={(v) => set("Tons", v)} /></Field>
              <div>
                <p className="mb-1.5 text-sm font-medium text-slate-700">Tem alguma destas habilidades</p>
                <div className="grid items-end gap-3 sm:grid-cols-[10rem_1fr_10rem_auto]">
                  <Select value={area} onChange={(e) => { setArea(e.target.value as typeof area); setHab(0); }}>
                    {Object.keys(OPCOES.habilidades).map((g) => <option key={g}>{g}</option>)}
                  </Select>
                  <Select value={hab} onChange={(e) => setHab(Number(e.target.value))}>
                    <option value={0}>Escolha</option>{OPCOES.habilidades[area].map((h) => <option key={h.id} value={h.id}>{h.nome}</option>)}
                  </Select>
                  <Select value={nivelHab} onChange={(e) => setNivelHab(Number(e.target.value))}>
                    <option value={0}>Qualquer nível</option>{OPCOES.niveis.map((n) => <option key={n.id} value={n.id}>{n.nome}</option>)}
                  </Select>
                  <Button type="button" variant="ghost" onClick={addHabilidade} disabled={!hab}><Plus className="size-4" /> Adicionar</Button>
                </div>
                {f.Habilidades.length > 0 && (
                  <ul className="mt-2 flex flex-wrap gap-2">
                    {f.Habilidades.map((h, i) => (
                      <li key={h.rotulo} className="flex items-center gap-1 rounded-full bg-slate-100 py-1 pl-3 pr-1 text-sm text-slate-700">
                        {h.rotulo}
                        <button type="button" onClick={() => set("Habilidades", f.Habilidades.filter((_, j) => j !== i))} className="rounded-full p-1 hover:bg-slate-200" aria-label={`Remover ${h.rotulo}`}>
                          <Trash2 className="size-3.5" />
                        </button>
                      </li>
                    ))}
                  </ul>
                )}
              </div>
              <div className="grid gap-3 sm:grid-cols-2 lg:w-2/3">
                <Field label="Fala o idioma">
                  <Select value={f.IdIdiomaFalado} onChange={(e) => set("IdIdiomaFalado", Number(e.target.value))}>
                    <option value={0}>Qualquer</option>{OPCOES.idiomas.map((i) => <option key={i.id} value={i.id}>{i.nome}</option>)}
                  </Select>
                </Field>
                <Field label="Nível no idioma">
                  <Select value={f.IdNivelIdiomaFalado} disabled={!f.IdIdiomaFalado} onChange={(e) => set("IdNivelIdiomaFalado", Number(e.target.value))}>
                    <option value={0}>Qualquer nível</option>{OPCOES.niveis.map((n) => <option key={n.id} value={n.id}>{n.nome}</option>)}
                  </Select>
                </Field>
              </div>
            </Grupo>

            <Grupo titulo="Estudo, trabalho e família" ativos={ativosDe(SIM_NAO.vida) + [f.Escolaridade, f.Profissao.trim(), f.NomeCursoSuperior.trim()].filter(Boolean).length}>
              {lista(SIM_NAO.vida)}
              <div className="grid gap-4 sm:grid-cols-3">
                <Field label="Escolaridade">
                  <Select value={f.Escolaridade} onChange={(e) => set("Escolaridade", e.target.value)}>
                    <option value="">Qualquer</option>{OPCOES.escolaridades.map((n) => <option key={n}>{n}</option>)}
                  </Select>
                </Field>
                <Field label="Profissão"><Input value={f.Profissao} onChange={(e) => set("Profissao", e.target.value)} /></Field>
                <Field label="Curso superior"><Input value={f.NomeCursoSuperior} onChange={(e) => set("NomeCursoSuperior", e.target.value)} /></Field>
              </div>
            </Grupo>

            <Grupo titulo="Redes sociais e mídia" ativos={ativosDe(SIM_NAO.redes)}>{lista(SIM_NAO.redes)}</Grupo>

            <Grupo titulo="Datas da ficha" ativos={[f.CadastroDe && f.CadastroAte, f.AtualizacaoDe && f.AtualizacaoAte].filter(Boolean).length}>
              <div className="grid gap-4 sm:grid-cols-2">
                <Field label="Cadastrado entre">
                  <div className="grid grid-cols-2 gap-2">
                    <Input type="date" value={f.CadastroDe} onChange={(e) => set("CadastroDe", e.target.value)} />
                    <Input type="date" value={f.CadastroAte} onChange={(e) => set("CadastroAte", e.target.value)} />
                  </div>
                </Field>
                <Field label="Atualizado entre">
                  <div className="grid grid-cols-2 gap-2">
                    <Input type="date" value={f.AtualizacaoDe} onChange={(e) => set("AtualizacaoDe", e.target.value)} />
                    <Input type="date" value={f.AtualizacaoAte} onChange={(e) => set("AtualizacaoAte", e.target.value)} />
                  </div>
                </Field>
              </div>
            </Grupo>

            <Grupo
              titulo="Superação (dados sensíveis)"
              ativos={ativosDe(SIM_NAO.sensiveis)}
              alerta={
                <div className="flex gap-2 rounded-lg border border-amber-200 bg-amber-50 p-3 text-xs text-amber-900">
                  <ShieldAlert className="size-4 shrink-0" />
                  Use só para cuidado pastoral. São dados sensíveis protegidos pela LGPD: não exporte nem compartilhe listas com esses filtros.
                </div>
              }
            >
              {lista(SIM_NAO.sensiveis)}
            </Grupo>
          </div>

          <div className="mt-5 flex flex-wrap items-center justify-between gap-3 border-t border-slate-100 pt-4">
            <span className="text-sm text-slate-500">{total === 0 ? "Nenhum filtro: traz todos os jovens que você pode ver." : `${total} ${total === 1 ? "filtro ativo" : "filtros ativos"}`}</span>
            <div className="flex gap-2">
              <Button type="button" variant="ghost" onClick={limpar}><RotateCcw className="size-4" /> Limpar</Button>
              <Button type="submit" disabled={carregando}><Search className="size-4" /> Consultar</Button>
            </div>
          </div>
        </Card>
      </form>

      <Card className="mt-6">
        {carregando && <Loading text="Consultando..." />}
        {erro && <ErrorBox message={erro} onRetry={() => consultar()} />}
        {!carregando && !erro && !resultado && <Empty text="Monte os filtros acima e clique em Consultar." />}
        {!carregando && resultado && (
          <>
            {resultado.Truncado && (
              <p className="mb-3 rounded-lg bg-amber-50 p-3 text-sm text-amber-900">
                A consulta encontrou {resultado.Total.toLocaleString("pt-BR")} jovens; mostrando os primeiros 5.000. Refine os filtros.
              </p>
            )}
            <TabelaJovens jovens={resultado.Jovens} nomeArquivo="consulta-geral-sgfju" />
          </>
        )}
      </Card>
    </>
  );
}
