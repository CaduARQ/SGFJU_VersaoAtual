using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Domain.UI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.Domain.UI
{
    public partial class RegistraUsuario : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtNomeUsuario"])) {
                SalvarUsuario();
            }
        }

        private void SalvarUsuario() {
            try {
                var usuarioFacade = new FacadeUsuarioImpl();
                var siglaEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado;
                var ehUsuarioDeBloco = (Request.Form["cboTipoUsuario"] == "7") ? true : false;
                var ehUsuarioDeRegiao = (Request.Form["cboTipoUsuario"] == "9") ? true : false;
                var novoUsuario = new Usuario
                {
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
                    novoUsuario.BlocoUsuario = new Bloco { Id = int.Parse(Request.Form["cboBloco"]) };
                }
                else if (ehUsuarioDeRegiao) {
                    novoUsuario.BlocoUsuario = new Bloco { Id = int.Parse(Request.Form["cboBloco"]) };
                    novoUsuario.RegiaoUsuario = new Regiao { Id = int.Parse(Request.Form["cboRegiao"]) };
                }

                usuarioFacade.RegistraUsuario(novoUsuario);

                (base.UserLogger as UserLoggerImpl).WriteUserAction(UsuarioLogado.Id, UsuarioLogado.EstadoUsuario.SiglaEstado, $"O usuário {UsuarioLogado.Login} cadastrou um novo usuário com ID {novoUsuario.Id} ");

                uploadFotoUsuario(novoUsuario.Id, siglaEstado);

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
        private void uploadFotoUsuario(int idUsuario, string psiglaEstado)
        {
            try
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string SaveLocation = Server.MapPath("FotosUsuarios") + "\\" + FileUpload1.PostedFile.FileName;
                    FileUpload1.PostedFile.SaveAs(SaveLocation);

                    if (File.Exists(SaveLocation))
                    {
                        var nomeArquivoFormatado = RetornaArquivofotoJovemFormatado(idUsuario, psiglaEstado, SaveLocation);

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
            string suffix = $"{siglaEstado}_ID_USUARIO_{idJovem}_{data}{hora}";
            string renamedFilePath = Path.Combine(fDir, String.Concat(suffix, fName, fExt));
            return renamedFilePath;
        }

    }
}