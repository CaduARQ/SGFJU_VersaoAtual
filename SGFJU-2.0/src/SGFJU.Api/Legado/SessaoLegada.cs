using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;

namespace SGFJU.Api.Legado
{
    /// <summary>
    /// Substitui o HttpSessionState do ASP.NET clássico. Os controllers antigos guardavam listas
    /// temporárias na sessão (idiomas, habilidades, cursos durante o cadastro do jovem).
    /// Aqui os objetos ficam em memória, indexados pelo identificador de sessão gravado no cookie
    /// de autenticação, e expiram após 2 horas sem uso — o mesmo comportamento do InProc do IIS.
    /// Observação: assim como no IIS InProc, isso supõe um único servidor (ou sticky sessions).
    /// </summary>
    public sealed class SessaoLegada
    {
        private static readonly TimeSpan Expiracao = TimeSpan.FromHours(2);
        private readonly IMemoryCache __cache;
        private readonly string __idSessao;
        private readonly Func<object> __carregarUsuario;

        public SessaoLegada(IMemoryCache cache, string idSessao, Func<object> carregarUsuario)
        {
            __cache = cache;
            __idSessao = idSessao;
            __carregarUsuario = carregarUsuario;
        }

        private ConcurrentDictionary<string, object> Itens =>
            __cache.GetOrCreate("sessao:" + __idSessao, entrada =>
            {
                entrada.SlidingExpiration = Expiracao;
                return new ConcurrentDictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            });

        public object this[string chave]
        {
            get
            {
                // O usuário logado não fica na sessão: vem do cookie de autenticação.
                if (string.Equals(chave, "UsuarioLogado", StringComparison.OrdinalIgnoreCase))
                    return __carregarUsuario();
                return Itens.TryGetValue(chave, out var valor) ? valor : null;
            }
            set
            {
                if (value == null) Itens.TryRemove(chave, out _);
                else Itens[chave] = value;
            }
        }

        public void Add(string chave, object valor) => this[chave] = valor;
        public void Remove(string chave) => Itens.TryRemove(chave, out _);
        public void Clear() => __cache.Remove("sessao:" + __idSessao);
    }
}
