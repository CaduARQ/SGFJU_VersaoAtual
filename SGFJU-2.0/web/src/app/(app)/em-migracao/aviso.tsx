"use client";

import { use } from "react";
import { Construction } from "lucide-react";
import { Card, PageHeader } from "@/components/ui";

export function AvisoMigracao({ searchParams }: { searchParams: Promise<Record<string, string | string[] | undefined>> }) {
  const p = use(searchParams);
  const titulo = typeof p.titulo === "string" ? p.titulo : "Tela em migração";
  const pagina = typeof p.pagina === "string" ? p.pagina : null;

  return (
    <>
      <PageHeader title={titulo} />
      <Card>
        <div className="flex flex-col items-center gap-3 py-10 text-center">
          <Construction className="size-10 text-accent" />
          <p className="text-lg font-medium text-slate-900">Esta tela ainda está sendo migrada</p>
          <p className="max-w-md text-sm text-slate-500">
            A API já atende esta funcionalidade. Enquanto a nova tela não fica pronta, use a versão antiga
            {pagina && (
              <>
                {" "}(<code className="rounded bg-slate-100 px-1 text-slate-700">{pagina}</code>)
              </>
            )}
            .
          </p>
        </div>
      </Card>
    </>
  );
}
