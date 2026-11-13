"use client";

import Link from "next/link";
import { use, useState, type FormEvent } from "react";
import { Flame, Search } from "lucide-react";
import { api } from "@/lib/api";
import type { JovemResumo } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { Avatar } from "@/components/avatar";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { TabelaJovens } from "@/components/tabela-jovens";
import { Button, Card, cx, Empty, ErrorBox, Field, Input, Loading, PageHeader, Select, plural } from "@/components/ui";

type JovemAltar = {
  IdJovem: number; NomeJovem: string; DataNascimento: string; NomeEstado: string; NomeBlocoJovem: string; NomeRegiaoJovem: string;
  NomeIgrejaJovem: string; Whatsapp: string | null; WhatsappSemFormatacao: string | null; FotoUrl: string | null;
};

// Grupos do Altar Jovem: o jovem precisa cumprir todos os marcados.
const GRUPOS = [
  { id: "Agua", nome: "Água", ajuda: "batizados nas águas" },
  { id: "Oleo", nome: "Óleo", ajuda: "batizados no Espírito Santo" },
  { id: "Sal", nome: "Sal", ajuda: "cursando o CPO" },
  { id: "Luz", nome: "Luz", ajuda: "obreiros" },
];

export function AltarJovem({ searchParams }: { searchParams: Promise<Record<string, string | string[] | undefined>> }) {
  const p = use(searchParams);
  const { usuario } = useAuth();
  const [aba, setAba] = useState<"altar" | "levantados">(p.aba === "levantados" ? "levantados" : "altar");
  const [filtro, setFiltro] = useState<FiltroValor>({ idEstado: usuario.EhAdm ? 0 : usuario.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 });
  const [nome, setNome] = useState("");
  const [sexo, setSexo] = useState("");
  const [grupos, setGrupos] = useState<string[]>([]);
  const [so318, setSo318] = useState(false);
  const [altar, setAltar] = useState<JovemAltar[] | null>(null);
  const [levantados, setLevantados] = useState<JovemResumo[] | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);

  async function pesquisar(e?: FormEvent) {
    e?.preventDefault();
    setCarregando(true);
    setErro(null);
    try {
      if (aba === "altar") {
        setAltar(await api.post<JovemAltar[]>("v2/altar-jovem/consulta", {
          IdEstado: filtro.idEstado, IdBloco: filtro.idBloco, IdRegiao: filtro.idRegiao, IdIgreja: filtro.idIgreja,
          Nome: nome.trim() || null, Sexo: sexo, Grupos: grupos, Somente318: so318,
        }));
      } else {
        const q = new URLSearchParams({ idEstado: String(filtro.idEstado), idBloco: String(filtro.idBloco), idRegiao: String(filtro.idRegiao), idIgreja: String(filtro.idIgreja) });
        setLevantados(await api.get<JovemResumo[]>(`v2/altar-jovem/levantados?${q}`));
      }
    } catch (err) {
      setErro((err as Error).message);
    } finally {
      setCarregando(false);
    }
  }

  return (
    <>
      <PageHeader title="Altar Jovem" subtitle="Jovens do Altar Jovem por grupo, e jovens levantados para o altar." />
      <div className="mb-4 inline-flex rounded-lg border border-slate-200 bg-white p-1">
        {(["altar", "levantados"] as const).map((a) => (
          <button key={a} type="button" onClick={() => { setAba(a); setErro(null); }}
            className={cx("rounded-md px-4 py-1.5 text-sm", aba === a ? "bg-brand text-white" : "text-slate-600 hover:bg-slate-50")}>
            {a === "altar" ? "Altar Jovem" : "Levantados para o altar"}
          </button>
        ))}
      </div>

      <Card>
        <form onSubmit={pesquisar} className="space-y-4">
          <div className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-6">
            <FiltroEstrutura valor={filtro} onChange={setFiltro} />
            {aba === "altar" && (
              <>
                <Field label="Nome"><Input value={nome} onChange={(e) => setNome(e.target.value)} placeholder="Opcional" /></Field>
                <Field label="Sexo">
                  <Select value={sexo} onChange={(e) => setSexo(e.target.value)}>
                    <option value="">Todos</option><option value="M">Masculino</option><option value="F">Feminino</option>
                  </Select>
                </Field>
              </>
            )}
          </div>
          {aba === "altar" && (
            <div className="flex flex-wrap items-center gap-2">
              <span className="text-sm font-medium text-slate-700">Grupos:</span>
              {GRUPOS.map((g) => {
                const ativo = grupos.includes(g.id);
                return (
                  <button key={g.id} type="button" aria-pressed={ativo} title={g.ajuda}
                    onClick={() => setGrupos(ativo ? grupos.filter((x) => x !== g.id) : [...grupos, g.id])}
                    className={cx("rounded-full border px-3 py-1 text-sm", ativo ? "border-brand bg-brand/10 font-medium text-brand" : "border-slate-300 text-slate-600 hover:bg-slate-50")}>
                    {g.nome} <span className="text-xs text-slate-400">({g.ajuda})</span>
                  </button>
                );
              })}
              <label className="ml-2 flex items-center gap-2 text-sm text-slate-600">
                <input type="checkbox" checked={so318} onChange={(e) => setSo318(e.target.checked)} /> Só Altar Jovem 318
              </label>
            </div>
          )}
          <div className="flex justify-end">
            <Button type="submit" disabled={carregando}><Search className="size-4" /> Pesquisar</Button>
          </div>
        </form>
      </Card>

      <Card className="mt-6">
        {carregando && <Loading />}
        {erro && <ErrorBox message={erro} onRetry={() => pesquisar()} />}
        {!carregando && aba === "altar" && (
          altar === null ? <Empty text="Use os filtros e clique em Pesquisar." /> :
          altar.length === 0 ? <Empty text="Nenhum jovem do Altar Jovem com esses filtros." /> : (
            <>
              <p className="mb-3 text-sm text-slate-600"><strong>{plural(altar.length, "jovem", "jovens")}</strong> no Altar Jovem</p>
              <ul className="grid gap-3 sm:grid-cols-2 xl:grid-cols-3">
                {altar.map((j) => (
                  <li key={j.IdJovem}>
                    <Link href={`/jovens/${j.IdJovem}`} className="flex items-center gap-3 rounded-lg border border-slate-200 p-3 transition hover:border-brand/40 hover:bg-slate-50">
                      <Avatar nome={j.NomeJovem} url={j.FotoUrl} />
                      <span className="min-w-0 flex-1">
                        <span className="block truncate font-medium text-slate-900">{j.NomeJovem}</span>
                        <span className="block truncate text-xs text-slate-500">{j.NomeIgrejaJovem} · {j.NomeRegiaoJovem}</span>
                      </span>
                      <Flame className="size-4 text-accent" />
                    </Link>
                  </li>
                ))}
              </ul>
            </>
          )
        )}
        {!carregando && aba === "levantados" && (
          levantados === null ? <Empty text="Use os filtros e clique em Pesquisar." /> : <TabelaJovens jovens={levantados} nomeArquivo="levantados-altar-sgfju" />
        )}
      </Card>
    </>
  );
}
