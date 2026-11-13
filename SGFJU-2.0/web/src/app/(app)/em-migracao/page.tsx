import { Suspense } from "react";
import { Loading } from "@/components/ui";
import { AvisoMigracao } from "./aviso";

export default function EmMigracao({ searchParams }: PageProps<"/em-migracao">) {
  return (
    <Suspense fallback={<Loading />}>
      <AvisoMigracao searchParams={searchParams} />
    </Suspense>
  );
}
