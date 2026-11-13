"use client";

import Link from "next/link";
import { useMemo, useState, type FormEvent } from "react";
import { Download, Search, UserPlus } from "lucide-react";
import { api } from "@/lib/api";
import type { JovemResumo, ParametroPesquisaJovens } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { Badge, Button, Card, Empty, ErrorBox, Field, Input, Loading, PageHeader, Table, Td, plural } from "@/components/ui";

const POR_PAGINA = 25;

export default function Jovens() {
  const { usuario } = useAuth();
  const [filtro, setFiltro] = useState<FiltroValor>({ idEstado: usuario.EhAdm ? 0 : usuario.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 });
  const [nome, setNome] = useState("");
  const [expiradas, setExpiradas] = useState(false);
  const [resultado, setResultado] = useState<JovemResumo[] | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);
  const [pagina, setPagina] = useState(1);
  const [busca, setBusca] = useState("");

  async function pesquisar(e?: FormEvent) {
    e?.preventDefault();
    setCarregando(true);
    setErro(null);
    try {
      const parametro: ParametroPesquisaJovens = {
        NomeJovem: nome.trim() || undefined,
        IdEstado: filtro.idEstado,
        IdBlocoJovem: filtro.idBloco,
        IdRegiaoJovem: filtro.idRegiao,
        IdIgreja: filtro.idIgreja,
        EhParaListarFichasExpiradas: expiradas ? "S" : "N",
      };
      setResultado(await api.post<JovemResumo[]>("Jovens/PesquisarPorParametro", parametro));
      setPagina(1);
    } catch (err) {
      setErro((err as Error).message);
    } finally {
      setCarregando(false);
    }
  }

  const filtrados = useMemo(() => {
    if (!resultado) return [];
    const q = busca.trim().toLowerCase();
    return q ? resultado.filter((j) => `${j.NomeJovem} ${j.NomeIgrejaJovem} ${j.Whatsapp}`.toLowerCase().includes(q)) : resultado;
  }, [resultado, busca]);
  const totalPaginas = Math.max(1, Math.ceil(filtrados.length / POR_PAGINA));
  const pagina_ = filtrados.slice((pagina - 1) * POR_PAGINA, pagina * POR_PAGINA);

  function exportarCsv() {
    const linhas = [
      ["Nome", "Nascimento", "Estado", "Bloco", "Região", "Igreja", "WhatsApp", "Projeto", "Classificação"],
      ...filtrados.map((j) => [j.NomeJovem, j.DataNascimento, j.SiglaEstado, j.NomeBlocoJovem, j.NomeRegiaoJovem, j.NomeIgrejaJovem, j.Whatsapp, j.ProjetoJovemPertence, j.ClassificacaoJovem]),
    ];
    const csv = linhas.map((l) => l.map((c) => `"${String(c ?? "").replace(/"/g, '""')}"`).join(";")).join("\n");
    const url = URL.createObjectURL(new Blob(["﻿" + csv], { type: "text/csv;charset=utf-8" }));
    const a = Object.assign(document.createElement("a"), { href: url, download: "jovens-sgfju.csv" });
    a.click();
    URL.revokeObjectURL(url);
  }

  return (
    <>
      <PageHeader
        title="Jovens"
        subtitle="Pesquise por estrutura ou nome"
        actions={
          <Link href="/jovens/novo" className="inline-flex items-center gap-2 rounded-lg bg-brand px-4 py-2 text-sm font-medium text-white hover:bg-brand-strong">
            <UserPlus className="size-4" /> Novo jovem
          </Link>
        }
      />
      <Card>
        <form onSubmit={pesquisar} className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-6">
          <FiltroEstrutura valor={filtro} onChange={setFiltro} />
          <Field label="Nome">
            <Input value={nome} onChange={(e) => setNome(e.target.value)} placeholder="Opcional" />
          </Field>
          <div className="flex flex-col justify-end gap-2 sm:col-span-2 lg:col-span-4 xl:col-span-6 sm:flex-row sm:items-center sm:justify-between">
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
        {!carregando && resultado && (
          <>
            <div className="mb-4 flex flex-wrap items-center justify-between gap-3">
              <p className="text-sm text-slate-600">
                <strong>{plural(filtrados.length, "jovem encontrado", "jovens encontrados")}</strong>
              </p>
              <div className="flex gap-2">
                <Input value={busca} onChange={(e) => { setBusca(e.target.value); setPagina(1); }} placeholder="Filtrar resultado..." className="w-56" />
                <Button variant="ghost" onClick={exportarCsv} disabled={!filtrados.length}>
                  <Download className="size-4" /> CSV
                </Button>
              </div>
            </div>
            {filtrados.length === 0 ? (
              <Empty text="Nenhum jovem encontrado com esses filtros." />
            ) : (
              <Table head={["Nome", "Igreja", "Região / Bloco", "WhatsApp", "Projeto", "Situação"]}>
                {pagina_.map((j) => (
                  <tr key={j.IdJovem} className="hover:bg-slate-50">
                    <Td className="font-medium">
                      <Link href={`/jovens/${j.IdJovem}`} className="text-brand hover:underline">
                        {j.NomeJovem}
                      </Link>
                      <span className="block text-xs font-normal text-slate-500">{j.DataNascimento}</span>
                    </Td>
                    <Td>{j.NomeIgrejaJovem}</Td>
                    <Td>
                      {j.NomeRegiaoJovem}
                      <span className="block text-xs text-slate-500">{j.NomeBlocoJovem}</span>
                    </Td>
                    <Td>
                      {j.WhatsappSemFormatacao ? (
                        <a href={`https://wa.me/55${j.WhatsappSemFormatacao}`} target="_blank" className="text-emerald-700 hover:underline">
                          {j.Whatsapp}
                        </a>
                      ) : (
                        j.Whatsapp
                      )}
                    </Td>
                    <Td>{j.ProjetoJovemPertence}</Td>
                    <Td>
                      <div className="flex flex-wrap gap-1">
                        {j.ClassificacaoJovem && <Badge tone="blue">{j.ClassificacaoJovem}</Badge>}
                        {j.FichaEstaExpirada && <Badge tone="red">Ficha expirada</Badge>}
                        {j.EstaSendoAcompanhadoAV && <Badge tone="green">Árvore da Vida</Badge>}
                      </div>
                    </Td>
                  </tr>
                ))}
              </Table>
            )}
            {totalPaginas > 1 && (
              <div className="mt-4 flex items-center justify-end gap-2 text-sm">
                <Button variant="ghost" disabled={pagina === 1} onClick={() => setPagina((p) => p - 1)}>Anterior</Button>
                <span className="text-slate-600">{pagina} de {totalPaginas}</span>
                <Button variant="ghost" disabled={pagina === totalPaginas} onClick={() => setPagina((p) => p + 1)}>Próxima</Button>
              </div>
            )}
          </>
        )}
      </Card>
    </>
  );
}
