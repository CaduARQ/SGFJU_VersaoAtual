import { Suspense } from "react";
import type { Metadata } from "next";
import { LoginForm } from "./login-form";

export const metadata: Metadata = { title: "Entrar" };

export default function LoginPage({ searchParams }: PageProps<"/login">) {
  return (
    <div className="grid min-h-screen lg:grid-cols-2">
      <div className="hidden flex-col justify-between bg-brand-strong p-12 text-white lg:flex">
        <p className="text-lg font-bold">
          SGFJU <span className="ml-1 rounded bg-accent px-1.5 py-0.5 text-xs font-semibold text-brand-strong">2.0</span>
        </p>
        <div>
          <h1 className="text-4xl font-semibold leading-tight">Gestão da Força Jovem Universal</h1>
          <p className="mt-4 max-w-md text-slate-300">Jovens, igrejas, relatórios e acompanhamento em um só lugar, agora mais rápido e em qualquer tela.</p>
        </div>
        <p className="text-xs text-slate-400">© Força Jovem Universal</p>
      </div>
      <div className="flex items-center justify-center p-6">
        <Suspense>
          <LoginForm searchParams={searchParams} />
        </Suspense>
      </div>
    </div>
  );
}
