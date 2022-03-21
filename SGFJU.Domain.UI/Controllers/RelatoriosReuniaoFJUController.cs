using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.Domain.UI.Controllers
{
    public class RelatoriosReuniaoFJUController : ApiController
    {
        
        private PeriodoRelatorioEJDTO RetornaPeriodoRelatorioSeFinalSemana() {
            try
            {
                PeriodoRelatorioEJDTO vPeriodoRetorno = null;
                var dataAtual = DateTime.Now;
                string vDataInicial = string.Empty;
                string vDataFinal = string.Empty;
                var vEhFinalSemana =
                    (dataAtual.DayOfWeek == DayOfWeek.Saturday ||
                     dataAtual.DayOfWeek == DayOfWeek.Sunday) ? true : false;

                if (vEhFinalSemana) {
                    if (dataAtual.DayOfWeek == DayOfWeek.Saturday)
                        vDataInicial = dataAtual.ToString("dd/MM/yyyy");
                    else if (dataAtual.DayOfWeek == DayOfWeek.Sunday)
                        vDataInicial = dataAtual.AddDays(-1).ToString("dd/MM/yyyy");

                    if (dataAtual.DayOfWeek == DayOfWeek.Saturday)
                        vDataFinal = dataAtual.AddDays(1).ToString("dd/MM/yyyy");
                    else if (dataAtual.DayOfWeek == DayOfWeek.Sunday)
                        vDataFinal = dataAtual.ToString("dd/MM/yyyy");

                        /*
                    var vDataInicial = (dataAtual.DayOfWeek == DayOfWeek.Sunday) ?
                                          dataAtual.AddDays(-1).ToString("dd/MM/yyyy") :
                                          dataAtual.ToString("dd/MM/yyyy");
                    var vDataFinal = (dataAtual.DayOfWeek == DayOfWeek.Saturday) ?
                                          dataAtual.ToString("dd/MM/yyyy") :
                                          dataAtual.AddDays(0).ToString("dd/MM/yyyy");
                    */
                    vPeriodoRetorno =
                        new PeriodoRelatorioEJDTO
                        {
                            DataInicial = vDataInicial,
                            DataFinal = vDataFinal,
                            PeriodoEletivoLancamento = (vEhFinalSemana) ? true : false
                        };
                }

                return vPeriodoRetorno;
            }
            catch (Exception exc)
            {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }
        [HttpGet]
        [Route("api/RelatoriosReuniaoFJU/ObterPeriodoRelatorioEncontroJovem")]
        public PeriodoRelatorioEJDTO ObterPeriodoRelatorioEncontroJovem() {
            try {
                return this.RetornaPeriodoRelatorioSeFinalSemana(); //vPeriodoRetorno;
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpGet]
        [Route("api/RelatoriosReuniaoFJU/ListaRelatorioIgrejasEstadoLogadoPorPeriodo")]
        public PanoramaRelatorioReuniaoFJUDTO ListaRelatorioIgrejasEstadoLogadoPorPeriodo() {
            try {
                var parametrosPesquisa = new ParametroPesquisaRelatorioIgrejasPeriodo();

                var vIdEstadoLogado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                var panoramaRetorno = new PanoramaRelatorioReuniaoFJUDTO();

                parametrosPesquisa.IdEstado = vIdEstadoLogado;

                //adicionando periodo corrente caso final de semana ao parâmetro
                parametrosPesquisa.DataInicial = this.RetornaPeriodoRelatorioSeFinalSemana().DataInicial;
                parametrosPesquisa.DataFinal = this.RetornaPeriodoRelatorioSeFinalSemana().DataFinal;

                var resultSetRetorno = facade.ListaRelatorioIgrejasEstadoPorPeriodo(parametrosPesquisa);

                var QuantidadeIgrejasSemRelatorio = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja == 0).Count();
                var quantidadeAlgoAMais = resultSetRetorno.Where(x => x.QuantidadeAlgoAMais > 0);
                var a = quantidadeAlgoAMais.Sum(x => x.QuantidadeAlgoAMais);

                panoramaRetorno.RelatorioIgrejasNoPeriodo = resultSetRetorno;
                panoramaRetorno.SomatorioRelatoriosJaLancados = resultSetRetorno.Sum(rel => rel.QuantidadeJovens);
                panoramaRetorno.SomatorioRelatoriosJaLancadosAM = resultSetRetorno.Sum(am => am.QuantidadeAlgoAMais);
                panoramaRetorno.QuantidadeIgrejasSemRelatorio = QuantidadeIgrejasSemRelatorio;

                var percentual = (QuantidadeIgrejasSemRelatorio / resultSetRetorno.Count() * 100);
                panoramaRetorno.PercentualRelatorioPreenchido = $"{percentual}%";
                panoramaRetorno.PercentualRelatorioNaoPreenchido = "";

                return panoramaRetorno;
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpPost]
        [Route("api/RelatoriosReuniaoFJU/ListaRelatorioIgrejasEstadoLogadoPorParametro")]
        public PanoramaRelatorioReuniaoFJUDTO ListaRelatorioIgrejasEstadoLogadoPorParametro([FromBody] ParametroPesquisaRelatorioIgrejasPeriodo parametros) {
            try {
                var vIdEstadoLogado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                var panoramaRetorno = new PanoramaRelatorioReuniaoFJUDTO();

                parametros.DataInicial = this.RetornaPeriodoRelatorioSeFinalSemana().DataInicial;
                parametros.DataFinal = this.RetornaPeriodoRelatorioSeFinalSemana().DataFinal;

                var resultSetRetorno = facade.ListaRelatorioIgrejasEstadoPorPeriodo(parametros);

                panoramaRetorno.RelatorioIgrejasNoPeriodo = resultSetRetorno;
                panoramaRetorno.SomatorioRelatoriosJaLancados = resultSetRetorno.Sum(rel => rel.QuantidadeJovens);

                return panoramaRetorno;
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpPost]
        [Route("api/RelatoriosReuniaoFJU/ProcessarRelatorioIgrejaEJ")]
        public RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgrejaEJ(RelatorioReuniaoFJUIgrejaDTO relatorioASerProcessado) {
            try {
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();

                relatorioASerProcessado.IdEstado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                relatorioASerProcessado.DataRelatorio = DateTime.Now.ToString("yyyy-MM-dd");
                relatorioASerProcessado.HorarioRelatorio = $"{DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes}:{DateTime.Now.TimeOfDay.Seconds}";
                relatorioASerProcessado.IdReuniaoFJURelatorio = int.Parse(ConfigurationManager.AppSettings["EJ_Code"]);

                facade.ProcessarRelatorioIgreja(relatorioASerProcessado);

                return new RespostaProcessamentoRelatorioDTO { SolicitacaoBemSucedida = true, RespostaSoliciticao = "Relatório processado com sucesso!!!" };
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }
    }
}