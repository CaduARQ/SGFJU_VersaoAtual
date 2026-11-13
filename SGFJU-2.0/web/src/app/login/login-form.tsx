"use client";

import { use, useState, type FormEvent } from "react";
import { api, ApiError } from "@/lib/api";
import type { UsuarioLogado } from "@/lib/types";
import { Button, ErrorBox, Field, Input } from "@/components/ui";

export function LoginForm({ searchParams }: { searchParams: Promise<Record<string, string | string[] | undefined>> }) {
  const params = use(searchParams);
  const voltar = typeof params.voltar === "string" && params.voltar.startsWith("/") ? params.voltar : null;
  const [login, setLogin] = useState("");
  const [senha, setSenha] = useState("");
  const [erro, setErro] = useState<string | null>(null);
  const [enviando, setEnviando] = useState(false);

  async function entrar(e: FormEvent) {
    e.preventDefault();
    setErro(null);
    setEnviando(true);
    try {
      const usuario = await api.post<UsuarioLogado>("auth/login", { Login: login, Senha: senha });
      window.location.href = voltar ?? usuario.PaginaInicial;
    } catch (err) {
      setErro(err instanceof ApiError ? err.message : "Não foi possível entrar. Tente novamente.");
      setEnviando(false);
    }
  }

  return (
    <form onSubmit={entrar} className="w-full max-w-sm space-y-5">
      <div>
        <h2 className="text-2xl font-semibold text-slate-900">Entrar</h2>
        <p className="mt-1 text-sm text-slate-500">Use o mesmo login do SGFJU.</p>
      </div>
      {erro && <ErrorBox message={erro} />}
      <Field label="Login">
        <Input value={login} onChange={(e) => setLogin(e.target.value)} autoComplete="username" autoFocus required />
      </Field>
      <Field label="Senha">
        <Input type="password" value={senha} onChange={(e) => setSenha(e.target.value)} autoComplete="current-password" required />
      </Field>
      <Button type="submit" disabled={enviando} className="w-full">
        {enviando ? "Entrando..." : "Entrar"}
      </Button>
    </form>
  );
}
