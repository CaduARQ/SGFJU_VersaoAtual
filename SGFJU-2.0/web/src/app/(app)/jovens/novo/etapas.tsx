"use client";

import { useState } from "react";
import { Plus, ShieldAlert, Trash2 } from "lucide-react";
import type { CadastroJovem } from "@/lib/cadastro";
import { OPCOES } from "@/lib/opcoes-cadastro";
import { FiltroEstrutura, type FiltroValor } from "@/components/filtro-estrutura";
import { Badge, Button, Field, Input, Select } from "@/components/ui";
import { AreaTexto, Escolha, Grade, Marcar, MesAno, Numero, Secao, SeSim, SimNao, Telefone, Tempo, Texto } from "./campos";

type Sub = "Contato" | "Endereco" | "Redes" | "Espiritual" | "Obra" | "Estudo" | "Trabalho" | "Projeto" | "Testemunho";

export type EtapaProps = {
  c: CadastroJovem;
  set: <K extends keyof CadastroJovem>(campo: K, valor: CadastroJovem[K]) => void;
  sub: <S extends Sub, K extends keyof CadastroJovem[S]>(secao: S, campo: K, valor: CadastroJovem[S][K]) => void;
};

const NIVEIS = OPCOES.niveis;
const PROJETOS = OPCOES.projetos;

// ---------------------------------------------------------------- 1. Identificação
export function EtapaIdentificacao({ c, set, filtro, setFiltro }: EtapaProps & { filtro: FiltroValor; setFiltro: (f: FiltroValor) => void }) {
  return (
    <div className="space-y-6">
      <Secao titulo="Igreja" descricao="Onde o jovem congrega.">
        <Grade cols={4}>
          <FiltroEstrutura
            rotuloVazio="Selecione"
            valor={filtro}
            onChange={(f) => {
              setFiltro(f);
              set("IdIgreja", f.idIgreja);
            }}
          />
        </Grade>
      </Secao>
      <Secao titulo="Dados pessoais">
        <Grade>
          <div className="sm:col-span-2">
            <Texto label="Nome completo *" valor={c.Nome} onChange={(v) => set("Nome", v)} autoComplete="off" />
          </div>
          <Texto label="Data de nascimento *" type="date" valor={c.DataNascimento} onChange={(v) => set("DataNascimento", v)} />
          <Escolha label="Sexo *" valor={c.Sexo} onChange={(v) => set("Sexo", v as CadastroJovem["Sexo"])} opcoes={[{ id: "M", nome: "Masculino" }, { id: "F", nome: "Feminino" }]} />
          <Escolha label="Estado civil" valor={c.IdEstadoCivil} onChange={(v) => set("IdEstadoCivil", v)} opcoes={OPCOES.estadosCivis} />
          <Escolha label="Classificação" valor={c.ClassificacaoJovem} onChange={(v) => set("ClassificacaoJovem", v)} opcoes={OPCOES.classificacoes} />
          <Texto label="Data em que a ficha foi preenchida" type="date" valor={c.DataPreenchimentoFormulario} onChange={(v) => set("DataPreenchimentoFormulario", v)} />
        </Grade>
      </Secao>
    </div>
  );
}

// ---------------------------------------------------------------- 2. Contato e família
export function EtapaContato({ c, set, sub }: EtapaProps) {
  const casado = c.IdEstadoCivil === 6 || c.IdEstadoCivil === 10;
  return (
    <div className="space-y-6">
      <Secao titulo="Contato">
        <Grade cols={2}>
          <Telefone label="WhatsApp" valor={c.Contato.Whatsapp} onChange={(v) => sub("Contato", "Whatsapp", v)} />
          <Telefone label="Telefone fixo" valor={c.Contato.TelefoneFixo} onChange={(v) => sub("Contato", "TelefoneFixo", v)} />
          <Texto label="Contato de emergência (nome)" valor={c.Contato.NomeContatoEmergencia} onChange={(v) => sub("Contato", "NomeContatoEmergencia", v)} />
          <Telefone label="Telefone de emergência" valor={c.Contato.TelefoneEmergencia} onChange={(v) => sub("Contato", "TelefoneEmergencia", v)} />
        </Grade>
      </Secao>
      <Secao titulo="Endereço">
        <Grade>
          <div className="sm:col-span-2">
            <Texto label="Endereço" valor={c.Endereco.Endereco} onChange={(v) => sub("Endereco", "Endereco", v)} />
          </div>
          <Texto label="Bairro" valor={c.Endereco.Bairro} onChange={(v) => sub("Endereco", "Bairro", v)} />
          <Texto label="Cidade" valor={c.Endereco.Cidade} onChange={(v) => sub("Endereco", "Cidade", v)} />
          <Escolha label="Mora com" valor={c.Endereco.IdTipoMoradia} onChange={(v) => sub("Endereco", "IdTipoMoradia", v)} opcoes={OPCOES.tiposMoradia} />
        </Grade>
      </Secao>
      <Secao titulo="Família">
        <Grade>
          {casado && (
            <>
              <Texto label="Nome do cônjuge" valor={c.NomeConjuge} onChange={(v) => set("NomeConjuge", v)} />
              <Texto label="Data do casamento" type="date" valor={c.DataCasamento} onChange={(v) => set("DataCasamento", v)} />
              <SimNao label="O cônjuge é da Universal?" valor={c.ConjugeEhIURD} onChange={(v) => set("ConjugeEhIURD", v)} />
            </>
          )}
          <SimNao label="Tem filhos?" valor={c.PossuiFilhos} onChange={(v) => set("PossuiFilhos", v)} />
          {c.PossuiFilhos === "S" && <Numero label="Quantos?" valor={c.QuantidadeFilhos} onChange={(v) => set("QuantidadeFilhos", v)} max={30} />}
          <SimNao label="Tem título de eleitor?" valor={c.PossuiTituloEleitor} onChange={(v) => set("PossuiTituloEleitor", v)} />
          {c.Sexo === "F" && (
            <>
              <SimNao label="Faz parte de grupo de mulheres da Universal?" valor={c.PertenceGrupoMulheresIURD} onChange={(v) => set("PertenceGrupoMulheresIURD", v)} />
              {c.PertenceGrupoMulheresIURD === "S" && <Texto label="Qual grupo?" valor={c.NomeGrupoMulheresIURD} onChange={(v) => set("NomeGrupoMulheresIURD", v)} />}
            </>
          )}
        </Grade>
      </Secao>
    </div>
  );
}

// ---------------------------------------------------------------- 3. Vida espiritual
export function EtapaEspiritual({ c, set, sub }: EtapaProps) {
  const e = c.Espiritual;
  const s = <K extends keyof CadastroJovem["Espiritual"]>(k: K, v: CadastroJovem["Espiritual"][K]) => sub("Espiritual", k, v);
  return (
    <div className="space-y-6">
      <Secao titulo="Universal">
        <Grade>
          <SimNao label="É membro da Universal?" valor={e.EhMembroIURD} onChange={(v) => s("EhMembroIURD", v)} />
          <MesAno label="Quando chegou (mês/ano)" valor={e.MesAnoChegadaIURD} onChange={(v) => s("MesAnoChegadaIURD", v)} />
          <Texto label="Como conheceu a Universal?" valor={e.ComoConheceuIURD} onChange={(v) => s("ComoConheceuIURD", v)} />
          <Texto label="Desde quando está firme?" valor={e.TempoEstaFirme} onChange={(v) => s("TempoEstaFirme", v)} />
          <SimNao label="Já se afastou?" valor={e.JaSeAfastou} onChange={(v) => s("JaSeAfastou", v)} />
        </Grade>
        <SeSim valor={e.JaSeAfastou}>
          <Grade>
            <MesAno label="Quando se afastou" valor={e.MesAnoAfastamento} onChange={(v) => s("MesAnoAfastamento", v)} />
            <Texto label="Por quanto tempo?" valor={e.TempoAfastamento} onChange={(v) => s("TempoAfastamento", v)} />
            <Texto label="Motivo" valor={e.MotivoSeAfastou} onChange={(v) => s("MotivoSeAfastou", v)} />
          </Grade>
        </SeSim>
        <Texto label="Familiares na Universal (quem?)" valor={e.DescricaoFamiliaresIURD} onChange={(v) => s("DescricaoFamiliaresIURD", v)} />
      </Secao>

      <Secao titulo="Batismos">
        <Grade>
          <SimNao label="Batizado nas águas?" valor={e.EhBatizadoAguas} onChange={(v) => s("EhBatizadoAguas", v)} />
          {e.EhBatizadoAguas === "S" && (
            <>
              <MesAno label="Quando (mês/ano)" valor={e.MesAnoBatismoAguas} onChange={(v) => s("MesAnoBatismoAguas", v)} />
              <SimNao label="Foi na Universal?" valor={e.BatismoAguasIURD} onChange={(v) => s("BatismoAguasIURD", v)} />
            </>
          )}
        </Grade>
        <Grade>
          <SimNao label="Batizado no Espírito Santo?" valor={e.EhBatizadoEspiritoSanto} onChange={(v) => s("EhBatizadoEspiritoSanto", v)} />
          {e.EhBatizadoEspiritoSanto === "S" && (
            <>
              <MesAno label="Quando (mês/ano)" valor={e.MesAnoBatismoEspiritoSanto} onChange={(v) => s("MesAnoBatismoEspiritoSanto", v)} />
              <Texto label="Em qual ocasião?" valor={e.OcasiaoBatismoEspiritoSanto} onChange={(v) => s("OcasiaoBatismoEspiritoSanto", v)} />
            </>
          )}
        </Grade>
      </Secao>

      <Secao titulo="Força Jovem">
        <Grade>
          <MesAno label="Quando entrou na FJU (mês/ano)" valor={e.MesAnoEntradaFJU} onChange={(v) => s("MesAnoEntradaFJU", v)} />
          <Texto label="Como conheceu a FJU?" valor={e.DescricaoModoChegouFJU} onChange={(v) => s("DescricaoModoChegouFJU", v)} />
          <Texto label="Por que entrou?" valor={e.MotivoEntradaFJU} onChange={(v) => s("MotivoEntradaFJU", v)} />
        </Grade>
        <Marcar label="Reuniões que frequenta" opcoes={OPCOES.reunioes} selecionados={c.Reunioes} onChange={(v) => set("Reunioes", v)} />
      </Secao>

      <Secao titulo="Bíblia e leitura">
        <Grade>
          <SimNao label="Tem Bíblia?" valor={e.PossuiBiblia} onChange={(v) => s("PossuiBiblia", v)} />
          <SimNao label="Já leu a Bíblia toda?" valor={e.LeuTodaBiblia} onChange={(v) => s("LeuTodaBiblia", v)} />
          <Escolha label="Com que frequência lê?" valor={e.IdFrequenciaLeituraBiblia} onChange={(v) => s("IdFrequenciaLeituraBiblia", v)} opcoes={OPCOES.frequenciaLeituraBiblia} />
        </Grade>
        <Marcar label="Livros que já leu" opcoes={OPCOES.livros} selecionados={c.Livros} onChange={(v) => set("Livros", v)} />
      </Secao>
    </div>
  );
}

// ---------------------------------------------------------------- 4. Na obra
export function EtapaObra({ c, sub }: EtapaProps) {
  const o = c.Obra;
  const s = <K extends keyof CadastroJovem["Obra"]>(k: K, v: CadastroJovem["Obra"][K]) => sub("Obra", k, v);
  const anoAtual = new Date().getFullYear();
  return (
    <div className="space-y-6">
      <Secao titulo="Situação atual">
        <Grade>
          <SimNao label="Faz parte da FJU?" valor={o.EhPertencenteFJU} onChange={(v) => s("EhPertencenteFJU", v)} />
          <SimNao label="É obreiro(a)?" valor={o.EhObreiro} onChange={(v) => s("EhObreiro", v)} />
          {o.EhObreiro === "S" && <Tempo label="Há quanto tempo?" anos={o.AnosObreiro} meses={o.MesesObreiro} onAnos={(v) => s("AnosObreiro", v)} onMeses={(v) => s("MesesObreiro", v)} />}
          <SimNao label="É colaborador(a)?" valor={o.EhColaborador} onChange={(v) => s("EhColaborador", v)} />
          {o.EhColaborador === "S" && <Tempo label="Há quanto tempo?" anos={o.AnosColaborador} meses={o.MesesColaborador} onAnos={(v) => s("AnosColaborador", v)} onMeses={(v) => s("MesesColaborador", v)} />}
          <SimNao label="Está cursando o CPO?" valor={o.EstaCursandoCPO} onChange={(v) => s("EstaCursandoCPO", v)} />
          {o.EstaCursandoCPO === "S" && (
            <div className="grid grid-cols-2 gap-2">
              <Numero label="Mês de início" valor={o.MesInicioCPO} onChange={(v) => s("MesInicioCPO", v)} max={12} />
              <Numero label="Ano de início" valor={o.AnoInicioCPO} onChange={(v) => s("AnoInicioCPO", v)} max={anoAtual} />
            </div>
          )}
          <SimNao label="Está no Altar Jovem?" valor={o.PertenceAltarJovem} onChange={(v) => s("PertenceAltarJovem", v)} />
        </Grade>
      </Secao>

      <Secao titulo="Liderança">
        <Grade>
          <SimNao label="É coordenador(a) da FJU?" valor={o.EhCoordenadorFJU} onChange={(v) => s("EhCoordenadorFJU", v)} />
          {o.EhCoordenadorFJU === "S" && <Tempo label="Há quanto tempo?" anos={o.AnosCoordenandoFJU} meses={o.MesesCoordenandoFJU} onAnos={(v) => s("AnosCoordenandoFJU", v)} onMeses={(v) => s("MesesCoordenandoFJU", v)} />}
        </Grade>
        <Grade>
          <SimNao label="É líder de tribo?" valor={o.EhLiderTribo} onChange={(v) => s("EhLiderTribo", v)} />
          {o.EhLiderTribo === "S" && (
            <>
              <Escolha label="Qual tribo?" valor={o.IdTribo} onChange={(v) => s("IdTribo", v)} opcoes={OPCOES.tribos} />
              <Tempo label="Há quanto tempo?" anos={o.AnosCoordenandoTribo} meses={o.MesesCoordenandoTribo} onAnos={(v) => s("AnosCoordenandoTribo", v)} onMeses={(v) => s("MesesCoordenandoTribo", v)} />
            </>
          )}
        </Grade>
        <Grade>
          <SimNao label="É líder de projeto?" valor={o.EhLiderProjeto} onChange={(v) => s("EhLiderProjeto", v)} />
          {o.EhLiderProjeto === "S" && (
            <>
              <Escolha label="Qual projeto?" valor={o.IdProjetoQueCoordena} onChange={(v) => s("IdProjetoQueCoordena", v)} opcoes={PROJETOS} />
              <Tempo label="Há quanto tempo?" anos={o.AnosCoordenandoProjeto} meses={o.MesesCoordenandoProjeto} onAnos={(v) => s("AnosCoordenandoProjeto", v)} onMeses={(v) => s("MesesCoordenandoProjeto", v)} />
            </>
          )}
        </Grade>
      </Secao>

      <Secao titulo="Camisa da FJU">
        <Grade>
          <SimNao label="Tem camisa da FJU?" valor={o.PossuiCamisaProjeto} onChange={(v) => s("PossuiCamisaProjeto", v)} />
          {o.PossuiCamisaProjeto === "S" && (
            <>
              <Escolha label="Qual camisa?" valor={o.NomeCamisaFJU} onChange={(v) => s("NomeCamisaFJU", v)} opcoes={[...new Set(OPCOES.camisas)].map((n) => ({ id: n, nome: n }))} />
              <Escolha label="Tamanho" valor={o.TamanhoCamisa} onChange={(v) => s("TamanhoCamisa", v)} opcoes={OPCOES.tamanhosCamisa.map((n) => ({ id: n, nome: n }))} />
            </>
          )}
        </Grade>
      </Secao>

      <Secao titulo="Histórico e desejos">
        <Grade cols={2}>
          <SimNao label="Já foi obreiro(a) antes?" valor={o.FoiObreiro} onChange={(v) => s("FoiObreiro", v)} />
          {o.FoiObreiro === "S" && <Texto label="Por que saiu?" valor={o.MotivoSaiuObreiro} onChange={(v) => s("MotivoSaiuObreiro", v)} />}
          <SimNao label="Já foi pastor(a) ou esposa de pastor?" valor={o.FoiPastor} onChange={(v) => s("FoiPastor", v)} />
          {o.FoiPastor === "S" && <Texto label="Por que saiu?" valor={o.MotivoSaidaPastor} onChange={(v) => s("MotivoSaidaPastor", v)} />}
          <SimNao label="Deseja ser obreiro(a)?" valor={o.DesejaSerObreiro} onChange={(v) => s("DesejaSerObreiro", v)} />
          {o.DesejaSerObreiro === "S" && <Texto label="Por quê?" valor={o.MotivoDesejaSerObreiro} onChange={(v) => s("MotivoDesejaSerObreiro", v)} />}
          <SimNao label="Deseja fazer a obra no altar?" valor={o.DesejaFazerObraNoAltar} onChange={(v) => s("DesejaFazerObraNoAltar", v)} />
        </Grade>
      </Secao>

      <Secao titulo="Intellimen">
        <Grade>
          <SimNao label="Faz parte do Intellimen?" valor={o.PertenceIntellimen} onChange={(v) => s("PertenceIntellimen", v)} />
          {o.PertenceIntellimen === "S" && (
            <>
              <SimNao label="Completou os desafios?" valor={o.DesafiosConcluidos} onChange={(v) => s("DesafiosConcluidos", v)} />
              <Numero label="Desafio atual" valor={o.DesafioAtual} onChange={(v) => s("DesafioAtual", v)} max={60} />
              <Texto label="Nome do parceiro" valor={o.NomeParceiroIntellimen} onChange={(v) => s("NomeParceiroIntellimen", v)} />
              <Telefone label="Telefone do parceiro" valor={o.TelefoneParceiroIntellimen} onChange={(v) => s("TelefoneParceiroIntellimen", v)} />
            </>
          )}
        </Grade>
      </Secao>
    </div>
  );
}

// ---------------------------------------------------------------- 5. Projeto e talentos
export function EtapaTalentos({ c, set, sub }: EtapaProps) {
  const p = c.Projeto;
  const [grupo, setGrupo] = useState<keyof typeof OPCOES.habilidades>("Dança");
  const [hab, setHab] = useState(0);
  const [nivelHab, setNivelHab] = useState(5);
  const [habExtra, setHabExtra] = useState("");
  const [idioma, setIdioma] = useState(0);
  const [idiomaExtra, setIdiomaExtra] = useState("");
  const [nivelIdioma, setNivelIdioma] = useState(5);
  const [curso, setCurso] = useState("");
  const [projetoCurso, setProjetoCurso] = useState<number>(PROJETOS[0].id);
  const nomeNivel = (id: number) => NIVEIS.find((n) => n.id === id)?.nome ?? "";

  function addHabilidade() {
    const extra = habExtra.trim();
    if (!hab && !extra) return;
    const rotulo = hab ? `${grupo}: ${OPCOES.habilidades[grupo].find((h) => h.id === hab)?.nome}` : `Outra: ${extra}`;
    if (c.Habilidades.some((h) => h.rotulo === rotulo)) return;
    set("Habilidades", [...c.Habilidades, { IdHabilidade: hab, IdNivel: nivelHab, NomeHabilidadeExtra: hab ? undefined : extra, rotulo }]);
    setHab(0);
    setHabExtra("");
  }

  function addIdioma() {
    const extra = idiomaExtra.trim();
    if (!idioma && !extra) return;
    if (idioma && c.Idiomas.some((i) => i.Id === idioma)) return;
    set("Idiomas", [...c.Idiomas, { Id: idioma, IdNivel: nivelIdioma, NomeExtra: idioma ? undefined : extra }]);
    setIdioma(0);
    setIdiomaExtra("");
  }

  const nomeIdioma = (i: CadastroJovem["Idiomas"][number]) => (i.Id ? OPCOES.idiomas.find((x) => x.id === i.Id)?.nome : i.NomeExtra);

  return (
    <div className="space-y-6">
      <Secao titulo="Projeto da FJU">
        <Grade>
          <Escolha label="Projeto de que participa" valor={p.IdProjeto} onChange={(v) => sub("Projeto", "IdProjeto", v)} opcoes={PROJETOS} vazio="Nenhum" />
          {p.IdProjeto > 0 && (
            <>
              <Tempo label="Há quanto tempo?" anos={p.Anos} meses={p.Meses} onAnos={(v) => sub("Projeto", "Anos", v)} onMeses={(v) => sub("Projeto", "Meses", v)} />
              <SimNao label="Já esteve em outro projeto?" valor={p.PertenceuOutroProjeto} onChange={(v) => sub("Projeto", "PertenceuOutroProjeto", v)} />
              {p.PertenceuOutroProjeto === "S" && (
                <Escolha label="Qual?" valor={p.IdProjetoAnterior} onChange={(v) => sub("Projeto", "IdProjetoAnterior", v)} opcoes={PROJETOS.filter((x) => x.id !== p.IdProjeto)} vazio="Nenhum" />
              )}
            </>
          )}
        </Grade>
        <Grade cols={2}>
          <SimNao label="É palestrante do Help?" valor={c.EhPalestranteHelp} onChange={(v) => set("EhPalestranteHelp", v)} />
          <SimNao label="É atendente do WhatsApp Help?" valor={c.EhAtendenteWhatsappHelp} onChange={(v) => set("EhAtendenteWhatsappHelp", v)} />
        </Grade>
        <Marcar label="Departamentos (Arte/Cultura)" opcoes={OPCOES.departamentos} selecionados={c.Departamentos} onChange={(v) => set("Departamentos", v)} />
        <Marcar label="Tom de voz" opcoes={OPCOES.tonsDeVoz} selecionados={c.TonsDeVoz} onChange={(v) => set("TonsDeVoz", v)} />
      </Secao>

      <Secao titulo="Habilidades">
        <div className="grid items-end gap-3 sm:grid-cols-[10rem_1fr_10rem_auto]">
          <Field label="Área">
            <Select value={grupo} onChange={(e) => { setGrupo(e.target.value as typeof grupo); setHab(0); }}>
              {Object.keys(OPCOES.habilidades).map((g) => <option key={g}>{g}</option>)}
            </Select>
          </Field>
          <Field label="Habilidade">
            <Select value={hab} onChange={(e) => setHab(Number(e.target.value))}>
              <option value={0}>Outra (digitar)</option>
              {OPCOES.habilidades[grupo].map((h) => <option key={h.id} value={h.id}>{h.nome}</option>)}
            </Select>
          </Field>
          <Field label="Nível">
            <Select value={nivelHab} onChange={(e) => setNivelHab(Number(e.target.value))}>
              {NIVEIS.map((n) => <option key={n.id} value={n.id}>{n.nome}</option>)}
            </Select>
          </Field>
          <Button type="button" variant="ghost" onClick={addHabilidade}><Plus className="size-4" /> Adicionar</Button>
        </div>
        {!hab && <Input value={habExtra} onChange={(e) => setHabExtra(e.target.value)} placeholder="Qual habilidade? (ex.: Edição de vídeo)" className="sm:w-96" />}
        <Lista itens={c.Habilidades.map((h) => `${h.rotulo} · ${nomeNivel(h.IdNivel)}`)} onRemover={(i) => set("Habilidades", c.Habilidades.filter((_, j) => j !== i))} />
      </Secao>

      <Secao titulo="Idiomas">
        <div className="grid items-end gap-3 sm:grid-cols-[1fr_10rem_auto]">
          <Field label="Idioma">
            <Select value={idioma} onChange={(e) => setIdioma(Number(e.target.value))}>
              <option value={0}>Outro (digitar)</option>
              {OPCOES.idiomas.map((i) => <option key={i.id} value={i.id}>{i.nome}</option>)}
            </Select>
          </Field>
          <Field label="Nível">
            <Select value={nivelIdioma} onChange={(e) => setNivelIdioma(Number(e.target.value))}>
              {NIVEIS.map((n) => <option key={n.id} value={n.id}>{n.nome}</option>)}
            </Select>
          </Field>
          <Button type="button" variant="ghost" onClick={addIdioma}><Plus className="size-4" /> Adicionar</Button>
        </div>
        {!idioma && <Input value={idiomaExtra} onChange={(e) => setIdiomaExtra(e.target.value)} placeholder="Qual idioma?" className="sm:w-96" />}
        <Lista itens={c.Idiomas.map((i) => `${nomeIdioma(i)} · ${nomeNivel(i.IdNivel)}`)} onRemover={(i) => set("Idiomas", c.Idiomas.filter((_, j) => j !== i))} />
      </Secao>

      <Secao titulo="Cursos ligados a projetos">
        <div className="grid items-end gap-3 sm:grid-cols-[1fr_12rem_auto]">
          <Field label="Curso">
            <Input value={curso} onChange={(e) => setCurso(e.target.value)} placeholder="Ex.: Primeiros socorros" />
          </Field>
          <Field label="Projeto">
            <Select value={projetoCurso} onChange={(e) => setProjetoCurso(Number(e.target.value))}>
              {PROJETOS.map((p) => <option key={p.id} value={p.id}>{p.nome}</option>)}
            </Select>
          </Field>
          <Button
            type="button"
            variant="ghost"
            onClick={() => {
              if (!curso.trim()) return;
              set("Cursos", [...c.Cursos, { NomeCurso: curso.trim(), IdProjeto: projetoCurso }]);
              setCurso("");
            }}
          >
            <Plus className="size-4" /> Adicionar
          </Button>
        </div>
        <Lista
          itens={c.Cursos.map((x) => `${x.NomeCurso} · ${PROJETOS.find((p) => p.id === x.IdProjeto)?.nome ?? ""}`)}
          onRemover={(i) => set("Cursos", c.Cursos.filter((_, j) => j !== i))}
        />
      </Secao>
    </div>
  );
}

function Lista({ itens, onRemover }: { itens: string[]; onRemover: (i: number) => void }) {
  if (!itens.length) return <p className="text-xs text-slate-400">Nenhum item adicionado.</p>;
  return (
    <ul className="flex flex-wrap gap-2">
      {itens.map((t, i) => (
        <li key={t + i} className="flex items-center gap-1 rounded-full bg-slate-100 py-1 pl-3 pr-1 text-sm text-slate-700">
          {t}
          <button type="button" onClick={() => onRemover(i)} className="rounded-full p-1 hover:bg-slate-200" aria-label={`Remover ${t}`}>
            <Trash2 className="size-3.5" />
          </button>
        </li>
      ))}
    </ul>
  );
}

// ---------------------------------------------------------------- 6. Estudo, trabalho e redes
export function EtapaEstudoTrabalho({ c, sub }: EtapaProps) {
  const s = c.Estudo;
  const e = <K extends keyof CadastroJovem["Estudo"]>(k: K, v: CadastroJovem["Estudo"][K]) => sub("Estudo", k, v);
  const r = <K extends keyof CadastroJovem["Redes"]>(k: K, v: CadastroJovem["Redes"][K]) => sub("Redes", k, v);
  return (
    <div className="space-y-6">
      <Secao titulo="Estudo">
        <Grade>
          <Escolha label="Escolaridade" valor={s.GrauEscolaridade} onChange={(v) => e("GrauEscolaridade", v)} opcoes={OPCOES.escolaridades.map((n) => ({ id: n, nome: n }))} />
          <SimNao label="Estuda atualmente?" valor={s.EstudaAtualmente} onChange={(v) => e("EstudaAtualmente", v)} />
          {s.EstudaAtualmente === "S" && <Texto label="Onde estuda?" valor={s.NomeInstituicaoEnsino} onChange={(v) => e("NomeInstituicaoEnsino", v)} />}
          <SimNao label="Faz ou fez faculdade?" valor={s.PossuiNivelSuperior} onChange={(v) => e("PossuiNivelSuperior", v)} />
        </Grade>
        <SeSim valor={s.PossuiNivelSuperior}>
          <Grade cols={4}>
            <Texto label="Curso" valor={s.NomeCursoSuperior} onChange={(v) => e("NomeCursoSuperior", v)} />
            <Texto label="Período atual" valor={s.PeriodoAtualNivelFaculdade} onChange={(v) => e("PeriodoAtualNivelFaculdade", v)} />
            <Escolha label="Modalidade" valor={s.IdModalidade} onChange={(v) => e("IdModalidade", v)} opcoes={OPCOES.modalidades} />
            <Texto label="Previsão de formatura" valor={s.PrevisaoConclusaoCurso} onChange={(v) => e("PrevisaoConclusaoCurso", v)} />
          </Grade>
        </SeSim>
        <Grade cols={2}>
          <SimNao label="Deseja cursar faculdade?" valor={s.DesejaCursarNivelSuperior} onChange={(v) => e("DesejaCursarNivelSuperior", v)} />
          {s.DesejaCursarNivelSuperior === "S" && <Texto label="Qual curso?" valor={s.NomeCursoSuperiorDesejaCursar} onChange={(v) => e("NomeCursoSuperiorDesejaCursar", v)} />}
        </Grade>
      </Secao>

      <Secao titulo="Trabalho">
        <Grade>
          <SimNao label="Trabalha atualmente?" valor={c.Trabalho.TrabalhaAtualmente} onChange={(v) => sub("Trabalho", "TrabalhaAtualmente", v)} />
          {c.Trabalho.TrabalhaAtualmente === "S" && (
            <>
              <Texto label="Profissão" valor={c.Trabalho.Profissao} onChange={(v) => sub("Trabalho", "Profissao", v)} />
              <Texto label="Empresa" valor={c.Trabalho.NomeEmpresa} onChange={(v) => sub("Trabalho", "NomeEmpresa", v)} />
            </>
          )}
        </Grade>
      </Secao>

      <Secao titulo="Redes sociais e mídia">
        <Grade cols={4}>
          <Texto label="E-mail" type="email" valor={c.Redes.Email} onChange={(v) => r("Email", v)} />
          <Texto label="Instagram" valor={c.Redes.Instagram} onChange={(v) => r("Instagram", v)} placeholder="@usuario" />
          <Texto label="Facebook" valor={c.Redes.Facebook} onChange={(v) => r("Facebook", v)} />
          <Texto label="X (Twitter)" valor={c.Redes.Twitter} onChange={(v) => r("Twitter", v)} />
        </Grade>
        <Grade cols={4}>
          <SimNao label="Segue a FJU oficial?" valor={c.Redes.EhSeguidorOficialFJU} onChange={(v) => r("EhSeguidorOficialFJU", v)} />
          <SimNao label="Segue a FJU no YouTube?" valor={c.Redes.EhSeguidorYoutube} onChange={(v) => r("EhSeguidorYoutube", v)} />
          <SimNao label="Segue a FJU no Telegram?" valor={c.Redes.EhSeguidorTelegram} onChange={(v) => r("EhSeguidorTelegram", v)} />
          <SimNao label="Lê o blog do Bispo?" valor={c.Redes.EhLeitorBlogBM} onChange={(v) => r("EhLeitorBlogBM", v)} />
          <SimNao label="Lê o site universal.org?" valor={c.Redes.EhLeitorUniversalorg} onChange={(v) => r("EhLeitorUniversalorg", v)} />
          <SimNao label="Assina o Univer Vídeo?" valor={c.Redes.EhAssinanteUNIVER} onChange={(v) => r("EhAssinanteUNIVER", v)} />
          {c.Redes.EhAssinanteUNIVER === "S" && (
            <Escolha label="Com que frequência assiste?" valor={c.Redes.FrequenciaAssisteUNIVER} onChange={(v) => r("FrequenciaAssisteUNIVER", v)} opcoes={OPCOES.frequenciaUniver.map((n) => ({ id: n, nome: n }))} />
          )}
          <SimNao label="Tem celular com internet?" valor={c.Redes.PossuiCelularComInternet} onChange={(v) => r("PossuiCelularComInternet", v)} />
          <SimNao label="Tem computador em casa?" valor={c.Redes.PossuiComputador} onChange={(v) => r("PossuiComputador", v)} />
        </Grade>
      </Secao>
    </div>
  );
}

// ---------------------------------------------------------------- 7. Testemunho (dados sensíveis)
export function EtapaTestemunho({ c, set, sub, foto, setFoto, documento, setDocumento }: EtapaProps & {
  foto: File | null; setFoto: (f: File | null) => void; documento: File | null; setDocumento: (f: File | null) => void;
}) {
  const t = c.Testemunho;
  const s = <K extends keyof CadastroJovem["Testemunho"]>(k: K, v: CadastroJovem["Testemunho"][K]) => sub("Testemunho", k, v);
  return (
    <div className="space-y-6">
      <div className="flex gap-3 rounded-lg border border-amber-200 bg-amber-50 p-4 text-sm text-amber-900">
        <ShieldAlert className="size-5 shrink-0" />
        <p>
          <strong>Informações sensíveis.</strong> As perguntas abaixo são opcionais. Preencha só com o consentimento do jovem. Esses dados são
          protegidos pela LGPD e devem ser vistos apenas por quem cuida do acompanhamento.
        </p>
      </div>
      <Secao titulo="Superação">
        <Grade cols={2}>
          <SimNao label="Já sofreu com depressão?" valor={t.SofreuComDepressao} onChange={(v) => s("SofreuComDepressao", v)} />
          {t.SofreuComDepressao === "S" && (
            <div className="grid grid-cols-2 gap-2">
              <Texto label="Por quanto tempo?" valor={t.TempoSofreuDepressao} onChange={(v) => s("TempoSofreuDepressao", v)} />
              <Texto label="Livre há quanto tempo?" valor={t.TempoLivreDepressao} onChange={(v) => s("TempoLivreDepressao", v)} />
            </div>
          )}
          <SimNao label="Já se automutilou?" valor={t.SofreuAutomutilacao} onChange={(v) => s("SofreuAutomutilacao", v)} />
          {t.SofreuAutomutilacao === "S" && <Texto label="Por quanto tempo?" valor={t.TempoSofreuAutomutilacao} onChange={(v) => s("TempoSofreuAutomutilacao", v)} />}
          <SimNao label="Já teve algum vício?" valor={t.SofreuVicio} onChange={(v) => s("SofreuVicio", v)} />
          {t.SofreuVicio === "S" && (
            <div className="grid grid-cols-2 gap-2">
              <Texto label="Por quanto tempo?" valor={t.TempoVicio} onChange={(v) => s("TempoVicio", v)} />
              <Texto label="Livre há quanto tempo?" valor={t.TempoLivreVicios} onChange={(v) => s("TempoLivreVicios", v)} />
            </div>
          )}
          <SimNao label="Já tentou tirar a própria vida?" valor={t.TentouSuicidio} onChange={(v) => s("TentouSuicidio", v)} />
        </Grade>
        <SeSim valor={t.TentouSuicidio}>
          <Grade>
            <Numero label="Quantas vezes?" valor={t.NumeroTentativasSuicidio} onChange={(v) => s("NumeroTentativasSuicidio", v)} max={50} />
            <MesAno label="Quando (mês/ano)" valor={t.MesAnoTentativaSuicidio} onChange={(v) => s("MesAnoTentativaSuicidio", v)} />
            <Texto label="Observações" valor={t.DescricaoTentativaSuicidio} onChange={(v) => s("DescricaoTentativaSuicidio", v)} />
          </Grade>
        </SeSim>
        <AreaTexto label="Testemunho" valor={t.TextoTestemunho} onChange={(v) => s("TextoTestemunho", v)} linhas={5} ajuda="Nas palavras do jovem, como Deus mudou a vida dele." />
      </Secao>

      <Secao titulo="Arquivos e observações">
        <Grade cols={2}>
          <Arquivo label="Foto do jovem" aceita="image/jpeg,image/png,image/webp" arquivo={foto} onChange={setFoto} />
          <Arquivo label="Documento de autorização" aceita="image/*,application/pdf" arquivo={documento} onChange={setDocumento} />
        </Grade>
        <AreaTexto label="Sugestões do jovem para a FJU" valor={c.TextoSugestao} onChange={(v) => set("TextoSugestao", v)} />
      </Secao>
    </div>
  );
}

function Arquivo({ label, aceita, arquivo, onChange }: { label: string; aceita: string; arquivo: File | null; onChange: (f: File | null) => void }) {
  const [erro, setErro] = useState<string | null>(null);
  return (
    <Field label={label}>
      <div className="flex items-center gap-3">
        <input
          type="file"
          accept={aceita}
          onChange={(e) => {
            const f = e.target.files?.[0] ?? null;
            if (f && f.size > 10 * 1024 * 1024) {
              setErro("Arquivo maior que 10 MB.");
              e.target.value = "";
              onChange(null);
              return;
            }
            setErro(null);
            onChange(f);
          }}
          className="text-sm file:mr-3 file:rounded-lg file:border-0 file:bg-slate-100 file:px-3 file:py-2 file:text-sm file:font-medium hover:file:bg-slate-200"
        />
        {arquivo && <Badge tone="green">{Math.round(arquivo.size / 1024)} KB</Badge>}
      </div>
      {erro && <span className="text-xs text-red-600">{erro}</span>}
    </Field>
  );
}
