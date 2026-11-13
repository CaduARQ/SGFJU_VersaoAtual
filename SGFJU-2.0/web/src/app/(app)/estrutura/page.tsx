"use client";

import { useMemo, useState } from "react";
import { ChevronRight, Church } from "lucide-react";
import { api } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { Igreja } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { Card, Empty, ErrorBox, Input, Loading, PageHeader, Stat, plural } from "@/components/ui";

type Arvore = Map<string, Map<string, Igreja[]>>;

export default function Estrutura() {
  const { usuario } = useAuth();
  const { data, error, loading, reload } = useApi(() => api.get<Igreja[]>("Estados/ObterIgrejasPorEstadoLogado"));
  const [busca, setBusca] = useState("");
  const [abertos, setAbertos] = useState<Set<string>>(new Set());

  const arvore = useMemo<Arvore>(() => {
    const q = busca.trim().toLowerCase();
    const mapa: Arvore = new Map();
    for (const i of data ?? []) {
      const bloco = i.NomeBlocoJovem ?? "Sem bloco";
      const regiao = i.NomeRegiaoJovem ?? "Sem região";
      if (q && !`${i.NomeIgreja} ${regiao} ${bloco}`.toLowerCase().includes(q)) continue;
      if (!mapa.has(bloco)) mapa.set(bloco, new Map());
      const regs = mapa.get(bloco)!;
      if (!regs.has(regiao)) regs.set(regiao, []);
      regs.get(regiao)!.push(i);
    }
    return new Map([...mapa.entries()].sort(([a], [b]) => a.localeCompare(b)));
  }, [data, busca]);

  const alternar = (k: string) =>
    setAbertos((s) => {
      const n = new Set(s);
      if (n.has(k)) n.delete(k);
      else n.add(k);
      return n;
    });

  const totalRegioes = new Set((data ?? []).map((i) => i.IdRegiao)).size;
  const totalBlocos = new Set((data ?? []).map((i) => i.IdBlocoJovem)).size;
  const filtrando = busca.trim().length > 0;

  return (
    <>
      <PageHeader title="Igrejas, blocos e regiões" subtitle={`Estrutura de ${usuario.Estado ?? "seu estado"}`} />
      {loading && <Loading />}
      {error && <ErrorBox message={error} onRetry={reload} />}
      {data && (
        <>
          <div className="mb-6 grid grid-cols-3 gap-4">
            <Stat label="Blocos" value={totalBlocos} />
            <Stat label="Regiões" value={totalRegioes} />
            <Stat label="Igrejas" value={data.length} />
          </div>
          <Card>
            <Input value={busca} onChange={(e) => setBusca(e.target.value)} placeholder="Buscar igreja, região ou bloco..." className="mb-4 w-full sm:w-80" />
            {arvore.size === 0 && <Empty text="Nada encontrado." />}
            <ul className="space-y-2">
              {[...arvore.entries()].map(([bloco, regioes]) => {
                const kb = `b:${bloco}`;
                const ab = filtrando || abertos.has(kb);
                return (
                  <li key={kb} className="rounded-lg border border-slate-200">
                    <button onClick={() => alternar(kb)} className="flex w-full items-center gap-2 px-4 py-3 text-left font-medium text-slate-900">
                      <ChevronRight className={`size-4 transition ${ab ? "rotate-90" : ""}`} />
                      {bloco}
                      <span className="ml-auto text-xs font-normal text-slate-500">{plural(regioes.size, "região", "regiões")}</span>
                    </button>
                    {ab && (
                      <ul className="space-y-1 border-t border-slate-100 px-4 py-2">
                        {[...regioes.entries()].sort(([a], [b]) => a.localeCompare(b)).map(([regiao, igrejas]) => {
                          const kr = `${kb}|r:${regiao}`;
                          const ar = filtrando || abertos.has(kr);
                          return (
                            <li key={kr}>
                              <button onClick={() => alternar(kr)} className="flex w-full items-center gap-2 py-1.5 pl-4 text-left text-sm text-slate-700">
                                <ChevronRight className={`size-3.5 transition ${ar ? "rotate-90" : ""}`} />
                                {regiao}
                                <span className="ml-auto text-xs text-slate-500">{plural(igrejas.length, "igreja", "igrejas")}</span>
                              </button>
                              {ar && (
                                <ul className="grid gap-1 py-1 pl-12 sm:grid-cols-2 lg:grid-cols-3">
                                  {igrejas.sort((a, b) => a.NomeIgreja.localeCompare(b.NomeIgreja)).map((i) => (
                                    <li key={i.IdIgreja} className="flex items-center gap-2 text-sm text-slate-600">
                                      <Church className="size-3.5 text-slate-400" /> {i.NomeIgreja}
                                    </li>
                                  ))}
                                </ul>
                              )}
                            </li>
                          );
                        })}
                      </ul>
                    )}
                  </li>
                );
              })}
            </ul>
          </Card>
        </>
      )}
    </>
  );
}
