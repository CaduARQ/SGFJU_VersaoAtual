using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class GerenciaDataSetController : ControllerBase
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
