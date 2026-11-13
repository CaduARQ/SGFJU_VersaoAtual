using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Domain.Model.ValueObjects;

namespace SGFJU.Api.Legado
{
    /// <summary>
    /// Mesma API do SessionHelper antigo, agora baseada no cookie de autenticação do ASP.NET Core.
    /// </summary>
    public static class SessionHelper
    {
        public const string ClaimIdSessao = "sgfju:sid";
        private const string ChaveUsuarioNaRequisicao = "__UsuarioLogado";

        public static SessaoLegada RetornaSessaoAtual()
        {
            var contexto = AmbienteLegado.HttpContextAtual;
            var idSessao = contexto.User?.FindFirstValue(ClaimIdSessao) ?? "anonimo";
            var cache = contexto.RequestServices.GetRequiredService<IMemoryCache>();
            return new SessaoLegada(cache, idSessao, () => RetornaUsuarioLogado());
        }

        public static Usuario RetornaUsuarioLogado()
        {
            var contexto = AmbienteLegado.HttpContextAtual;
            if (contexto.Items.TryGetValue(ChaveUsuarioNaRequisicao, out var emCache))
                return emCache as Usuario;

            Usuario usuario = null;
            var idTexto = contexto.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(idTexto, out var idUsuario))
                usuario = new FacadeUsuarioImpl().GetByID(idUsuario);

            contexto.Items[ChaveUsuarioNaRequisicao] = usuario;
            return usuario;
        }

        public static UserLoggerImpl ObterLoogerParaController()
        {
            var caminho = AmbienteLegado.MapPath(
                SgfjuConfig.Get("LoggerFilePath") + SgfjuConfig.Get("LoggerUserFileName"));
            return new UserLoggerImpl(caminho);
        }

        public static Estado RetornaEstadoUsuarioLogado() => RetornaUsuarioLogado()?.EstadoUsuario;

        public static PerfilUsuario RetornaPerfilUsuarioLogado() => RetornaUsuarioLogado()?.PerfilUsuario;
    }
}
