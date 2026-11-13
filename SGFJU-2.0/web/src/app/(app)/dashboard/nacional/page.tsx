"use client";

import { api } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { TotaisGerais } from "@/lib/types";
import { Card, ErrorBox, Loading, PageHeader, Table, Td } from "@/components/ui";
import { TotaisResumo } from "../totais";

export default function DashboardNacional() {
  const totais = useApi(() => api.get<TotaisGerais>("Relatorios/TotaisDashboardNacional"));
  const estados = useApi(() => api.get<TotaisGerais[]>("Relatorios/ListaTodosTotaisDosEstados"));

  return (
    <>
      <PageHeader title="Dashboard nacional" subtitle="Visão geral dos jovens cadastrados em todos os estados" />
      {totais.loading && <Loading />}
      {totais.error && <ErrorBox message={totais.error} onRetry={totais.reload} />}
      {totais.data && <TotaisResumo t={totais.data} />}

      <Card title="Por estado" className="mt-6">
        {estados.loading && <Loading />}
        {estados.error && <ErrorBox message={estados.error} onRetry={estados.reload} />}
        {estados.data && (
          <Table head={["Estado", "Jovens", "Ativos", "Iniciantes", "Inativos", "Obreiros", "Batizados águas", "Altar Jovem"]}>
            {[...estados.data]
              .sort((a, b) => b.QuantidadeTotalJovens - a.QuantidadeTotalJovens)
              .map((e) => (
                <tr key={e.IdEstado} className="hover:bg-slate-50">
                  <Td className="font-medium text-slate-900">{e.NomeEstado}</Td>
                  <Td>{e.QuantidadeTotalJovens.toLocaleString("pt-BR")}</Td>
                  <Td>{e.QuantidadeTotalJovensAtivos.toLocaleString("pt-BR")}</Td>
                  <Td>{e.QuantidadeTotalJovensIniciantes.toLocaleString("pt-BR")}</Td>
                  <Td>{e.QuantidadeTotalJovensInativos.toLocaleString("pt-BR")}</Td>
                  <Td>{e.QuantidadeTotalObreiros.toLocaleString("pt-BR")}</Td>
                  <Td>{e.QuantidadeTotalBatizadosAguas.toLocaleString("pt-BR")}</Td>
                  <Td>{e.QuantidadeJovensAltarJovem.toLocaleString("pt-BR")}</Td>
                </tr>
              ))}
          </Table>
        )}
      </Card>
    </>
  );
}
