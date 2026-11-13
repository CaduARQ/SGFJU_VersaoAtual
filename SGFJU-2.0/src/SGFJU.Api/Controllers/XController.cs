using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Security;
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
    public class XController : ControllerBase
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
                        AmbienteLegado.MapPath(vDiretorioBase + "menuADMGeral.txt");
                    vHTMLMenuPerfil = System.IO.File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 5) {
                    vCaminhoArquivoHTMLCompleto =
                            AmbienteLegado.MapPath(vDiretorioBase + "menuPastorEstadual.txt");
                    vHTMLMenuPerfil = System.IO.File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 6) {
                    vCaminhoArquivoHTMLCompleto =
                            AmbienteLegado.MapPath(vDiretorioBase + "menuSecretariaEstadual.txt");
                    vHTMLMenuPerfil = System.IO.File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 7) {
                    vCaminhoArquivoHTMLCompleto =
                            AmbienteLegado.MapPath(vDiretorioBase + "menuSecretariaBloco.txt");
                    vHTMLMenuPerfil = System.IO.File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 9) {
                    vCaminhoArquivoHTMLCompleto =
                            AmbienteLegado.MapPath(vDiretorioBase + "menuSecretariaRegional.txt");
                    vHTMLMenuPerfil = System.IO.File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 13) {
                    vCaminhoArquivoHTMLCompleto =
                            AmbienteLegado.MapPath(vDiretorioBase + "menuSecretariaBR.txt");
                    vHTMLMenuPerfil = System.IO.File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
                }
                else if (vCodigoPerfil == 14) {
                    vCaminhoArquivoHTMLCompleto =
                            AmbienteLegado.MapPath(vDiretorioBase + "menuCoordHelp.txt");
                    vHTMLMenuPerfil = System.IO.File.ReadAllText(path: vCaminhoArquivoHTMLCompleto);
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
