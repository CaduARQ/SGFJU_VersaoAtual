"use client";

import { createContext, useContext, useEffect, useState, type ReactNode } from "react";
import { api } from "@/lib/api";
import type { UsuarioLogado } from "@/lib/types";
import { Loading } from "@/components/ui";

type AuthCtx = { usuario: UsuarioLogado; sair: () => Promise<void> };
const Ctx = createContext<AuthCtx | null>(null);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [usuario, setUsuario] = useState<UsuarioLogado | null>(null);

  useEffect(() => {
    // Em caso de 401 o cliente da API já redireciona para /login.
    api.get<UsuarioLogado>("auth/me").then(setUsuario).catch(() => {});
  }, []);

  const sair = async () => {
    await api.post("auth/logout").catch(() => {});
    // Recarga completa de propósito: limpa todo o estado da sessão anterior.
    // eslint-disable-next-line @next/next/no-location-assign-relative-destination
    window.location.href = "/login";
  };

  if (!usuario)
    return (
      <div className="grid min-h-screen place-items-center">
        <Loading text="Verificando acesso..." />
      </div>
    );

  return <Ctx.Provider value={{ usuario, sair }}>{children}</Ctx.Provider>;
}

export function useAuth() {
  const ctx = useContext(Ctx);
  if (!ctx) throw new Error("useAuth precisa estar dentro de <AuthProvider>");
  return ctx;
}
