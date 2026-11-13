"use client";

import Link from "next/link";
import { useEffect, useRef, useState } from "react";
import { ArrowLeft, ArrowRight, Check, CheckCircle2, Save } from "lucide-react";
import { api, ApiError } from "@/lib/api";
import { cadastroVazio, errosIdentificacao, paraApi, type CadastroJovem } from "@/lib/cadastro";
import { useAuth } from "@/components/auth-provider";
import type { FiltroValor } from "@/components/filtro-estrutura";
import { Button, Card, cx, ErrorBox, PageHeader } from "@/components/ui";
import { EtapaContato, EtapaEspiritual, EtapaEstudoTrabalho, EtapaIdentificacao, EtapaObra, EtapaTalentos, EtapaTestemunho, type EtapaProps } from "./etapas";

export type ModoFormulario = { tipo: "novo" } | { tipo: "editar"; idJovem: number; inicial: CadastroJovem; filtro: FiltroValor; fotoUrl: string | null };

const ETAPAS = ["Identificação", "Contato e família", "Vida espiritual", "Na obra", "Projeto e talentos", "Estudo e trabalho", "Testemunho"];
const CHAVE_RASCUNHO = "sgfju:rascunho-cadastro-jovem";

type Rascunho = { cadastro: CadastroJovem; filtro: FiltroValor; etapa: number; salvoEm: string };

function lerRascunho(): Rascunho | null {
  try {
    const t = localStorage.getItem(CHAVE_RASCUNHO);
    return t ? (JSON.parse(t) as Rascunho) : null;
  } catch {
    return null;
  }
}

export function FormularioJovem({ modo }: { modo: ModoFormulario }) {
  const editando = modo.tipo === "editar";
  const { usuario } = useAuth();
  const filtroInicial: FiltroValor = { idEstado: usuario.EhAdm ? 0 : usuario.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 };

  const [c, setC] = useState<CadastroJovem>(() => (modo.tipo === "editar" ? modo.inicial : cadastroVazio()));
  const [filtro, setFiltro] = useState<FiltroValor>(() => (modo.tipo === "editar" ? modo.filtro : filtroInicial));
  const [etapa, setEtapa] = useState(0);
  const [foto, setFoto] = useState<File | null>(null);
  const [documento, setDocumento] = useState<File | null>(null);
  const [erros, setErros] = useState<string[]>([]);
  const [enviando, setEnviando] = useState(false);
  const [erroEnvio, setErroEnvio] = useState<string | null>(null);
  const [resultado, setResultado] = useState<{ id: number; avisoArquivo?: string } | null>(null);
  const [rascunho, setRascunho] = useState<Rascunho | null>(null);
  const topo = useRef<HTMLDivElement>(null);

  // Oferece retomar um rascunho salvo neste navegador.
  useEffect(() => {
    if (editando) return;
    const r = lerRascunho();
    if (r && r.cadastro.Nome) queueMicrotask(() => setRascunho(r));
  }, [editando]);

  // Salva rascunho automaticamente (só neste navegador; arquivos não entram).
  useEffect(() => {
    if (editando || (!c.Nome && !c.IdIgreja)) return;
    const id = setTimeout(() => {
      try {
        localStorage.setItem(CHAVE_RASCUNHO, JSON.stringify({ cadastro: c, filtro, etapa, salvoEm: new Date().toISOString() }));
      } catch {
        /* armazenamento indisponível: segue sem rascunho */
      }
    }, 800);
    return () => clearTimeout(id);
  }, [c, filtro, etapa, editando]);

  const set: EtapaProps["set"] = (campo, valor) => setC((atual) => ({ ...atual, [campo]: valor }));
  const sub: EtapaProps["sub"] = (secao, campo, valor) => setC((atual) => ({ ...atual, [secao]: { ...atual[secao], [campo]: valor } }));
  const props: EtapaProps = { c, set, sub };

  function irPara(n: number) {
    if (n > 0 && etapa === 0) {
      const e = errosIdentificacao(c);
      setErros(e);
      if (e.length) return;
    }
    setErros([]);
    setEtapa(n);
    topo.current?.scrollIntoView({ behavior: "smooth", block: "start" });
  }

  async function salvar() {
    const e = errosIdentificacao(c);
    if (e.length) {
      setErros(e);
      setEtapa(0);
      return;
    }
    setEnviando(true);
    setErroEnvio(null);
    try {
      const r =
        modo.tipo === "editar"
          ? await api.put<{ IdJovem: number }>(`v2/jovens/${modo.idJovem}`, paraApi(c))
          : await api.post<{ IdJovem: number }>("v2/jovens", paraApi(c));
      let avisoArquivo: string | undefined;
      if (foto || documento) {
        const fd = new FormData();
        if (foto) fd.append("foto", foto);
        if (documento) fd.append("documento", documento);
        const up = await fetch(`/api/v2/jovens/${r.IdJovem}/arquivos`, { method: "POST", body: fd, credentials: "include" });
        if (!up.ok) avisoArquivo = "Os dados foram salvos, mas a foto/documento não foi enviado. Tente de novo.";
      }
      try {
        localStorage.removeItem(CHAVE_RASCUNHO);
      } catch {
        /* ignora */
      }
      setResultado({ id: r.IdJovem, avisoArquivo });
    } catch (err) {
      setErroEnvio(err instanceof ApiError ? err.message : "Não foi possível salvar. Seus dados continuam aqui; tente de novo.");
    } finally {
      setEnviando(false);
    }
  }

  function novoCadastro() {
    setC(cadastroVazio());
    setFiltro(filtroInicial);
    setFoto(null);
    setDocumento(null);
    setEtapa(0);
    setResultado(null);
  }

  if (resultado)
    return (
      <Card className="mx-auto max-w-lg">
        <div className="flex flex-col items-center gap-3 py-6 text-center">
          <CheckCircle2 className="size-12 text-emerald-600" />
          <h1 className="text-xl font-semibold text-slate-900">{editando ? "Alterações salvas!" : "Jovem cadastrado!"}</h1>
          <p className="text-sm text-slate-500">{editando ? `A ficha de ${c.Nome} foi atualizada.` : `${c.Nome} já aparece na lista de jovens.`}</p>
          {resultado.avisoArquivo && <ErrorBox message={resultado.avisoArquivo} />}
          <div className="mt-2 flex gap-2">
            <Link href={`/jovens/${resultado.id}`} className="rounded-lg px-4 py-2 text-sm font-medium text-slate-700 hover:bg-slate-100">
              Ver ficha
            </Link>
            {editando ? (
              <Button onClick={() => setResultado(null)}>Continuar editando</Button>
            ) : (
              <Button onClick={novoCadastro}>Cadastrar outro jovem</Button>
            )}
          </div>
        </div>
      </Card>
    );

  const ultima = etapa === ETAPAS.length - 1;

  return (
    <div ref={topo} className="scroll-mt-24">
      {editando && (
        <Link href={`/jovens/${modo.idJovem}`} className="mb-4 inline-flex items-center gap-1 text-sm text-slate-500 hover:text-slate-800">
          <ArrowLeft className="size-4" /> Voltar para a ficha
        </Link>
      )}
      <PageHeader
        title={editando ? `Editar: ${modo.inicial.Nome}` : "Novo jovem"}
        subtitle={editando ? "Navegue pelas etapas e salve quando terminar. Só o que você mudar é alterado." : "Os campos com * são obrigatórios. O restante pode ser completado depois."}
      />

      {rascunho && (
        <div className="mb-4 flex flex-wrap items-center justify-between gap-3 rounded-lg border border-blue-200 bg-blue-50 p-3 text-sm text-blue-900">
          <span>
            Há um cadastro não concluído de <strong>{rascunho.cadastro.Nome}</strong> ({new Date(rascunho.salvoEm).toLocaleString("pt-BR")}).
          </span>
          <div className="flex gap-2">
            <Button
              variant="ghost"
              onClick={() => {
                try {
                  localStorage.removeItem(CHAVE_RASCUNHO);
                } catch {
                  /* ignora */
                }
                setRascunho(null);
              }}
            >
              Descartar
            </Button>
            <Button
              onClick={() => {
                setC({ ...cadastroVazio(), ...rascunho.cadastro });
                setFiltro(rascunho.filtro);
                setEtapa(rascunho.etapa);
                setRascunho(null);
              }}
            >
              Continuar
            </Button>
          </div>
        </div>
      )}

      {/* Indicador de etapas */}
      <ol className="mb-6 flex gap-1 overflow-x-auto pb-1">
        {ETAPAS.map((nome, i) => (
          <li key={nome} className="min-w-28 flex-1">
            <button
              type="button"
              onClick={() => irPara(i)}
              className={cx(
                "w-full border-t-4 pt-2 text-left text-xs transition",
                i < etapa ? "border-brand text-brand" : i === etapa ? "border-accent font-semibold text-slate-900" : "border-slate-200 text-slate-400 hover:text-slate-600",
              )}
              aria-current={i === etapa ? "step" : undefined}
            >
              <span className="flex items-center gap-1">
                {i < etapa && <Check className="size-3" />} {i + 1}. {nome}
              </span>
            </button>
          </li>
        ))}
      </ol>

      <Card>
        {erros.length > 0 && (
          <div className="mb-5">
            <ErrorBox message={erros.join(" ")} />
          </div>
        )}
        {etapa === 0 && <EtapaIdentificacao {...props} filtro={filtro} setFiltro={setFiltro} />}
        {etapa === 1 && <EtapaContato {...props} />}
        {etapa === 2 && <EtapaEspiritual {...props} />}
        {etapa === 3 && <EtapaObra {...props} />}
        {etapa === 4 && <EtapaTalentos {...props} />}
        {etapa === 5 && <EtapaEstudoTrabalho {...props} />}
        {etapa === 6 && (
          <EtapaTestemunho
            {...props}
            foto={foto}
            setFoto={setFoto}
            documento={documento}
            setDocumento={setDocumento}
            fotoAtual={modo.tipo === "editar" ? modo.fotoUrl : null}
          />
        )}

        {erroEnvio && (
          <div className="mt-5">
            <ErrorBox message={erroEnvio} />
          </div>
        )}

        <div className="mt-8 flex items-center justify-between border-t border-slate-100 pt-5">
          <Button variant="ghost" onClick={() => irPara(etapa - 1)} disabled={etapa === 0}>
            <ArrowLeft className="size-4" /> Voltar
          </Button>
          <div className="flex gap-2">
            {!ultima && (editando || etapa > 0) && (
              <Button variant="ghost" onClick={salvar} disabled={enviando} title="Salvar agora com o que já foi preenchido">
                <Save className="size-4" /> {editando ? "Salvar alterações" : "Salvar agora"}
              </Button>
            )}
            {ultima ? (
              <Button onClick={salvar} disabled={enviando}>
                <Save className="size-4" /> {enviando ? "Salvando..." : editando ? "Salvar alterações" : "Salvar cadastro"}
              </Button>
            ) : (
              <Button onClick={() => irPara(etapa + 1)}>
                Próximo <ArrowRight className="size-4" />
              </Button>
            )}
          </div>
        </div>
      </Card>
    </div>
  );
}
