import { Suspense } from "react";
import { Loading } from "@/components/ui";
import { DetalheJovem } from "./detalhe";

export default function JovemPage({ params }: PageProps<"/jovens/[id]">) {
  return (
    <Suspense fallback={<Loading />}>
      <DetalheJovem params={params} />
    </Suspense>
  );
}
