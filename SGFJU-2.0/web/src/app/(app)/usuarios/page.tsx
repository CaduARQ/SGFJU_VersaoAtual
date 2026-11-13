"use client";

import { useMemo, useState } from "react";
import { api } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { Usuario } from "@/lib/types";
import { useAuth } from "@/components/auth-provider";
import { Badge, Card, Empty, ErrorBox, Input, Loading, PageHeader, Table, Td } from "@/components/ui";

export default function Usuarios() {
  const { usuario } = useAuth();
  const { data, error, loading, reload } = useApi(() => api.get<Usuario[]>("Usuarios/RetornaUsuarioEstadoLogado"));
  const [busca, setBusca] = useState("");

  const lista = useMemo(() => {
    const q = busca.trim().toLowerCase();
    const base = [...(data ?? [])].sort((a, b) => a.NomeUsuario.localeCompare(b.NomeUsuario));
    return q ? base.filter((u) => `${u.NomeUsuario} ${u.Login} ${u.NomePerfil}`.toLowerCase().includes(q)) : base;
  }, [data, busca]);

  return (
    <>
      <PageHeader title="Usuários" subtitle={`Quem tem acesso ao SGFJU em ${usuario.Estado ?? "seu estado"}`} />
      <Card>
        <Input value={busca} onChange={(e) => setBusca(e.target.value)} placeholder="Buscar por nome, login ou perfil..." className="mb-4 w-full sm:w-80" />
        {loading && <Loading />}
        {error && <ErrorBox message={error} onRetry={reload} />}
        {data && lista.length === 0 && <Empty text="Nenhum usuário encontrado." />}
        {lista.length > 0 && (
          <Table head={["Nome", "Login", "Perfil", "Bloco", "Região"]}>
            {lista.map((u) => (
              <tr key={u.IdUsuario} className="hover:bg-slate-50">
                <Td className="font-medium text-slate-900">{u.NomeUsuario}</Td>
                <Td>{u.Login}</Td>
                <Td><Badge tone="blue">{u.NomePerfil}</Badge></Td>
                <Td>{u.NomeBlocoUsuario || "—"}</Td>
                <Td>{u.NomeRegiaoUsuario || "—"}</Td>
              </tr>
            ))}
          </Table>
        )}
      </Card>
    </>
  );
}
