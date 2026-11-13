using SGFJU.Domain.Model.Infra.Util;
using Newtonsoft.Json;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class UsuariosController : ControllerBase {

        [HttpGet]
        [Route("api/Usuarios/X072470")]
        public UsuarioDTO X072470() {
            
            try{
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var codigoADM = (!string.IsNullOrEmpty(SgfjuConfig.Get("CodeADM"))) ? int.Parse(SgfjuConfig.Get("CodeADM")):0;
                
                return new UsuarioDTO {
                    IdUsuario = usuarioLogado.Id,
                    NomeUsuario = usuarioLogado.NomeUsuario,
                    Login       = usuarioLogado.Login,
                    NomePerfil = usuarioLogado.PerfilUsuario.Descricao,
                    PathImagemUsuario = (!string.IsNullOrEmpty(usuarioLogado.NomeArquivoPerfil))?usuarioLogado.NomeArquivoPerfil: "../FotosUsuarios/user_default_icon.png",
                    IdEstadoUsuarioLogado = usuarioLogado.EstadoUsuario.Id,
                    NomeEstadoUsuarioLogado = usuarioLogado.EstadoUsuario.NomeEstado,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado,
                    IdBloco = (usuarioLogado.BlocoUsuario != null)?
                                 usuarioLogado.BlocoUsuario.Id:0,
                    NomeBlocoUsuario = (usuarioLogado.BlocoUsuario != null)?
                                          usuarioLogado.BlocoUsuario.NomeBloco:"",
                    IdRegiao = (usuarioLogado.RegiaoUsuario != null) ?
                                 usuarioLogado.RegiaoUsuario.Id : 0,
                    NomeRegiaoUsuario = (usuarioLogado.RegiaoUsuario != null) ?
                                          usuarioLogado.RegiaoUsuario.NomeRegiao : "",
                    EhADM = (usuarioLogado.PerfilUsuario.Code == codigoADM) ? true : false
                };
            }
            catch (Exception exc){
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Usuarios/X072433")]
        public void X072433(){
            SessionHelper.RetornaSessaoAtual().Clear();
        }

        [HttpGet]
        [Route("api/Usuarios/X072477")]
        public string X072477() {
            try {
                var urlRetorno = "";
                var usuarioRetornado = SessionHelper.RetornaUsuarioLogado();
                var codigoADM = int.Parse(SgfjuConfig.Get("CodeADM"));
                var codigoPrEstadual = int.Parse(SgfjuConfig.Get("CodePastorEstadual"));

                if (usuarioRetornado.PerfilUsuario.Code == codigoADM)
                    urlRetorno = "DashboardNacional.html";
                else if (usuarioRetornado.PerfilUsuario.Code == codigoPrEstadual)
                    urlRetorno = "DashboardEstadual.html";
                else
                    urlRetorno = "RegistraJovem.aspx";

                return urlRetorno;
            }
            catch (Exception exc){
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Usuarios/RegistraNovoUsuario")]
        public RespostaRequisicaoDTO RegistraNovoUsuario([FromBody] UsuarioDTO usuarioNovo) { 
            try {
                var facade = new FacadeUsuarioImpl();
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;

                facade.Save(new Usuario { 
                    Login = usuarioNovo.Login,
                    NomeUsuario = usuarioNovo.NomeUsuario,
                    NomeArquivoPerfil = usuarioNovo.PathImagemUsuario,
                    Senha = usuarioNovo.Pwd,
                    EstadoUsuario = new Estado { Id = idEstadoLogado },
                    BlocoUsuario = (usuarioNovo.IdBloco != 0)? new Bloco { Id = usuarioNovo.IdBloco } : null,
                    RegiaoUsuario = (usuarioNovo.IdRegiao != 0)? new Regiao { Id = usuarioNovo.IdRegiao } : null,
                    PerfilUsuario = new PerfilUsuario { Code = usuarioNovo.IdPerfilUsuario }
                });

                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Usuario cadastrado com sucesso !!!", RequisicaoBemSucedida = true };
            }
            catch (Exception exc){
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Usuarios/RetornaUsuarioEstadoLogado")]
        public IList<UsuarioDTO> RetornaUsuarioEstadoLogado() {
            try {
                var facade = new FacadeUsuarioImpl();
                var estadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario;

                return facade.RetornaUsuariosEstado(estadoLogado);
            }
            catch (Exception exc){
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Usuarios/RetornaUsuarioBlocoLogado")]
        public IList<UsuarioDTO> RetornaUsuarioBlocoLogado() {
            try {
                var facade = new FacadeUsuarioImpl();
                var blocoLogado = SessionHelper.RetornaUsuarioLogado().BlocoUsuario;

                return facade.RetornaUsuariosBloco(blocoLogado);
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Usuarios/RetornaUsuarioRegiaoLogado")]
        public IList<UsuarioDTO> RetornaUsuarioRegiaoLogado() {
            try {
                var facade = new FacadeUsuarioImpl();
                var regiaoLogado = SessionHelper.RetornaUsuarioLogado().RegiaoUsuario;

                return facade.RetornaUsuariosRegiao(regiaoLogado);
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Usuarios/RetornaUsuario")]
        public UsuarioDTO RetornaUsuario([FromBody] UsuarioDTO usuarioParametro) {
            try {
                var facade = new FacadeUsuarioImpl();
                var usuarioRetorno = facade.RetornaUsuario(usuarioParametro);
                SessionHelper.RetornaSessaoAtual().Add("UsuarioEmAtualizacao", usuarioRetorno);

                return usuarioRetorno;
            }
            catch (Exception exc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Usuarios/ExcluirUsuario")]
        public RespostaRequisicaoDTO ExcluirUsuario([FromBody] UsuarioDTO usuarioParaExclusao) {
            try {
                var facade = new FacadeUsuarioImpl();
                facade.Delete(int.Parse(EncryptionHelper.Decrypt(usuarioParaExclusao.IdUsuarioX)));

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Usuário excluido com sucesso !" };
            }
            catch (Exception exc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
        [HttpGet]
        [Route("api/Usuarios/RetornaAcoesSGFJU")]
        public IList<LogUsuarioDTO> RetornaAcoesSGFJU() {
            try {
                var facade = new FacadeUsuarioImpl();
                var pathArquivoUserActions =
                    AmbienteLegado.MapPath(
                        SgfjuConfig.Get("LoggerFilePath") +
                        SgfjuConfig.Get("LoggerUserFileName")
                    );
                
                var acoesSGFJUUsuarios = facade.ObterTodasAcoesSGFJU(pathArquivoUserActions);
                var idAcao = "";
                var i = 0;
                foreach (var acaoSGFJU in acoesSGFJUUsuarios) {
                    if (acaoSGFJU != null)
                        acaoSGFJU.IdLogUsuario = i + 1 + acaoSGFJU.IdUsuario + DateTime.Now.Millisecond;
                    else
                        acoesSGFJUUsuarios.Remove(acaoSGFJU);
                    i++;
                }
                return acoesSGFJUUsuarios;
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Usuarios/RetornaAcoesSGFJUPorEstadoLogado")]
        public IList<LogUsuarioDTO> RetornaAcoesSGFJUPorEstadoLogado() {
            try {
                var siglaEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado;
                return RetornaAcoesSGFJUPorParametro(new ParametroPesquisaUsuarioDTO { SiglaEstadoUsuario = siglaEstadoLogado });
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Usuarios/RetornaAcoesSGFJUPorParametro")]
        public IList<LogUsuarioDTO> RetornaAcoesSGFJUPorParametro([FromBody] ParametroPesquisaUsuarioDTO parametrosPesquisa) {
            try
            {
                var facade = new FacadeUsuarioImpl();
                var pathArquivoUserActions =
                    AmbienteLegado.MapPath(
                        SgfjuConfig.Get("LoggerFilePath") +
                        SgfjuConfig.Get("LoggerUserFileName")
                    );

                var acoesSGFJUUsuarios = facade.ObterTodasAcoesSGFJU(pathArquivoUserActions);
                var acoesFiltradas = new List<LogUsuarioDTO>();
                var idAcao = "";
                var i = 0;

                if (!string.IsNullOrEmpty(parametrosPesquisa.DataAcaoUsuario) &&
                    parametrosPesquisa.IdUsuario != 0 &&
                    !string.IsNullOrEmpty(parametrosPesquisa.SiglaEstadoUsuario)) {
                    acoesFiltradas = acoesSGFJUUsuarios
                                        .Where(usrs => usrs.IdUsuario == parametrosPesquisa.IdUsuario &&
                                                       string.Compare(usrs.DataAcaoUsuario,
                                                                      parametrosPesquisa.DataAcaoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0 &&
                                                       string.Compare(usrs.SiglaEstadoUsuario,
                                                                      parametrosPesquisa.SiglaEstadoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0 )
                                        .ToList();
                }
                else if (!string.IsNullOrEmpty(parametrosPesquisa.DataAcaoUsuario) &&
                         parametrosPesquisa.IdUsuario != 0 &&
                         string.IsNullOrEmpty(parametrosPesquisa.SiglaEstadoUsuario)) {
                    acoesFiltradas = acoesSGFJUUsuarios
                                        .Where(usrs => string.Compare(usrs.DataAcaoUsuario,
                                                                      parametrosPesquisa.DataAcaoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0 &&
                                                       usrs.IdUsuario == parametrosPesquisa.IdUsuario )
                                        .ToList();
                }
                else if (!string.IsNullOrEmpty(parametrosPesquisa.DataAcaoUsuario) &&
                         parametrosPesquisa.IdUsuario == 0 &&
                         !string.IsNullOrEmpty(parametrosPesquisa.SiglaEstadoUsuario))
                {
                    acoesFiltradas = acoesSGFJUUsuarios
                                        .Where(usrs => string.Compare(usrs.DataAcaoUsuario,
                                                                      parametrosPesquisa.DataAcaoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0 &&
                                                       string.Compare(usrs.SiglaEstadoUsuario,
                                                                      parametrosPesquisa.SiglaEstadoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0)
                                        .ToList();
                }
                else if (!string.IsNullOrEmpty(parametrosPesquisa.DataAcaoUsuario) &&
                         parametrosPesquisa.IdUsuario == 0 &&
                         string.IsNullOrEmpty(parametrosPesquisa.SiglaEstadoUsuario)) {
                    acoesFiltradas = acoesSGFJUUsuarios
                                        .Where(usrs => string.Compare(usrs.DataAcaoUsuario,
                                                                      parametrosPesquisa.DataAcaoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0)
                                        .ToList();
                }
                else if (string.IsNullOrEmpty(parametrosPesquisa.DataAcaoUsuario) &&
                         parametrosPesquisa.IdUsuario != 0 &&
                         string.IsNullOrEmpty(parametrosPesquisa.SiglaEstadoUsuario))
                {
                    acoesFiltradas = acoesSGFJUUsuarios
                                        .Where(usrs => usrs.IdUsuario == parametrosPesquisa.IdUsuario)
                                        .ToList();
                }
                else if (string.IsNullOrEmpty(parametrosPesquisa.DataAcaoUsuario) &&
                         parametrosPesquisa.IdUsuario != 0 &&
                         !string.IsNullOrEmpty(parametrosPesquisa.SiglaEstadoUsuario))
                {
                    acoesFiltradas = acoesSGFJUUsuarios
                                          .Where(usrs => usrs.IdUsuario == parametrosPesquisa.IdUsuario &&
                                                       string.Compare(usrs.SiglaEstadoUsuario,
                                                                      parametrosPesquisa.SiglaEstadoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0 )
                                        .ToList();
                }
                else if (string.IsNullOrEmpty(parametrosPesquisa.DataAcaoUsuario) &&
                         parametrosPesquisa.IdUsuario == 0 &&
                         !string.IsNullOrEmpty(parametrosPesquisa.SiglaEstadoUsuario))
                {
                    acoesFiltradas = acoesSGFJUUsuarios
                                        .Where(usrs => string.Compare(usrs.SiglaEstadoUsuario,
                                                                      parametrosPesquisa.SiglaEstadoUsuario,
                                                                      StringComparison.OrdinalIgnoreCase) == 0 )
                                        .ToList();
                }

                return acoesFiltradas;
            }
            catch (Exception exc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Usuarios/PesquisaUsuariosPorParametro")]
        public IList<UsuarioDTO> PesquisaUsuariosPorParametro([FromBody] PesquisaGeralDTO parametroPesquisa) {
            try {
                var facade = new FacadeUsuarioImpl();
                var aaaa = facade.PesquisaUsuariosPorParametro(parametroPesquisa);
                return aaaa;
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
