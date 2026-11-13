using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Util;

namespace SGFJU.Api.Legado
{
    public static class LoggerHelper
    {
        public static void WriteLogError(string errorMessage)
        {
            var caminho = AmbienteLegado.MapPath(
                SgfjuConfig.Get("LoggerFilePath") + SgfjuConfig.Get("LoggerErrorFileName"));
            new ErrorLoggerImpl(caminho).WriteLog(errorMessage);
        }
    }
}
