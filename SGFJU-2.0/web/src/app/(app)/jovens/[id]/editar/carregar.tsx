"use client";

import { use } from "react";
import { api } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import { deApi } from "@/lib/cadastro";
import { ErrorBox, Loading } from "@/components/ui";
import { FormularioJovem } from "../../_formulario/formulario";
import { rotuloHabilidade } from "../../_formulario/etapas";

type Resposta = {
  IdJovem: number;
  Dados: Record<string, unknown>;
  IdEstado: number;
  IdBloco: number;
  IdRegiao: number;
  FotoUrl: string | null;
};

export function CarregarEdicao({ params }: { params: Promise<{ id: string }> }) {
  const { id } = use(params);
  const { data, error, loading, reload } = useApi(() => api.get<Resposta>(`v2/jovens/${id}`), [id]);

  if (loading) return <Loading text="Carregando ficha..." />;
  if (error) return <ErrorBox message={error} onRetry={reload} />;
  if (!data) return <ErrorBox message="Jovem não encontrado." />;

  const inicial = deApi(data.Dados, rotuloHabilidade);
  return (
    <FormularioJovem
      key={data.IdJovem}
      modo={{
        tipo: "editar",
        idJovem: data.IdJovem,
        inicial,
        filtro: { idEstado: data.IdEstado, idBloco: data.IdBloco, idRegiao: data.IdRegiao, idIgreja: inicial.IdIgreja },
        fotoUrl: data.FotoUrl,
      }}
    />
  );
}
