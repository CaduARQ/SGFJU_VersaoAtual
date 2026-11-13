"use client";

import Link from "next/link";
import { use, useState } from "react";
import { ArrowLeft, Link2, Unlink } from "lucide-react";
import { api, ApiError } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { JovemResumo, ObreiroAV } from "@/lib/types";
import { Avatar } from "@/components/avatar";
import { Button, Card, cx, Empty, ErrorBox, Input, Loading, PageHeader, plural } from "@/components/ui";

type Resposta = { Obreiro: ObreiroAV; Acompanhados: JovemResumo[]; Disponiveis: JovemResumo[] };

const hoje = () => {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}-${String(d.getDate()).padStart(2, "0")}`;
};

export function DetalheObreiro({ params }: { params: Promise<{ id: string }> }) {
  const { id } = use(params);
  const { data, error, loading, reload } = useApi(() => api.get<Resposta>(`v2/arvore-vida/obreiros/${id}`), [id]);
  const [paraSair, setParaSair] = useState<number[]>([]);
  const [paraEntrar, setParaEntrar] = useState<number[]>([]);
  const [inicio, setInicio] = useState(hoje);
  const [busca, setBusca] = useState("");
  const [msg, setMsg] = useState<{ tipo: "ok" | "erro"; texto: string } | null>(null);
  const [salvando, setSalvando] = useState(false);

  if (loading) return <Loading />;
  if (error) return <ErrorBox message={error} onRetry={reload} />;
  if (!data) return null;
  const o = data.Obreiro;

  const alternar = (lista: number[], set: (v: number[]) => void, id: number) => set(lista.includes(id) ? lista.filter((x) => x !== id) : [...lista, id]);

  async function executar(acao: "associar" | "desassociar") {
    setSalvando(true);
    setMsg(null);
    try {
      if (acao === "associar") {
        const r = await api.post<{ Associados: number }>(`v2/arvore-vida/obreiros/${id}/associar`, { IdsJovens: paraEntrar, DataInicio: inicio });
        setMsg({ tipo: "ok", texto: `${plural(r.Associados, "jovem associado", "jovens associados")} a ${o.NomeObreiro}.` });
        setParaEntrar([]);
      } else {
        const r = await api.post<{ Desassociados: number }>(`v2/arvore-vida/obreiros/${id}/desassociar`, { IdsJovens: paraSair });
        setMsg({ tipo: "ok", texto: `${plural(r.Desassociados, "jovem desassociado", "jovens desassociados")}.` });
        setParaSair([]);
      }
      reload();
    } catch (err) {
      setMsg({ tipo: "erro", texto: err instanceof ApiError ? err.message : "Não foi possível concluir." });
    } finally {
      setSalvando(false);
    }
  }

  const q = busca.trim().toLowerCase();
  const disponiveis = q ? data.Disponiveis.filter((j) => j.NomeJovem.toLowerCase().includes(q)) : data.Disponiveis;

  return (
    <>
      <Link href="/arvore-da-vida/obreiros" className="mb-4 inline-flex items-center gap-1 text-sm text-slate-500 hover:text-slate-800"><ArrowLeft className="size-4" /> Obreiros</Link>
      <div className="mb-6 flex items-center gap-4">
        <Avatar nome={o.NomeObreiro} url={o.FotoUrl} tamanho="lg" />
        <PageHeader title={o.NomeObreiro} subtitle={[o.NomeIgreja, o.NomeRegiao, o.NomeBloco, o.NomeEstado].filter(Boolean).join(" · ")} />
      </div>
      {msg && (
        <div className={cx("mb-4 rounded-lg p-3 text-sm", msg.tipo === "ok" ? "bg-emerald-50 text-emerald-800" : "bg-red-50 text-red-700")}>{msg.texto}</div>
      )}

      <div className="grid gap-6 lg:grid-cols-2">
        <Card title={`Acompanha (${data.Acompanhados.length})`}>
          {data.Acompanhados.length === 0 ? <Empty text="Este obreiro ainda não acompanha nenhum jovem." /> : (
            <>
              <ListaSelecionavel jovens={data.Acompanhados} marcados={paraSair} onAlternar={(j) => alternar(paraSair, setParaSair, j)} link />
              <div className="mt-4 flex justify-end">
                <Button variant="ghost" onClick={() => executar("desassociar")} disabled={!paraSair.length || salvando} className="text-red-700 hover:bg-red-50">
                  <Unlink className="size-4" /> Desassociar {paraSair.length > 0 && `(${paraSair.length})`}
                </Button>
              </div>
            </>
          )}
        </Card>

        <Card title={`Jovens da igreja sem acompanhamento (${data.Disponiveis.length})`}>
          {data.Disponiveis.length === 0 ? <Empty text="Não há jovens disponíveis na igreja deste obreiro." /> : (
            <>
              <Input value={busca} onChange={(e) => setBusca(e.target.value)} placeholder="Buscar jovem..." className="mb-3 w-full" />
              <ListaSelecionavel jovens={disponiveis} marcados={paraEntrar} onAlternar={(j) => alternar(paraEntrar, setParaEntrar, j)} />
              <div className="mt-4 flex flex-wrap items-end justify-end gap-3">
                <label className="flex flex-col gap-1 text-sm">
                  <span className="font-medium text-slate-700">Início do acompanhamento</span>
                  <Input type="date" value={inicio} max={hoje()} onChange={(e) => setInicio(e.target.value)} />
                </label>
                <Button onClick={() => executar("associar")} disabled={!paraEntrar.length || salvando}>
                  <Link2 className="size-4" /> Associar {paraEntrar.length > 0 && `(${paraEntrar.length})`}
                </Button>
              </div>
            </>
          )}
        </Card>
      </div>
    </>
  );
}

function ListaSelecionavel({ jovens, marcados, onAlternar, link }: { jovens: JovemResumo[]; marcados: number[]; onAlternar: (id: number) => void; link?: boolean }) {
  return (
    <ul className="max-h-96 divide-y divide-slate-100 overflow-y-auto rounded-lg border border-slate-200">
      {jovens.map((j) => (
        <li key={j.IdJovem} className={cx("flex items-center gap-3 px-3 py-2", marcados.includes(j.IdJovem) && "bg-brand/5")}>
          <input type="checkbox" checked={marcados.includes(j.IdJovem)} onChange={() => onAlternar(j.IdJovem)} aria-label={`Selecionar ${j.NomeJovem}`} />
          <span className="min-w-0 flex-1">
            {link ? (
              <Link href={`/arvore-da-vida/acompanhamentos/${j.IdJovem}`} className="block truncate text-sm font-medium text-brand hover:underline">{j.NomeJovem}</Link>
            ) : (
              <span className="block truncate text-sm font-medium text-slate-900">{j.NomeJovem}</span>
            )}
            <span className="block text-xs text-slate-500">{j.DataNascimento} {j.Whatsapp && /[1-9]/.test(j.Whatsapp) && `· ${j.Whatsapp}`}</span>
          </span>
        </li>
      ))}
    </ul>
  );
}
