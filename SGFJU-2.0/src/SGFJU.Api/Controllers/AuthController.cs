using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGFJU.Api.Legado;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Util;

namespace SGFJU.Api.Controllers
{
    /// <summary>
    /// Substitui a tela formLogin.aspx: autentica e grava um cookie HttpOnly.
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        public sealed class LoginRequest
        {
            public string Login { get; set; }
            public string Senha { get; set; }
        }

        public sealed class UsuarioLogadoResponse
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Login { get; set; }
            public int CodigoPerfil { get; set; }
            public string Perfil { get; set; }
            public int IdEstado { get; set; }
            public string Estado { get; set; }
            public string SiglaEstado { get; set; }
            public int IdBloco { get; set; }
            public string Bloco { get; set; }
            public int IdRegiao { get; set; }
            public string Regiao { get; set; }
            public string Foto { get; set; }
            public bool EhAdm { get; set; }
            public string PaginaInicial { get; set; }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLogadoResponse>> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Login) || string.IsNullOrWhiteSpace(request.Senha))
                return BadRequest(new { mensagem = "Informe login e senha." });

            var usuario = new FacadeUsuarioImpl().Loggar(request.Login.Trim(), request.Senha);
            if (usuario == null)
                return Unauthorized(new { mensagem = "Login ou senha inválidos." });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Login ?? string.Empty),
                new Claim(ClaimTypes.Role, usuario.PerfilUsuario?.Code.ToString() ?? "0"),
                new Claim(SessionHelper.ClaimIdSessao, Guid.NewGuid().ToString("N"))
            };
            var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identidade));

            try
            {
                SessionHelper.ObterLoogerParaController().WriteUserAction(
                    usuario.Id, usuario.EstadoUsuario?.SiglaEstado, $"O usuário {usuario.Login} acessou o sistema");
            }
            catch (Exception exc)
            {
                LoggerHelper.WriteLogError("Falha ao registrar acesso: " + exc.Message);
            }

            return Ok(Mapear(usuario));
        }

        [Authorize]
        [HttpGet("me")]
        public ActionResult<UsuarioLogadoResponse> Me()
        {
            var usuario = SessionHelper.RetornaUsuarioLogado();
            if (usuario == null) return Unauthorized();
            return Ok(Mapear(usuario));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity?.IsAuthenticated == true)
                SessionHelper.RetornaSessaoAtual().Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return NoContent();
        }

        private static UsuarioLogadoResponse Mapear(Usuario usuario)
        {
            int.TryParse(SgfjuConfig.Get("CodeADM"), out var codigoAdm);
            int.TryParse(SgfjuConfig.Get("CodePastorEstadual"), out var codigoPastorEstadual);
            var codigoPerfil = usuario.PerfilUsuario?.Code ?? 0;
            var descricaoPerfil = usuario.PerfilUsuario?.Descricao ?? string.Empty;

            // Mesmas regras de redirecionamento do formLogin.aspx, apontando para as novas rotas.
            string paginaInicial;
            if (codigoPerfil == codigoAdm) paginaInicial = "/dashboard/nacional";
            else if (codigoPerfil == codigoPastorEstadual) paginaInicial = "/dashboard/estadual";
            else if (descricaoPerfil == "ConsultaCamisa") paginaInicial = "/camisas";
            else if (descricaoPerfil == "SecretariaBR") paginaInicial = "/painel";
            else if (descricaoPerfil == "Coordenador Projeto Help") paginaInicial = "/instituicoes";
            else paginaInicial = "/jovens/novo";

            return new UsuarioLogadoResponse
            {
                Id = usuario.Id,
                Nome = usuario.NomeUsuario,
                Login = usuario.Login,
                CodigoPerfil = codigoPerfil,
                Perfil = descricaoPerfil,
                IdEstado = usuario.EstadoUsuario?.Id ?? 0,
                Estado = usuario.EstadoUsuario?.NomeEstado,
                SiglaEstado = usuario.EstadoUsuario?.SiglaEstado,
                IdBloco = usuario.BlocoUsuario?.Id ?? 0,
                Bloco = usuario.BlocoUsuario?.NomeBloco,
                IdRegiao = usuario.RegiaoUsuario?.Id ?? 0,
                Regiao = usuario.RegiaoUsuario?.NomeRegiao,
                Foto = usuario.NomeArquivoPerfil,
                EhAdm = codigoPerfil == codigoAdm,
                PaginaInicial = paginaInicial
            };
        }
    }
}
