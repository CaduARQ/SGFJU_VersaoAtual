"use client";

import Link from "next/link";
import { useMemo, useState, type FormEvent } from "react";
import { ArrowLeft, Search } from "lucide-react";
import { api } from "@/lib/api";
import type { JovemResumo } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { Button, Card, Empty, ErrorBox, Field, Input, Loading, PageHeader, Table, Td, plural } from "@/components/ui";

type Acompanhado = JovemResumo & { NomeObreiroAcompanha?: string | null };

export default function Acompanhamentos() {
  const { usuario } = useAuth();
  const [filtro, setFiltro] = useState<FiltroValor>({ idEstado: usuario.EhAdm ? 0 : usuario.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 });
  const [nome, setNome] = useState("");
  const [lista, setLista] = useState<Acompanhado[] | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);
  const [porObreiro, setPorObreiro] = useState(false);

  async function pesquisar(e?: FormEvent) {
    e?.preventDefault();
    setCarregando(true);
    setErro(null);
    try {
      const q = new URLSearchParams({
        idEstado: String(filtro.idEstado), idBloco: String(filtro.idBloco), idRegiao: String(filtro.idRegiao), idIgreja: String(filtro.idIgreja),
        ...(nome.trim() ? { nome: nome.trim() } : {}),
      });
      setLista(await api.get<Acompanhado[]>(`v2/arvore-vida/acompanhamentos?${q}`));
    } catch (err) {
      setErro((err as Error).message);
    } finally {
      setCarregando(false);
    }
  }

  const grupos = useMemo(() => {
    const m = new Map<string, Acompanhado[]>();
    for (const j of lista ?? []) {
      const k = j.NomeObreiroAcompanha || "Sem obreiro";
      m.set(k, [...(m.get(k) ?? []), j]);
    }
    return [...m.entries()].sort(([a], [b]) => a.localeCompare(b));
  }, [lista]);

  return (
    <>
      <Link href="/arvore-da-vida" className="mb-4 inline-flex items-center gap-1 text-sm text-slate-500 hover:text-slate-800"><ArrowLeft className="size-4" /> Árvore da Vida</Link>
      <PageHeader title="Jovens em acompanhamento" subtitle="Abra um jovem para ver o histórico e registrar o acompanhamento do mês." />
      <Card>
        <form onSubmit={pesquisar} className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-6">
          <FiltroEstrutura valor={filtro} onChange={setFiltro} />
          <Field label="Nome do jovem"><Input value={nome} onChange={(e) => setNome(e.target.value)} placeholder="Opcional" /></Field>
          <div className="flex items-end"><Button type="submit" disabled={carregando}><Search className="size-4" /> Pesquisar</Button></div>
        </form>
      </Card>
      <Card className="mt-6">
        {carregando && <Loading />}
        {erro && <ErrorBox message={erro} onRetry={() => pesquisar()} />}
        {!carregando && lista === null && <Empty text="Use os filtros e clique em Pesquisar." />}
        {!carregando && lista && lista.length === 0 && <Empty text="Nenhum jovem em acompanhamento com esses filtros." />}
        {!carregando && lista && lista.length > 0 && (
          <>
            <div className="mb-3 flex items-center justify-between">
              <p className="text-sm text-slate-600"><strong>{plural(lista.length, "jovem", "jovens")}</strong> em acompanhamento</p>
              <label className="flex items-center gap-2 text-sm text-slate-600">
                <input type="checkbox" checked={porObreiro} onChange={(e) => setPorObreiro(e.target.checked)} /> Agrupar por obreiro
              </label>
            </div>
            {porObreiro ? (
              <div className="space-y-4">
                {grupos.map(([obreiro, jovens]) => (
                  <section key={obreiro}>
                    <h3 className="mb-1 text-sm font-semibold text-slate-800">{obreiro} <span className="font-normal text-slate-500">({jovens.length})</span></h3>
                    <ul className="flex flex-wrap gap-2">
                      {jovens.map((j) => (
                        <li key={j.IdJovem}><Link href={`/arvore-da-vida/acompanhamentos/${j.IdJovem}`} className="rounded-full bg-slate-100 px-3 py-1 text-sm text-brand hover:bg-slate-200">{j.NomeJovem}</Link></li>
                      ))}
                    </ul>
                  </section>
                ))}
              </div>
            ) : (
              <Table head={["Jovem", "Obreiro", "Igreja", "Região / Bloco"]}>
                {lista.map((j) => (
                  <tr key={j.IdJovem} className="hover:bg-slate-50">
                    <Td className="font-medium"><Link href={`/arvore-da-vida/acompanhamentos/${j.IdJovem}`} className="text-brand hover:underline">{j.NomeJovem}</Link></Td>
                    <Td>{j.NomeObreiroAcompanha}</Td>
                    <Td>{j.NomeIgrejaJovem}</Td>
                    <Td>{j.NomeRegiaoJovem}<span className="block text-xs text-slate-500">{j.NomeBlocoJovem}</span></Td>
                  </tr>
                ))}
              </Table>
            )}
          </>
        )}
      </Card>
    </>
  );
}
