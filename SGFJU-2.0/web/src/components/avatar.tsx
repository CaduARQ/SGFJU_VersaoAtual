"use client";

import { useState } from "react";
import { cx } from "@/components/ui";

/** Foto da API com cookie; se não houver, mostra as iniciais. */
export function Avatar({ nome, url, tamanho = "md" }: { nome: string; url?: string | null; tamanho?: "sm" | "md" | "lg" }) {
  const [falhou, setFalhou] = useState(false);
  const cls = { sm: "size-8 text-xs", md: "size-10 text-sm", lg: "size-16 text-lg" }[tamanho];
  const iniciais = nome.split(" ").filter(Boolean).slice(0, 2).map((p) => p[0]).join("").toUpperCase();
  if (!url || falhou) return <span className={cx("grid shrink-0 place-items-center rounded-full bg-brand/10 font-semibold text-brand", cls)}>{iniciais}</span>;
  // eslint-disable-next-line @next/next/no-img-element -- imagem servida pela API autenticada
  return <img src={url} alt={nome} onError={() => setFalhou(true)} className={cx("shrink-0 rounded-full object-cover", cls)} />;
}
