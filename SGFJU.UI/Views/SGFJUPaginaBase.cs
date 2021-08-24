using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Logging.Abstractions;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SGFJU.UI.Views
{
    public class SGFJUPaginaBase : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            //var objLogger = new LoggerImpl();
            try {
                //if (!Page.IsPostBack)
                VerificaUsuarioLogado();
            }
            catch (Exception ex) {
                //objLogger.WriteLog(ex.Message, TipoLog.ErroSistemico);
            }
        }
        private void VerificaUsuarioLogado()
        {
            if (Session["UsuarioLogado"] != null)
                this.UsuarioLogado = (Usuario)Session["UsuarioLogado"];
            else
                Response.Redirect("../Views/FJUDoor.aspx");
        }
        public Usuario UsuarioLogado { get; set; }
        public ErrorLogger LoggerErrorApp { 
            get {
                var pathArquivoLoggerError = 
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] + 
                        ConfigurationManager.AppSettings["LoggerErrorFileName"]
                    );//System.Web.Hosting.HostingEnvironment.MapPath("~/LogWebApp/ErrorApp.txt");
                var errorLogger = new ErrorLoggerImpl(pathArquivoLoggerError);
                return errorLogger;
            } 
        }
        public UserLogger UserLogger {
            get {
                var pathArquivoUserActions =
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] +
                        ConfigurationManager.AppSettings["LoggerUserFileName"]
                    );
                var loggerUsuario = new UserLoggerImpl(pathArquivoUserActions);
                return loggerUsuario;
            }
        }
        public bool EhADM {
            get {
                var codigoPerfilADM = int.Parse(ConfigurationManager.AppSettings["CodeADM"]);
                if (this.UsuarioLogado != null) {
                    if (UsuarioLogado.PerfilUsuario.Code == codigoPerfilADM) {
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
        }
    }
}