"use client";

import { useState } from "react";
import { RefreshCw } from "lucide-react";
import { api } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { RespostaRequisicao, TotaisBloco, TotaisGerais } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { Button, Card, ErrorBox, Loading, PageHeader, Table, Td } from "@/components/ui";
import { TotaisResumo } from "../totais";

export default function DashboardEstadual() {
  const { usuario } = useAuth();
  const totais = useApi(() => api.get<TotaisGerais>("Relatorios/TotaisDashBoardEstadoLogado"));
  const blocos = useApi(() => api.get<TotaisBloco[]>("Relatorios/TotaisBlocosEstadoLogado"));
  const [atualizando, setAtualizando] = useState(false);

  async function atualizar() {
    setAtualizando(true);
    try {
      await api.post<RespostaRequisicao>("Relatorios/AtualizarDashboardEstadoLogado");
      totais.reload();
      blocos.reload();
    } finally {
      setAtualizando(false);
    }
  }

  return (
    <>
      <PageHeader
        title={`Dashboard ${usuario.Estado ?? "estadual"}`}
        subtitle="Totais do estado e de cada bloco"
        actions={
          <Button onClick={atualizar} disabled={atualizando}>
            <RefreshCw className={atualizando ? "size-4 animate-spin" : "size-4"} /> Atualizar números
          </Button>
        }
      />
      {totais.loading && <Loading />}
      {totais.error && <ErrorBox message={totais.error} onRetry={totais.reload} />}
      {totais.data && <TotaisResumo t={totais.data} />}

      <Card title="Por bloco" className="mt-6">
        {blocos.loading && <Loading />}
        {blocos.error && <ErrorBox message={blocos.error} onRetry={blocos.reload} />}
        {blocos.data && (
          <Table head={["Bloco", "Jovens", "Ativos", "Iniciantes", "Inativos", "Obreiros", "Batizados águas"]}>
            {blocos.data.map((b) => (
              <tr key={b.IdBloco} className="hover:bg-slate-50">
                <Td className="font-medium text-slate-900">{b.NomeBloco}</Td>
                <Td>{b.QuantidadeTotalJovens.toLocaleString("pt-BR")}</Td>
                <Td>{b.QuantidadeTotalJovensAtivos.toLocaleString("pt-BR")}</Td>
                <Td>{b.QuantidadeTotalJovensIniciantes.toLocaleString("pt-BR")}</Td>
                <Td>{b.QuantidadeTotalJovensInativos.toLocaleString("pt-BR")}</Td>
                <Td>{b.QuantidadeTotalObreiros.toLocaleString("pt-BR")}</Td>
                <Td>{b.QuantidadeTotalBatizadosAguas.toLocaleString("pt-BR")}</Td>
              </tr>
            ))}
          </Table>
        )}
      </Card>
    </>
  );
}
