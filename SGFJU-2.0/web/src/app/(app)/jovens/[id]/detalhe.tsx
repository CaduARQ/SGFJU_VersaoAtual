"use client";

import Link from "next/link";
import { use, useState, type ReactNode } from "react";
import { ArrowLeft, Pencil } from "lucide-react";
import { api } from "@/lib/api";
import { useApi } from "@/lib/use-api";
import type { JovemDetalhe } from "@/lib/types";
import { Badge, Card, ErrorBox, Loading, PageHeader } from "@/components/ui";

const simNao = (c?: string | null) => (c === "S" ? "Sim" : c === "N" ? "Não" : "—");
const val = (v?: string | number | null) => (v === null || v === undefined || v === "" || v === "\u0000" ? "—" : String(v));

function Info({ label, children }: { label: string; children: ReactNode }) {
  return (
    <div>
      <dt className="text-xs font-medium uppercase tracking-wide text-slate-500">{label}</dt>
      <dd className="mt-0.5 text-sm text-slate-900">{children}</dd>
    </div>
  );
}

function Foto({ id, nome }: { id: string; nome: string }) {
  const [falhou, setFalhou] = useState(false);
  const iniciais = nome.split(" ").slice(0, 2).map((p) => p[0]).join("").toUpperCase();
  if (falhou) return <div className="grid size-16 place-items-center rounded-xl bg-brand text-lg font-semibold text-white">{iniciais}</div>;
  // eslint-disable-next-line @next/next/no-img-element -- foto servida pela API, com cookie de sessão
  return <img src={`/api/v2/jovens/${id}/foto`} alt={nome} onError={() => setFalhou(true)} className="size-16 rounded-xl object-cover" />;
}

export function DetalheJovem({ params }: { params: Promise<{ id: string }> }) {
  const { id } = use(params);
  const { data: j, error, loading, reload } = useApi(() => api.post<JovemDetalhe>("Jovens/ObterJovemAtualizacao", { IdJovem: Number(id) }), [id]);

  if (loading) return <Loading />;
  if (error) return <ErrorBox message={error} onRetry={reload} />;
  if (!j) return <ErrorBox message="Jovem não encontrado." />;

  const igreja = j.IgrejaAQualJovemPertence;
  const esp = j.DadosEspirituaisJovem;
  const sit = j.SituacaoJovemIURDFJU;

  return (
    <>
      <Link href="/jovens" className="mb-4 inline-flex items-center gap-1 text-sm text-slate-500 hover:text-slate-800">
        <ArrowLeft className="size-4" /> Voltar para a lista
      </Link>
      <div className="mb-4">
        <Foto id={id} nome={j.Nome} />
      </div>
      <PageHeader
        title={j.Nome}
        subtitle={[igreja?.NomeIgreja, igreja?.NomeRegiaoJovem, igreja?.NomeBlocoJovem, igreja?.NomeEstado].filter(Boolean).join(" · ")}
        actions={
          <div className="flex flex-wrap items-center gap-2">
            <Link href={`/jovens/${id}/editar`} className="inline-flex items-center gap-2 rounded-lg bg-brand px-4 py-2 text-sm font-medium text-white hover:bg-brand-strong">
              <Pencil className="size-4" /> Editar
            </Link>
            {j.FichaEstaExpirada && <Badge tone="red">Ficha expirada</Badge>}
            {j.EhPastor && <Badge tone="amber">Pastor</Badge>}
            {sit?.EhObreiro === "S" && <Badge tone="blue">Obreiro</Badge>}
          </div>
        }
      />
      <div className="grid gap-6 lg:grid-cols-3">
        <Card title="Dados pessoais">
          <dl className="grid grid-cols-2 gap-4">
            <Info label="Nascimento">{val(j.DataNascimento)}</Info>
            <Info label="Sexo">{j.Sexo === "M" ? "Masculino" : j.Sexo === "F" ? "Feminino" : "—"}</Info>
            <Info label="Estado civil">{val(j.DescricaoEstadoCivilJovem)}</Info>
            <Info label="Cônjuge">{val(j.NomeConjuge)}</Info>
            <Info label="Cadastro">{val(j.DataCadastro)}</Info>
            <Info label="Última atualização">{val(j.DataUltimaAtualizacao)}</Info>
          </dl>
        </Card>
        <Card title="Contato">
          <dl className="grid grid-cols-2 gap-4">
            <Info label="WhatsApp">{val(j.ContatoJovem?.Whatsapp)}</Info>
            <Info label="Telefone">{val(j.ContatoJovem?.TelefoneFixo)}</Info>
            <Info label="Instagram">{val(j.RedeSocialJovem?.Instagram)}</Info>
            <Info label="E-mail">{val(j.RedeSocialJovem?.Email)}</Info>
            <Info label="Emergência">{val(j.ContatoJovem?.NomeContatoEmergencia)}</Info>
            <Info label="Tel. emergência">{val(j.ContatoJovem?.TelefoneEmergencia)}</Info>
          </dl>
        </Card>
        <Card title="Endereço">
          <dl className="grid grid-cols-2 gap-4">
            <Info label="Endereço">{val(j.EnderecoJovem?.DescricaoEndereco)}</Info>
            <Info label="Bairro">{val(j.EnderecoJovem?.Bairro)}</Info>
            <Info label="Cidade">{val(j.EnderecoJovem?.Cidade)}</Info>
            <Info label="Moradia">{val(j.EnderecoJovem?.DescricaoTipoDeMoradia)}</Info>
          </dl>
        </Card>
        <Card title="Vida espiritual">
          <dl className="grid grid-cols-2 gap-4">
            <Info label="Membro IURD">{simNao(esp?.EhMembroIURD)}</Info>
            <Info label="Chegou na IURD">{val(esp?.MesAnoChegadaIURD)}</Info>
            <Info label="Batizado nas águas">{simNao(esp?.EhBatizadoAguas)} {esp?.MesAnoBatismoAguas ? `(${esp.MesAnoBatismoAguas})` : ""}</Info>
            <Info label="Batizado no Espírito">{simNao(esp?.EhBatizadoEspiritoSanto)} {esp?.MesAnoBatismoEspiritoSanto ? `(${esp.MesAnoBatismoEspiritoSanto})` : ""}</Info>
            <Info label="Entrou na FJU">{val(esp?.MesAnoEntradaFJU)}</Info>
            <Info label="Como conheceu">{val(esp?.ComoConheceuIURD)}</Info>
          </dl>
        </Card>
        <Card title="Na obra">
          <dl className="grid grid-cols-2 gap-4">
            <Info label="Obreiro">{simNao(sit?.EhObreiro)}</Info>
            <Info label="Colaborador">{simNao(sit?.EhColaborador)}</Info>
            <Info label="Cursando CPO">{simNao(sit?.EstaCursandoCPO)}</Info>
            <Info label="Coordenador FJU">{simNao(sit?.EhCoordenadorFJU)}</Info>
            <Info label="Camisa">{val(sit?.TamanhoCamisa)}</Info>
          </dl>
        </Card>
        <Card title="Estudo e trabalho">
          <dl className="grid grid-cols-2 gap-4">
            <Info label="Estuda">{simNao(j.DadosEducacionaisJovem?.EstudaAtualmente)}</Info>
            <Info label="Escolaridade">{val(j.DadosEducacionaisJovem?.GrauEscolaridade)}</Info>
            <Info label="Curso">{val(j.DadosEducacionaisJovem?.NomeCursoSuperior)}</Info>
            <Info label="Trabalha">{simNao(j.DadosProfissionaisJovem?.TrabalhaAtualmente)}</Info>
            <Info label="Profissão">{val(j.DadosProfissionaisJovem?.Profissao)}</Info>
            <Info label="Empresa">{val(j.DadosProfissionaisJovem?.NomeEmpresa)}</Info>
          </dl>
        </Card>
      </div>
    </>
  );
}
