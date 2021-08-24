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
    public partial class AlteraUsuario : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(Request.Form["txtNomeUsuario"])) {
                SalvarAlteracoes();
            }
        }
        private void SalvarAlteracoes() {
            try {
                var usuarioFacade = new FacadeUsuarioImpl();
                var UsuarioEmAtualizacao = Session["UsuarioEmAtualizacao"] as UsuarioDTO;
                var siglaEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado;
                var ehUsuarioDeBloco = (Request.Form["cboTipoUsuario"] == "7") ? true : false;
                var ehUsuarioDeRegiao = (Request.Form["cboTipoUsuario"] == "9") ? true : false;
                var nomeFotoAntesAtualizacao = UsuarioEmAtualizacao.PathImagemUsuario;
                var usuarioParaAtualizar = new Usuario
                {
                    Id = UsuarioEmAtualizacao.IdUsuario,
                    NomeUsuario = Request.Form["txtNomeUsuario"],
                    Login = Request.Form["txtLogin"],
                    Senha = Request.Form["txtPwd"],
                    EstadoUsuario = new Estado {
                        Id = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id,
                        SiglaEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado
                    },
                    NomeArquivoPerfil = FileUpload1.PostedFile.FileName,
                    PerfilUsuario = new PerfilUsuario { Code = int.Parse( Request.Form["cboTipoUsuario"] ) }
                };

                if (ehUsuarioDeBloco){
                    usuarioParaAtualizar.BlocoUsuario = new Bloco { Id = int.Parse(Request.Form["cboBloco"]) };
                }
                else if (ehUsuarioDeRegiao) {
                    usuarioParaAtualizar.BlocoUsuario = new Bloco { Id = int.Parse(Request.Form["cboBloco"]) };
                    usuarioParaAtualizar.RegiaoUsuario = new Regiao { Id = int.Parse(Request.Form["cboRegiao"]) };
                }

                usuarioFacade.RegistraUsuario(usuarioParaAtualizar);

                base.RegistraAcaoUsuarioLogado($"Atualização do Usuário {UsuarioEmAtualizacao.IdUsuario} e Login {UsuarioEmAtualizacao.Login} ");

                uploadFotoJovem(nomeFotoAntesAtualizacao, UsuarioEmAtualizacao.IdUsuario, siglaEstado);

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
        private string uploadFotoJovem(string nomeArquivoFotoJovem, int idJovem, string psiglaEstado)
        {
            try
            {
                var nomeArquivoRetorno = string.Empty;
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    if (string.Compare(FileUpload1.PostedFile.FileName, nomeArquivoFotoJovem, StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        var data = DateTime.Now.ToString("yyyy-MM-dd");
                        var hora = DateTime.Now.Hour.ToString();
                        var siglaEstado = psiglaEstado;
                        var arquivoUpload = FileUpload1.FileName;
                        nomeArquivoRetorno = $"{siglaEstado}_ID_{idJovem}_{data}{hora}_{arquivoUpload}";

                        if (string.IsNullOrEmpty(nomeArquivoFotoJovem))
                        {
                            string SaveLocation = Server.MapPath("FotosJovens") + "\\" + FileUpload1.PostedFile.FileName;

                            FileUpload1.PostedFile.SaveAs(SaveLocation);

                            var nomeArquivoFormatado = RetornaArquivofotoJovemFormatado(idJovem, psiglaEstado, SaveLocation);

                            File.Move(SaveLocation, nomeArquivoFormatado);
                            File.Delete(SaveLocation);
                        }
                        else
                        {
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
            var siglaEstado = pSiglaEstado;
            string suffix = $"{siglaEstado}_ID_{idJovem}_{data}{hora}_";
            string renamedFilePath = Path.Combine(fDir, String.Concat(suffix, fName, fExt));
            return renamedFilePath;
        }
    }
}