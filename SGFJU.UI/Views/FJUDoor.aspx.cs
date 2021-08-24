using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using System;
using System.Configuration;
using System.Web.UI;

namespace SGFJU.UI.Views
{
    public partial class FJUDoor2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                VerificaUsuarioLogado();
        }
        protected void VerificaUsuarioLogado()
        {
            if (Session["UsuarioLogado"] != null)
                Response.Redirect("../Views/RegistraJovem.aspx");
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var folderFileLogger = System.Web.Hosting.HostingEnvironment.MapPath("~/LogWebApp/");
            var pathArquivoUserActions =
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] +
                        ConfigurationManager.AppSettings["LoggerUserFileName"]
                    );
            try
            {
                var facadeUsuario = new FacadeUsuarioImpl();
                var login = Request.Form["username"];
                var senha = Request.Form["password"];

                var usuarioRetornado = facadeUsuario.Loggar(login, senha);
                var loggerUsuario = new UserLoggerImpl(pathArquivoUserActions);

                
                if (usuarioRetornado != null) {
                    Session.Add("UsuarioLogado", usuarioRetornado);
                    loggerUsuario.WriteUserAction("Acessou o sistema", "Acesso", usuarioRetornado);
                    Response.Redirect("../Views/RegistraJovem.aspx");
                }
                else
                    RadWindowManager1.RadAlert("Usuário não encontrado", 200, 100, "Mensagem de alerta", null);
            }
            catch (FacadeException bussinessTierException) {
                RadWindowManager1.RadAlert("O sistema de comportou de forma inadequada, por favor tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
                var Errorlogger = new ErrorLoggerImpl(folderFileLogger + "ErrorApp.txt");
                Errorlogger.WriteLog("TelaLogin.Camada de negócios:" + bussinessTierException.InnerException.Message + " Gerado por: " + bussinessTierException.TargetSite + "pilha" + bussinessTierException.StackTrace);
            }
            catch (Exception GeneralException)
            {
                if (!(GeneralException is System.Threading.ThreadAbortException)) {
                    RadWindowManager1.RadAlert("O sistema de comportou de forma inadequada, por favor tente mais tarde",
                                           400,
                                           150,
                                           "Mensagem de alerta",
                                           null);
                    var Errorlogger = new ErrorLoggerImpl(folderFileLogger + "ErrorApp.txt");
                    Errorlogger.WriteLog(GeneralException.Message);
                }
            }
        }

    }
}