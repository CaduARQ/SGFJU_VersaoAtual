using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.Domain.UI.Controllers
{
    public class ArvoreVidaDashboardController : ApiController
    {
        [HttpGet]
        [Route("api/ArvoreVidaDashboard/ListaTotaisArvoreVidaGeral")]
        public TotaisArvoreVidaEstadoDTO ListaTotaisArvoreVidaGeral() {
            try {
                var facade = new AVDashboardFacadeImpl();
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var totaisArvoreVida = facade.ListaTotaisArvoreVidaGeral();
                var totalNacionalArvoreVida = new TotaisArvoreVidaEstadoDTO();

                sessaoAtual.Add("Totais_ArvoreVida_Nacional", totaisArvoreVida.OrderByDescending(av => av.MediaAcompanhamentoJovensPorObreiro).ToList());

                totalNacionalArvoreVida.QuantidadeJovens                    = totaisArvoreVida.Sum(tt => tt.QuantidadeJovens);
                totalNacionalArvoreVida.QuantidadeObreiros                  = totaisArvoreVida.Sum(tt => tt.QuantidadeObreiros);
                totalNacionalArvoreVida.QuantidadeObreirosQueAcompanham     = totaisArvoreVida.Sum(tt => tt.QuantidadeObreirosQueAcompanham);
                totalNacionalArvoreVida.QuantidadeJovensAcompanhados        = totaisArvoreVida.Sum(tt => tt.QuantidadeJovensAcompanhados);
                totalNacionalArvoreVida.QuantidadeJovensSemAcompanhamento   = totaisArvoreVida.Sum(tt => tt.QuantidadeJovensSemAcompanhamento);
                totalNacionalArvoreVida.MediaAcompanhamentoJovensPorObreiro = ( totaisArvoreVida.Sum(tt => tt.QuantidadeJovens) / totaisArvoreVida.Sum(tt => tt.QuantidadeObreiros) ).ToString();
                
                return totalNacionalArvoreVida;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/ArvoreVidaDashboard/ListaTotaisArvoreVidaEstados")]
        public IList<TotaisArvoreVidaEstadoDTO> ListaTotaisArvoreVidaEstados() {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();

                if (sessaoAtual["Totais_ArvoreVida_Nacional"] != null) {
                    return (sessaoAtual["Totais_ArvoreVida_Nacional"] as IList<TotaisArvoreVidaEstadoDTO>);
                }

                var facade = new AVDashboardFacadeImpl();
                return facade.ListaTotaisArvoreVidaGeral();
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVidaDashboard/ListaTotaisArvoreVidaPorEstado")]
        public TotaisArvoreVidaEstadoDTO ListaTotaisArvoreVidaPorEstado([FromBody] EstadoDTO estadoParametro) {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                IList<TotaisArvoreVidaEstadoDTO>  totaisEstado = null;
                if (sessaoAtual["Totais_ArvoreVida_Nacional"] != null) {
                    totaisEstado = (sessaoAtual["Totais_ArvoreVida_Nacional"] as IList<TotaisArvoreVidaEstadoDTO>);
                }
                else {
                    var retorno = (new AVDashboardFacadeImpl()).ListaTotaisArvoreVidaPorEstado(estadoParametro);
                    return retorno;
                }

                return totaisEstado.Where(av => av.IdEstado == estadoParametro.IdEstado).First();
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