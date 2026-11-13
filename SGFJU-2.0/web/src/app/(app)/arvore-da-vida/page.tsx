"use client";

import Link from "next/link";
import { HeartHandshake, TreePine, Users } from "lucide-react";
import { api } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { TotaisAV } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { BarRow, Card, Empty, ErrorBox, Loading, PageHeader, Stat, Table, Td } from "@/components/ui";

export default function PainelArvoreVida() {
  const { usuario } = useAuth();
  const { data, error, loading, reload } = useApi(() => api.get<{ Estados: TotaisAV[] }>("v2/arvore-vida/totais"));
  const estados = data?.Estados ?? [];
  const soma = (k: keyof TotaisAV) => estados.reduce((s, e) => s + (Number(e[k]) || 0), 0);
  const jovens = soma("QuantidadeJovens");
  const acompanhados = soma("QuantidadeJovensAcompanhados");
  const obreiros = soma("QuantidadeObreiros");
  const obreirosAtivos = soma("QuantidadeObreirosQueAcompanham");

  return (
    <>
      <PageHeader title="Árvore da Vida" subtitle={usuario.EhAdm ? "Acompanhamento de jovens por obreiros em todo o país" : `Acompanhamento de jovens por obreiros em ${usuario.Estado ?? "seu estado"}`} />

      <div className="mb-6 grid gap-4 sm:grid-cols-3">
        {[
          { href: "/arvore-da-vida/obreiros", icon: Users, titulo: "Obreiros", texto: "Associe e desassocie jovens" },
          { href: "/arvore-da-vida/acompanhamentos", icon: HeartHandshake, titulo: "Em acompanhamento", texto: "Histórico e registros" },
          { href: "/arvore-da-vida/obreiros?aba=panorama", icon: TreePine, titulo: "Panorama", texto: "Obreiros com e sem ramos" },
        ].map((a) => (
          <Link key={a.href} href={a.href} className="flex items-center gap-4 rounded-xl border border-slate-200 bg-white p-4 shadow-sm transition hover:border-brand/40 hover:shadow">
            <span className="grid size-10 place-items-center rounded-lg bg-brand/10 text-brand"><a.icon className="size-5" /></span>
            <span>
              <span className="block font-medium text-slate-900">{a.titulo}</span>
              <span className="block text-sm text-slate-500">{a.texto}</span>
            </span>
          </Link>
        ))}
      </div>

      {loading && <Loading />}
      {error && <ErrorBox message={error} onRetry={reload} />}
      {data && estados.length === 0 && (
        <Card><Empty text="Ainda não há números consolidados da Árvore da Vida para mostrar." /></Card>
      )}
      {estados.length > 0 && (
        <>
          <div className="grid grid-cols-2 gap-4 md:grid-cols-4">
            <Stat label="Jovens" value={jovens} />
            <Stat label="Acompanhados" value={acompanhados} hint={jovens ? `${Math.round((acompanhados / jovens) * 100)}% dos jovens` : undefined} />
            <Stat label="Obreiros" value={obreiros} />
            <Stat label="Obreiros que acompanham" value={obreirosAtivos} hint={obreiros ? `${Math.round((obreirosAtivos / obreiros) * 100)}% dos obreiros` : undefined} />
          </div>
          {usuario.EhAdm && (
            <Card title="Por estado" className="mt-6">
              <div className="mb-6 space-y-2">
                {estados.slice(0, 10).map((e) => (
                  <BarRow key={e.IdEstado} label={e.NomeEstado} value={e.QuantidadeJovensAcompanhados} max={Math.max(...estados.map((x) => x.QuantidadeJovensAcompanhados), 1)} />
                ))}
              </div>
              <Table head={["Estado", "Jovens", "Acompanhados", "Sem acompanhamento", "Obreiros", "Obreiros que acompanham", "Média por obreiro"]}>
                {estados.map((e) => (
                  <tr key={e.IdEstado} className="hover:bg-slate-50">
                    <Td className="font-medium text-slate-900">{e.NomeEstado}</Td>
                    <Td>{e.QuantidadeJovens.toLocaleString("pt-BR")}</Td>
                    <Td>{e.QuantidadeJovensAcompanhados.toLocaleString("pt-BR")}</Td>
                    <Td>{e.QuantidadeJovensSemAcompanhamento.toLocaleString("pt-BR")}</Td>
                    <Td>{e.QuantidadeObreiros.toLocaleString("pt-BR")}</Td>
                    <Td>{e.QuantidadeObreirosQueAcompanham.toLocaleString("pt-BR")}</Td>
                    <Td>{e.MediaAcompanhamentoJovensPorObreiro}</Td>
                  </tr>
                ))}
              </Table>
            </Card>
          )}
        </>
      )}
    </>
  );
}
