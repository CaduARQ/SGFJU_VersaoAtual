import { Suspense } from "react";
import { Loading } from "@/components/ui";
import { ListaObreiros } from "./lista";

export default function ObreirosPage({ searchParams }: PageProps<"/arvore-da-vida/obreiros">) {
  return (
    <Suspense fallback={<Loading />}>
      <ListaObreiros searchParams={searchParams} />
    </Suspense>
  );
}
