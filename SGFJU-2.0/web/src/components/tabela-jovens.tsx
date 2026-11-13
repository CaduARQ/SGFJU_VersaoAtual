"use client";

import Link from "next/link";
import { useMemo, useState } from "react";
import { Download } from "lucide-react";
import type { JovemResumo } from "@/lib/types";
import { Badge, Button, Empty, Input, Table, Td, plural } from "@/components/ui";

const POR_PAGINA = 25;

/** Lista de jovens com filtro rápido, paginação e exportação CSV. */
export function TabelaJovens({ jovens, nomeArquivo = "jovens-sgfju" }: { jovens: JovemResumo[]; nomeArquivo?: string }) {
  const [busca, setBusca] = useState("");
  const [pagina, setPagina] = useState(1);

  const filtrados = useMemo(() => {
    const q = busca.trim().toLowerCase();
    return q ? jovens.filter((j) => `${j.NomeJovem} ${j.NomeIgrejaJovem} ${j.Whatsapp}`.toLowerCase().includes(q)) : jovens;
  }, [jovens, busca]);
  const totalPaginas = Math.max(1, Math.ceil(filtrados.length / POR_PAGINA));
  const atual = Math.min(pagina, totalPaginas);
  const linhas = filtrados.slice((atual - 1) * POR_PAGINA, atual * POR_PAGINA);

  function exportarCsv() {
    const tabela = [
      ["Nome", "Nascimento", "Estado", "Bloco", "Região", "Igreja", "WhatsApp", "Projeto", "Classificação"],
      ...filtrados.map((j) => [j.NomeJovem, j.DataNascimento, j.SiglaEstado, j.NomeBlocoJovem, j.NomeRegiaoJovem, j.NomeIgrejaJovem, j.Whatsapp, j.ProjetoJovemPertence, j.ClassificacaoJovem]),
    ];
    const csv = tabela.map((l) => l.map((c) => `"${String(c ?? "").replace(/"/g, '""')}"`).join(";")).join("\n");
    const url = URL.createObjectURL(new Blob(["﻿" + csv], { type: "text/csv;charset=utf-8" }));
    const a = Object.assign(document.createElement("a"), { href: url, download: `${nomeArquivo}.csv` });
    a.click();
    URL.revokeObjectURL(url);
  }

  return (
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
          {linhas.map((j) => (
            <tr key={j.IdJovem} className="hover:bg-slate-50">
              <Td className="font-medium">
                <Link href={`/jovens/${j.IdJovem}`} className="text-brand hover:underline">{j.NomeJovem}</Link>
                <span className="block text-xs font-normal text-slate-500">{j.DataNascimento}</span>
              </Td>
              <Td>{j.NomeIgrejaJovem}</Td>
              <Td>
                {j.NomeRegiaoJovem}
                <span className="block text-xs text-slate-500">{j.NomeBlocoJovem}</span>
              </Td>
              <Td>
                {j.WhatsappSemFormatacao ? (
                  <a href={`https://wa.me/55${j.WhatsappSemFormatacao}`} target="_blank" className="text-emerald-700 hover:underline">{j.Whatsapp}</a>
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
          <Button variant="ghost" disabled={atual === 1} onClick={() => setPagina(atual - 1)}>Anterior</Button>
          <span className="text-slate-600">{atual} de {totalPaginas}</span>
          <Button variant="ghost" disabled={atual === totalPaginas} onClick={() => setPagina(atual + 1)}>Próxima</Button>
        </div>
      )}
    </>
  );
}
