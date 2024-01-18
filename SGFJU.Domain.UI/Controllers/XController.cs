using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.Domain.UI.Controllers
{
    public class XController : ApiController
    {
        [HttpPost]
        [Route("api/X/XBRO")]
        public string XBRO([FromBody] XDTO _XDTO) {
            try {
                var xbro = EncryptionHelper.Encrypt(_XDTO.XBRO.ToString());
                return xbro;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/X/__IS")]
        public RespostaRequisicaoDTO __IS() {
            try {
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                return (usuarioLogado != null)?
                          new RespostaRequisicaoDTO { RequisicaoBemSucedida = true }:
                          new RespostaRequisicaoDTO { RequisicaoBemSucedida = false };
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/X/RMM")]
        public string RMM() {
            try {
                var vHTMLMenuPerfil = string.Empty;
                var vCodigoPerfil = SessionHelper.RetornaUsuarioLogado().PerfilUsuario.Code;
                var vDiretorioBase = "~/Serializeds/";
                var vCaminhoArquivoHTMLCompleto = string.Empty;

                if (vCodigoPerfil == 4) {
                    vCaminhoArquivoHTMLCompleto =
                        System.Web.Hosting.HostingEnvironment.MapPath(vDiretorioBase + "menuADMGeral.txt");
                    vHTMLMenuPerfil = File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 5) {
                    vCaminhoArquivoHTMLCompleto =
                            System.Web.Hosting.HostingEnvironment.MapPath(vDiretorioBase + "menuPastorEstadual.txt");
                    vHTMLMenuPerfil = File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 6) {
                    vCaminhoArquivoHTMLCompleto =
                            System.Web.Hosting.HostingEnvironment.MapPath(vDiretorioBase + "menuSecretariaEstadual.txt");
                    vHTMLMenuPerfil = File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 7) {
                    vCaminhoArquivoHTMLCompleto =
                            System.Web.Hosting.HostingEnvironment.MapPath(vDiretorioBase + "menuSecretariaBloco.txt");
                    vHTMLMenuPerfil = File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 9) {
                    vCaminhoArquivoHTMLCompleto =
                            System.Web.Hosting.HostingEnvironment.MapPath(vDiretorioBase + "menuSecretariaRegional.txt");
                    vHTMLMenuPerfil = File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 13) {
                    vCaminhoArquivoHTMLCompleto =
                            System.Web.Hosting.HostingEnvironment.MapPath(vDiretorioBase + "menuSecretariaBR.txt");
                    vHTMLMenuPerfil = File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 14) {
                    vCaminhoArquivoHTMLCompleto =
                            System.Web.Hosting.HostingEnvironment.MapPath(vDiretorioBase + "menuCoordHelp.txt");
                    vHTMLMenuPerfil = File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }

                return vHTMLMenuPerfil;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
