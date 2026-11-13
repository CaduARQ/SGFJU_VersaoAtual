"use client";

import Link from "next/link";
import { useState } from "react";
import { ArrowLeft } from "lucide-react";
import { api } from "@/lib/api";
import { useApi, useLista } from "@/lib/use-api";
import type { TotaisGerais } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { BarRow, Card, Empty, ErrorBox, Field, Loading, PageHeader, Select, Stat, Table, Td } from "@/components/ui";

type Panorama = {
  Totais: { ComCoordenador: number; SemCoordenador: number; SemFju: number; Igrejas: number };
  PorEstado: { IdEstado: number; NomeEstado: string; ComCoordenador: number; SemCoordenador: number; SemFju: number }[];
  IgrejasSemCoordenador: { IdIgreja: number; NomeIgreja: string; NomeRegiao: string; NomeBloco: string; NomeEstado: string }[];
};

export default function PanoramaCoordenadores() {
  const { usuario } = useAuth();
  const [idEstado, setIdEstado] = useState(0);
  const estados = useLista<{ id: number; nome: string }>(usuario.EhAdm ? "Relatorios/ListaTodosTotaisDosEstados" : null, (u) =>
    api.get<TotaisGerais[]>(u).then((l) => l.map((e) => ({ id: e.IdEstado, nome: e.NomeEstado })).sort((a, b) => a.nome.localeCompare(b.nome))),
  );
  const { data, error, loading, reload } = useApi(() => api.get<Panorama>(`v2/coordenadores/panorama?idEstado=${idEstado}`), [idEstado]);
  const t = data?.Totais;
  const pct = (n: number) => (t?.Igrejas ? `${Math.round((n / t.Igrejas) * 100)}% das igrejas` : undefined);

  return (
    <>
      <Link href="/coordenadores" className="mb-4 inline-flex items-center gap-1 text-sm text-slate-500 hover:text-slate-800"><ArrowLeft className="size-4" /> Coordenadores</Link>
      <PageHeader
        title="Panorama de coordenadores"
        subtitle={usuario.EhAdm ? (idEstado ? "Estado selecionado" : "Brasil") : usuario.Estado ?? ""}
        actions={usuario.EhAdm ? (
          <Field label="Estado">
            <Select value={idEstado} onChange={(e) => setIdEstado(Number(e.target.value))}>
              <option value={0}>Brasil (todos)</option>
              {estados.map((e) => <option key={e.id} value={e.id}>{e.nome}</option>)}
            </Select>
          </Field>
        ) : undefined}
      />
      {loading && <Loading />}
      {error && <ErrorBox message={error} onRetry={reload} />}
      {data && t && (
        <>
          <div className="grid grid-cols-2 gap-4 md:grid-cols-4">
            <Stat label="Igrejas" value={t.Igrejas} />
            <Stat label="Com coordenador" value={t.ComCoordenador} hint={pct(t.ComCoordenador)} />
            <Stat label="Sem coordenador" value={t.SemCoordenador} hint={pct(t.SemCoordenador)} />
            <Stat label="Sem FJU" value={t.SemFju} hint={pct(t.SemFju)} />
          </div>
          {usuario.EhAdm && !idEstado && data.PorEstado.length > 0 && (
            <Card title="Por estado" className="mt-6">
              <div className="mb-6 space-y-2">
                {data.PorEstado.map((e) => (
                  <BarRow key={e.IdEstado} label={e.NomeEstado} value={e.ComCoordenador} max={Math.max(...data.PorEstado.map((x) => x.ComCoordenador + x.SemCoordenador + x.SemFju), 1)} />
                ))}
              </div>
              <Table head={["Estado", "Com coordenador", "Sem coordenador", "Sem FJU"]}>
                {data.PorEstado.map((e) => (
                  <tr key={e.IdEstado} className="hover:bg-slate-50">
                    <Td className="font-medium text-slate-900">{e.NomeEstado}</Td>
                    <Td>{e.ComCoordenador}</Td><Td>{e.SemCoordenador}</Td><Td>{e.SemFju}</Td>
                  </tr>
                ))}
              </Table>
            </Card>
          )}
          <Card title={`Igrejas sem coordenador (${data.IgrejasSemCoordenador.length})`} className="mt-6">
            {data.IgrejasSemCoordenador.length === 0 ? <Empty text="Todas as igrejas têm coordenador." /> : (
              <Table head={["Igreja", "Região", "Bloco", ...(usuario.EhAdm && !idEstado ? ["Estado"] : [])]}>
                {data.IgrejasSemCoordenador.map((i) => (
                  <tr key={i.IdIgreja} className="hover:bg-slate-50">
                    <Td className="font-medium text-slate-900">{i.NomeIgreja}</Td><Td>{i.NomeRegiao}</Td><Td>{i.NomeBloco}</Td>
                    {usuario.EhAdm && !idEstado && <Td>{i.NomeEstado}</Td>}
                  </tr>
                ))}
              </Table>
            )}
          </Card>
        </>
      )}
    </>
  );
}
