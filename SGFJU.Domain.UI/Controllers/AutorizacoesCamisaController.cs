using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;

namespace SGFJU.Domain.UI.Controllers
{
    public class AutorizacoesCamisaController : ApiController
    {
        [HttpPost]
        [Route("api/AutorizacoesCamisa/ExcluirAutorizacaoCamisa")]
        public RespostaRequisicaoDTO ExcluirAutorizacaoCamisa([FromBody] AutorizacaoCompraCamisaDTO autorizacaoASerExcluida) {
            try {
                var facade = new FacadeJovemImpl();

                facade.ExcluirAutorizacaoCamisa(autorizacaoASerExcluida);

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Autorização excluida com sucesso!!!" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
        [HttpPost]
        [Route("api/AutorizacoesCamisa/RetornaHistoricoSolicitacoesCamisa")]
        public IList<AutorizacaoCompraCamisaDTO> RetornaHistoricoSolicitacoesCamisa([FromBody] JovemDTO pJovem) {
            try {
                var facade = new FacadeJovemImpl();
                var historicoSolicitacoes = 
                    facade.RetornaHistoricoSolicitacoesCamisa(pJovem);

                return historicoSolicitacoes;
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
