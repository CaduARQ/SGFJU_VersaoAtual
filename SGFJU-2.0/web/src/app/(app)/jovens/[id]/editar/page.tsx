import { Suspense } from "react";
import { Loading } from "@/components/ui";
import { CarregarEdicao } from "./carregar";

export default function EditarJovemPage({ params }: PageProps<"/jovens/[id]/editar">) {
  return (
    <Suspense fallback={<Loading />}>
      <CarregarEdicao params={params} />
    </Suspense>
  );
}
