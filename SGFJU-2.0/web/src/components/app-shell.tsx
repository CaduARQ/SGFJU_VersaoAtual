"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";
import { useState, type ReactNode } from "react";
import { ChevronDown, LogOut, Menu, X } from "lucide-react";
import { useAuth } from "@/components/auth-provider";
import { menuDoPerfil } from "@/lib/menu";
import { cx } from "@/components/ui";

export function AppShell({ children }: { children: ReactNode }) {
  const { usuario, sair } = useAuth();
  const pathname = usePathname();
  const [aberto, setAberto] = useState(false);
  const grupos = menuDoPerfil(usuario.CodigoPerfil);

  const iniciais = usuario.Nome?.split(" ").slice(0, 2).map((p) => p[0]).join("").toUpperCase() ?? "?";

  return (
    <div className="flex min-h-screen">
      {/* Sidebar */}
      <aside
        className={cx(
          "fixed inset-y-0 left-0 z-40 flex w-72 flex-col bg-brand-strong text-slate-200 transition-transform lg:static lg:translate-x-0",
          aberto ? "translate-x-0" : "-translate-x-full",
        )}
      >
        <div className="flex h-16 items-center justify-between px-6">
          <Link href={usuario.PaginaInicial} className="text-lg font-bold tracking-tight text-white">
            SGFJU <span className="ml-1 rounded bg-accent px-1.5 py-0.5 text-xs font-semibold text-brand-strong">2.0</span>
          </Link>
          <button className="lg:hidden" onClick={() => setAberto(false)} aria-label="Fechar menu">
            <X className="size-5" />
          </button>
        </div>

        <nav className="flex-1 space-y-5 overflow-y-auto px-4 pb-6">
          {grupos.map((g) => (
            <div key={g.label}>
              <p className="mb-1.5 flex items-center gap-2 px-2 text-xs font-semibold uppercase tracking-wider text-slate-400">
                <g.icon className="size-3.5" /> {g.label}
              </p>
              <ul className="space-y-0.5">
                {g.itens.map((item) => {
                  const ativo = !item.externo && pathname === item.href.split("?")[0] && !item.legado;
                  return (
                    <li key={item.label}>
                      <Link
                        href={item.href}
                        target={item.externo ? "_blank" : undefined}
                        onClick={() => setAberto(false)}
                        className={cx(
                          "flex items-center justify-between rounded-lg px-2 py-1.5 text-sm transition",
                          ativo ? "bg-white/10 font-medium text-white" : "hover:bg-white/5 hover:text-white",
                        )}
                      >
                        {item.label}
                        {item.legado && <span className="rounded bg-white/10 px-1.5 text-[10px] uppercase text-slate-300">em breve</span>}
                      </Link>
                    </li>
                  );
                })}
              </ul>
            </div>
          ))}
        </nav>
      </aside>
      {aberto && <div className="fixed inset-0 z-30 bg-black/40 lg:hidden" onClick={() => setAberto(false)} />}

      {/* Conteúdo */}
      <div className="flex min-w-0 flex-1 flex-col">
        <header className="sticky top-0 z-20 flex h-16 items-center justify-between border-b border-slate-200 bg-white/90 px-4 backdrop-blur lg:px-8">
          <button className="lg:hidden" onClick={() => setAberto(true)} aria-label="Abrir menu">
            <Menu className="size-5" />
          </button>
          <div className="hidden text-sm text-slate-500 lg:block">
            {usuario.Estado ?? "Nacional"}
            {usuario.Bloco ? ` · ${usuario.Bloco}` : ""}
            {usuario.Regiao ? ` · ${usuario.Regiao}` : ""}
          </div>
          <details className="relative">
            <summary className="flex cursor-pointer list-none items-center gap-3">
              <span className="grid size-9 place-items-center rounded-full bg-brand text-sm font-semibold text-white">{iniciais}</span>
              <span className="hidden text-left text-sm sm:block">
                <span className="block font-medium text-slate-900">{usuario.Nome}</span>
                <span className="block text-xs text-slate-500">{usuario.Perfil}</span>
              </span>
              <ChevronDown className="size-4 text-slate-400" />
            </summary>
            <div className="absolute right-0 mt-2 w-48 rounded-lg border border-slate-200 bg-white p-1 shadow-lg">
              <button onClick={sair} className="flex w-full items-center gap-2 rounded-md px-3 py-2 text-sm text-slate-700 hover:bg-slate-100">
                <LogOut className="size-4" /> Sair
              </button>
            </div>
          </details>
        </header>
        <main className="flex-1 p-4 lg:p-8">{children}</main>
      </div>
    </div>
  );
}
