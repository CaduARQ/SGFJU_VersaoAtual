using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
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
    }
}
