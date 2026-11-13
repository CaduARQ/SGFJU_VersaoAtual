import { Suspense } from "react";
import { Loading } from "@/components/ui";
import { DetalheObreiro } from "./detalhe";

export default function ObreiroPage({ params }: PageProps<"/arvore-da-vida/obreiros/[id]">) {
  return (
    <Suspense fallback={<Loading />}>
      <DetalheObreiro params={params} />
    </Suspense>
  );
}
