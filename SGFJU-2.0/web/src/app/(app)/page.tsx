"use client";

import { useEffect } from "react";
import { useRouter } from "next/navigation";
import { useAuth } from "@/components/auth-provider";
import { Loading } from "@/components/ui";

// "/" leva cada perfil para sua página inicial (mesma regra do formLogin.aspx).
export default function Inicio() {
  const { usuario } = useAuth();
  const router = useRouter();
  useEffect(() => router.replace(usuario.PaginaInicial), [router, usuario.PaginaInicial]);
  return <Loading text="Abrindo..." />;
}
