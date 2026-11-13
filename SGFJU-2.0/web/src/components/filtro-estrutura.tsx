"use client";

import { api } from "@/lib/api";
import { useLista } from "@/lib/use-api";
import type { Igreja, Regiao, TotaisGerais } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { Field, Select } from "@/components/ui";

export type FiltroValor = { idEstado: number; idBloco: number; idRegiao: number; idIgreja: number };
type Opcao = { id: number; nome: string };

/** Selects encadeados Estado → Bloco → Região → Igreja (o estado só aparece para o ADM). */
export function FiltroEstrutura({ valor, onChange }: { valor: FiltroValor; onChange: (v: FiltroValor) => void }) {
  const { usuario } = useAuth();
  const estados = useLista<Opcao>(usuario.EhAdm ? "Relatorios/ListaTodosTotaisDosEstados" : null, (u) =>
    api.get<TotaisGerais[]>(u).then((l) => l.map((e) => ({ id: e.IdEstado, nome: e.NomeEstado })).sort((a, b) => a.nome.localeCompare(b.nome))),
  );

  // Blocos vêm direto do banco (o endpoint ObterPorEstadoLogado lê um cache em arquivo que pode estar desatualizado).
  const idEstadoBlocos = usuario.EhAdm ? valor.idEstado : usuario.IdEstado;
  const blocos = useLista<Opcao>(idEstadoBlocos ? `blocos/ObterPorEstado/${idEstadoBlocos}` : null, (u) =>
    api
      .get<{ Id: number; NomeBloco: string }[]>(u)
      .then((l) => l.map((b) => ({ id: b.Id, nome: b.NomeBloco })).sort((a, b) => a.nome.localeCompare(b.nome))),
  );

  const regioes = useLista<Opcao>(valor.idBloco ? `regioes/ObterPorBloco/${valor.idBloco}` : null, (u) =>
    api.get<Regiao[]>(u).then((l) => l.map((r) => ({ id: r.IdRegiao, nome: r.NomeRegiao }))),
  );

  const igrejas = useLista<Opcao>(valor.idRegiao ? `igrejas/ObterPorRegiao/${valor.idRegiao}` : null, (u) =>
    api.get<Igreja[]>(u).then((l) => l.map((i) => ({ id: i.IdIgreja, nome: i.NomeIgreja }))),
  );

  const sel = (label: string, opcoes: Opcao[], atual: number, set: (n: number) => void, disabled = false) => (
    <Field label={label}>
      <Select value={atual} disabled={disabled} onChange={(e) => set(Number(e.target.value))}>
        <option value={0}>Todos</option>
        {opcoes.map((o) => (
          <option key={o.id} value={o.id}>
            {o.nome}
          </option>
        ))}
      </Select>
    </Field>
  );

  return (
    <>
      {usuario.EhAdm && sel("Estado", estados, valor.idEstado, (id) => onChange({ idEstado: id, idBloco: 0, idRegiao: 0, idIgreja: 0 }))}
      {sel("Bloco", blocos, valor.idBloco, (id) => onChange({ ...valor, idBloco: id, idRegiao: 0, idIgreja: 0 }), usuario.EhAdm && !valor.idEstado)}
      {sel("Região", regioes, valor.idRegiao, (id) => onChange({ ...valor, idRegiao: id, idIgreja: 0 }), !valor.idBloco)}
      {sel("Igreja", igrejas, valor.idIgreja, (id) => onChange({ ...valor, idIgreja: id }), !valor.idRegiao)}
    </>
  );
}
