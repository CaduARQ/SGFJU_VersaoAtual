using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;

namespace SGFJU.Domain.UI
{
    public partial class RegistraJovem : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtNome"])) {
                Salvar();
            }
        }

        protected void Salvar() {
            try {
                var facade = new FacadeJovemImpl();
                var siglaEstado = ((Usuario)Session["UsuarioLogado"] != null)?((Usuario)Session["UsuarioLogado"]).EstadoUsuario.SiglaEstado:"";                

                var contatoJovem = new Contato {
                    Whatsapp = Request.Form["txtWhatsapp"],
                    TelefoneFixo = Request.Form["txtTelefoneFixo"],
                    TelefoneEmergencia = Request.Form["txtTelefoneEmergencia"],
                    NomeContatoEmergencia = Request.Form["txtContatoEmergencia"]
                };
                var enderecoJovem = new Endereco {
                    DescricaoEndereco = Request.Form["txtEndereco"],
                    Bairro = Request.Form["txtBairro"],
                    Cidade = Request.Form["txtCidade"],
                    TipoDeMoradia = (!string.IsNullOrEmpty(Request.Form["cboTipoMoradia"]))? 
                                        new TipoMoradia { Code = int.Parse(Request.Form["cboTipoMoradia"]) } : 
                                        null
                };
                var redesSociaisJovem = new RedeSocial {
                    Email = Request.Form["txtEmail"],
                    Instagram = Request.Form["txtInstagram"],
                    Facebook = Request.Form["txtFacebook"],
                    Twitter = Request.Form["txtTwitter"],
                    EhLeitorBlogBM = (string.IsNullOrEmpty(Request.Form["rbLeDiariamenteBlogBM"])) ? 
                                        'N' : 
                                        char.Parse(Request.Form["rbLeDiariamenteBlogBM"]),
                    EhAssinanteUNIVER = (string.IsNullOrEmpty(Request.Form["rbAssinanteUNIVERVIDEO"])) ? 
                                            'N' : 
                                            char.Parse(Request.Form["rbAssinanteUNIVERVIDEO"]),
                    EhLeitorUniversalorg = (string.IsNullOrEmpty(Request.Form["rbLeitorSiteUniversalOrg"])) ? 
                                                'N' : 
                                                char.Parse(Request.Form["rbLeitorSiteUniversalOrg"]),
                    EhSeguidorOficialFJU = (string.IsNullOrEmpty(Request.Form["rbEhSeguidorOFICIALFJU"]))? 
                                                'N':
                                                char.Parse(Request.Form["rbEhSeguidorOFICIALFJU"]),
                    EhSeguidorTelegram = (string.IsNullOrEmpty(Request.Form["rbSegueFJUTelegram"])) ? 
                                            'N' : 
                                            char.Parse(Request.Form["rbSegueFJUTelegram"]),
                    EhSeguidorYoutube = (string.IsNullOrEmpty(Request.Form["rbEhSeguidorFJUYouTube"])) ? 
                                            'N' : 
                                            char.Parse(Request.Form["rbEhSeguidorFJUYouTube"]),
                    PossuiCelularComInternet = (string.IsNullOrEmpty(Request.Form["rbTemCelularComInternet"])) ? 
                                                    'N' : 
                                                    char.Parse(Request.Form["rbTemCelularComInternet"]),
                    FrequenciaAssisteUNIVER = Request.Form["txtFrequenciaAssisteUniver"],
                    PossuiComputador = (string.IsNullOrEmpty(Request.Form["rbTemComputadorEmCasa"])) ? 
                                        'N' : 
                                        char.Parse(Request.Form["rbTemComputadorEmCasa"])
                };

                var dadosProfissionaisJovem = new DadosProfissionais {
                    NomeEmpresa = Request.Form["txtEmpresa"],
                    TrabalhaAtualmente = (string.IsNullOrEmpty(Request.Form["rbTrabalha"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbTrabalha"]),
                    Profissao = Request.Form["txtProfissao"]
                };

                var anoChegadaIURD = (!string.IsNullOrEmpty(Request.Form["txtMesAnoChegadaIURD"])) ?
                                        (Regex.Match(Request.Form["txtMesAnoChegadaIURD"], @"/[0-9]{4}").Success) ?
                                           int.Parse(Regex.Match(Request.Form["txtMesAnoChegadaIURD"], @"/[0-9]{4}").Value.Replace("/", ""))
                                           : 0
                                        : 0;
                var mesChegadaIURD = (!string.IsNullOrEmpty(Request.Form["txtMesAnoChegadaIURD"])) ?
                                        (Regex.Match(Request.Form["txtMesAnoChegadaIURD"], @"[0-9]{1,2}/").Success) ?
                                           int.Parse(Regex.Match(Request.Form["txtMesAnoChegadaIURD"], @"[0-9]{1,2}/").Value.Replace("/", ""))
                                           : 0
                                        : 0;
                var dadosEspirituais = new DadosEspirituais {
                    EhMembroIURD = (string.IsNullOrEmpty(Request.Form["rbEhMembroIURD"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbEhMembroIURD"]),
                    MesAnoChegadaIURD = Request.Form["txtMesAnoChegadaIURD"],
                    AnoChegadaiurd = anoChegadaIURD,
                    MesChegadaiurd = anoChegadaIURD,
                    ComoConheceuIURD = Request.Form["txtComoConheceuIURD"],
                    JaSeAfastou = (string.IsNullOrEmpty(Request.Form["rbJaSeAfastou"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbJaSeAfastou"]),
                    MotivoSeAfastou = Request.Form["txctMotivoAfastamento"],
                    TempoEstaFirme = Request.Form["txtDesdeQuandoFirme"],
                    TempoAfastamento = Request.Form["txtPorQuantoTempoSeAfastou"],                    
                    MesAnoAfastamento = Request.Form["txtMesAnoAfastou"],

                    BatismoAguasIURD = (string.IsNullOrEmpty(Request.Form["rbBatismoAguasNaIURD"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbBatismoAguasNaIURD"]),
                    EhBatizadoAguas = (string.IsNullOrEmpty(Request.Form["rbBatizadoAguas"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbBatizadoAguas"]),
                    MesAnoBatismoAguas = Request.Form["txtQuandoSeBatizouAguas"],

                    EhBatizadoEspiritoSanto = (string.IsNullOrEmpty(Request.Form["rbBatizadoEspiritoSanto"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbBatizadoEspiritoSanto"]),
                    MesAnoBatismoEspiritoSanto = Request.Form["txtQuandoSeBatizadoES"],
                    OcasiaoBatismoEspiritoSanto = Request.Form["txtOndeBatismoEspiritoSanto"],

                    DescricaoFamiliaresIURD = Request.Form["txtFamiliaresIURD"],
                    DescricaoModoChegouFJU = Request.Form["txtComoConheceuFJU"],
                    MotivoEntradaFJU = Request.Form["txtMotivoEntrouFJU"],
                    MesAnoEntradaFJU = Request.Form["txtQuandoEntrouFJU"],
                    FrequenciaLeituraBiblia = (string.IsNullOrEmpty(Request.Form["cboFrequenciaLeituraBiblia"])) ? null : new FrequenciaLeitura { Code = int.Parse(Request.Form["cboFrequenciaLeituraBiblia"]) },
                    LeuTodaBiblia = (string.IsNullOrEmpty(Request.Form["rbJaLeuBibliaToda"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbJaLeuBibliaToda"]),
                    PossuiBiblia = (string.IsNullOrEmpty(Request.Form["rbTemBiblia"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbTemBiblia"]),
                };

                var dadosEducacionais = new DadosEducacionais {
                    GrauEscolaridade = Request.Form["escolaridade"],
                    EstudaAtualmente = (string.IsNullOrEmpty(Request.Form["rbEstuda"])) ?
                                        'N' :
                                        char.Parse(Request.Form["rbEstuda"]),
                    NomeInstituicaoEnsino = Request.Form["txtInstituicaoOndeEstuda"],
                    NomeCursoSuperior = Request.Form["txtNomeCursoFaculdadeJovem"],
                    DesejaCursarNivelSuperior = (string.IsNullOrEmpty(Request.Form["rbDesejaCursarNivelSuperior"])) ?
                                                'N' :
                                                char.Parse(Request.Form["rbDesejaCursarNivelSuperior"]),
                    NomeCursoSuperiorDesejaCursar = Request.Form["txtNomeCursoDesejaCursar"],
                    ModalidadeCursadaEnsinoSuperior = (! string.IsNullOrEmpty(Request.Form["rbModalidadeNivelSuperior"]))?
                                                      new ModalidadeEnsinoSuperior { Code = int.Parse(Request.Form["rbModalidadeNivelSuperior"]) } :
                                                      null,
                    PeriodoAtualNivelFaculdade = Request.Form["txtPeriodoCursando"],
                    PossuiNivelSuperior = (string.IsNullOrEmpty(Request.Form["rbJaSeFormou"])) ?
                                             'N' :
                                             char.Parse(Request.Form["rbJaSeFormou"]),
                    PrevisaoConclusaoCurso = Request.Form["txtPrevisaoFormatura"]
                };


                var dadosSituacaoIURD_FJU = new SituacaoIURDFJU {
                    EhObreiro = (string.IsNullOrEmpty(Request.Form["chkEhObreiro"])) ?
                                'N' :
                                char.Parse(Request.Form["chkEhObreiro"]),
                    AnosObreiro = (!string.IsNullOrEmpty(Request.Form["txtAnosEhObreiro"])) ? int.Parse(Request.Form["txtAnosEhObreiro"]) : 0,
                    MesesObreiro = (!string.IsNullOrEmpty(Request.Form["txtMesesEhObreiro"])) ? int.Parse(Request.Form["txtMesesEhObreiro"]) : 0,
                    EhColaborador = (string.IsNullOrEmpty(Request.Form["chkEhColaborador"])) ?
                                    'N' :
                                    char.Parse(Request.Form["chkEhColaborador"]),
                    MesesColaborador = (!string.IsNullOrEmpty(Request.Form["txtMesesEhColaborador"])) ? int.Parse(Request.Form["txtMesesEhColaborador"]) : 0,
                    AnosColaborador = (!string.IsNullOrEmpty(Request.Form["txtAnosEhColaborador"])) ? int.Parse(Request.Form["txtAnosEhColaborador"]) : 0,
                    MesAnoInicioCPO = Request.Form["txtMesesInicioCPO"] + "#" + Request.Form["txtAnosInicioCPO"],
                    EstaCursandoCPO = (string.IsNullOrEmpty(Request.Form["chkCursandoCPO"])) ?
                                         'N' :
                                         char.Parse(Request.Form["chkCursandoCPO"]),

                    EhPertencenteFJU = (string.IsNullOrEmpty(Request.Form["chkMembroFJU"])) ?
                                          'N' :
                                          char.Parse(Request.Form["chkMembroFJU"]),
                    EhCoordenadorFJU = (string.IsNullOrEmpty(Request.Form["chkEhCoordenadorFJU"])) ?
                                          'N' :
                                          char.Parse(Request.Form["chkEhCoordenadorFJU"]),
                    MesAnoCoordenandoFJU = Request.Form["txtMesesInicioCoordenacaoFJU"] + "#" + Request.Form["txtAnosInicioCoordenacaoFJU"],
                    MesesCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtMesesInicioCoordenacaoFJU"])) ? int.Parse(Request.Form["txtMesesInicioCoordenacaoFJU"]) : 0,
                    AnosCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtAnosInicioCoordenacaoFJU"])) ? int.Parse(Request.Form["txtAnosInicioCoordenacaoFJU"]) : 0,

                    EhLiderTribo = (string.IsNullOrEmpty(Request.Form["chkLiderTribo"])) ?
                                      'N' :
                                      char.Parse(Request.Form["chkLiderTribo"]),
                    TriboQueLidera = (!string.IsNullOrEmpty(Request.Form["cboTribo"])) ?
                                        new Tribo { Code = int.Parse(Request.Form["cboTribo"]) } : null,
                    PeriodoCoordenandoTribo = Request.Form["txtMesesInicioCoordenacaoTribo"] + "#" + Request.Form["txtAnosInicioCoordenacaoTribo"],
                    MesesCoordenandoTribo = (!string.IsNullOrEmpty(Request.Form["txtMesesInicioCoordenacaoTribo"])) ? int.Parse(Request.Form["txtMesesInicioCoordenacaoTribo"]) : 0,
                    AnosCoordenandoTribo = (!string.IsNullOrEmpty(Request.Form["txtAnosInicioCoordenacaoTribo"])) ? int.Parse(Request.Form["txtAnosInicioCoordenacaoTribo"]) : 0,

                    EhLiderProjeto = (string.IsNullOrEmpty(Request.Form["chkLiderProjeto"])) ?
                                        'N' :
                                        char.Parse(Request.Form["chkLiderProjeto"]),
                    ProjetoQueCoordena = (!string.IsNullOrEmpty(Request.Form["cboProjetoFJU"])) ? new Projeto { Code = int.Parse(Request.Form["cboProjetoFJU"]) } : null,
                    PeriodoCoordenandoProjeto = Request.Form["txtMesesInicioCoordenacaoProjeto"] + "#" + Request.Form["txtAnosInicioCoordenacaoProjeto"],
                    MesesCoordenandoProjeto = (!string.IsNullOrEmpty(Request.Form["txtMesesInicioCoordenacaoProjeto"])) ? int.Parse(Request.Form["txtMesesInicioCoordenacaoProjeto"]) : 0,
                    AnosCoordenandoProjeto = (!string.IsNullOrEmpty(Request.Form["txtAnosInicioCoordenacaoProjeto"])) ? int.Parse(Request.Form["txtAnosInicioCoordenacaoProjeto"]) : 0,

                    PossuiCamisaProjeto = (string.IsNullOrEmpty(Request.Form["rbTemCamisaFJU"])) ?
                                          'N' :
                                          char.Parse(Request.Form["rbTemCamisaFJU"]),
                    NomeCamisaFJU = Request.Form["cboCamisasFJU"],
                    TamanhoCamisa = Request.Form["cboTamanhoCamisaFJU"],
                    FoiObreiro = (string.IsNullOrEmpty(Request.Form["rbJaFoiObreiroAntes"])) ?
                                'N' :
                                char.Parse(Request.Form["rbJaFoiObreiroAntes"]),
                    MotivoSaiuObreiro = Request.Form["txtMotivoSaidaObreiro"],
                    FoiPastor = (string.IsNullOrEmpty(Request.Form["rbJaFoiPastorEsposaAntes"])) ?
                                'N' :
                                char.Parse(Request.Form["rbJaFoiPastorEsposaAntes"]),
                    MotivoSaidaPastor = Request.Form["txtMotivoSaidaPastorEsposa"],
                    DesejaSerObreiro = (string.IsNullOrEmpty(Request.Form["rbDesejaSerObreiro"])) ?
                                          'N' :
                                          char.Parse(Request.Form["rbDesejaSerObreiro"]),
                    MotivoDesejaSerObreiro = Request.Form["txtMotivoDesejaSErObreiro"],
                    DesejaFazerObraNoAltar = (string.IsNullOrEmpty(Request.Form["rbDesejaFazerObraAltar"])) ?
                                                'N' :
                                                char.Parse(Request.Form["rbDesejaFazerObraAltar"]),
                    PertenceAltarJovem = (string.IsNullOrEmpty(Request.Form["rbEstaNoAltarJovem"])) ?
                                          'N' :
                                          char.Parse(Request.Form["rbEstaNoAltarJovem"]),
                    PertenceIntellimen = (string.IsNullOrEmpty(Request.Form["rbFazParteIntellimen"])) ?
                                          'N' :
                                          char.Parse(Request.Form["rbFazParteIntellimen"]),
                    DesafiosConcluidos = (string.IsNullOrEmpty(Request.Form["rbCompletouDesafios"])) ?
                                          'N' :
                                          char.Parse(Request.Form["rbCompletouDesafios"]),
                    DesafioAtual = (!string.IsNullOrEmpty(Request.Form["txtNumeroDesafioIntellimen"]))?int.Parse(Request.Form["txtNumeroDesafioIntellimen"]):0,
                    NomeParceiroIntellimen = Request.Form["txtNomeParceiroIntellimen"],
                    TelefoneParceiroIntellimen = Request.Form["txtTelefoneParceiroIntellimen"]
                };                

                var igrejaJovem = new Igreja { Id = int.Parse(Request.Form["cboIgreja"]) };
                var novoJovem = new Jovem {
                    Nome = Request.Form["txtNome"],
                    DataNascimento = (! string.IsNullOrEmpty(Request.Form["txtDataNascimento"])) ? DateTime.Parse(Request.Form["txtDataNascimento"]) : DateTime.Parse("01/01/1990"),
                    DataCadastro = DateTime.Now,
                    ConjugeEhIURD = (string.IsNullOrEmpty(Request.Form["rbConjugeEhIURD"])) ? 'N' : char.Parse(Request.Form["rbConjugeEhIURD"]),
                    NomeConjuge = Request.Form["txtNomeconjuge"],
                    DataCasamento = (!string.IsNullOrEmpty(Request.Form["txtDataCasamento"])) ? DateTime.Parse(Request.Form["txtDataCasamento"]) : new Nullable<DateTime>(),
                    DataPreenchimentoFormulario = (! string.IsNullOrEmpty(Request.Form["txtDataPreenchimentoFormulario"])) ? DateTime.Parse(Request.Form["txtDataPreenchimentoFormulario"]) : DateTime.Parse("01/01/1990"),
                    PossuiTituloEleitor = (string.IsNullOrEmpty(Request.Form["rbPossuiTituloeleitor"])) ? 'N' :
                                          char.Parse(Request.Form["rbPossuiTituloeleitor"]),
                    PossuiFilhos = (string.IsNullOrEmpty(Request.Form["rbPossuiFilhos"])) ? 'N' : char.Parse(Request.Form["rbPossuiFilhos"]),
                    QuantidadeFilhos = (!string.IsNullOrEmpty(Request.Form["txtQtdFilhos"])) ? int.Parse(Request.Form["txtQtdFilhos"]) : 0,
                    NomeArquivoFoto = FileUpload1.FileName,
                    NomeArquivoAutorizacao = FileUploadDocumentoJovem.FileName,
                    ArquivoAutorizacaoOk = (FileUploadDocumentoJovem.HasFiles)?'S':'N',
                    SiglaEstadoJovem = siglaEstado,
                    TextoSugestao = Request.Form["txtSugestao"],
                    Sexo = (string.IsNullOrEmpty(Request.Form["cboSexo"])) ? 'N' : char.Parse(Request.Form["cboSexo"]),
                    ClassificacaoJovem = (string.IsNullOrEmpty(Request.Form["cboClassificacaoJovem"])) ? char.Parse("SC") : char.Parse(Request.Form["cboClassificacaoJovem"]),
                    ContatoJovem = contatoJovem,
                    EnderecoJovem = enderecoJovem,
                    RedeSocialJovem = redesSociaisJovem,
                    DadosProfissionaisJovem = dadosProfissionaisJovem,
                    DadosEspirituaisJovem = dadosEspirituais,
                    DadosEducacionaisJovem = dadosEducacionais,
                    SituacaoJovemIURDFJU = dadosSituacaoIURD_FJU,
                    PertenceGrupoMulheresIURD = (string.IsNullOrEmpty(Request.Form["rbFazParteGrupoMulheresUniversal"])) ? 'N' : char.Parse(Request.Form["rbFazParteGrupoMulheresUniversal"]),
                    NomeGrupoMulheresIURD = Request.Form["txtNomeGrupoMulheresUniversal"],
                    EstadoCivilJovem = (!string.IsNullOrEmpty(Request.Form["cboTipoEstadoCivil"])) ? new TipoEstadoCivil { Code = int.Parse(Request.Form["cboTipoEstadoCivil"]) } : null,
                    IgrejaAQualJovemPertence = igrejaJovem,
                    //DataAutorizacaoCompraCamisa = (!string.IsNullOrEmpty(Request.Form["txtDataAutorizacaoCompraCamisa"])) ? DateTime.Parse(Request.Form["txtDataAutorizacaoCompraCamisa"]) : new Nullable<DateTime>(),
                    //NomeAutorizadorCompraCamisa = Request.Form["txtNomeAutorizadorCompraCamisa"],
                    //CodigoAutorizacaoCompraCamisa = (!string.IsNullOrEmpty(Request.Form["rbOrigemCompraCamisa"]) && Request.Form["rbOrigemCompraCamisa"] == "A")? 
                    //                                   Request.Form["txtCodigoAutorizacaoCompraCamisa"]:"",
                    //OrigemCompraCamisa = Request.Form["rbOrigemCompraCamisa"]
                };

                var testemunhoJovem = new Testemunho {
                    SofreuComDepressao = (string.IsNullOrEmpty(Request.Form["rbJaSofreuDepressao"])) ? 'N' : char.Parse(Request.Form["rbJaSofreuDepressao"]),
                    TempoSofreuDepressao = Request.Form["txtTempoSofreuDepressao"],
                    TempoLivreDepressao = Request.Form["txtTempoLivreDepressao"],

                    TentouSuicidio = (string.IsNullOrEmpty(Request.Form["rbJaTentouSuicidio"])) ? 'N' : char.Parse(Request.Form["rbJaTentouSuicidio"]),
                    DescricaoTentativaSuicidio = Request.Form["txtDescricaoTentativaSuicidio"],
                    MesAnoTentativaSuicidio = Request.Form["txtQuandoTentouSuicidio"],
                    NumeroTentativasSuicidio = (!string.IsNullOrEmpty(Request.Form["txtNumeroTentativasSuicidio"])) ? int.Parse(Request.Form["txtNumeroTentativasSuicidio"]) : 0,
                    
                    SofreuAutomutilacao = (string.IsNullOrEmpty(Request.Form["rbJaSofreuAutomutilacao"])) ? 'N' : char.Parse(Request.Form["rbJaSofreuAutomutilacao"]),
                    TempoSofreuAutomutilacao = Request.Form["txtTempoSofreuAutomutilacao"],
                    SofreuVicio = (string.IsNullOrEmpty(Request.Form["rbJaTeveVicio"])) ? 'N' : char.Parse(Request.Form["rbJaTeveVicio"]),                    
                    TempoLivreVicios = Request.Form["txtTempoLivreVicios"],
                    TempoVicio = Request.Form["txtTempoVicio"],
                    TextoTestemunho = Request.Form["txtTestemunho"],
                    JovemTestemunho = novoJovem
                };

                if (Session["cursosAdicionados"] != null) {
                    var cursosAdicionaisJovem = 
                        (Session["cursosAdicionados"] as IList<CursoRelacionadoProjeto>);
                    if (cursosAdicionaisJovem.Count > 0) {
                        novoJovem.AddCursosRelacionados(cursosAdicionaisJovem);
                    }
                }                

                if(existeDepartamentoParaAssociar())
                    novoJovem.addDepartamentosProjetoJovemFazParte(retornaDepartamentosSelecionados());

                var reunioesAssistidasPeloJovem = RetornaReunioesQueOJovemAssiste();
                if (reunioesAssistidasPeloJovem.Count > 0)
                    novoJovem.addReunioesFJUAssistidaPeloJovem(reunioesAssistidasPeloJovem);

                var livrosLidosPeloJovem = RetornaLivrosLidosPeloJovem();
                if (livrosLidosPeloJovem != null && livrosLidosPeloJovem.Count > 0)
                    novoJovem.addLivrosLidoPeloJovem(livrosLidosPeloJovem);

                var idiomasFaladoPeloJovem = retornaIdiomasFaladosPeloJovem();
                if (idiomasFaladoPeloJovem != null) { 
                    if (idiomasFaladoPeloJovem.Count() > 0) {
                        foreach (var idiomaJovem in idiomasFaladoPeloJovem) {
                            idiomaJovem.Jovem = novoJovem;
                        }
                    }
                }

                var habilidadesSelecionadasParaOJovem = (Session["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>);
                List<JovemHabilidadeProjeto> habilidadesAdicionadas = null;
                if (habilidadesSelecionadasParaOJovem != null && habilidadesSelecionadasParaOJovem.Count > 0) {
                    if (existeTonDeVozParaAdicionar())
                        adicionarHabilidadesTonDeVoz(ref habilidadesSelecionadasParaOJovem);
                    habilidadesAdicionadas = 
                        habilidadesSelecionadasParaOJovem.Select(h => new JovemHabilidadeProjeto { 
                            Habilidade = new HabilidadeProjeto { 
                                Code = h.IdHabilidade, 
                                NomeHabilidade = (h.IdHabilidade == 0)?h.NomeHabilidade:"" 
                            },
                            Nivel = new Nivel { Code = h.IdNivel }
                        }).ToList();
                    foreach (var HabilidadeJovemProjeto in habilidadesAdicionadas) {
                        HabilidadeJovemProjeto.Jovem = novoJovem;
                    }
                }
                
                JovemProjeto jovemProjeto = null;
                if (Request.Form["cboProjetoJovemPertence"] != "0") {
                    jovemProjeto = new JovemProjeto
                    {
                        Projeto = new Projeto { Code = int.Parse(Request.Form["cboProjetoJovemPertence"]) },
                        MesesProjeto = (!string.IsNullOrEmpty(Request.Form["txtMesesProjeto"])) ? int.Parse(Request.Form["txtMesesProjeto"]) : 0,
                        AnosProjeto = (!string.IsNullOrEmpty(Request.Form["txtAnosProjeto"])) ? int.Parse(Request.Form["txtAnosProjeto"]) : 0,
                        PertenceuOutroProjeto = (string.IsNullOrEmpty(Request.Form["rbJaEsteveEmOutroProjeto"])) ? 'N': char.Parse(Request.Form["rbJaEsteveEmOutroProjeto"]),
                        ProjetoAnterior = (Request.Form["cboProjetoAnterior"] != "0") ? new Projeto { Code = int.Parse(Request.Form["cboProjetoAnterior"]) }:null,
                        TempoProjeto = Request.Form["txtMesesProjeto"] + "#" + Request.Form["txtAnosProjeto"],
                        Jovem = novoJovem
                    };
                }

                facade.SalvarJovem(novoJovem, idiomasFaladoPeloJovem, habilidadesAdicionadas, jovemProjeto, testemunhoJovem);

                (base.UserLogger as UserLoggerImpl).WriteUserAction(UsuarioLogado.Id, UsuarioLogado.EstadoUsuario.SiglaEstado, $"O usuário {UsuarioLogado.Login} cadastrou o jovem de ID {novoJovem.Id} ");

                uploadFotoJovem(novoJovem.Id, siglaEstado);
                uploadDocumentoAutorizacaoJovem(novoJovem.Id, siglaEstado);

                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoCadastro();", true);

                /*
                if (novoJovem.OrigemCompraCamisa == "S") {
                    var CODIGO_SGFJU_AUTORIZACAO_COMPRA_CAMISA = novoJovem.CodigoAutorizacaoCompraCamisa;

                    ClientScript.RegisterStartupScript(GetType(), "hwa", $"mensagemConfirmacaoCadastroComCodigoAutorizacao('{novoJovem.CodigoAutorizacaoCompraCamisa}');", true);
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoCadastro();", true);
                */

                LimpaSessao();

                string script = "function f(){ mensagemConfirmacaoCadastro(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                //ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoCadastro();", true);
            }
            catch (DomainException excDominio) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
            catch (FacadeException excBussiness) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
            catch (Exception generalException) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
        }
        private void uploadFotoJovem(int idJovem, string psiglaEstado) {
            try {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0)) {
                    string SaveLocation = Server.MapPath("FotosJovens") + "\\" + FileUpload1.PostedFile.FileName;
                    FileUpload1.PostedFile.SaveAs(SaveLocation);

                    if (File.Exists(SaveLocation)){
                        var nomeArquivoFormatado = RetornaArquivofotoJovemFormatado(idJovem, psiglaEstado, SaveLocation);

                        File.Move(SaveLocation, nomeArquivoFormatado);
                        File.Delete(SaveLocation);
                    }
                }
            }
            catch (Exception excUploadFoto) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excUploadFoto, "CAMADA_APP");
                throw new Exception(mensagemErroExcecao);
            }
        }
        private void uploadDocumentoAutorizacaoJovem(int idJovem, string psiglaEstado)
        {
            try
            {
                if ((FileUploadDocumentoJovem.PostedFile != null) && (FileUploadDocumentoJovem.PostedFile.ContentLength > 0))
                {
                    string SaveLocation = Server.MapPath("DocumentosAutorizacao") + "\\" + FileUploadDocumentoJovem.PostedFile.FileName;
                    FileUploadDocumentoJovem.PostedFile.SaveAs(SaveLocation);

                    if (File.Exists(SaveLocation))
                    {
                        var nomeArquivoFormatado = RetornaArquivoDocumentoAutorizacaoJovemFormatado(idJovem, psiglaEstado, SaveLocation);

                        File.Move(SaveLocation, nomeArquivoFormatado);
                        File.Delete(SaveLocation);
                    }
                }
            }
            catch (Exception excUploadFoto)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excUploadFoto, "CAMADA_APP");
                throw new Exception(mensagemErroExcecao);
            }
        }
        private IList<ReuniaoFJU> RetornaReunioesQueOJovemAssiste()
        {
            var reunioesAssistidasPeloJovem = new List<ReuniaoFJU>();
            if (!string.IsNullOrEmpty(Request.Form["chkEncontroJovem"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkEncontroJovem"]) });

            if (!string.IsNullOrEmpty(Request.Form["chkReuniaoAlgoAMais"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkReuniaoAlgoAMais"]) });

            if (!string.IsNullOrEmpty(Request.Form["chkReuniaoaltarJovem"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkReuniaoaltarJovem"]) });

            if (!string.IsNullOrEmpty(Request.Form["chkReuniaoProjeto"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkReuniaoProjeto"]) });

            return reunioesAssistidasPeloJovem;
        }
        private IList<Livro> RetornaLivrosLidosPeloJovem() {
            var livrosLidosPeloJovem = new List<Livro>();
            string a;
            foreach (var item in Request.Form.Keys) {
                if (item.ToString().Contains("chkLivro")) {
                    if(Request.Form[item.ToString()] != null)
                        livrosLidosPeloJovem.Add(new Livro { Code = int.Parse(Request.Form[item.ToString()]) });
                }
            }
            return livrosLidosPeloJovem;
        }
        private IList<JovemIdioma> retornaIdiomasFaladosPeloJovem() {
            IList<JovemIdioma> retorno = null;
            if(Session["IdiomasAdicionados"] != null) 
                return (Session["IdiomasAdicionados"] as List<IdiomaNivelDTO>)
                          .Select(i => new JovemIdioma {
                              Idioma = new Idioma { Code = i.CodigoIdioma },
                              Nivel = new Nivel { Code = i.CodigoNivel }
                          }).ToList();
            return retorno;
        }
        public IList<DepartamentoProjeto> retornaDepartamentosSelecionados() {
            var departamentosSelecionados = new List<DepartamentoProjeto>();
            if (!string.IsNullOrEmpty(Request.Form["chkBanda"]))
                departamentosSelecionados.Add(new DepartamentoProjeto { Code = int.Parse(Request.Form["chkBanda"]) });
            if (!string.IsNullOrEmpty(Request.Form["chkTeatro"]))
                departamentosSelecionados.Add(new DepartamentoProjeto { Code = int.Parse(Request.Form["chkTeatro"]) });
            if (!string.IsNullOrEmpty(Request.Form["chkDanca"]))
                departamentosSelecionados.Add(new DepartamentoProjeto { Code = int.Parse(Request.Form["chkDanca"]) });
            return departamentosSelecionados;
        }
        public bool existeDepartamentoParaAssociar() {
            var departamentosAdicionados = (Session["departamentosAdicionados"] != null) ?
                                              (Session["departamentosAdicionados"] as IList<DepartamentoProjeto>) : null;
            var deptoNaSessao = (departamentosAdicionados != null) ? departamentosAdicionados.Count : 0;
            if ((!string.IsNullOrEmpty(Request.Form["chkBanda"]))  ||
                (!string.IsNullOrEmpty(Request.Form["chkTeatro"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkDanca"]))  ||
                (deptoNaSessao > 0 ) )
                return true;
            return false;
        }
        protected bool existeTonDeVozParaAdicionar() {
            if ((!string.IsNullOrEmpty(Request.Form["chkTonTenor"]))        ||
                (!string.IsNullOrEmpty(Request.Form["chkTonBaritono"]))     ||
                (!string.IsNullOrEmpty(Request.Form["chkTonBaixo"]))     ||
                (!string.IsNullOrEmpty(Request.Form["chkTonSoprano"]))      ||
                (!string.IsNullOrEmpty(Request.Form["chkTonMezzosoprano"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkTonContralto"]))    )
                return true;
            return false;
        }
        protected void adicionarHabilidadesTonDeVoz(ref IList<HabilidadeProjetoNivelDTO> habilidadesJaExistentes) { 
            foreach (var item in Request.Form.Keys) {
                if (item.ToString().Contains("chkTon")) {
                    if (Request.Form[item.ToString()] != null)
                        habilidadesJaExistentes
                            .Add(new HabilidadeProjetoNivelDTO { 
                                IdHabilidade = int.Parse(Request.Form[item.ToString()]),
                                IdNivel = 5
                            });
                }
            }
        }

        protected string RetornaArquivofotoJovemFormatado(int idJovem, string pSiglaEstado, string filename) {
            string fDir = Path.GetDirectoryName(filename);
            string fName = Path.GetFileNameWithoutExtension(filename);
            string fExt = Path.GetExtension(filename);
            var data = DateTime.Now.ToString("yyyy-MM-dd");
            var hora = DateTime.Now.Hour.ToString();
            var siglaEstado = pSiglaEstado;
            string suffix = $"{siglaEstado}_ID_{idJovem}_{data}{hora}_";
            string renamedFilePath = Path.Combine(fDir, String.Concat(suffix, fName, fExt));
            return renamedFilePath;
        }
        protected string RetornaArquivoDocumentoAutorizacaoJovemFormatado(int idJovem, string pSiglaEstado, string filename)
        {
            string fDir = Path.GetDirectoryName(filename);
            string fName = Path.GetFileNameWithoutExtension(filename);
            string fExt = Path.GetExtension(filename);
            var data = DateTime.Now.ToString("yyyy-MM-dd");
            var hora = DateTime.Now.Hour.ToString();
            var siglaEstado = pSiglaEstado;
            string suffix = $"DocAutorizacao_{siglaEstado}_ID_{idJovem}_{data}{hora}_";
            string renamedFilePath = Path.Combine(fDir, String.Concat(suffix, fName, fExt));
            return renamedFilePath;
        }

        protected void LimpaSessao() {
            Session.Remove("HabilidadesAdicionadas");
            txtTestemunho.InnerText = "";
            txtSugestao.InnerText = "";
        }
    }
}