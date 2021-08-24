using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;

namespace SGFJU.Domain.UI
{
    public partial class RegistraCoordenadorFJU : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtNome"])) {
                SalvarCoordenador();
            }
        }

        private void SalvarCoordenador() {
            try {
                var facade = new FacadeCoordenadorImpl();
                var siglaEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado;
                var igrejaCoordenador = new Igreja { Id = int.Parse(Request.Form["cboIgreja"]) };
                var vDataNascimento = (!string.IsNullOrEmpty(Request.Form["txtDataNascimento"])) ? DateTime.Parse(Request.Form["txtDataNascimento"]) : DateTime.Parse("01/01/1990");
                var vDataEntradaCoordenador = (!string.IsNullOrEmpty(Request.Form["txtDataAssumiuFJU"])) ? DateTime.Parse(Request.Form["txtDataAssumiuFJU"]) : DateTime.Parse("01/01/1990");
                var estaNamorando = (string.IsNullOrEmpty(Request.Form["rbNamorandoAtualmente"])) ?
                                       'N' : char.Parse(Request.Form["rbNamorandoAtualmente"]);
                var estaGostandoDeAlguem = (string.IsNullOrEmpty(Request.Form["rbGostandoDeAlguem"])) ?
                                              'N' : char.Parse(Request.Form["rbGostandoDeAlguem"]);
                var nomePretendente = Request.Form["txtNomePretendente"];
                Jovem objCoordenadorFJU = null;
                var ehAssociacaoObreiroCoordenador = false;

                if (Session["CoordenadorSelecionado"] != null) {
                    objCoordenadorFJU = (Session["CoordenadorSelecionado"] as Jovem);
                    objCoordenadorFJU.SiglaEstadoJovem = UsuarioLogado.EstadoUsuario.SiglaEstado;
                    objCoordenadorFJU.SituacaoJovemIURDFJU = new SituacaoIURDFJU {
                        MesAnoSaidaObra = Request.Form["txtMesAnoSaiuObra"],
                        MesAnoFoiLevantadoObreiro = Request.Form["txtQuandoLevantadoObreiro"]
                    };
                    ehAssociacaoObreiroCoordenador = true;
                }
                else {
                    objCoordenadorFJU = new Jovem
                    {
                        Nome = Request.Form["txtNome"],
                        DataNascimento = vDataNascimento,
                        NomeArquivoFoto = FileUpload1.FileName,
                        SiglaEstadoJovem = siglaEstado,
                        EstadoCivilJovem = (!string.IsNullOrEmpty(Request.Form["cboTipoEstadoCivil"])) ? new TipoEstadoCivil { Code = int.Parse(Request.Form["cboTipoEstadoCivil"]) } : null,
                        ConjugeEhObreiro = (string.IsNullOrEmpty(Request.Form["rbConjugeEhObreiro"])) ?
                                              'N' :
                                              char.Parse(Request.Form["rbConjugeEhObreiro"]),
                        PossuiFilhos = (string.IsNullOrEmpty(Request.Form["rbPossuiFilhos"])) ? 'N' : char.Parse(Request.Form["rbPossuiFilhos"]),
                        QuantidadeFilhos = (!string.IsNullOrEmpty(Request.Form["txtQtdFilhos"])) ? int.Parse(Request.Form["txtQtdFilhos"]) : 0,
                        GostaDeAlguem = estaGostandoDeAlguem,
                        NamoraAtualmente = estaNamorando,
                        NomePretendente = nomePretendente,
                        EhPastor = (string.IsNullOrEmpty(Request.Form["rbObreiroPastor"])) ?
                                      false :
                                      (Request.Form["rbObreiroPastor"] == "P") ? true : false,
                        SituacaoJovemIURDFJU = new SituacaoIURDFJU
                        {
                            EhObreiro = (string.IsNullOrEmpty(Request.Form["rbObreiroPastor"])) ?
                                          'S' :
                                          (Request.Form["rbObreiroPastor"] == "P") ? 'N' : 'S',
                            MesAnoFoiLevantadoObreiro = Request.Form["txtQuandoLevantadoObreiro"],
                            DesejaFazerObraNoAltar = (string.IsNullOrEmpty(Request.Form["rbDesejaFazerObraAltar"])) ?
                                                        'N' :
                                                        char.Parse(Request.Form["rbDesejaFazerObraAltar"]),
                            FoiPastor = (string.IsNullOrEmpty(Request.Form["rbJaFoiPastorEsposaAntes"])) ?
                                            'N' :
                                            char.Parse(Request.Form["rbJaFoiPastorEsposaAntes"]),
                            MotivoSaidaPastor = Request.Form["txtMotivoSaidaPastorEsposa"],
                            MesAnoSaidaObra = Request.Form["txtMesAnoSaiuObra"]
                        },
                        IgrejaAQualJovemPertence = igrejaCoordenador
                    };

                    /*
                    objCoordenadorFJU = new Jovem
                    {
                        Nome = Request.Form["txtNome"],
                        DataNascimento = vDataNascimento,
                        NomeArquivoFoto = FileUpload1.FileName,
                        SiglaEstadoJovem = siglaEstado,
                        EstadoCivilJovem = (!string.IsNullOrEmpty(Request.Form["cboTipoEstadoCivil"])) ? new TipoEstadoCivil { Code = int.Parse(Request.Form["cboTipoEstadoCivil"]) } : null,
                        ConjugeEhObreiro = (string.IsNullOrEmpty(Request.Form["rbConjugeEhObreiro"])) ?
                                              'N' :
                                              char.Parse(Request.Form["rbConjugeEhObreiro"]),
                        PossuiFilhos = (string.IsNullOrEmpty(Request.Form["rbPossuiFilhos"])) ? 'N' : char.Parse(Request.Form["rbPossuiFilhos"]),
                        QuantidadeFilhos = (!string.IsNullOrEmpty(Request.Form["txtQtdFilhos"])) ? int.Parse(Request.Form["txtQtdFilhos"]) : 0,
                        GostaDeAlguem = estaGostandoDeAlguem,
                        NamoraAtualmente = estaNamorando,
                        NomePretendente = nomePretendente,
                        EhPastor = (string.IsNullOrEmpty(Request.Form["rbObreiroPastor"])) ?
                                      false :
                                      (Request.Form["rbObreiroPastor"] == "P") ? true : false,
                        SituacaoJovemIURDFJU = new SituacaoIURDFJU
                        {
                            EhObreiro = (string.IsNullOrEmpty(Request.Form["rbObreiroPastor"])) ?
                                          'S' :
                                          (Request.Form["rbObreiroPastor"] == "P") ? 'N' : 'S',
                            MesAnoFoiLevantadoObreiro = Request.Form["txtQuandoLevantadoObreiro"],
                            DesejaFazerObraNoAltar = (string.IsNullOrEmpty(Request.Form["rbDesejaFazerObraAltar"])) ?
                                                        'N' :
                                                        char.Parse(Request.Form["rbDesejaFazerObraAltar"]),
                            FoiPastor = (string.IsNullOrEmpty(Request.Form["rbJaFoiPastorEsposaAntes"])) ?
                                            'N' :
                                            char.Parse(Request.Form["rbJaFoiPastorEsposaAntes"]),
                            MotivoSaidaPastor = Request.Form["txtMotivoSaidaPastorEsposa"],
                            MesAnoSaidaObra = Request.Form["txtMesAnoSaiuObra"]
                        },
                        DadosEspirituaisJovem = new DadosEspirituais { },
                        DadosProfissionaisJovem = new DadosProfissionais { },
                        DadosEducacionaisJovem = new DadosEducacionais { },
                        RedeSocialJovem = new RedeSocial { },                        
                        IgrejaAQualJovemPertence = igrejaCoordenador
                    };*/
                }

                var novoCoordenador = new IgrejaCoordenador
                {
                    CoordenadorFJU = objCoordenadorFJU,
                    IgrejaFJU = igrejaCoordenador,
                    TotalAnosCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtAnosTotalCoodenadorFJU"])) ? int.Parse(Request.Form["txtAnosTotalCoodenadorFJU"]) : 0,
                    TotalMesesCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtMesesTotalCoodenadorFJU"])) ? int.Parse(Request.Form["txtMesesTotalCoodenadorFJU"]) : 0,
                    AnosCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(Request.Form["txtAnosCoodenandoFJUIgrejaAtual"])) ? int.Parse(Request.Form["txtAnosCoodenandoFJUIgrejaAtual"]) : 0,
                    MesesCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(Request.Form["txtMesesCoodenandoFJUIgrejaAtual"])) ? int.Parse(Request.Form["txtMesesCoodenandoFJUIgrejaAtual"]) : 0,
                    QuantidadeJovensEncontroAnterior = int.Parse(Request.Form["txtQtdJovensAnterior"]),
                    QuantidadeJovensEncontroAtual = int.Parse(Request.Form["txtQtdJovensAtual"]),
                    DataEntradaCoordenador = vDataEntradaCoordenador,
                    FoiEntrevistadoEstadualFJU = (string.IsNullOrEmpty(Request.Form["rbEntrevistadoEstadualFJU"])) ?
                                                    'N' :
                                                    char.Parse(Request.Form["rbEntrevistadoEstadualFJU"]),
                    NomeEstadualEntrevistou = Request.Form["txtNomeEstadualEntrevistou"],
                    MesAnoEntrevistaEstadual = Request.Form["txtMesAnoEntrevistaEstadual"]
                };

                if (ehAssociacaoObreiroCoordenador)
                    facade.AssociaObreiroComoCoordenador(novoCoordenador);
                else 
                    facade.RegistraCoordenador(novoCoordenador);

                uploadFotoJovem(novoCoordenador.CoordenadorFJU.Id, siglaEstado);

                Session.Remove("CoordenadorSelecionado");

                string script = "function f(){ mensagemConfirmacaoCadastro(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoCadastro();", true);
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
        private void uploadFotoJovem(int idCoordenador, string psiglaEstado)
        {
            try
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string SaveLocation = Server.MapPath("FotosJovens") + "\\" + FileUpload1.PostedFile.FileName;
                    FileUpload1.PostedFile.SaveAs(SaveLocation);

                    if (File.Exists(SaveLocation))
                    {
                        var nomeArquivoFormatado = RetornaArquivofotoJovemFormatado(idCoordenador, psiglaEstado, SaveLocation);

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
        protected string RetornaArquivofotoJovemFormatado(int idJovem, string pSiglaEstado, string filename)
        {
            string fDir = Path.GetDirectoryName(filename);
            string fName = Path.GetFileNameWithoutExtension(filename);
            string fExt = Path.GetExtension(filename);
            var data = DateTime.Now.ToString("yyyy-MM-dd");
            var hora = DateTime.Now.Hour.ToString();
            var minutos = DateTime.Now.Minute.ToString();
            var segundos = DateTime.Now.Second.ToString();
            var siglaEstado = pSiglaEstado;
            string suffix = $"{siglaEstado}_ID_COORDENADOR_{idJovem}_{data}{hora}";
            string renamedFilePath = Path.Combine(fDir, String.Concat(suffix, fName, fExt));
            return renamedFilePath;
        }
    }
}