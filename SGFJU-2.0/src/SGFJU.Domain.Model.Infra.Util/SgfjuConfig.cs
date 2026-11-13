using System;
using System.Collections.Generic;

namespace SGFJU.Domain.Model.Infra.Util
{
    /// <summary>
    /// Substitui o System.Configuration.ConfigurationManager (web.config) usado no .NET Framework.
    /// A API (ASP.NET Core) preenche estes valores na inicialização a partir do appsettings.json,
    /// variáveis de ambiente ou User Secrets. Nenhuma senha deve ficar versionada no código.
    /// </summary>
    public static class SgfjuConfig
    {
        private static readonly Dictionary<string, string> __appSettings =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static string ConnectionString { get; private set; } = string.Empty;

        public static void Configure(string connectionString, IDictionary<string, string> appSettings)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException(
                    "A connection string 'banco' não foi configurada. Defina ConnectionStrings__banco " +
                    "por variável de ambiente ou User Secrets.");

            ConnectionString = connectionString;
            __appSettings.Clear();
            if (appSettings == null) return;
            foreach (var item in appSettings)
                __appSettings[item.Key] = item.Value;
        }

        /// <summary>Equivalente a ConfigurationManager.AppSettings["chave"]. Retorna null se não existir.</summary>
        public static string Get(string key)
        {
            return __appSettings.TryGetValue(key, out var value) ? value : null;
        }
    }
}
