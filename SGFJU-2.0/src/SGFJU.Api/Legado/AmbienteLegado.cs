using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SGFJU.Api.Legado
{
    /// <summary>
    /// Substitui System.Web.Hosting.HostingEnvironment.MapPath e HttpContext.Current do .NET Framework.
    /// Os caminhos "~/" passam a apontar para a pasta configurada em Sgfju:PastaConteudoLegado
    /// (por padrão, a pasta SGFJU.Domain.UI, onde ficam Serializeds, LogWebApp, FotosJovens etc.).
    /// </summary>
    public static class AmbienteLegado
    {
        private static IHttpContextAccessor __httpContextAccessor;

        public static string PastaConteudo { get; private set; } = AppContext.BaseDirectory;

        public static void Configurar(IHttpContextAccessor httpContextAccessor, string pastaConteudo)
        {
            __httpContextAccessor = httpContextAccessor;
            PastaConteudo = Path.GetFullPath(pastaConteudo);
        }

        public static HttpContext HttpContextAtual =>
            __httpContextAccessor?.HttpContext
            ?? throw new InvalidOperationException("Não há requisição HTTP em andamento.");

        /// <summary>Equivalente a HostingEnvironment.MapPath("~/pasta/arquivo").</summary>
        public static string MapPath(string caminhoVirtual)
        {
            if (string.IsNullOrEmpty(caminhoVirtual)) return PastaConteudo;

            var relativo = caminhoVirtual.Replace('\\', '/');
            if (relativo.StartsWith("~")) relativo = relativo.Substring(1);
            relativo = relativo.TrimStart('/');

            // Compatibilidade com o caminho antigo do IIS (aplicação publicada em /SGFJU2.0).
            if (relativo.StartsWith("SGFJU2.0/", StringComparison.OrdinalIgnoreCase))
                relativo = relativo.Substring("SGFJU2.0/".Length);

            var caminhoFisico = Path.Combine(PastaConteudo, relativo);
            if (caminhoVirtual.EndsWith("/") || caminhoVirtual.EndsWith("\\"))
                caminhoFisico = caminhoFisico.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            return caminhoFisico;
        }
    }
}
