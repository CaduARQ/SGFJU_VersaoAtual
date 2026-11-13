// Tipos espelhando os DTOs da API .NET (SGFJU.ServicesLayer.DTO).
// A API mantém PascalCase, igual ao sistema antigo.

export type UsuarioLogado = {
  Id: number;
  Nome: string;
  Login: string;
  CodigoPerfil: number;
  Perfil: string;
  IdEstado: number;
  Estado: string | null;
  SiglaEstado: string | null;
  IdBloco: number;
  Bloco: string | null;
  IdRegiao: number;
  Regiao: string | null;
  Foto: string | null;
  EhAdm: boolean;
  PaginaInicial: string;
};

export type TotaisGerais = {
  IdEstado: number;
  NomeEstado: string;
  QuantidadeTotalJovens: number;
  QuantidadeTotalHomens: number;
  QuantidadeTotalMulheres: number;
  QuantidadeTotalBatizadosAguas: number;
  QuantidadeTotalBatizadosAguasPercent?: string;
  QuantidadeTotalEspiritoSanto: number;
  QuantidadeTotalEspiritoSantoPercent?: string;
  QuantidadeJovensAltarJovem: number;
  QuantidadeTotalObreiros: number;
  QuantidadeTotalColaboradores: number;
  QuantidadeTotalCPO: number;
  QuantidadeTotalUniversitarios: number;
  QuantidadeTotalMidia: number;
  QuantidadeTotalHelp: number;
  QuantidadeTotalSecretarias: number;
  QuantidadeTotalCultura: number;
  QuantidadeTotalEsporte: number;
  QuantidadeTotalAtalaia: number;
  QuantidadeTotalArcanjos: number;
  QuantidadeTotalUniforca: number;
  QuantidadeTotalJovensAtivos: number;
  QuantidadeTotalJovensInativos: number;
  QuantidadeTotalJovensIniciantes: number;
  QuantidadeTotalAVJovensAcompanhados: number;
  QuantidadeTotalAVJovensSemAcompanhamento: number;
};

export type TotaisBloco = Omit<TotaisGerais, "NomeEstado" | "QuantidadeTotalBatizadosAguasPercent" | "QuantidadeTotalEspiritoSantoPercent"> & {
  IdBloco: number;
  NomeBloco: string;
};

export type Bloco = { idBloco: number; NomeBloco: string; IdEstadoBloco: number; EstadoBloco: string };

export type Regiao = {
  IdEstado: number;
  NomeEstado: string | null;
  idBloco: number;
  NomeBloco: string | null;
  IdRegiao: number;
  NomeRegiao: string;
};

export type Igreja = {
  IdEstado: number;
  NomeEstado: string | null;
  IdBlocoJovem: number;
  NomeBlocoJovem: string | null;
  IdRegiao: number;
  NomeRegiaoJovem: string | null;
  IdIgreja: number;
  NomeIgreja: string;
};

export type JovemResumo = {
  IdJovem: number;
  IdX: string | null;
  NomeJovem: string;
  DataNascimento: string | null;
  IdEstado: number;
  NomeEstado: string | null;
  SiglaEstado: string | null;
  IdBlocoJovem: number;
  NomeBlocoJovem: string | null;
  IdRegiaoJovem: number;
  NomeRegiaoJovem: string | null;
  IdIgreja: number;
  NomeIgrejaJovem: string | null;
  Whatsapp: string | null;
  WhatsappSemFormatacao: string | null;
  NomeArquivoFotoFormatado: string | null;
  EstadoCivil: string | null;
  ProjetoJovemPertence: string | null;
  EhBatizadoAguas: string | null;
  EhBatizadoEspiritoSanto: string | null;
  EstaSendoAcompanhadoAV: boolean;
  NomeObreiroAcompanha: string | null;
  ClassificacaoJovem: string | null;
  FichaEstaExpirada: boolean;
};

export type ParametroPesquisaJovens = {
  NomeJovem?: string;
  IdEstado: number;
  IdBlocoJovem: number;
  IdRegiaoJovem: number;
  IdIgreja: number;
  EhParaListarFichasExpiradas?: "S" | "N";
};

export type JovemDetalhe = {
  Id: number;
  Nome: string;
  DataNascimento: string | null;
  DataCadastro: string | null;
  DataUltimaAtualizacao: string | null;
  DataIngressoObra: string | null;
  Sexo: string;
  ClassificacaoJovem: string;
  FichaEstaExpirada: boolean;
  NomeArquivoFotoFormatado: string | null;
  DescricaoEstadoCivilJovem: string | null;
  NomeConjuge: string | null;
  TipoJovem: string | null;
  EhPastor: boolean;
  EnderecoJovem?: { DescricaoEndereco: string | null; Cidade: string | null; Bairro: string | null; NomeEstado: string | null; DescricaoTipoDeMoradia: string | null } | null;
  ContatoJovem?: { Whatsapp: string | null; TelefoneFixo: string | null; TelefoneEmergencia: string | null; NomeContatoEmergencia: string | null } | null;
  RedeSocialJovem?: { Instagram: string | null; Facebook: string | null; Email: string | null } | null;
  DadosEspirituaisJovem?: {
    EhMembroIURD: string;
    MesAnoChegadaIURD: string | null;
    EhBatizadoAguas: string;
    MesAnoBatismoAguas: string | null;
    EhBatizadoEspiritoSanto: string;
    MesAnoBatismoEspiritoSanto: string | null;
    MesAnoEntradaFJU: string | null;
    ComoConheceuIURD: string | null;
  } | null;
  SituacaoJovemIURDFJU?: { EhObreiro: string; EhColaborador: string; EstaCursandoCPO: string; EhCoordenadorFJU: string; TamanhoCamisa: string | null } | null;
  DadosProfissionaisJovem?: { TrabalhaAtualmente: string; Profissao: string | null; NomeEmpresa: string | null } | null;
  DadosEducacionaisJovem?: { EstudaAtualmente: string; GrauEscolaridade: string | null; NomeInstituicaoEnsino: string | null; NomeCursoSuperior: string | null } | null;
  IgrejaAQualJovemPertence?: Igreja | null;
};

export type Usuario = {
  IdUsuario: number;
  NomeUsuario: string;
  Login: string;
  NomePerfil: string;
  IdPerfilUsuario: number;
  NomeBlocoUsuario: string | null;
  NomeRegiaoUsuario: string | null;
  NomeEstadoUsuario: string | null;
  SiglaEstadoUsuario: string | null;
};

export type RespostaRequisicao = { RequisicaoBemSucedida: boolean; MensagemRespostaRequisicao: string | null };
