"use client";

import Link from "next/link";
import { useState, type FormEvent } from "react";
import { Search, SlidersHorizontal, UserPlus } from "lucide-react";
import { api } from "@/lib/api";
import type { JovemResumo } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { TabelaJovens } from "@/components/tabela-jovens";
import { Button, Card, Empty, ErrorBox, Field, Input, Loading, PageHeader } from "@/components/ui";

type Resultado = { Total: number; Truncado: boolean; Jovens: JovemResumo[] };

export default function Jovens() {
  const { usuario } = useAuth();
  const [filtro, setFiltro] = useState<FiltroValor>({ idEstado: usuario.EhAdm ? 0 : usuario.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 });
  const [nome, setNome] = useState("");
  const [expiradas, setExpiradas] = useState(false);
  const [resultado, setResultado] = useState<Resultado | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);

  async function pesquisar(e?: FormEvent) {
    e?.preventDefault();
    setCarregando(true);
    setErro(null);
    try {
      // Usa a Consulta Geral 2.0: respeita o nome e limita ao estado do usuário (exceto ADM).
      setResultado(
        await api.post<Resultado>("v2/jovens/consulta", {
          IdEstado: filtro.idEstado,
          IdBlocoJovem: filtro.idBloco,
          IdRegiao: filtro.idRegiao,
          IdIgreja: filtro.idIgreja,
          Nome: nome.trim() || null,
          EhParaListarFichasExpiradas: expiradas ? "S" : "",
        }),
      );
    } catch (err) {
      setErro((err as Error).message);
    } finally {
      setCarregando(false);
    }
  }

  return (
    <>
      <PageHeader
        title="Jovens"
        subtitle="Pesquise por estrutura ou nome"
        actions={
          <div className="flex gap-2">
            <Link href="/consulta" className="inline-flex items-center gap-2 rounded-lg px-4 py-2 text-sm font-medium text-slate-700 hover:bg-slate-100">
              <SlidersHorizontal className="size-4" /> Consulta avançada
            </Link>
            <Link href="/jovens/novo" className="inline-flex items-center gap-2 rounded-lg bg-brand px-4 py-2 text-sm font-medium text-white hover:bg-brand-strong">
              <UserPlus className="size-4" /> Novo jovem
            </Link>
          </div>
        }
      />
      <Card>
        <form onSubmit={pesquisar} className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-6">
          <FiltroEstrutura valor={filtro} onChange={setFiltro} />
          <Field label="Nome">
            <Input value={nome} onChange={(e) => setNome(e.target.value)} placeholder="Opcional" />
          </Field>
          <div className="flex flex-col justify-end gap-2 sm:col-span-2 sm:flex-row sm:items-center sm:justify-between lg:col-span-4 xl:col-span-6">
            <label className="flex items-center gap-2 text-sm text-slate-600">
              <input type="checkbox" checked={expiradas} onChange={(e) => setExpiradas(e.target.checked)} /> Somente fichas expiradas
            </label>
            <Button type="submit" disabled={carregando}>
              <Search className="size-4" /> Pesquisar
            </Button>
          </div>
        </form>
      </Card>

      <Card className="mt-6">
        {carregando && <Loading text="Buscando jovens..." />}
        {erro && <ErrorBox message={erro} onRetry={() => pesquisar()} />}
        {!carregando && !erro && resultado === null && <Empty text="Escolha os filtros e clique em Pesquisar." />}
        {!carregando && resultado && <TabelaJovens jovens={resultado.Jovens} />}
      </Card>
    </>
  );
}
