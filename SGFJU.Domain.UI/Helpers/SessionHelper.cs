using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SGFJU.Domain.UI.Helpers
{
    public static class SessionHelper
    {
        public static HttpSessionState RetornaSessaoAtual()
        {
            return (System.Web.HttpContext.Current.Session);
        }

        public static Usuario RetornaUsuarioLogado()
        {
            var sessaoAtual = (System.Web.HttpContext.Current.Session);
            return (sessaoAtual["UsuarioLogado"] as Usuario);
        }

        public static UserLoggerImpl ObterLoogerParaController() {
            var pathArquivoUserActions =
                    System.Web.Hosting.HostingEnvironment.MapPath(
                        ConfigurationManager.AppSettings["LoggerFilePath"] +
                        ConfigurationManager.AppSettings["LoggerUserFileName"]
                    );
            return new UserLoggerImpl(pathArquivoUserActions);
        }
    }
}