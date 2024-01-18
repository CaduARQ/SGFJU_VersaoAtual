using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.Domain.UI
{
    public partial class formLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack)
                VerificaUsuarioLogado();
        }
        protected void VerificaUsuarioLogado() {
            if (Session["UsuarioLogado"] != null)
                Response.Redirect("RegistraJovem.aspx");
            else {
                var login = Request.Form["login"];
                var senha = Request.Form["senha"];
                
                if(!string.IsNullOrEmpty(login) &&
                   !string.IsNullOrEmpty(senha) )
                    logar();
            }
                
        }
        private void logar()
        {
            var folderFileLogger = System.Web.Hosting.HostingEnvironment.MapPath("~/LogWebApp/");
            var pathArquivoUserActions =
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] +
                        ConfigurationManager.AppSettings["LoggerUserFileName"]
                    );
            try{
                var facadeUsuario = new FacadeUsuarioImpl();
                var login = Request.Form["login"];
                var senha = Request.Form["senha"];

                var usuarioRetornado = facadeUsuario.Loggar(login, senha);
                var loggerUsuario = new UserLoggerImpl(pathArquivoUserActions);                

                if (usuarioRetornado != null)
                {
                    var codigoADM = int.Parse(ConfigurationManager.AppSettings["CodeADM"]);
                    var codigoPrEstadual = int.Parse(ConfigurationManager.AppSettings["CodePastorEstadual"]);
                    Session.Add("UsuarioLogado", usuarioRetornado);

                    loggerUsuario.WriteUserAction(usuarioRetornado.Id, usuarioRetornado.EstadoUsuario.SiglaEstado, $"O usuário {usuarioRetornado.Login} acessou o sistema");

                    if (usuarioRetornado.PerfilUsuario.Code == codigoADM)
                        Response.Redirect("DashboardNacional.html");
                    else if (usuarioRetornado.PerfilUsuario.Code == codigoPrEstadual)
                        Response.Redirect("DashboardEstadual.html");
                    else if(usuarioRetornado.PerfilUsuario.Descricao == "ConsultaCamisa")
                        Response.Redirect("GerenciaCamisasFJU.html");
                    else if (usuarioRetornado.PerfilUsuario.Descricao == "SecretariaBR")
                        Response.Redirect("PainelControle.html");
                    else if (usuarioRetornado.PerfilUsuario.Descricao == "Coordenador Projeto Help")
                        Response.Redirect("GerenciarInstituicaoEnsino.html");
                    else
                        Response.Redirect("RegistraJovem.aspx");
                }
                else
                    Response.Write("Usuário não encontrado");
            }
            catch (FacadeException bussinessTierException){
                //Response.Write("O sistema de comportou de forma inadequada, por favor tente mais tarde");
                var Errorlogger = new ErrorLoggerImpl(folderFileLogger + "ErrorApp.txt");
                Errorlogger.WriteLog("TelaLogin.Camada de negócios:" + bussinessTierException.Message + " Gerado por: " + bussinessTierException.TargetSite + "pilha" + bussinessTierException.StackTrace);
            }
            catch (Exception GeneralException){
                if (!(GeneralException is System.Threading.ThreadAbortException)){                    
                    var Errorlogger = new ErrorLoggerImpl(folderFileLogger + "ErrorApp.txt");
                    Errorlogger.WriteLog(GeneralException.Message);
                }
            }
        }
    }
}