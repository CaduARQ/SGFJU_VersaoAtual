using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.Domain.UI
{
    public partial class AlteraJovem : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtNome"])) {
                SalvarAlteracoes();
            }
        }
        protected void SalvarAlteracoes() {
            try {
                var facade = new FacadeJovemImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var siglaEstado = usuarioLogado.EstadoUsuario.SiglaEstado;
                var jovemAtualizacaoSessao = Session["JovemParaAtualizar"] as JovemDTO;
                var jovemEmAtualizacao = facade.GetByID(jovemAtualizacaoSessao.Id);
                var nomeFotoAntesAtualizacao = jovemEmAtualizacao.NomeArquivoFoto;
                var nomeArquivofotoPosAtualizacao = uploadFotoJovem(nomeFotoAntesAtualizacao, jovemEmAtualizacao.Id, siglaEstado);

                /* Contato */
                jovemEmAtualizacao.ContatoJovem.Whatsapp              = Request.Form["txtWhatsapp"];
                jovemEmAtualizacao.ContatoJovem.TelefoneFixo          = Request.Form["txtTelefoneFixo"];
                jovemEmAtualizacao.ContatoJovem.TelefoneEmergencia    = Request.Form["txtTelefoneEmergencia"];
                jovemEmAtualizacao.ContatoJovem.NomeContatoEmergencia = Request.Form["txtContatoEmergencia"];

                /* Endereço */
                jovemEmAtualizacao.EnderecoJovem.DescricaoEndereco = Request.Form["txtEndereco"];
                jovemEmAtualizacao.EnderecoJovem.Bairro            = Request.Form["txtBairro"];
                jovemEmAtualizacao.EnderecoJovem.Cidade            = Request.Form["txtCidade"];
                jovemEmAtualizacao.EnderecoJovem.TipoDeMoradia     = (!string.IsNullOrEmpty(Request.Form["cboTipoMoradia"])) ?
                                                                       new TipoMoradia { Code = int.Parse(Request.Form["cboTipoMoradia"]) } : null;

                /* Rede Social */
                jovemEmAtualizacao.RedeSocialJovem.Email          = Request.Form["txtEmail"];
                jovemEmAtualizacao.RedeSocialJovem.Instagram      = Request.Form["txtInstagram"];
                jovemEmAtualizacao.RedeSocialJovem.Facebook       = Request.Form["txtFacebook"];
                jovemEmAtualizacao.RedeSocialJovem.Twitter        = Request.Form["txtTwitter"];
                jovemEmAtualizacao.RedeSocialJovem.EhLeitorBlogBM = (string.IsNullOrEmpty(Request.Form["rbLeDiariamenteBlogBM"])) ?
                                                                    'N' :
                                                                    char.Parse(Request.Form["rbLeDiariamenteBlogBM"]);
                jovemEmAtualizacao.RedeSocialJovem.EhAssinanteUNIVER = (string.IsNullOrEmpty(Request.Form["rbAssinanteUNIVERVIDEO"])) ?
                                                                        'N' :
                                                                        char.Parse(Request.Form["rbAssinanteUNIVERVIDEO"]);
                jovemEmAtualizacao.RedeSocialJovem.EhLeitorUniversalorg = (string.IsNullOrEmpty(Request.Form["rbLeitorSiteUniversalOrg"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["rbLeitorSiteUniversalOrg"]);
                jovemEmAtualizacao.RedeSocialJovem.EhSeguidorOficialFJU = (string.IsNullOrEmpty(Request.Form["rbEhSeguidorOFICIALFJU"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["rbEhSeguidorOFICIALFJU"]);
                jovemEmAtualizacao.RedeSocialJovem.EhSeguidorTelegram = (string.IsNullOrEmpty(Request.Form["rbSegueFJUTelegram"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["rbSegueFJUTelegram"]);
                jovemEmAtualizacao.RedeSocialJovem.EhSeguidorYoutube = (string.IsNullOrEmpty(Request.Form["rbEhSeguidorFJUYouTube"])) ?
                                                                        'N' :
                                                                        char.Parse(Request.Form["rbEhSeguidorFJUYouTube"]);
                jovemEmAtualizacao.RedeSocialJovem.PossuiCelularComInternet = (string.IsNullOrEmpty(Request.Form["rbTemCelularComInternet"])) ?
                                                                                'N' :
                                                                                char.Parse(Request.Form["rbTemCelularComInternet"]);
                jovemEmAtualizacao.RedeSocialJovem.FrequenciaAssisteUNIVER = Request.Form["txtFrequenciaAssisteUniver"];
                jovemEmAtualizacao.RedeSocialJovem.PossuiComputador = (string.IsNullOrEmpty(Request.Form["rbTemComputadorEmCasa"])) ?
                                                                        'N' :
                                                                        char.Parse(Request.Form["rbTemComputadorEmCasa"]);

                /* Dados profissionais */
                jovemEmAtualizacao.DadosProfissionaisJovem.NomeEmpresa = Request.Form["txtEmpresa"];
                jovemEmAtualizacao.DadosProfissionaisJovem.TrabalhaAtualmente = (string.IsNullOrEmpty(Request.Form["rbTrabalha"])) ?
                                                                                'N' :
                                                                                char.Parse(Request.Form["rbTrabalha"]);
                jovemEmAtualizacao.DadosProfissionaisJovem.Profissao = Request.Form["txtProfissao"];

                /* Dados Espirituais */
                jovemEmAtualizacao.DadosEspirituaisJovem.EhMembroIURD = (string.IsNullOrEmpty(Request.Form["rbEhMembroIURD"])) ?
                                                                        'N' :
                                                                        char.Parse(Request.Form["rbEhMembroIURD"]);

                if (ehMesEAnoChegadaIURDValido(Request.Form["txtMesAnoChegadaIURD"])) {
                    jovemEmAtualizacao.DadosEspirituaisJovem.MesAnoChegadaIURD = Request.Form["txtMesAnoChegadaIURD"];
                    jovemEmAtualizacao.DadosEspirituaisJovem.AnoChegadaiurd = RetornaAnoChegadaIURD(Request.Form["txtMesAnoChegadaIURD"]);
                    jovemEmAtualizacao.DadosEspirituaisJovem.MesChegadaiurd = RetornaMesChegadaIURD(Request.Form["txtMesAnoChegadaIURD"]);
                }
                else if (ehDataInvertida(Request.Form["txtMesAnoChegadaIURD"])) {
                    var mesAnoChegadaIURD = Request.Form["txtMesAnoChegadaIURD"];
                    var anoChegadaIURD = Regex.Match(mesAnoChegadaIURD, @"[0-9]{4}/").Value.Replace("/", "");
                    var mesChegadaIURD = Regex.Match(mesAnoChegadaIURD, @"/[0-9]{1,2}").Value.Replace("/", "");
                    jovemEmAtualizacao.DadosEspirituaisJovem.MesAnoChegadaIURD = mesChegadaIURD + "/" + anoChegadaIURD;
                    jovemEmAtualizacao.DadosEspirituaisJovem.AnoChegadaiurd = int.Parse(anoChegadaIURD);
                    jovemEmAtualizacao.DadosEspirituaisJovem.MesChegadaiurd = int.Parse(mesChegadaIURD);
                }

                jovemEmAtualizacao.DadosEspirituaisJovem.ComoConheceuIURD  = Request.Form["txtComoConheceuIURD"];
                jovemEmAtualizacao.DadosEspirituaisJovem.JaSeAfastou = (string.IsNullOrEmpty(Request.Form["rbJaSeAfastou"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["rbJaSeAfastou"]);
                jovemEmAtualizacao.DadosEspirituaisJovem.MotivoSeAfastou   = Request.Form["txtMotivoAfastamento"];
                jovemEmAtualizacao.DadosEspirituaisJovem.TempoEstaFirme    = Request.Form["txtDesdeQuandoFirme"];
                jovemEmAtualizacao.DadosEspirituaisJovem.TempoAfastamento  = Request.Form["txtPorQuantoTempoSeAfastou"];
                jovemEmAtualizacao.DadosEspirituaisJovem.MesAnoAfastamento = Request.Form["txtMesAnoAfastou"];
                jovemEmAtualizacao.DadosEspirituaisJovem.BatismoAguasIURD = (string.IsNullOrEmpty(Request.Form["rbBatismoAguasNaIURD"])) ?
                                                                                'N' :
                                                                                char.Parse(Request.Form["rbBatismoAguasNaIURD"]);
                jovemEmAtualizacao.DadosEspirituaisJovem.EhBatizadoAguas = (string.IsNullOrEmpty(Request.Form["rbBatizadoAguas"])) ?
                                                                                'N' :
                                                                                char.Parse(Request.Form["rbBatizadoAguas"]);
                jovemEmAtualizacao.DadosEspirituaisJovem.MesAnoBatismoAguas = Request.Form["txtQuandoSeBatizouAguas"];

                jovemEmAtualizacao.DadosEspirituaisJovem.EhBatizadoEspiritoSanto = (string.IsNullOrEmpty(Request.Form["rbBatizadoEspiritoSanto"])) ?
                                                                                        'N' :
                                                                                        char.Parse(Request.Form["rbBatizadoEspiritoSanto"]);
                jovemEmAtualizacao.DadosEspirituaisJovem.MesAnoBatismoEspiritoSanto  = Request.Form["txtQuandoSeBatizadoES"];
                jovemEmAtualizacao.DadosEspirituaisJovem.OcasiaoBatismoEspiritoSanto = Request.Form["txtOndeBatismoEspiritoSanto"];
                jovemEmAtualizacao.DadosEspirituaisJovem.DescricaoFamiliaresIURD = Request.Form["txtFamiliaresIURD"];
                jovemEmAtualizacao.DadosEspirituaisJovem.DescricaoModoChegouFJU = Request.Form["txtComoConheceuFJU"];
                jovemEmAtualizacao.DadosEspirituaisJovem.MotivoEntradaFJU = Request.Form["txtMotivoEntrouFJU"];
                jovemEmAtualizacao.DadosEspirituaisJovem.MesAnoEntradaFJU = Request.Form["txtQuandoEntrouFJU"];
                jovemEmAtualizacao.DadosEspirituaisJovem.FrequenciaLeituraBiblia = (string.IsNullOrEmpty(Request.Form["cboFrequenciaLeituraBiblia"])) ? null : new FrequenciaLeitura { Code = int.Parse(Request.Form["cboFrequenciaLeituraBiblia"]) };
                jovemEmAtualizacao.DadosEspirituaisJovem.LeuTodaBiblia = (string.IsNullOrEmpty(Request.Form["rbJaLeuBibliaToda"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["rbJaLeuBibliaToda"]);
                jovemEmAtualizacao.DadosEspirituaisJovem.PossuiBiblia = (string.IsNullOrEmpty(Request.Form["rbTemBiblia"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["rbTemBiblia"]);
                jovemEmAtualizacao.DadosEspirituaisJovem.PossuiBibliaNoCelular = (string.IsNullOrEmpty(Request.Form["rbTemBibliaNoCelular"])) ?
                                                                                    'N' :
                                                                                    char.Parse(Request.Form["rbTemBibliaNoCelular"]);

                /* Educacional */
                jovemEmAtualizacao.DadosEducacionaisJovem.GrauEscolaridade = Request.Form["escolaridade"];
                jovemEmAtualizacao.DadosEducacionaisJovem.EstudaAtualmente = (string.IsNullOrEmpty(Request.Form["rbEstuda"])) ?
                                                                                'N' :
                                                                                char.Parse(Request.Form["rbEstuda"]);
                jovemEmAtualizacao.DadosEducacionaisJovem.NomeInstituicaoEnsino     = Request.Form["txtInstituicaoOndeEstuda"];
                jovemEmAtualizacao.DadosEducacionaisJovem.NomeCursoSuperior         = Request.Form["txtNomeCursoFaculdadeJovem"];
                jovemEmAtualizacao.DadosEducacionaisJovem.DesejaCursarNivelSuperior = (string.IsNullOrEmpty(Request.Form["rbDesejaCursarNivelSuperior"])) ?
                                                                                        'N' :
                                                                                        char.Parse(Request.Form["rbDesejaCursarNivelSuperior"]);
                jovemEmAtualizacao.DadosEducacionaisJovem.NomeCursoSuperiorDesejaCursar = Request.Form["txtNomeCursoDesejaCursar"];
                jovemEmAtualizacao.DadosEducacionaisJovem.ModalidadeCursadaEnsinoSuperior = (!string.IsNullOrEmpty(Request.Form["rbModalidadeNivelSuperior"])) ?
                                                                                              new ModalidadeEnsinoSuperior { Code = int.Parse(Request.Form["rbModalidadeNivelSuperior"]) } :
                                                                                              null;
                jovemEmAtualizacao.DadosEducacionaisJovem.PeriodoAtualNivelFaculdade = Request.Form["txtPeriodoCursando"];
                jovemEmAtualizacao.DadosEducacionaisJovem.PossuiNivelSuperior = (string.IsNullOrEmpty(Request.Form["rbJaSeFormou"])) ?
                                                                                     'N' :
                                                                                     char.Parse(Request.Form["rbJaSeFormou"]);
                jovemEmAtualizacao.DadosEducacionaisJovem.PrevisaoConclusaoCurso = Request.Form["txtPrevisaoFormatura"];

                /* Situação */
                jovemEmAtualizacao.SituacaoJovemIURDFJU.EhObreiro = (string.IsNullOrEmpty(Request.Form["chkEhObreiro"])) ?
                                                                    'N' :
                                                                    char.Parse(Request.Form["chkEhObreiro"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.AnosObreiro   = (!string.IsNullOrEmpty(Request.Form["txtAnosEhObreiro"])) ? int.Parse(Request.Form["txtAnosEhObreiro"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MesesObreiro  = (!string.IsNullOrEmpty(Request.Form["txtMesesEhObreiro"])) ? int.Parse(Request.Form["txtMesesEhObreiro"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.EhColaborador = (string.IsNullOrEmpty(Request.Form["chkEhColaborador"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["chkEhColaborador"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MesesColaborador = (!string.IsNullOrEmpty(Request.Form["txtMesesEhColaborador"])) ? int.Parse(Request.Form["txtMesesEhColaborador"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.AnosColaborador = (!string.IsNullOrEmpty(Request.Form["txtAnosEhColaborador"])) ? int.Parse(Request.Form["txtAnosEhColaborador"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MesAnoInicioCPO = Request.Form["txtMesesInicioCPO"] + "#" + Request.Form["txtAnosInicioCPO"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.EstaCursandoCPO = (string.IsNullOrEmpty(Request.Form["chkCursandoCPO"])) ?
                                                                             'N' :
                                                                             char.Parse(Request.Form["chkCursandoCPO"]);

                jovemEmAtualizacao.SituacaoJovemIURDFJU.EhPertencenteFJU = (string.IsNullOrEmpty(Request.Form["chkMembroFJU"])) ?
                                                                              'N' :
                                                                              char.Parse(Request.Form["chkMembroFJU"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.EhCoordenadorFJU = (string.IsNullOrEmpty(Request.Form["chkEhCoordenadorFJU"])) ?
                                                                              'N' :
                                                                              char.Parse(Request.Form["chkEhCoordenadorFJU"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MesAnoCoordenandoFJU = Request.Form["txtMesesInicioCoordenacaoFJU"] + "#" + Request.Form["txtAnosInicioCoordenacaoFJU"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MesesCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtMesesInicioCoordenacaoFJU"])) ? int.Parse(Request.Form["txtMesesInicioCoordenacaoFJU"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.AnosCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtAnosInicioCoordenacaoFJU"])) ? int.Parse(Request.Form["txtAnosInicioCoordenacaoFJU"]) : 0;

                jovemEmAtualizacao.SituacaoJovemIURDFJU.EhLiderTribo = (string.IsNullOrEmpty(Request.Form["chkLiderTribo"])) ?
                                                                          'N' :
                                                                          char.Parse(Request.Form["chkLiderTribo"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.TriboQueLidera = (!string.IsNullOrEmpty(Request.Form["cboTribo"])) ?
                                                                            new Tribo { Code = int.Parse(Request.Form["cboTribo"]) } : null;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.PeriodoCoordenandoTribo = Request.Form["txtMesesInicioCoordenacaoTribo"] + "#" + Request.Form["txtAnosInicioCoordenacaoTribo"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MesesCoordenandoTribo = (!string.IsNullOrEmpty(Request.Form["txtMesesInicioCoordenacaoTribo"])) ? int.Parse(Request.Form["txtMesesInicioCoordenacaoTribo"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.AnosCoordenandoTribo = (!string.IsNullOrEmpty(Request.Form["txtAnosInicioCoordenacaoTribo"])) ? int.Parse(Request.Form["txtAnosInicioCoordenacaoTribo"]) : 0;

                jovemEmAtualizacao.SituacaoJovemIURDFJU.EhLiderProjeto = (string.IsNullOrEmpty(Request.Form["chkLiderProjeto"])) ?
                                                                            'N' :
                                                                            char.Parse(Request.Form["chkLiderProjeto"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.ProjetoQueCoordena = (!string.IsNullOrEmpty(Request.Form["cboProjetoFJU"])) ? new Projeto { Code = int.Parse(Request.Form["cboProjetoFJU"]) } : null;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.PeriodoCoordenandoProjeto = Request.Form["txtMesesInicioCoordenacaoProjeto"] + "#" + Request.Form["txtAnosInicioCoordenacaoProjeto"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MesesCoordenandoProjeto = (!string.IsNullOrEmpty(Request.Form["txtMesesInicioCoordenacaoProjeto"])) ? int.Parse(Request.Form["txtMesesInicioCoordenacaoProjeto"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.AnosCoordenandoProjeto = (!string.IsNullOrEmpty(Request.Form["txtAnosInicioCoordenacaoProjeto"])) ? int.Parse(Request.Form["txtAnosInicioCoordenacaoProjeto"]) : 0;

                jovemEmAtualizacao.SituacaoJovemIURDFJU.PossuiCamisaProjeto = (string.IsNullOrEmpty(Request.Form["rbTemCamisaFJU"])) ?
                                                                                  'N' :
                                                                                  char.Parse(Request.Form["rbTemCamisaFJU"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.NomeCamisaFJU = Request.Form["cboCamisasFJU"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.TamanhoCamisa = Request.Form["cboTamanhoCamisaFJU"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.FoiObreiro = (string.IsNullOrEmpty(Request.Form["rbJaFoiObreiroAntes"])) ?
                                                                        'N' :
                                                                        char.Parse(Request.Form["rbJaFoiObreiroAntes"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MotivoSaiuObreiro = Request.Form["txtMotivoSaidaObreiro"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.FoiPastor = (string.IsNullOrEmpty(Request.Form["rbJaFoiPastorEsposaAntes"])) ?
                                                                        'N' :
                                                                        char.Parse(Request.Form["rbJaFoiPastorEsposaAntes"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MotivoSaidaPastor = Request.Form["txtMotivoSaidaPastorEsposa"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.DesejaSerObreiro = (string.IsNullOrEmpty(Request.Form["rbDesejaSerObreiro"])) ?
                                                                          'N' :
                                                                          char.Parse(Request.Form["rbDesejaSerObreiro"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.MotivoDesejaSerObreiro = Request.Form["txtMotivoDesejaSErObreiro"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar = (string.IsNullOrEmpty(Request.Form["rbDesejaFazerObraAltar"])) ?
                                                                                'N' :
                                                                                char.Parse(Request.Form["rbDesejaFazerObraAltar"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.PertenceAltarJovem = (string.IsNullOrEmpty(Request.Form["rbEstaNoAltarJovem"])) ?
                                                                              'N' :
                                                                              char.Parse(Request.Form["rbEstaNoAltarJovem"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.PertenceIntellimen = (string.IsNullOrEmpty(Request.Form["rbFazParteIntellimen"])) ?
                                                                              'N' :
                                                                              char.Parse(Request.Form["rbFazParteIntellimen"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.DesafiosConcluidos = (string.IsNullOrEmpty(Request.Form["rbCompletouDesafios"])) ?
                                                                              'N' :
                                                                              char.Parse(Request.Form["rbCompletouDesafios"]);
                jovemEmAtualizacao.SituacaoJovemIURDFJU.DesafioAtual = (!string.IsNullOrEmpty(Request.Form["txtNumeroDesafioIntellimen"])) ? int.Parse(Request.Form["txtNumeroDesafioIntellimen"]) : 0;
                jovemEmAtualizacao.SituacaoJovemIURDFJU.NomeParceiroIntellimen = Request.Form["txtNomeParceiroIntellimen"];
                jovemEmAtualizacao.SituacaoJovemIURDFJU.TelefoneParceiroIntellimen = Request.Form["txtTelefoneParceiroIntellimen"];



                jovemEmAtualizacao.Nome = Request.Form["txtNome"];


                //-------------------------------------------------------------------------------------------------
                if (Session["DataNascimentoAlterada"] != null){
                    jovemEmAtualizacao.DataNascimento = DateTime.ParseExact(Session["DataNascimentoAlterada"].ToString(), "dd/MM/yyyy", null);
                }

                if (Session["DataPreenchimentoAlterada"] != null) {
                    jovemEmAtualizacao.DataPreenchimentoFormulario = DateTime.ParseExact(Session["DataPreenchimentoAlterada"].ToString(), "dd/MM/yyyy", null);
                }

                if (Session["DataCasamentoAlterada"] != null) {
                    jovemEmAtualizacao.DataCasamento = DateTime.ParseExact(Session["DataCasamentoAlterada"].ToString(), "dd/MM/yyyy", null);
                }

                //--------------------------------------------------------------------------------------------------------------
                jovemEmAtualizacao.DataUltimaAtualizacao = DateTime.Now;
                jovemEmAtualizacao.ConjugeEhIURD = (string.IsNullOrEmpty(Request.Form["rbConjugeEhIURD"])) ? 'N' : char.Parse(Request.Form["rbConjugeEhIURD"]);
                jovemEmAtualizacao.NomeConjuge = Request.Form["txtNomeconjuge"];
                //jovemEmAtualizacao.DataCasamento = (!string.IsNullOrEmpty(Request.Form["txtDataCasamento"])) ? DateTime.Parse(Request.Form["txtDataCasamento"]) : new Nullable<DateTime>();
                jovemEmAtualizacao.PossuiTituloEleitor = (string.IsNullOrEmpty(Request.Form["rbPossuiTituloeleitor"])) ? 'N' :
                                                            char.Parse(Request.Form["rbPossuiTituloeleitor"]);
                jovemEmAtualizacao.PossuiFilhos = (string.IsNullOrEmpty(Request.Form["rbPossuiFilhos"])) ? 'N' : char.Parse(Request.Form["rbPossuiFilhos"]);
                jovemEmAtualizacao.QuantidadeFilhos = (!string.IsNullOrEmpty(Request.Form["txtQtdFilhos"])) ? int.Parse(Request.Form["txtQtdFilhos"]) : 0;
                jovemEmAtualizacao.NomeArquivoFoto = (string.IsNullOrEmpty(nomeArquivofotoPosAtualizacao))? jovemEmAtualizacao.NomeArquivoFoto:nomeArquivofotoPosAtualizacao;
                jovemEmAtualizacao.TextoSugestao = Request.Form["txtSugestao"];
                jovemEmAtualizacao.Sexo = (string.IsNullOrEmpty(Request.Form["cboSexo"])) ? 'N' : char.Parse(Request.Form["cboSexo"]);
                jovemEmAtualizacao.ClassificacaoJovem = (string.IsNullOrEmpty(Request.Form["cboClassificacaoJovem"])) ? char.Parse("N") : char.Parse(Request.Form["cboClassificacaoJovem"]);
                jovemEmAtualizacao.PertenceGrupoMulheresIURD = (string.IsNullOrEmpty(Request.Form["rbFazParteGrupoMulheresUniversal"])) ? 'N' : char.Parse(Request.Form["rbFazParteGrupoMulheresUniversal"]);
                jovemEmAtualizacao.NomeGrupoMulheresIURD = Request.Form["txtNomeGrupoMulheresUniversal"];
                jovemEmAtualizacao.EstadoCivilJovem = (!string.IsNullOrEmpty(Request.Form["cboTipoEstadoCivil"])) ? new TipoEstadoCivil { Code = int.Parse(Request.Form["cboTipoEstadoCivil"]) } : null;

                /*Projeto Altar Jovem 318*/
                jovemEmAtualizacao.EhAltarJovem318 = (string.IsNullOrEmpty(Request.Form["chkAltarJovem318"])) ?
                                                                              'N' :
                                                                              'S';
                jovemEmAtualizacao.CodigoAltarJovem318 = Request.Form["txtCodigoAltarJovem318"];

                /* Testemunho */
                var testemunhoJovem = new Testemunho
                {
                    Code = jovemAtualizacaoSessao.TestemunhoJovem.Code,
                    SofreuComDepressao = (string.IsNullOrEmpty(Request.Form["rbJaSofreuDepressao"])) ? 'N' : char.Parse(Request.Form["rbJaSofreuDepressao"]),
                    TempoSofreuDepressao = Request.Form["txtTempoSofreuDepressao"],
                    TempoLivreDepressao = Request.Form["txtTempoLivreDepressao"],

                    TentouSuicidio = (string.IsNullOrEmpty(Request.Form["rbJaTentouSuicidio"])) ? 'N' : char.Parse(Request.Form["rbJaTentouSuicidio"]),
                    DescricaoTentativaSuicidio = Request.Form["txtDescricaoTentativaSuicidio"],
                    MesAnoTentativaSuicidio = Request.Form["txtQuandoTentouSuicidio"],
                    NumeroTentativasSuicidio = (!string.IsNullOrEmpty(Request.Form["txtNumeroTentativasSuicidio"])) ? int.Parse(Request.Form["txtNumeroTentativasSuicidio"]) : 0,

                    SofreuAutomutilacao = (string.IsNullOrEmpty(Request.Form["rbJaSofreuAutomutilacao"])) ? 'N' : char.Parse(Request.Form["rbJaSofreuAutomutilacao"]),
                    TempoSofreuAutomutilacao = Request.Form["txtTempoSofreuAutomutilacao"],
                    TempoLivreAutomutilacao = Request.Form["txtTempoLivreAutomutilacao"],

                    SofreuVicio = (string.IsNullOrEmpty(Request.Form["rbJaTeveVicio"])) ? 'N' : char.Parse(Request.Form["rbJaTeveVicio"]),
                    DescricaoVicio = Request.Form["txtNomeVicio"],
                    TempoLivreVicios = Request.Form["txtTempoLivreVicios"],
                    TempoVicio = Request.Form["txtTempoVicio"],
                    TextoTestemunho = Request.Form["txtTestemunho"],
                    JovemTestemunho = jovemEmAtualizacao
                };

                TrataCursos(ref jovemEmAtualizacao);

                if (existeDepartamentoParaAssociar())
                    TrataDepartamento(ref jovemEmAtualizacao);

                TrataReunioes(ref jovemEmAtualizacao);

                TrataLivrosLidos(ref jovemEmAtualizacao);

                /**/
                var habilidadesSelecionadasParaOJovem = (Session["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>);
                List<JovemHabilidadeProjeto> habilidadesAdicionadas = null;
                if (habilidadesSelecionadasParaOJovem != null && habilidadesSelecionadasParaOJovem.Count > 0)
                {
                    if (existeTonDeVozParaAdicionar())
                        adicionarHabilidadesTonDeVoz(ref habilidadesSelecionadasParaOJovem);
                    habilidadesAdicionadas =
                        habilidadesSelecionadasParaOJovem.Select(h => new JovemHabilidadeProjeto
                        {
                            Habilidade = new HabilidadeProjeto
                            {
                                Code = h.IdHabilidade,
                                NomeHabilidade = (h.IdHabilidade == 0) ? h.NomeHabilidade : ""
                            },
                            Nivel = new Nivel { Code = h.IdNivel }
                        }).ToList();
                    foreach (var HabilidadeJovemProjeto in habilidadesAdicionadas) {
                        HabilidadeJovemProjeto.Jovem = jovemEmAtualizacao;
                    }
                }

                var habilidadesParaFazerExclusao = (Session["HabilidadesParaExcluir"] as IList<HabilidadeProjetoNivelDTO>);
                List<JovemHabilidadeProjeto> habilidadesParaRetirarDoJovem = null;
                if (habilidadesParaFazerExclusao != null && habilidadesParaFazerExclusao.Count > 0) {
                    habilidadesParaRetirarDoJovem = habilidadesParaFazerExclusao.Select(h => new JovemHabilidadeProjeto
                    {
                        Habilidade = new HabilidadeProjeto
                        {
                            Code = h.IdHabilidade,
                            NomeHabilidade = (h.IdHabilidade == 0) ? h.NomeHabilidade : ""
                        },
                        Nivel = new Nivel { Code = h.IdNivel }
                    }).ToList();
                    foreach (var habilidadeEmExclusao in habilidadesParaRetirarDoJovem) {
                        habilidadeEmExclusao.Jovem = jovemEmAtualizacao;
                    }
                }

                var idiomasFaladoPeloJovem = retornaIdiomasFaladosPeloJovem();
                if (idiomasFaladoPeloJovem != null)
                {
                    if (idiomasFaladoPeloJovem.Count() > 0)
                    {
                        foreach (var idiomaJovem in idiomasFaladoPeloJovem)
                        {
                            idiomaJovem.Jovem = jovemEmAtualizacao;
                        }
                    }
                }

                var idiomasParaExcluir = retornaIdiomasParaExcluir();
                if (idiomasParaExcluir != null) {
                    if (idiomasParaExcluir.Count() > 0) { 
                        foreach (var idiomaParaExclusao in idiomasParaExcluir) {
                            idiomaParaExclusao.Jovem = jovemEmAtualizacao;
                        }
                    }
                }

                var objJovemProjetoContainer = new JovemProjetoContainer();
                objJovemProjetoContainer.ProjetoAnterior = (Session["ProjetoAnterior"] as JovemProjeto);
                if (objJovemProjetoContainer.ProjetoAnterior != null) {
                    objJovemProjetoContainer.ProjetoAnterior.Jovem = jovemEmAtualizacao;
                }
                
                JovemProjeto jovemProjeto = null;
                if (Request.Form["cboProjetoJovemPertence"] != "0") {
                    jovemProjeto = new JovemProjeto
                    {
                        Projeto = new Projeto { Code = int.Parse(Request.Form["cboProjetoJovemPertence"]) },
                        MesesProjeto = (!string.IsNullOrEmpty(Request.Form["txtMesesProjeto"])) ? int.Parse(Request.Form["txtMesesProjeto"]) : 0,
                        AnosProjeto = (!string.IsNullOrEmpty(Request.Form["txtAnosProjeto"])) ? int.Parse(Request.Form["txtAnosProjeto"]) : 0,
                        PertenceuOutroProjeto = (string.IsNullOrEmpty(Request.Form["rbJaEsteveEmOutroProjeto"])) ? 'N' : char.Parse(Request.Form["rbJaEsteveEmOutroProjeto"]),
                        ProjetoAnterior = (Request.Form["cboProjetoAnterior"] != "0") ? new Projeto { Code = int.Parse(Request.Form["cboProjetoAnterior"]) } : null,
                        TempoProjeto = Request.Form["txtMesesProjeto"] + "#" + Request.Form["txtAnosProjeto"],
                        Jovem = jovemEmAtualizacao
                    };
                }
                objJovemProjetoContainer.ProjetoAtual = jovemProjeto;
                
                facade.AtualizarJovem(jovemEmAtualizacao, idiomasFaladoPeloJovem, idiomasParaExcluir, habilidadesAdicionadas, habilidadesParaRetirarDoJovem, objJovemProjetoContainer, testemunhoJovem);

                (base.UserLogger as UserLoggerImpl).WriteUserAction(new LogUsuarioDTO { 
                    IdLogUsuario = usuarioLogado.Id+DateTime.Now.Millisecond,
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"Atualização do Jovem {jovemEmAtualizacao.Id} e nome {jovemEmAtualizacao.Nome} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = siglaEstado
                });

                LimpaSessao();
                string script = "function f(){ mensagemConfirmacaoCadastro(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoCadastro();", true);
            }
            catch (DomainException excDominio)
            {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemErroInadequadoSistema();", true);
            }
            catch (FacadeException excBussiness)
            {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemErroInadequadoSistema();", true);
            }
            catch (Exception generalException)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemErroInadequadoSistema();", true);
                //
            }
        }

        private void TrataDepartamento(ref Jovem jovemEmAtualizacao){
            var departamentosSelecionados = this.retornaDepartamentosSelecionados();
            foreach (var departamentoSel in departamentosSelecionados){
                var departamentoEstaAdicionado = (jovemEmAtualizacao.DepartamentosProjetoJovemFazParte.Where(dp => dp.Code == departamentoSel.Code).Count() > 0) ? true : false;
                if (departamentoEstaAdicionado == false)
                    jovemEmAtualizacao.addDepartamentoProjetoJovemFazParte(departamentoSel);
            }
        }

        private void LimpaSessao() {
            Session.Remove("cursosParaExcluir");
            Session.Remove("Atualizacao_cursosAdicionados");        
            Session.Remove("HabilidadesParaExcluir");
            Session.Remove("Atualizacao_HabilidadesAdicionadas");
            Session.Remove("Atualizacao_IdiomasAdicionados");
            Session.Remove("IdiomasParaExcluir");
            Session.Remove("Atualizacao_departamentosAdicionados");

            Session.Remove("DataNascimentoAlterada");
            Session.Remove("DataPreenchimentoAlterada");
            Session.Remove("DataCasamentoAlterada");
        }

        private string uploadFotoJovem(string nomeArquivoFotoJovem, int idJovem, string psiglaEstado) {
            try {
                var nomeArquivoRetorno = string.Empty;
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0)) {
                    if (string.Compare(FileUpload1.PostedFile.FileName, nomeArquivoFotoJovem, StringComparison.OrdinalIgnoreCase) != 0) {
                        var data = DateTime.Now.ToString("yyyy-MM-dd");
                        var hora = DateTime.Now.Hour.ToString();
                        var siglaEstado = psiglaEstado;
                        var arquivoUpload = FileUpload1.FileName;
                        nomeArquivoRetorno = $"{siglaEstado}_ID_{idJovem}_{data}{hora}_{arquivoUpload}";

                        if (string.IsNullOrEmpty(nomeArquivoFotoJovem)) {
                            string SaveLocation = Server.MapPath("FotosJovens") + "\\" + FileUpload1.PostedFile.FileName;

                            FileUpload1.PostedFile.SaveAs(SaveLocation);

                            var nomeArquivoFormatado = RetornaArquivofotoJovemFormatado(idJovem, psiglaEstado, SaveLocation);

                            File.Move(SaveLocation, nomeArquivoFormatado);
                            File.Delete(SaveLocation);
                        }
                        else {
                            //excluo o anterior
                            //File.Delete(Server.MapPath("FotosJovens") + "\\" + nomeArquivoFotoJovem);

                            string SaveLocation = Server.MapPath("FotosJovens") + "\\" + FileUpload1.PostedFile.FileName;

                            FileUpload1.PostedFile.SaveAs(SaveLocation);

                            var nomeArquivoFormatado = RetornaArquivofotoJovemFormatado(idJovem, psiglaEstado, SaveLocation);

                            File.Move(SaveLocation, nomeArquivoFormatado);
                            //File.Delete(SaveLocation);"FotosJovens") + "\\" + nomeArquivoFotoJovem
                            File.Delete(Server.MapPath("FotosJovens") + "\\" + nomeArquivoFotoJovem); 
                        }
                    }
                }
                return nomeArquivoRetorno;
            }
            catch (Exception excUploadFoto) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excUploadFoto, "CAMADA_APP");
                throw new Exception(mensagemErroExcecao);
            }
        }
        
        private IList<ReuniaoFJU> RetornaReunioesQueOJovemAssiste()
        {
            var reunioesAssistidasPeloJovem = new List<ReuniaoFJU>();
            if (!string.IsNullOrEmpty(Request.Form["chkEncontroJovem"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkEncontroJovem"]), NomeReuniaoFJU = "Encontro Jovem" });

            if (!string.IsNullOrEmpty(Request.Form["chkReuniaoAlgoAMais"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkReuniaoAlgoAMais"]), NomeReuniaoFJU = "Algo a Mais" });

            if (!string.IsNullOrEmpty(Request.Form["chkReuniaoaltarJovem"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkReuniaoaltarJovem"]), NomeReuniaoFJU = "Altar Jovem" });

            if (!string.IsNullOrEmpty(Request.Form["chkReuniaoProjeto"]))
                reunioesAssistidasPeloJovem.Add(new ReuniaoFJU { Code = int.Parse(Request.Form["chkReuniaoProjeto"]), NomeReuniaoFJU = "Projeto" });

            return reunioesAssistidasPeloJovem;
        }
        private void TrataReunioes(ref Jovem jovemParametroEmAtualizacao) {
            var numeroReunioesJovem = jovemParametroEmAtualizacao.ReunioesFJUAssistidasPeloJovem.Count();
            var reunioesSelecionadas = this.RetornaReunioesQueOJovemAssiste();
            var numeroReunioesSelecionadas = reunioesSelecionadas.Count;
            var temReunioesAExcluir = (numeroReunioesJovem > numeroReunioesSelecionadas) ? true : false;

            if (temReunioesAExcluir) {
                int contador = -1;
                var reunioesNaColecaoJovem = jovemParametroEmAtualizacao.ReunioesFJUAssistidasPeloJovem;
                var listaDeReunioesParaExcluir = new List<ReuniaoFJU>();
                foreach (var reuniaoJovem in reunioesNaColecaoJovem){
                    contador++;
                    var reuniaoDaColecaoEstaSelecionada = (reunioesSelecionadas.Where(rn => rn.Code == reuniaoJovem.Code).Count() > 0) ? true : false;
                    if (reuniaoDaColecaoEstaSelecionada == false)
                        listaDeReunioesParaExcluir.Add(reuniaoJovem);
                }

                int r = -1;
                foreach (var reuniaoExcluir in listaDeReunioesParaExcluir) {
                    foreach (var rDoJovem in jovemParametroEmAtualizacao.ReunioesFJUAssistidasPeloJovem.ToList()){
                        r++;
                        if (reuniaoExcluir.Code == rDoJovem.Code) {
                            jovemParametroEmAtualizacao.removeReuniaoFJUAssistidaPeloJovem(r);
                        }
                        
                    }
                    r = -1;
                }
            }
            else {
                foreach (var reuniaoSel in reunioesSelecionadas) {
                    var EstaNaColecao = (jovemParametroEmAtualizacao.ReunioesFJUAssistidasPeloJovem.Where(r => r.Code == reuniaoSel.Code).Count() > 0) ? true : false;
                    if (EstaNaColecao == false)
                        jovemParametroEmAtualizacao.addReuniaoFJUAssistidaPeloJovem(reuniaoSel);
                }
            }
        }
        private IList<Livro> RetornaLivrosLidosPeloJovem()
        {
            var livrosLidosPeloJovem = new List<Livro>();
            string a;
            foreach (var item in Request.Form.Keys)
            {
                if (item.ToString().Contains("chkLivro"))
                {
                    if (Request.Form[item.ToString()] != null)
                        livrosLidosPeloJovem.Add(new Livro { Code = int.Parse(Request.Form[item.ToString()]) });
                }
            }
            return livrosLidosPeloJovem;
        }
        private IList<JovemIdioma> retornaIdiomasFaladosPeloJovem()
        {
            IList<JovemIdioma> retorno = null;
            if (Session["Atualizacao_IdiomasAdicionados"] != null)
                return (Session["Atualizacao_IdiomasAdicionados"] as List<IdiomaNivelDTO>)
                          .Select(i => new JovemIdioma
                          {
                              Idioma = new Idioma { Code = i.CodigoIdioma },
                              Nivel = new Nivel { Code = i.CodigoNivel }
                          }).ToList();
            return retorno;
        }
        protected IList<JovemIdioma> retornaIdiomasParaExcluir() {
            IList<JovemIdioma> retorno = null;
            if (Session["IdiomasParaExcluir"] != null)
                return (Session["IdiomasParaExcluir"] as List<IdiomaNivelDTO>)
                          .Select(i => new JovemIdioma
                          {
                              Idioma = new Idioma { Code = i.CodigoIdioma },
                              Nivel = new Nivel { Code = i.CodigoNivel }
                          }).ToList();
            return retorno;
        }
        public IList<DepartamentoProjeto> retornaDepartamentosSelecionados()
        {
            var departamentosSelecionados = new List<DepartamentoProjeto>();
            if (!string.IsNullOrEmpty(Request.Form["chkBanda"]))
                departamentosSelecionados.Add(new DepartamentoProjeto { Code = int.Parse(Request.Form["chkBanda"]) });
            if (!string.IsNullOrEmpty(Request.Form["chkTeatro"]))
                departamentosSelecionados.Add(new DepartamentoProjeto { Code = int.Parse(Request.Form["chkTeatro"]) });
            if (!string.IsNullOrEmpty(Request.Form["chkDanca"]))
                departamentosSelecionados.Add(new DepartamentoProjeto { Code = int.Parse(Request.Form["chkDanca"]) });
            return departamentosSelecionados;
        }
        public bool existeDepartamentoParaAssociar()
        {
            var departamentosAdicionados = (Session["Atualizacao_departamentosAdicionados"] != null) ?
                                              (Session["Atualizacao_departamentosAdicionados"] as IList<DepartamentoProjeto>) : null;
            var deptoNaSessao = (departamentosAdicionados != null) ? departamentosAdicionados.Count : 0;
            if ((!string.IsNullOrEmpty(Request.Form["chkBanda"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkTeatro"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkDanca"])) ||
                (deptoNaSessao > 0))
                return true;
            return false;
        }
        protected bool existeTonDeVozParaAdicionar()
        {
            if ((!string.IsNullOrEmpty(Request.Form["chkTonTenor"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkTonBaritono"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkTonBaixo"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkTonSoprano"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkTonMezzosoprano"])) ||
                (!string.IsNullOrEmpty(Request.Form["chkTonContralto"])))
                return true;
            return false;
        }
        protected void adicionarHabilidadesTonDeVoz(ref IList<HabilidadeProjetoNivelDTO> habilidadesJaExistentes)
        {
            foreach (var item in Request.Form.Keys)
            {
                if (item.ToString().Contains("chkTon"))
                {
                    if (Request.Form[item.ToString()] != null)
                        habilidadesJaExistentes
                            .Add(new HabilidadeProjetoNivelDTO
                            {
                                IdHabilidade = int.Parse(Request.Form[item.ToString()]),
                                IdNivel = 5
                            });
                }
            }
        }

        protected void TrataCursos(ref Jovem jovemParametroEmAtualizacao) {
            if (Session["cursosParaExcluir"] != null) {
                int contador = -1;
                int indiceCursoExcluir = -1;

                foreach (var cursoExcluir in (Session["cursosParaExcluir"] as List<CursoRelacionadoProjeto>)){
                    foreach (var cursoDaColecao in jovemParametroEmAtualizacao.CursosRelacionados) {
                        contador++;
                        if (cursoDaColecao.Code == cursoExcluir.Code)
                            indiceCursoExcluir = contador;
                    }
                    jovemParametroEmAtualizacao.RemoveCursoRelacionado(indiceCursoExcluir);
                }
            }

            if (Session["Atualizacao_cursosAdicionados"] != null){
                var cursosAdicionaisAInserirJovem =
                    (Session["Atualizacao_cursosAdicionados"] as IList<CursoRelacionadoProjeto>);
                if (cursosAdicionaisAInserirJovem.Count > 0) {
                    foreach (var cursoParaAdicionar in cursosAdicionaisAInserirJovem){
                        var cursoEstaNaColecao = (jovemParametroEmAtualizacao.CursosRelacionados.Where(crs => crs.Code == cursoParaAdicionar.Code).Count() != 0)?true:false;
                        if (cursoParaAdicionar.Code == 0 || cursoEstaNaColecao == false) 
                            jovemParametroEmAtualizacao.AddCursoRelacionado(cursoParaAdicionar);
                    }
                }
            }
        }

        protected void TrataLivrosLidos(ref Jovem jovemParametroEmAtualizacao) {
            var livrosSelecionados = this.RetornaLivrosLidosPeloJovem();
            var livrosDoJovem = jovemParametroEmAtualizacao.LivrosLidosPeloJovem;
            var quantidadeLivrosSelecionados = livrosSelecionados.Count;
            var quantidadeLivrosDoJovem = livrosDoJovem.Count;
            var temLivrosParaExcluir = (quantidadeLivrosDoJovem > quantidadeLivrosSelecionados) ? true : false;

            if (temLivrosParaExcluir) {
                var listaLivrosParaExcluir = new List<Livro>();
                foreach (var livroJovem in livrosDoJovem){
                    var livroNaColecaoDoJovemEstaSelecionado = (livrosSelecionados.Where(lvr => lvr.Code == livroJovem.Code).Count() > 0) ? true : false;
                    if (livroNaColecaoDoJovemEstaSelecionado == false)
                        listaLivrosParaExcluir.Add(livroJovem);
                }

                int livroContador = -1;
                foreach (var livroParaExcluirDoJovem in listaLivrosParaExcluir){
                    foreach (var livroEhDoJovem in livrosDoJovem.ToList()){
                        livroContador++;
                        if (livroParaExcluirDoJovem.Code == livroEhDoJovem.Code)
                            jovemParametroEmAtualizacao.removeLivroLidoPeloJovem(livroContador);
                    }
                    livroContador = -1;
                }

            }
            else {
                foreach (var livroSelecionado in livrosSelecionados) {
                    var livroEstaNaColecaoDoJovem = (jovemParametroEmAtualizacao.LivrosLidosPeloJovem.Where(lv => lv.Code == livroSelecionado.Code).Count() > 0) ? true : false;
                    if (livroEstaNaColecaoDoJovem == false)
                        jovemParametroEmAtualizacao.addLivroLidoPeloJovem(livroSelecionado);
                }
            }
        }
        protected bool ehMesEAnoChegadaIURDValido(string pMesAnoChegadaIURD) {
            var mesEAnoValido = false;

            if (string.IsNullOrEmpty(pMesAnoChegadaIURD)){
                mesEAnoValido = false;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') != -1 &&
                     pMesAnoChegadaIURD.Length < 7) {
                mesEAnoValido = false;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') == -1 &&
                     pMesAnoChegadaIURD.Length == 6) {
                mesEAnoValido = true;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') != -1 &&
                     pMesAnoChegadaIURD.Length       == 7  &&
                     (!ehDataInvertida(pMesAnoChegadaIURD)) ) {
                mesEAnoValido = true;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') == -1 &&
                     pMesAnoChegadaIURD.Length       == 4  &&
                     (int.Parse(pMesAnoChegadaIURD) >= 1977 && int.Parse(pMesAnoChegadaIURD) <= DateTime.Now.Year )) {
                mesEAnoValido = true;
            }            

            return mesEAnoValido;
        }

        protected bool ehDataInvertida(string pMesAnoChegadaIURD) {
            var dataEstaInvertida = (Regex.Match(pMesAnoChegadaIURD, @"[0-9]{4}/").Value.Replace("/", "").Length == 4)?true:false;
            if (dataEstaInvertida) {
                return true;
            }
            return false;
        }

        protected int RetornaAnoChegadaIURD(string pMesAnoChegadaIURD) {
            var anoRetorno = 0;

            if (pMesAnoChegadaIURD.Length == 7)
                anoRetorno = int.Parse(Regex.Match(pMesAnoChegadaIURD, @"/[0-9]{4}").Value.Replace("/", ""));
            else if (pMesAnoChegadaIURD.Length == 6)
                anoRetorno = int.Parse(pMesAnoChegadaIURD.Substring(1, 3));
            else if (pMesAnoChegadaIURD.Length == 4)
                anoRetorno = int.Parse(pMesAnoChegadaIURD);

            return anoRetorno;
        }

        protected int RetornaMesChegadaIURD(string pMesAnoChegadaIURD) {
            var mesRetorno = 0;

            if (pMesAnoChegadaIURD.Length == 7)
                mesRetorno = int.Parse(Regex.Match(pMesAnoChegadaIURD, @"[0-9]{1,2}/").Value.Replace("/", ""));
            else if (pMesAnoChegadaIURD.Length == 6)
                mesRetorno = int.Parse(pMesAnoChegadaIURD.Substring(0, 2));

            return mesRetorno;
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
    }
}