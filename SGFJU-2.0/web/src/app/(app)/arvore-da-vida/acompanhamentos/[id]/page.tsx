import { Suspense } from "react";
import { Loading } from "@/components/ui";
import { HistoricoJovem } from "./historico";

export default function HistoricoPage({ params }: PageProps<"/arvore-da-vida/acompanhamentos/[id]">) {
  return (
    <Suspense fallback={<Loading />}>
      <HistoricoJovem params={params} />
    </Suspense>
  );
}
