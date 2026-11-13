"use client";

import Link from "next/link";
import { use, useState, type FormEvent } from "react";
import { ArrowLeft, Send } from "lucide-react";
import { api, ApiError } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { HistoricoAV } from "@/lib/types";
import { Avatar } from "@/components/avatar";
import { Badge, Button, Card, cx, Empty, ErrorBox, Loading, PageHeader } from "@/components/ui";

const STATUS = [
  { id: 1, nome: "Iniciando na fé", tom: "amber" as const },
  { id: 2, nome: "Batizado nas águas", tom: "blue" as const },
  { id: 3, nome: "Batizado com o Espírito Santo", tom: "green" as const },
];

export function HistoricoJovem({ params }: { params: Promise<{ id: string }> }) {
  const { id } = use(params);
  const { data, error, loading, reload } = useApi(() => api.get<HistoricoAV>(`v2/arvore-vida/acompanhamentos/${id}`), [id]);
  const [status, setStatus] = useState(0);
  const [texto, setTexto] = useState("");
  const [enviando, setEnviando] = useState(false);
  const [msg, setMsg] = useState<{ tipo: "ok" | "erro"; texto: string } | null>(null);

  if (loading) return <Loading />;
  if (error) return <ErrorBox message={error} onRetry={reload} />;
  if (!data) return null;

  const atual = data.Historico[0]?.IdStatusAcompanhamento;

  async function registrar(e: FormEvent) {
    e.preventDefault();
    setEnviando(true);
    setMsg(null);
    try {
      await api.post(`v2/arvore-vida/acompanhamentos/${id}/historico`, { IdStatus: status, Texto: texto });
      setTexto("");
      setStatus(0);
      setMsg({ tipo: "ok", texto: "Registro salvo." });
      reload();
    } catch (err) {
      setMsg({ tipo: "erro", texto: err instanceof ApiError ? err.message : "Não foi possível salvar." });
    } finally {
      setEnviando(false);
    }
  }

  return (
    <>
      <Link href="/arvore-da-vida/acompanhamentos" className="mb-4 inline-flex items-center gap-1 text-sm text-slate-500 hover:text-slate-800"><ArrowLeft className="size-4" /> Em acompanhamento</Link>
      <div className="mb-6 flex items-center gap-4">
        <Avatar nome={data.Nome} url={data.FotoUrl} tamanho="lg" />
        <PageHeader
          title={data.Nome}
          subtitle={`Acompanhado por ${data.NomeObreiro}${data.DataInicioAcompanhamento ? ` desde ${data.DataInicioAcompanhamento}` : ""}${data.Igreja?.NomeIgreja ? ` · ${data.Igreja.NomeIgreja}` : ""}`}
          actions={atual ? <Badge tone={STATUS.find((s) => s.id === atual)?.tom ?? "slate"}>{STATUS.find((s) => s.id === atual)?.nome}</Badge> : undefined}
        />
      </div>

      <div className="grid gap-6 lg:grid-cols-[2fr_3fr]">
        <Card title="Novo registro">
          <form onSubmit={registrar} className="space-y-4">
            <div className="space-y-2">
              <span className="text-sm font-medium text-slate-700">Como o jovem está?</span>
              {STATUS.map((s) => (
                <label key={s.id} className={cx("flex cursor-pointer items-center gap-3 rounded-lg border px-3 py-2 text-sm", status === s.id ? "border-brand bg-brand/5" : "border-slate-200 hover:bg-slate-50")}>
                  <input type="radio" name="status" checked={status === s.id} onChange={() => setStatus(s.id)} /> {s.nome}
                </label>
              ))}
            </div>
            <label className="flex flex-col gap-1.5 text-sm">
              <span className="font-medium text-slate-700">O que aconteceu neste acompanhamento?</span>
              <textarea rows={5} value={texto} onChange={(e) => setTexto(e.target.value)} maxLength={4000}
                className="rounded-lg border border-slate-300 px-3 py-2 outline-none focus:border-brand focus:ring-2 focus:ring-brand/20" />
            </label>
            {msg && <p className={cx("rounded-lg p-2 text-sm", msg.tipo === "ok" ? "bg-emerald-50 text-emerald-800" : "bg-red-50 text-red-700")}>{msg.texto}</p>}
            <Button type="submit" disabled={enviando || !status || texto.trim().length < 3} className="w-full">
              <Send className="size-4" /> {enviando ? "Salvando..." : "Registrar"}
            </Button>
          </form>
        </Card>

        <Card title={`Histórico (${data.Historico.length})`}>
          {data.Historico.length === 0 ? <Empty text="Nenhum registro ainda." /> : (
            <ol className="relative space-y-5 border-l border-slate-200 pl-5">
              {data.Historico.map((h) => (
                <li key={h.IdHistorico} className="relative">
                  <span className="absolute -left-[1.6rem] top-1 size-3 rounded-full border-2 border-white bg-brand" />
                  <div className="flex flex-wrap items-center gap-2">
                    <span className="text-xs font-medium text-slate-500">{h.DataHistorico}</span>
                    <Badge tone={STATUS.find((s) => s.id === h.IdStatusAcompanhamento)?.tom ?? "slate"}>{h.DescricaoStatusAcompanhamento}</Badge>
                  </div>
                  <p className="mt-1 whitespace-pre-wrap text-sm text-slate-700">{h.TextoHistorico}</p>
                </li>
              ))}
            </ol>
          )}
        </Card>
      </div>
    </>
  );
}
