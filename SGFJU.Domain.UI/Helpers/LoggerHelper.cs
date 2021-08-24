using SGFJU.Domain.Model.Infra.Logging.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SGFJU.Domain.UI.Helpers
{
    public static class LoggerHelper
    {
        public static void WriteLogError(string errorMessage) {
            var pathArquivoLoggerError =
                        System.Web.Hosting.HostingEnvironment.MapPath(
                            ConfigurationManager.AppSettings["LoggerFilePath"] +
                            ConfigurationManager.AppSettings["LoggerErrorFileName"]
                        );//System.Web.Hosting.HostingEnvironment.MapPath("~/LogWebApp/ErrorApp.txt");
            var errorLogger = new ErrorLoggerImpl(pathArquivoLoggerError);
            errorLogger.WriteLog(errorMessage);
        }
    }
}