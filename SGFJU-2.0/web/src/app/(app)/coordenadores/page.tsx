"use client";

import Link from "next/link";
import { useState, type FormEvent } from "react";
import { BarChart3, Repeat, Search, X } from "lucide-react";
import { api, ApiError } from "@/lib/api";
import { useAuth } from "@/components/auth-provider";
import { Avatar } from "@/components/avatar";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { Button, Card, Empty, ErrorBox, Field, Input, Loading, PageHeader, Table, Td, plural } from "@/components/ui";

type Coordenador = {
  IdIgrejaCoordenador: number; IdCoordenadorFJU: number; NomeCoordenador: string; NomeIgreja: string; NomeRegiao: string; NomeBloco: string;
  NomeEstado: string; DataEntradaCoordenador: string | null; TotalAnosCoordenandoFJU: number; TotalMesesCoordenandoFJU: number;
  QuantidadeJovensEncontroAtual: number; FotoUrl: string | null;
};

const hoje = () => {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}-${String(d.getDate()).padStart(2, "0")}`;
};

export default function Coordenadores() {
  const { usuario } = useAuth();
  const [filtro, setFiltro] = useState<FiltroValor>({ idEstado: usuario.EhAdm ? 0 : usuario.IdEstado, idBloco: 0, idRegiao: 0, idIgreja: 0 });
  const [lista, setLista] = useState<Coordenador[] | null>(null);
  const [carregando, setCarregando] = useState(false);
  const [erro, setErro] = useState<string | null>(null);
  const [troca, setTroca] = useState<Coordenador | null>(null);
  const [aviso, setAviso] = useState<string | null>(null);

  async function pesquisar(e?: FormEvent) {
    e?.preventDefault();
    setCarregando(true);
    setErro(null);
    try {
      const q = new URLSearchParams({ idEstado: String(filtro.idEstado), idBloco: String(filtro.idBloco), idRegiao: String(filtro.idRegiao), idIgreja: String(filtro.idIgreja) });
      setLista(await api.get<Coordenador[]>(`v2/coordenadores?${q}`));
    } catch (err) {
      setErro((err as Error).message);
    } finally {
      setCarregando(false);
    }
  }

  const tempo = (c: Coordenador) => [c.TotalAnosCoordenandoFJU && plural(c.TotalAnosCoordenandoFJU, "ano", "anos"), c.TotalMesesCoordenandoFJU && plural(c.TotalMesesCoordenandoFJU, "mês", "meses")].filter(Boolean).join(" e ") || "—";

  return (
    <>
      <PageHeader
        title="Coordenadores"
        subtitle="Coordenadores da FJU por igreja. Registre aqui quando um coordenador sair."
        actions={
          <Link href="/coordenadores/panorama" className="inline-flex items-center gap-2 rounded-lg px-4 py-2 text-sm font-medium text-slate-700 hover:bg-slate-100">
            <BarChart3 className="size-4" /> Panorama
          </Link>
        }
      />
      <Card>
        <form onSubmit={pesquisar} className="grid gap-4 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-5">
          <FiltroEstrutura valor={filtro} onChange={setFiltro} />
          <div className="flex items-end"><Button type="submit" disabled={carregando}><Search className="size-4" /> Pesquisar</Button></div>
        </form>
      </Card>
      {aviso && <div className="mt-4 rounded-lg bg-emerald-50 p-3 text-sm text-emerald-800">{aviso}</div>}
      <Card className="mt-6">
        {carregando && <Loading />}
        {erro && <ErrorBox message={erro} onRetry={() => pesquisar()} />}
        {!carregando && lista === null && <Empty text={usuario.EhAdm ? "Escolha um estado e clique em Pesquisar." : "Clique em Pesquisar."} />}
        {!carregando && lista && lista.length === 0 && <Empty text="Nenhum coordenador encontrado." />}
        {!carregando && lista && lista.length > 0 && (
          <Table head={["Coordenador", "Igreja", "Região / Bloco", "Desde", "Tempo na FJU", "Jovens no encontro", ""]}>
            {lista.map((c) => (
              <tr key={c.IdIgrejaCoordenador} className="hover:bg-slate-50">
                <Td>
                  <Link href={`/jovens/${c.IdCoordenadorFJU}`} className="flex items-center gap-3 font-medium text-brand hover:underline">
                    <Avatar nome={c.NomeCoordenador ?? "?"} url={c.FotoUrl} tamanho="sm" /> {c.NomeCoordenador}
                  </Link>
                </Td>
                <Td>{c.NomeIgreja}</Td>
                <Td>{c.NomeRegiao}<span className="block text-xs text-slate-500">{c.NomeBloco}</span></Td>
                <Td>{c.DataEntradaCoordenador ?? "—"}</Td>
                <Td>{tempo(c)}</Td>
                <Td>{c.QuantidadeJovensEncontroAtual || "—"}</Td>
                <Td><Button variant="ghost" onClick={() => setTroca(c)}><Repeat className="size-4" /> Troca</Button></Td>
              </tr>
            ))}
          </Table>
        )}
      </Card>
      {troca && (
        <DialogoTroca
          c={troca}
          onFechar={() => setTroca(null)}
          onConcluir={() => {
            setAviso(`Saída de ${troca.NomeCoordenador} registrada.`);
            setTroca(null);
            pesquisar();
          }}
        />
      )}
    </>
  );
}

function DialogoTroca({ c, onFechar, onConcluir }: { c: Coordenador; onFechar: () => void; onConcluir: () => void }) {
  const { usuario } = useAuth();
  const [data, setData] = useState(hoje);
  const [motivo, setMotivo] = useState("");
  const [pastor, setPastor] = useState(usuario.Nome ?? "");
  const [novo, setNovo] = useState("");
  const [erro, setErro] = useState<string | null>(null);
  const [enviando, setEnviando] = useState(false);

  async function enviar(e: FormEvent) {
    e.preventDefault();
    setEnviando(true);
    setErro(null);
    try {
      await api.post(`v2/coordenadores/${c.IdIgrejaCoordenador}/troca`, { DataSaida: data, Motivo: motivo, NomePastor: pastor, NomeNovoCoordenador: novo || null });
      onConcluir();
    } catch (err) {
      setErro(err instanceof ApiError ? err.message : "Não foi possível registrar.");
      setEnviando(false);
    }
  }

  return (
    <div className="fixed inset-0 z-50 grid place-items-center bg-black/40 p-4" role="dialog" aria-modal="true" aria-labelledby="titulo-troca">
      <form onSubmit={enviar} className="w-full max-w-md space-y-4 rounded-xl bg-white p-6 shadow-xl">
        <div className="flex items-start justify-between">
          <div>
            <h2 id="titulo-troca" className="text-lg font-semibold text-slate-900">Troca de coordenador</h2>
            <p className="text-sm text-slate-500">{c.NomeCoordenador} · {c.NomeIgreja}</p>
          </div>
          <button type="button" onClick={onFechar} aria-label="Fechar"><X className="size-5 text-slate-400" /></button>
        </div>
        {erro && <ErrorBox message={erro} />}
        <Field label="Data de saída *"><Input type="date" value={data} max={hoje()} onChange={(e) => setData(e.target.value)} required /></Field>
        <label className="flex flex-col gap-1.5 text-sm">
          <span className="font-medium text-slate-700">Motivo *</span>
          <textarea rows={3} value={motivo} onChange={(e) => setMotivo(e.target.value)} required minLength={3}
            className="rounded-lg border border-slate-300 px-3 py-2 outline-none focus:border-brand focus:ring-2 focus:ring-brand/20" />
        </label>
        <Field label="Quem fez a troca *"><Input value={pastor} onChange={(e) => setPastor(e.target.value)} required /></Field>
        <Field label="Novo coordenador (opcional)"><Input value={novo} onChange={(e) => setNovo(e.target.value)} /></Field>
        <div className="flex justify-end gap-2">
          <Button type="button" variant="ghost" onClick={onFechar}>Cancelar</Button>
          <Button type="submit" disabled={enviando}>{enviando ? "Registrando..." : "Registrar saída"}</Button>
        </div>
      </form>
    </div>
  );
}
