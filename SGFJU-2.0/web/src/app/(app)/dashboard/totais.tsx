import type { TotaisGerais } from "@/lib/types";
import { BarRow, Card, Stat } from "@/components/ui";

export function TotaisResumo({ t }: { t: TotaisGerais }) {
  const ministerios: [string, number][] = [
    ["Universitários", t.QuantidadeTotalUniversitarios],
    ["Mídia", t.QuantidadeTotalMidia],
    ["Help", t.QuantidadeTotalHelp],
    ["Secretarias", t.QuantidadeTotalSecretarias],
    ["Cultura", t.QuantidadeTotalCultura],
    ["Esporte", t.QuantidadeTotalEsporte],
    ["Atalaia", t.QuantidadeTotalAtalaia],
    ["Arcanjos", t.QuantidadeTotalArcanjos],
    ["Uniforça", t.QuantidadeTotalUniforca],
  ];
  const max = Math.max(...ministerios.map(([, v]) => v), 1);
  const pct = (v: number) => (t.QuantidadeTotalJovens ? `${Math.round((v / t.QuantidadeTotalJovens) * 100)}% do total` : undefined);

  return (
    <div className="space-y-6">
      <div className="grid grid-cols-2 gap-4 md:grid-cols-3 xl:grid-cols-6">
        <Stat label="Jovens" value={t.QuantidadeTotalJovens} />
        <Stat label="Ativos" value={t.QuantidadeTotalJovensAtivos} hint={pct(t.QuantidadeTotalJovensAtivos)} />
        <Stat label="Iniciantes" value={t.QuantidadeTotalJovensIniciantes} />
        <Stat label="Inativos" value={t.QuantidadeTotalJovensInativos} />
        <Stat label="Batizados nas águas" value={t.QuantidadeTotalBatizadosAguas} hint={pct(t.QuantidadeTotalBatizadosAguas)} />
        <Stat label="Batizados no Espírito" value={t.QuantidadeTotalEspiritoSanto} hint={pct(t.QuantidadeTotalEspiritoSanto)} />
      </div>
      <div className="grid gap-6 lg:grid-cols-3">
        <Card title="Perfil">
          <div className="space-y-3">
            <BarRow label="Homens" value={t.QuantidadeTotalHomens} max={t.QuantidadeTotalJovens} />
            <BarRow label="Mulheres" value={t.QuantidadeTotalMulheres} max={t.QuantidadeTotalJovens} />
            <BarRow label="Obreiros" value={t.QuantidadeTotalObreiros} max={t.QuantidadeTotalJovens} />
            <BarRow label="Colaboradores" value={t.QuantidadeTotalColaboradores} max={t.QuantidadeTotalJovens} />
            <BarRow label="CPO" value={t.QuantidadeTotalCPO} max={t.QuantidadeTotalJovens} />
            <BarRow label="Altar Jovem" value={t.QuantidadeJovensAltarJovem} max={t.QuantidadeTotalJovens} />
          </div>
        </Card>
        <Card title="Projetos" className="lg:col-span-2">
          <div className="space-y-3">
            {ministerios.map(([l, v]) => (
              <BarRow key={l} label={l} value={v} max={max} />
            ))}
          </div>
        </Card>
      </div>
      <div className="grid grid-cols-2 gap-4 md:grid-cols-4">
        <Stat label="Árvore da Vida: acompanhados" value={t.QuantidadeTotalAVJovensAcompanhados} />
        <Stat label="Árvore da Vida: sem acompanhamento" value={t.QuantidadeTotalAVJovensSemAcompanhamento} />
      </div>
    </div>
  );
}
