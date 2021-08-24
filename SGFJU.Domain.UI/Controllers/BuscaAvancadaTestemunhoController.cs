using SGFJU.Bussiness.Facade;
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
    public class BuscaAvancadaTestemunhoController : ApiController
    {
        [HttpPost]
        [Route("api/BuscaAvancadaTestemunho/BuscaAvancadaTestemunhoPorParametro")]
        public IList<RetornoBuscaAvancadaDTO> BuscaAvancadaTestemunhoPorParametro([FromBody] BuscaAvancadaParametroDTO parametrosBuscaAvancada) {
            try {
                var facade = new BuscaAvancadaTestemunhoFacadeImpl();
                var resultadoBuscaAvancada = facade.BuscaAvancadaTestemunhoPorParametro(parametrosBuscaAvancada);
                SessionHelper.RetornaSessaoAtual().Add("TestemunhosRetornados", resultadoBuscaAvancada);
                return resultadoBuscaAvancada;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/BuscaAvancadaTestemunho/ObterTxtoTestemunhoSessao")]
        public RetornoBuscaAvancadaDTO ObterTxtoTestemunhoSessao([FromBody] IdXDTO parametroIdX ) {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var testemunhosSelecionado = (sessaoAtual["TestemunhosRetornados"] as IList<RetornoBuscaAvancadaDTO>).Where(ts => ts.IdX == parametroIdX.IdX).Single();

                return testemunhosSelecionado;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

    }
}
