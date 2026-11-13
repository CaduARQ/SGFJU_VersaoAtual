"use client";

import { useEffect, useRef, useState } from "react";

type Estado<T> = { chave: string; data: T | null; error: string | null };

/**
 * Busca dados da API e controla carregando/erro.
 * `deps` refaz a busca quando muda; `reload()` força nova busca.
 */
export function useApi<T>(loader: () => Promise<T>, deps: unknown[] = []) {
  const [tick, setTick] = useState(0);
  const [estado, setEstado] = useState<Estado<T>>({ chave: "", data: null, error: null });
  const loaderRef = useRef(loader);
  useEffect(() => {
    loaderRef.current = loader;
  });

  const chave = JSON.stringify([tick, ...deps]);

  useEffect(() => {
    let ativo = true;
    loaderRef
      .current()
      .then((data) => ativo && setEstado({ chave, data, error: null }))
      .catch((e: Error) => ativo && setEstado({ chave, data: null, error: e.message }));
    return () => {
      ativo = false;
    };
  }, [chave]);

  const atual = estado.chave === chave;
  return {
    data: atual ? estado.data : null,
    error: atual ? estado.error : null,
    loading: !atual,
    reload: () => setTick((t) => t + 1),
  };
}

/** Lista que depende de uma URL; `null` = nada a buscar (retorna lista vazia). */
export function useLista<T>(url: string | null, buscar: (url: string) => Promise<T[]>): T[] {
  const [estado, setEstado] = useState<{ url: string | null; itens: T[] }>({ url: null, itens: [] });
  const buscarRef = useRef(buscar);
  useEffect(() => {
    buscarRef.current = buscar;
  });

  useEffect(() => {
    if (!url) return;
    let ativo = true;
    buscarRef
      .current(url)
      .then((itens) => ativo && setEstado({ url, itens }))
      .catch(() => ativo && setEstado({ url, itens: [] }));
    return () => {
      ativo = false;
    };
  }, [url]);

  return url && estado.url === url ? estado.itens : [];
}
