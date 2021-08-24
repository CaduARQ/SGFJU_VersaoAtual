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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.Domain.UI
{
    public partial class AlteraCoordenador : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(Request.Form["txtNome"])) {
                SalvarAlteracoes();
            }
        }
        private void SalvarAlteracoes() {
            try {
                var facade = new FacadeCoordenadorImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var siglaEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado;
                var coordenadorNaSessao = Session["CoordenadorAtualizacaoSessao"] as IgrejaCoordenadorDTO;
                var coordenadorParaAtualizar = facade.ObterIgrejaCoordenadorPorID(coordenadorNaSessao.IdIgrejaCoordenador);

                var vDataNascimento = coordenadorParaAtualizar.CoordenadorFJU.DataNascimento;

                var estaNamorando = (string.IsNullOrEmpty(Request.Form["rbNamorandoAtualmente"])) ?
                                       'N' : char.Parse(Request.Form["rbNamorandoAtualmente"]);

                var estaGostandoDeAlguem = (string.IsNullOrEmpty(Request.Form["rbGostandoDeAlguem"])) ?
                                              'N' : char.Parse(Request.Form["rbGostandoDeAlguem"]);

                var nomePretendente = Request.Form["txtNomePretendente"];
                var nomeFotoAntesAtualizacao = coordenadorParaAtualizar.CoordenadorFJU.NomeArquivoFoto;
                var nomeArquivofotoPosAtualizacao = uploadFotoJovem(nomeFotoAntesAtualizacao, coordenadorNaSessao.IdCoordenadorFJU, siglaEstado);

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------
                if (Session["Coordenadores_DataNascimentoAlterada"] != null) 
                    vDataNascimento = DateTime.ParseExact(Session["Coordenadores_DataNascimentoAlterada"].ToString(), "dd/MM/yyyy", null);       
                //else
                //    coordenadorParaAtualizar.CoordenadorFJU.DataNascimento = DateTime.ParseExact(coordenadorParaAtualizar.CoordenadorFJU.DataNascimento.ToString(), "dd/MM/yyyy", null);

                if (Session["Coordenadores_DataAssumiurFJUAlterada"] != null) {
                    coordenadorParaAtualizar.DataEntradaCoordenador = DateTime.ParseExact(Session["Coordenadores_DataAssumiurFJUAlterada"].ToString(), "dd/MM/yyyy", null);
                }
                //----------------------------------------------------------------------------------------------------------------------------------------------------------------

                coordenadorParaAtualizar.CoordenadorFJU.Id = coordenadorNaSessao.IdCoordenadorFJU;
                coordenadorParaAtualizar.CoordenadorFJU.Nome = Request.Form["txtNome"];
                coordenadorParaAtualizar.CoordenadorFJU.DataNascimento = vDataNascimento;

                coordenadorParaAtualizar.CoordenadorFJU.NomeArquivoFoto 
                    = (string.IsNullOrEmpty(nomeArquivofotoPosAtualizacao))? 
                         coordenadorParaAtualizar. CoordenadorFJU.NomeArquivoFoto:nomeArquivofotoPosAtualizacao;

                coordenadorParaAtualizar.CoordenadorFJU.SiglaEstadoJovem = siglaEstado;

                coordenadorParaAtualizar.CoordenadorFJU.EstadoCivilJovem 
                    = (!string.IsNullOrEmpty(Request.Form["cboTipoEstadoCivil"])) ? 
                         new TipoEstadoCivil { Code = int.Parse(Request.Form["cboTipoEstadoCivil"]) } : 
                         null;

                coordenadorParaAtualizar.CoordenadorFJU.NomeConjuge = Request.Form["txtNomeconjuge"];

                coordenadorParaAtualizar.CoordenadorFJU.ConjugeEhObreiro = (string.IsNullOrEmpty(Request.Form["rbConjugeEhObreiro"])) ?
                                              'N' :
                                              char.Parse(Request.Form["rbConjugeEhObreiro"]);
                coordenadorParaAtualizar.CoordenadorFJU.PossuiFilhos = (string.IsNullOrEmpty(Request.Form["rbPossuiFilhos"])) ? 'N' : char.Parse(Request.Form["rbPossuiFilhos"]);
                coordenadorParaAtualizar.CoordenadorFJU.QuantidadeFilhos = (!string.IsNullOrEmpty(Request.Form["txtQtdFilhos"])) ? int.Parse(Request.Form["txtQtdFilhos"]) : 0;
                coordenadorParaAtualizar.CoordenadorFJU.GostaDeAlguem = estaGostandoDeAlguem;
                coordenadorParaAtualizar.CoordenadorFJU.NamoraAtualmente = estaNamorando;
                coordenadorParaAtualizar.CoordenadorFJU.NomePretendente = nomePretendente;

                coordenadorParaAtualizar.CoordenadorFJU.EhPastor =
                    (string.IsNullOrEmpty(Request.Form["rbObreiroPastor"])) ?
                       false :
                       (Request.Form["rbObreiroPastor"] == "P") ? true : false;

                coordenadorParaAtualizar.CoordenadorFJU.SituacaoJovemIURDFJU = 
                    new SituacaoIURDFJU
                    {
                        Code = coordenadorParaAtualizar.CoordenadorFJU.SituacaoJovemIURDFJU.Code,

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
                    };

                coordenadorParaAtualizar.TotalAnosCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtAnosTotalCoodenadorFJU"])) ? int.Parse(Request.Form["txtAnosTotalCoodenadorFJU"]) : 0;
                coordenadorParaAtualizar.TotalMesesCoordenandoFJU = (!string.IsNullOrEmpty(Request.Form["txtMesesTotalCoodenadorFJU"])) ? int.Parse(Request.Form["txtMesesTotalCoodenadorFJU"]) : 0;

                coordenadorParaAtualizar.AnosCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(Request.Form["txtAnosCoodenandoFJUIgrejaAtual"])) ? int.Parse(Request.Form["txtAnosCoodenandoFJUIgrejaAtual"]) : 0;
                coordenadorParaAtualizar.MesesCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(Request.Form["txtMesesCoodenandoFJUIgrejaAtual"])) ? int.Parse(Request.Form["txtMesesCoodenandoFJUIgrejaAtual"]) : 0;

                coordenadorParaAtualizar.QuantidadeJovensEncontroAnterior = int.Parse(Request.Form["txtQtdJovensAnterior"]);
                coordenadorParaAtualizar.QuantidadeJovensEncontroAtual = int.Parse(Request.Form["txtQtdJovensAtual"]);

                coordenadorParaAtualizar.FoiEntrevistadoEstadualFJU =
                    (string.IsNullOrEmpty(Request.Form["rbEntrevistadoEstadualFJU"])) ?
                       'N' :
                       char.Parse(Request.Form["rbEntrevistadoEstadualFJU"]);

                coordenadorParaAtualizar.NomeEstadualEntrevistou = Request.Form["txtNomeEstadualEntrevistou"];

                coordenadorParaAtualizar.MesAnoEntrevistaEstadual = Request.Form["txtMesAnoEntrevistaEstadual"];

                facade.AtualizarCoordenador(coordenadorParaAtualizar);

                (base.UserLogger as UserLoggerImpl).WriteUserAction(new LogUsuarioDTO
                {
                    IdLogUsuario = usuarioLogado.Id + DateTime.Now.Millisecond,
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"Atualização do Coordenador {coordenadorParaAtualizar.CoordenadorFJU.Id} e nome {coordenadorParaAtualizar.CoordenadorFJU.Nome} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = siglaEstado
                });
                
                LimpaSessao();
                string script = "function f(){ mensagemConfirmacaoAtualizacao(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoAtualizacao();", true);
            }
            catch (DomainException excDominio) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemErroInadequadoSistema();", true);
            }
            catch (FacadeException excBussiness) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemErroInadequadoSistema();", true);
            }
            catch (Exception generalException) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemErroInadequadoSistema();", true);
            }
        }
        private string uploadFotoJovem(string nomeArquivoFotoJovem, int idJovem, string psiglaEstado)
        {
            try
            {
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

                            var nomeArquivoFormatado = RetornaArquivoFotoCoordenadorFormatado(idJovem, psiglaEstado, SaveLocation);

                            File.Move(SaveLocation, nomeArquivoFormatado);
                            File.Delete(SaveLocation);
                        }
                        else {
                            //excluo o anterior
                            //File.Delete(Server.MapPath("FotosJovens") + "\\" + nomeArquivoFotoJovem);

                            string SaveLocation = Server.MapPath("FotosJovens") + "\\" + FileUpload1.PostedFile.FileName;

                            FileUpload1.PostedFile.SaveAs(SaveLocation);

                            var nomeArquivoFormatado = RetornaArquivoFotoCoordenadorFormatado(idJovem, psiglaEstado, SaveLocation);

                            File.Move(SaveLocation, nomeArquivoFormatado);
                            //File.Delete(SaveLocation);"FotosJovens") + "\\" + nomeArquivoFotoJovem
                            File.Delete(Server.MapPath("FotosJovens") + "\\" + nomeArquivoFotoJovem);
                        }
                    }
                }
                return nomeArquivoRetorno;
            }
            catch (Exception excUploadFoto)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excUploadFoto, "CAMADA_APP");
                throw new Exception(mensagemErroExcecao);
            }
        }
        protected string RetornaArquivoFotoCoordenadorFormatado(int idJovem, string pSiglaEstado, string filename)
        {
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
        private void LimpaSessao() {
            Session.Remove("Coordenadores_DataNascimentoAlterada");
            Session.Remove("Coordenadores_DataAssumiurFJUAlterada");
            Session.Remove("CoordenadorAtualizacaoSessao");
        }
    }
}