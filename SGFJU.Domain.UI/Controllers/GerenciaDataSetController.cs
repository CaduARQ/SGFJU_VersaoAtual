using SGFJU.Domain.Model.Infra.ExceptionManager;
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
    public class GerenciaDataSetController : ApiController
    {
        [HttpPost]
        [Route("api/GerenciaDataSet/ArmazenaDataSet")]
        public RespostaRequisicaoDTO ArmazenaDataSet([FromBody] InformacaoDataSetDTO informacoesDTO) {
            try {
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
