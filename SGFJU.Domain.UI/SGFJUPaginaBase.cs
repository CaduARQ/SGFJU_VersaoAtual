using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Logging.Abstractions;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SGFJU.Domain.UI
{
    public class SGFJUPaginaBase : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            try {
            }
            catch (Exception ex){
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

        public void RegistraAcaoUsuarioLogado(string pDescricaoAcao) {
            var siglaEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado;
            var usuarioLogadosistema = SessionHelper.RetornaUsuarioLogado();
            (this.UserLogger as UserLoggerImpl).WriteUserAction(new LogUsuarioDTO
            {
                DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                DescricaoAcaoUsuario = $"{pDescricaoAcao} - Realizada pelo usuário de ID: {usuarioLogadosistema.Id} e Login: {usuarioLogadosistema.Login} ",
                HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                IdUsuario = usuarioLogadosistema.Id,
                SiglaEstadoUsuario = siglaEstado
            });
        }
        private Usuario __usuarioLogado;
        public Usuario UsuarioLogado {
            get {
                __usuarioLogado = (Session["UsuarioLogado"] != null) ? ((Usuario)Session["UsuarioLogado"]) : null;
                return __usuarioLogado;
            }
            set { __usuarioLogado = value; } 
        }
        public ErrorLogger LoggerErrorApp
        {
            get
            {
                var pathArquivoLoggerError =
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] +
                        ConfigurationManager.AppSettings["LoggerErrorFileName"]
                    );//System.Web.Hosting.HostingEnvironment.MapPath("~/LogWebApp/ErrorApp.txt");
                var errorLogger = new ErrorLoggerImpl(pathArquivoLoggerError);
                return errorLogger;
            }
        }
        public UserLogger UserLogger
        {
            get
            {
                var pathArquivoUserActions =
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] +
                        ConfigurationManager.AppSettings["LoggerUserFileName"]
                    );
                var loggerUsuario = new UserLoggerImpl(pathArquivoUserActions);
                return loggerUsuario;
            }
        }
        public bool EhADM
        {
            get
            {
                var codigoPerfilADM = int.Parse(ConfigurationManager.AppSettings["CodeADM"]);
                if (this.UsuarioLogado != null)
                {
                    if (UsuarioLogado.PerfilUsuario.Code == codigoPerfilADM)
                    {
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