"use client";

import type { ReactNode } from "react";
import type { SN } from "@/lib/cadastro";
import { mascaraMesAno, mascaraTelefone } from "@/lib/cadastro";
import { cx, Field, Input, Select } from "@/components/ui";

export function Secao({ titulo, children, descricao }: { titulo: string; descricao?: string; children: ReactNode }) {
  return (
    <fieldset className="space-y-4 border-t border-slate-100 pt-5 first:border-0 first:pt-0">
      <legend className="sr-only">{titulo}</legend>
      <div>
        <h3 className="text-sm font-semibold text-slate-900">{titulo}</h3>
        {descricao && <p className="text-xs text-slate-500">{descricao}</p>}
      </div>
      {children}
    </fieldset>
  );
}

export function Grade({ children, cols = 3 }: { children: ReactNode; cols?: 2 | 3 | 4 }) {
  const c = { 2: "sm:grid-cols-2", 3: "sm:grid-cols-2 lg:grid-cols-3", 4: "sm:grid-cols-2 lg:grid-cols-4" }[cols];
  return <div className={cx("grid gap-4", c)}>{children}</div>;
}

/** Pergunta Sim/Não em botões (mais fácil no celular que radio). Clicar de novo desmarca. */
export function SimNao({ label, valor, onChange }: { label: string; valor: SN; onChange: (v: SN) => void }) {
  return (
    <div className="flex flex-col gap-1.5 text-sm">
      <span className="font-medium text-slate-700">{label}</span>
      <div className="inline-flex w-fit overflow-hidden rounded-lg border border-slate-300" role="radiogroup" aria-label={label}>
        {(["S", "N"] as const).map((op) => (
          <button
            key={op}
            type="button"
            role="radio"
            aria-checked={valor === op}
            onClick={() => onChange(valor === op ? "" : op)}
            className={cx(
              "px-4 py-1.5 text-sm transition first:border-r first:border-slate-300",
              valor === op ? "bg-brand text-white" : "bg-white text-slate-700 hover:bg-slate-50",
            )}
          >
            {op === "S" ? "Sim" : "Não"}
          </button>
        ))}
      </div>
    </div>
  );
}

export function Texto({ label, valor, onChange, ...rest }: { label: string; valor: string; onChange: (v: string) => void } & Omit<React.InputHTMLAttributes<HTMLInputElement>, "onChange" | "value">) {
  return (
    <Field label={label}>
      <Input value={valor} onChange={(e) => onChange(e.target.value)} {...rest} />
    </Field>
  );
}

export function Telefone({ label, valor, onChange }: { label: string; valor: string; onChange: (v: string) => void }) {
  return <Texto label={label} valor={valor} onChange={(v) => onChange(mascaraTelefone(v))} inputMode="tel" placeholder="(11) 91234-5678" />;
}

export function MesAno({ label, valor, onChange }: { label: string; valor: string; onChange: (v: string) => void }) {
  return <Texto label={label} valor={valor} onChange={(v) => onChange(mascaraMesAno(v))} inputMode="numeric" placeholder="mm/aaaa" />;
}

export function Numero({ label, valor, onChange, max }: { label: string; valor: number; onChange: (v: number) => void; max?: number }) {
  return (
    <Field label={label}>
      <Input
        type="number"
        min={0}
        max={max}
        value={valor || ""}
        onChange={(e) => onChange(Math.max(0, Math.min(max ?? 9999, Number(e.target.value) || 0)))}
        inputMode="numeric"
      />
    </Field>
  );
}

/** Tempo em anos + meses (padrão "meses#anos" da tela antiga). */
export function Tempo({ label, anos, meses, onAnos, onMeses }: { label: string; anos: number; meses: number; onAnos: (v: number) => void; onMeses: (v: number) => void }) {
  return (
    <div className="flex flex-col gap-1.5 text-sm">
      <span className="font-medium text-slate-700">{label}</span>
      <div className="grid grid-cols-2 gap-2">
        <Input type="number" min={0} max={80} placeholder="Anos" value={anos || ""} onChange={(e) => onAnos(Math.max(0, Number(e.target.value) || 0))} aria-label={`${label}: anos`} />
        <Input type="number" min={0} max={11} placeholder="Meses" value={meses || ""} onChange={(e) => onMeses(Math.min(11, Math.max(0, Number(e.target.value) || 0)))} aria-label={`${label}: meses`} />
      </div>
    </div>
  );
}

export function Escolha<T extends string | number>({
  label,
  valor,
  onChange,
  opcoes,
  vazio = "Selecione",
}: {
  label: string;
  valor: T;
  onChange: (v: T) => void;
  opcoes: readonly { id: T; nome: string }[];
  vazio?: string;
}) {
  const numerico = opcoes.length > 0 && typeof opcoes[0].id === "number";
  return (
    <Field label={label}>
      <Select value={String(valor)} onChange={(e) => onChange((numerico ? Number(e.target.value) : e.target.value) as T)}>
        <option value={numerico ? 0 : ""}>{vazio}</option>
        {opcoes.map((o) => (
          <option key={String(o.id) + o.nome} value={String(o.id)}>
            {o.nome}
          </option>
        ))}
      </Select>
    </Field>
  );
}

export function AreaTexto({ label, valor, onChange, linhas = 3, ajuda }: { label: string; valor: string; onChange: (v: string) => void; linhas?: number; ajuda?: string }) {
  return (
    <label className="flex flex-col gap-1.5 text-sm">
      <span className="font-medium text-slate-700">{label}</span>
      <textarea
        rows={linhas}
        value={valor}
        onChange={(e) => onChange(e.target.value)}
        className="rounded-lg border border-slate-300 bg-white px-3 py-2 text-sm outline-none focus:border-brand focus:ring-2 focus:ring-brand/20"
      />
      {ajuda && <span className="text-xs text-slate-500">{ajuda}</span>}
    </label>
  );
}

/** Grupo de caixas de seleção que guarda uma lista de ids. */
export function Marcar({ label, opcoes, selecionados, onChange }: { label: string; opcoes: readonly { id: number; nome: string }[]; selecionados: number[]; onChange: (v: number[]) => void }) {
  const alternar = (id: number) => onChange(selecionados.includes(id) ? selecionados.filter((x) => x !== id) : [...selecionados, id]);
  return (
    <div className="flex flex-col gap-2 text-sm">
      <span className="font-medium text-slate-700">{label}</span>
      <div className="flex flex-wrap gap-2">
        {opcoes.map((o) => {
          const ativo = selecionados.includes(o.id);
          return (
            <button
              key={o.id}
              type="button"
              aria-pressed={ativo}
              onClick={() => alternar(o.id)}
              className={cx(
                "rounded-full border px-3 py-1 text-sm transition",
                ativo ? "border-brand bg-brand/10 font-medium text-brand" : "border-slate-300 text-slate-600 hover:bg-slate-50",
              )}
            >
              {o.nome}
            </button>
          );
        })}
      </div>
    </div>
  );
}

/** Mostra o conteúdo só quando a resposta for "Sim". */
export function SeSim({ valor, children }: { valor: SN; children: ReactNode }) {
  if (valor !== "S") return null;
  return <div className="rounded-lg border-l-2 border-brand/30 bg-slate-50 p-4">{children}</div>;
}
