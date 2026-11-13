import { Suspense } from "react";
import { Loading } from "@/components/ui";
import { AltarJovem } from "./altar";

export default function AltarJovemPage({ searchParams }: PageProps<"/altar-jovem">) {
  return (
    <Suspense fallback={<Loading />}>
      <AltarJovem searchParams={searchParams} />
    </Suspense>
  );
}
