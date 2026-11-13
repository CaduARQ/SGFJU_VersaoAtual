// Modelo do formulário de cadastro de jovem (espelha NovoJovemRequest da API).

export type SN = "" | "S" | "N";

export type CadastroJovem = {
  IdIgreja: number;
  Nome: string;
  DataNascimento: string;
  Sexo: "" | "M" | "F";
  ClassificacaoJovem: string;
  IdEstadoCivil: number;
  DataPreenchimentoFormulario: string;
  NomeConjuge: string;
  ConjugeEhIURD: SN;
  DataCasamento: string;
  PossuiFilhos: SN;
  QuantidadeFilhos: number;
  PossuiTituloEleitor: SN;
  PertenceGrupoMulheresIURD: SN;
  NomeGrupoMulheresIURD: string;
  Contato: { Whatsapp: string; TelefoneFixo: string; TelefoneEmergencia: string; NomeContatoEmergencia: string };
  Endereco: { Endereco: string; Bairro: string; Cidade: string; IdTipoMoradia: number };
  Redes: {
    Email: string; Instagram: string; Facebook: string; Twitter: string;
    EhSeguidorOficialFJU: SN; EhSeguidorYoutube: SN; EhSeguidorTelegram: SN; EhAssinanteUNIVER: SN; FrequenciaAssisteUNIVER: string;
    EhLeitorBlogBM: SN; EhLeitorUniversalorg: SN; PossuiCelularComInternet: SN; PossuiComputador: SN;
  };
  Espiritual: {
    EhMembroIURD: SN; MesAnoChegadaIURD: string; ComoConheceuIURD: string;
    JaSeAfastou: SN; MotivoSeAfastou: string; MesAnoAfastamento: string; TempoAfastamento: string; TempoEstaFirme: string;
    DescricaoFamiliaresIURD: string;
    EhBatizadoAguas: SN; MesAnoBatismoAguas: string; BatismoAguasIURD: SN;
    EhBatizadoEspiritoSanto: SN; MesAnoBatismoEspiritoSanto: string; OcasiaoBatismoEspiritoSanto: string;
    DescricaoModoChegouFJU: string; MotivoEntradaFJU: string; MesAnoEntradaFJU: string;
    PossuiBiblia: SN; LeuTodaBiblia: SN; IdFrequenciaLeituraBiblia: number;
  };
  Obra: {
    EhObreiro: SN; AnosObreiro: number; MesesObreiro: number;
    EhColaborador: SN; AnosColaborador: number; MesesColaborador: number;
    EstaCursandoCPO: SN; MesInicioCPO: number; AnoInicioCPO: number;
    EhPertencenteFJU: SN;
    EhCoordenadorFJU: SN; MesesCoordenandoFJU: number; AnosCoordenandoFJU: number;
    EhLiderTribo: SN; IdTribo: number; MesesCoordenandoTribo: number; AnosCoordenandoTribo: number;
    EhLiderProjeto: SN; IdProjetoQueCoordena: number; MesesCoordenandoProjeto: number; AnosCoordenandoProjeto: number;
    PossuiCamisaProjeto: SN; NomeCamisaFJU: string; TamanhoCamisa: string;
    FoiObreiro: SN; MotivoSaiuObreiro: string; FoiPastor: SN; MotivoSaidaPastor: string;
    DesejaSerObreiro: SN; MotivoDesejaSerObreiro: string; DesejaFazerObraNoAltar: SN; PertenceAltarJovem: SN;
    PertenceIntellimen: SN; DesafiosConcluidos: SN; DesafioAtual: number; NomeParceiroIntellimen: string; TelefoneParceiroIntellimen: string;
  };
  Estudo: {
    GrauEscolaridade: string; EstudaAtualmente: SN; NomeInstituicaoEnsino: string; NomeCursoSuperior: string;
    PeriodoAtualNivelFaculdade: string; IdModalidade: number; PossuiNivelSuperior: SN; PrevisaoConclusaoCurso: string;
    DesejaCursarNivelSuperior: SN; NomeCursoSuperiorDesejaCursar: string;
  };
  Trabalho: { TrabalhaAtualmente: SN; Profissao: string; NomeEmpresa: string };
  Projeto: { IdProjeto: number; Meses: number; Anos: number; PertenceuOutroProjeto: SN; IdProjetoAnterior: number };
  Testemunho: {
    SofreuComDepressao: SN; TempoSofreuDepressao: string; TempoLivreDepressao: string;
    TentouSuicidio: SN; DescricaoTentativaSuicidio: string; MesAnoTentativaSuicidio: string; NumeroTentativasSuicidio: number;
    SofreuAutomutilacao: SN; TempoSofreuAutomutilacao: string;
    SofreuVicio: SN; TempoVicio: string; TempoLivreVicios: string;
    TextoTestemunho: string;
  };
  Idiomas: { Id: number; IdNivel: number; NomeExtra?: string }[];
  Habilidades: { IdHabilidade: number; IdNivel: number; NomeHabilidadeExtra?: string; rotulo: string }[];
  Cursos: { NomeCurso: string; IdProjeto: number }[];
  TonsDeVoz: number[];
  Departamentos: number[];
  Reunioes: number[];
  Livros: number[];
  EhPalestranteHelp: SN;
  EhAtendenteWhatsappHelp: SN;
  TextoSugestao: string;
};

/** Data de hoje no fuso do navegador (toISOString usaria UTC e viraria o dia à noite). */
const hoje = () => {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}-${String(d.getDate()).padStart(2, "0")}`;
};

export function cadastroVazio(): CadastroJovem {
  return {
    IdIgreja: 0, Nome: "", DataNascimento: "", Sexo: "", ClassificacaoJovem: "N", IdEstadoCivil: 0,
    DataPreenchimentoFormulario: hoje(),
    NomeConjuge: "", ConjugeEhIURD: "", DataCasamento: "", PossuiFilhos: "", QuantidadeFilhos: 0, PossuiTituloEleitor: "",
    PertenceGrupoMulheresIURD: "", NomeGrupoMulheresIURD: "",
    Contato: { Whatsapp: "", TelefoneFixo: "", TelefoneEmergencia: "", NomeContatoEmergencia: "" },
    Endereco: { Endereco: "", Bairro: "", Cidade: "", IdTipoMoradia: 0 },
    Redes: {
      Email: "", Instagram: "", Facebook: "", Twitter: "", EhSeguidorOficialFJU: "", EhSeguidorYoutube: "", EhSeguidorTelegram: "",
      EhAssinanteUNIVER: "", FrequenciaAssisteUNIVER: "", EhLeitorBlogBM: "", EhLeitorUniversalorg: "", PossuiCelularComInternet: "", PossuiComputador: "",
    },
    Espiritual: {
      EhMembroIURD: "", MesAnoChegadaIURD: "", ComoConheceuIURD: "", JaSeAfastou: "", MotivoSeAfastou: "", MesAnoAfastamento: "",
      TempoAfastamento: "", TempoEstaFirme: "", DescricaoFamiliaresIURD: "", EhBatizadoAguas: "", MesAnoBatismoAguas: "", BatismoAguasIURD: "",
      EhBatizadoEspiritoSanto: "", MesAnoBatismoEspiritoSanto: "", OcasiaoBatismoEspiritoSanto: "", DescricaoModoChegouFJU: "",
      MotivoEntradaFJU: "", MesAnoEntradaFJU: "", PossuiBiblia: "", LeuTodaBiblia: "", IdFrequenciaLeituraBiblia: 0,
    },
    Obra: {
      EhObreiro: "", AnosObreiro: 0, MesesObreiro: 0, EhColaborador: "", AnosColaborador: 0, MesesColaborador: 0,
      EstaCursandoCPO: "", MesInicioCPO: 0, AnoInicioCPO: 0, EhPertencenteFJU: "", EhCoordenadorFJU: "", MesesCoordenandoFJU: 0, AnosCoordenandoFJU: 0,
      EhLiderTribo: "", IdTribo: 0, MesesCoordenandoTribo: 0, AnosCoordenandoTribo: 0,
      EhLiderProjeto: "", IdProjetoQueCoordena: 0, MesesCoordenandoProjeto: 0, AnosCoordenandoProjeto: 0,
      PossuiCamisaProjeto: "", NomeCamisaFJU: "", TamanhoCamisa: "", FoiObreiro: "", MotivoSaiuObreiro: "", FoiPastor: "", MotivoSaidaPastor: "",
      DesejaSerObreiro: "", MotivoDesejaSerObreiro: "", DesejaFazerObraNoAltar: "", PertenceAltarJovem: "",
      PertenceIntellimen: "", DesafiosConcluidos: "", DesafioAtual: 0, NomeParceiroIntellimen: "", TelefoneParceiroIntellimen: "",
    },
    Estudo: {
      GrauEscolaridade: "", EstudaAtualmente: "", NomeInstituicaoEnsino: "", NomeCursoSuperior: "", PeriodoAtualNivelFaculdade: "",
      IdModalidade: 0, PossuiNivelSuperior: "", PrevisaoConclusaoCurso: "", DesejaCursarNivelSuperior: "", NomeCursoSuperiorDesejaCursar: "",
    },
    Trabalho: { TrabalhaAtualmente: "", Profissao: "", NomeEmpresa: "" },
    Projeto: { IdProjeto: 0, Meses: 0, Anos: 0, PertenceuOutroProjeto: "", IdProjetoAnterior: 0 },
    Testemunho: {
      SofreuComDepressao: "", TempoSofreuDepressao: "", TempoLivreDepressao: "", TentouSuicidio: "", DescricaoTentativaSuicidio: "",
      MesAnoTentativaSuicidio: "", NumeroTentativasSuicidio: 0, SofreuAutomutilacao: "", TempoSofreuAutomutilacao: "",
      SofreuVicio: "", TempoVicio: "", TempoLivreVicios: "", TextoTestemunho: "",
    },
    Idiomas: [], Habilidades: [], Cursos: [], TonsDeVoz: [], Departamentos: [], Reunioes: [], Livros: [],
    EhPalestranteHelp: "", EhAtendenteWhatsappHelp: "", TextoSugestao: "",
  };
}

/** Converte o formulário no JSON da API (datas vazias viram null; o rótulo das habilidades sai). */
export function paraApi(c: CadastroJovem) {
  const data = (v: string) => (v ? v : null);
  return {
    ...c,
    DataNascimento: data(c.DataNascimento),
    DataCasamento: data(c.DataCasamento),
    DataPreenchimentoFormulario: data(c.DataPreenchimentoFormulario),
    IdEstadoCivil: c.IdEstadoCivil || null,
    Habilidades: c.Habilidades.map(({ IdHabilidade, IdNivel, NomeHabilidadeExtra }) => ({ IdHabilidade, IdNivel, NomeHabilidadeExtra })),
  };
}

/** Erros que impedem avançar na primeira etapa (os mesmos que a API valida). */
export function errosIdentificacao(c: CadastroJovem): string[] {
  const e: string[] = [];
  if (!c.IdIgreja) e.push("Selecione a igreja.");
  if (!c.Nome.trim()) e.push("Informe o nome completo.");
  if (!c.DataNascimento) e.push("Informe a data de nascimento.");
  else if (c.DataNascimento > hoje()) e.push("A data de nascimento não pode ser no futuro.");
  if (!c.Sexo) e.push("Informe o sexo.");
  return e;
}

/** Máscara simples de telefone brasileiro: (11) 91234-5678 */
export function mascaraTelefone(v: string) {
  const d = v.replace(/\D/g, "").slice(0, 11);
  if (d.length <= 2) return d ? `(${d}` : "";
  if (d.length <= 6) return `(${d.slice(0, 2)}) ${d.slice(2)}`;
  if (d.length <= 10) return `(${d.slice(0, 2)}) ${d.slice(2, 6)}-${d.slice(6)}`;
  return `(${d.slice(0, 2)}) ${d.slice(2, 7)}-${d.slice(7)}`;
}

/** Máscara mês/ano: 03/2019 */
export function mascaraMesAno(v: string) {
  const d = v.replace(/\D/g, "").slice(0, 6);
  return d.length <= 2 ? d : `${d.slice(0, 2)}/${d.slice(2)}`;
}
