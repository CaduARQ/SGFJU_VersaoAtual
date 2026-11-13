"use client";

import Link from "next/link";
import { use, useMemo, useState, type FormEvent } from "react";
import { ArrowLeft, Search } from "lucide-react";
import { api } from "@/lib/api";
import type { ObreiroAV } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { Avatar } from "@/components/avatar";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { Badge, Button, Card, cx, Empty, ErrorBox, Field, Input, Loading, PageHeader, plural } from "@/components/ui";

type Panorama = { ComRamos: { Obreiro: ObreiroAV; Jovens: number }[]; SemRamos: ObreiroAV[] };

export function ListaObreiros({ searchParams }: { searchParams: Promise<Record<string, string | string[] | undefined>> }) {
  const params = use(searchParams);
  const { usuario } = useAuth();
  const [aba, setAba] = useState<"obreiros" | "panorama">(params.aba === "panorama" ? "panorama" : "obreiros");
  const [filtro, setFiltro] = useState<FiltroValor>({ idEstado: usuario.EhAdm ? 0 : usuario.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 });
  const [nome, setNome] = useState("");
  const [obreiros, setObreiros] = useState<ObreiroAV[] | null>(null);
  const [panorama, setPanorama] = useState<Panorama | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);

  const query = () =>
    new URLSearchParams({
      idEstado: String(filtro.idEstado), idBloco: String(filtro.idBloco), idRegiao: String(filtro.idRegiao), idIgreja: String(filtro.idIgreja),
      ...(nome.trim() ? { nome: nome.trim() } : {}),
    }).toString();

  async function pesquisar(e?: FormEvent) {
    e?.preventDefault();
    setCarregando(true);
    setErro(null);
    try {
      if (aba === "obreiros") setObreiros(await api.get<ObreiroAV[]>(`v2/arvore-vida/obreiros?${query()}`));
      else setPanorama(await api.get<Panorama>(`v2/arvore-vida/panorama?${query()}`));
    } catch (err) {
      setErro((err as Error).message);
    } finally {
      setCarregando(false);
    }
  }

  const resumo = useMemo(() => {
    if (!panorama) return null;
    const total = panorama.ComRamos.length + panorama.SemRamos.length;
    return { total, pct: total ? Math.round((panorama.ComRamos.length / total) * 100) : 0 };
  }, [panorama]);

  return (
    <>
      <Link href="/arvore-da-vida" className="mb-4 inline-flex items-center gap-1 text-sm text-slate-500 hover:text-slate-800"><ArrowLeft className="size-4" /> Árvore da Vida</Link>
      <PageHeader title="Obreiros" subtitle="Escolha um obreiro para ver e mudar os jovens que ele acompanha." />

      <div className="mb-4 inline-flex rounded-lg border border-slate-200 bg-white p-1">
        {(["obreiros", "panorama"] as const).map((a) => (
          <button key={a} type="button" onClick={() => { setAba(a); setErro(null); }}
            className={cx("rounded-md px-4 py-1.5 text-sm", aba === a ? "bg-brand text-white" : "text-slate-600 hover:bg-slate-50")}>
            {a === "obreiros" ? "Pesquisar obreiros" : "Panorama (com e sem ramos)"}
          </button>
        ))}
      </div>

      <Card>
        <form onSubmit={pesquisar} className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-6">
          <FiltroEstrutura valor={filtro} onChange={setFiltro} />
          {aba === "obreiros" && <Field label="Nome do obreiro"><Input value={nome} onChange={(e) => setNome(e.target.value)} placeholder="Opcional" /></Field>}
          <div className="flex items-end">
            <Button type="submit" disabled={carregando}><Search className="size-4" /> {aba === "obreiros" ? "Pesquisar" : "Ver panorama"}</Button>
          </div>
        </form>
      </Card>

      <Card className="mt-6">
        {carregando && <Loading />}
        {erro && <ErrorBox message={erro} onRetry={() => pesquisar()} />}

        {!carregando && aba === "obreiros" && (
          obreiros === null ? <Empty text="Use os filtros e clique em Pesquisar." /> :
          obreiros.length === 0 ? <Empty text="Nenhum obreiro encontrado." /> : (
            <>
              <p className="mb-3 text-sm text-slate-600"><strong>{plural(obreiros.length, "obreiro", "obreiros")}</strong></p>
              <ul className="grid gap-3 sm:grid-cols-2 xl:grid-cols-3">
                {obreiros.map((o) => <CartaoObreiro key={o.IdObreiro} o={o} />)}
              </ul>
            </>
          )
        )}

        {!carregando && aba === "panorama" && (
          panorama === null ? <Empty text={usuario.EhAdm ? "Escolha um estado e clique em Ver panorama." : "Clique em Ver panorama."} /> : (
            <div className="space-y-6">
              {resumo && (
                <p className="text-sm text-slate-600">
                  <strong>{panorama.ComRamos.length}</strong> de {resumo.total} obreiros acompanham jovens ({resumo.pct}%).
                </p>
              )}
              <section>
                <h3 className="mb-2 text-sm font-semibold text-slate-800">Com ramos ({panorama.ComRamos.length})</h3>
                {panorama.ComRamos.length === 0 ? <Empty text="Nenhum obreiro acompanhando jovens." /> : (
                  <ul className="grid gap-3 sm:grid-cols-2 xl:grid-cols-3">
                    {panorama.ComRamos.map((x) => <CartaoObreiro key={x.Obreiro.IdObreiro} o={x.Obreiro} extra={<Badge tone="green">{plural(x.Jovens, "jovem", "jovens")}</Badge>} />)}
                  </ul>
                )}
              </section>
              <section>
                <h3 className="mb-2 text-sm font-semibold text-slate-800">Sem ramos ({panorama.SemRamos.length})</h3>
                {panorama.SemRamos.length === 0 ? <Empty text="Todos os obreiros acompanham ao menos um jovem." /> : (
                  <ul className="grid gap-3 sm:grid-cols-2 xl:grid-cols-3">
                    {panorama.SemRamos.map((o) => <CartaoObreiro key={o.IdObreiro} o={o} extra={<Badge tone="amber">Sem jovens</Badge>} />)}
                  </ul>
                )}
              </section>
            </div>
          )
        )}
      </Card>
    </>
  );
}

function CartaoObreiro({ o, extra }: { o: ObreiroAV; extra?: React.ReactNode }) {
  return (
    <li>
      <Link href={`/arvore-da-vida/obreiros/${o.IdObreiro}`} className="flex items-center gap-3 rounded-lg border border-slate-200 p-3 transition hover:border-brand/40 hover:bg-slate-50">
        <Avatar nome={o.NomeObreiro} url={o.FotoUrl} />
        <span className="min-w-0 flex-1">
          <span className="block truncate font-medium text-slate-900">{o.NomeObreiro}</span>
          <span className="block truncate text-xs text-slate-500">{o.NomeIgreja} · {o.NomeRegiao}</span>
        </span>
        {extra}
      </Link>
    </li>
  );
}
