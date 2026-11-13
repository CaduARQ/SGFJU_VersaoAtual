using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace SGFJU.Api.Controllers
{
    public class RelatoriosReuniaoFJUController : ControllerBase
    {
        
        private PeriodoRelatorioEJDTO RetornaPeriodoRelatorioSeFinalSemana() {
            try {
                PeriodoRelatorioEJDTO vPeriodoRetorno = null;
                var dataAtual = DateTime.Now;
                string vDataInicial = string.Empty;
                string vDataFinal = string.Empty;
                var objPeriodoParametrizado = RetornaPeriodoParametrizado();
                var vEhFinalSemana =
                    (dataAtual.DayOfWeek == DayOfWeek.Saturday ||
                     dataAtual.DayOfWeek == DayOfWeek.Sunday) ? true : false;

                if (vEhFinalSemana) {
                    /*********************************************************************************************************/
                    if (dataAtual.DayOfWeek == DayOfWeek.Saturday)
                        vDataInicial = dataAtual.AddDays(-5).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
                    else if (dataAtual.DayOfWeek == DayOfWeek.Sunday)
                        vDataInicial = dataAtual.AddDays(-6).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));

                    if (dataAtual.DayOfWeek == DayOfWeek.Saturday)
                        vDataFinal = dataAtual.AddDays(1).ToString("dd/MM/yyyy");
                    else if (dataAtual.DayOfWeek == DayOfWeek.Sunday)
                        vDataFinal = dataAtual.ToString("dd/MM/yyyy");
                    /*********************************************************************************************************/

                    vPeriodoRetorno =
                        new PeriodoRelatorioEJDTO
                        {
                            DataInicial = vDataInicial,
                            DataFinal = vDataFinal,
                            PeriodoEletivoLancamento = (vEhFinalSemana) ? true : false
                        };
                }
                else if (objPeriodoParametrizado != null) {
                    var periodoParametrizado = objPeriodoParametrizado.ConverteParaPeriodoRelatorioEJDTO();
                    SessionHelper.RetornaSessaoAtual().Add("PeriodoParametrizado", objPeriodoParametrizado);
                    return periodoParametrizado;
                }

                return vPeriodoRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        private PeriodoRelatorioParametrizadoEJDTO RetornaPeriodoParametrizado()
        {
            try {
                var caminhoPastaArquivosSerializados = SgfjuConfig.Get("PathArquivosObjetosSerializados");
                var caminhoArquivoParametrosRelatorio = AmbienteLegado.MapPath(caminhoPastaArquivosSerializados + "/" + "ParametroRelatorioFJU.txt");
                var serializer = (new JSONSerializer());
                PeriodoRelatorioParametrizadoEJDTO
                    parametrosRelatorio = null;

                if (System.IO.File.Exists(caminhoArquivoParametrosRelatorio))
                    parametrosRelatorio = serializer.Deserialized<PeriodoRelatorioParametrizadoEJDTO>(caminhoArquivoParametrosRelatorio);

                return (parametrosRelatorio != null)?parametrosRelatorio:null;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/RelatoriosReuniaoFJU/ObterPeriodoRelatorioEncontroJovem")]
        public PeriodoRelatorioEJDTO ObterPeriodoRelatorioEncontroJovem() {
            try {
                return this.RetornaPeriodoRelatorioSeFinalSemana(); //vPeriodoRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [Obsolete]
        [HttpGet]
        [Route("api/RelatoriosReuniaoFJU/ListaRelatorioIgrejasEstadoLogadoPorPeriodo")]
        public PanoramaRelatorioReuniaoFJUDTO ListaRelatorioIgrejasEstadoLogadoPorPeriodo() {
            try {
                var parametrosPesquisa = new ParametroPesquisaRelatorioIgrejasPeriodo();

                var vIdEstadoLogado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                var panoramaRetorno = new PanoramaRelatorioReuniaoFJUDTO();

                parametrosPesquisa.IdEstado = vIdEstadoLogado;

                try {
                    parametrosPesquisa.DataInicial = this.RetornaPeriodoRelatorioSeFinalSemana().DataInicial;
                    parametrosPesquisa.DataFinal = this.RetornaPeriodoRelatorioSeFinalSemana().DataFinal;
                }
                catch (Exception controllerExc) {
                    var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                    LoggerHelper.WriteLogError(mensagemTratada + "conversão de data");
                    throw new Exception(mensagemTratada);
                }

                IList<RelatorioReuniaoFJUIgrejaDTO> resultSetRetorno;
                try {
                    resultSetRetorno = facade.ListaRelatorioIgrejasEstadoPorPeriodo(parametrosPesquisa);
                }
                catch (Exception controllerExc) {
                    var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                    LoggerHelper.WriteLogError("ERRO FOI NA QUERY TENTANDO FORMATAR DATA INTERNAMENTE");
                    throw new Exception(mensagemTratada);
                }

                var QuantidadeIgrejasSemRelatorio = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja == 0).Count();
                var quantidadeAlgoAMais = resultSetRetorno.Where(x => x.QuantidadeAlgoAMais > 0);
                var a = quantidadeAlgoAMais.Sum(x => x.QuantidadeAlgoAMais);

                panoramaRetorno.RelatorioIgrejasNoPeriodo = resultSetRetorno;
                panoramaRetorno.RelatorioIgrejasJaPreenchidoNoPeriodo = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja > 0).ToList();
                panoramaRetorno.SomatorioRelatoriosJaLancados = resultSetRetorno.Sum(rel => rel.QuantidadeJovens);
                panoramaRetorno.SomatorioRelatoriosJaLancadosAM = resultSetRetorno.Sum(am => am.QuantidadeAlgoAMais);
                panoramaRetorno.QuantidadeIgrejasSemRelatorio = QuantidadeIgrejasSemRelatorio;

                var percentual = ((decimal)QuantidadeIgrejasSemRelatorio / resultSetRetorno.Count() * 100);
                panoramaRetorno.PercentualRelatorioPreenchido = $"{percentual}";
                panoramaRetorno.PercentualRelatorioNaoPreenchido = ((decimal)100 - percentual).ToString();

                return panoramaRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/RelatorioReuniaoFJU/ListaRelatorioIgrejasPerfilLogado")]
        public PanoramaRelatorioReuniaoFJUDTO ListaRelatorioIgrejasPerfilLogado() {
            try {
                var parametrosPesquisa = new ParametroPesquisaRelatorioIgrejasPeriodo();

                var vIdEstadoLogado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                var panoramaRetorno = new PanoramaRelatorioReuniaoFJUDTO();
                var codigoPerfilUsuarioLogado = SessionHelper.RetornaPerfilUsuarioLogado().Code;
                var vDataInicial = this.RetornaPeriodoRelatorioSeFinalSemana().DataInicial;
                var vDataFinal = this.RetornaPeriodoRelatorioSeFinalSemana().DataFinal;


                switch (codigoPerfilUsuarioLogado) {
                    case 6:
                        parametrosPesquisa.IdEstado = vIdEstadoLogado;
                        break;
                    case 7:
                        parametrosPesquisa.IdBloco = SessionHelper.RetornaUsuarioLogado().BlocoUsuario.Id;
                        break;
                    case 9:
                        parametrosPesquisa.IdRegiao = SessionHelper.RetornaUsuarioLogado().RegiaoUsuario.Id;
                        break;
                }
                
                parametrosPesquisa.DataInicial = vDataInicial;
                parametrosPesquisa.DataFinal = vDataFinal;

                IList<RelatorioReuniaoFJUIgrejaDTO> resultSetRetorno;
                try {
                    resultSetRetorno = facade.ListaRelatorioIgrejasEstadoPorPeriodo(parametrosPesquisa);
                }
                catch (Exception controllerExc)
                {
                    var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                    LoggerHelper.WriteLogError("ERRO FOI NA QUERY TENTANDO FORMATAR DATA INTERNAMENTE");
                    throw new Exception(mensagemTratada);
                }

                var QuantidadeIgrejasSemRelatorio = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja == 0).Count();
                var quantidadeAlgoAMais = resultSetRetorno.Where(x => x.QuantidadeAlgoAMais > 0);
                var a = quantidadeAlgoAMais.Sum(x => x.QuantidadeAlgoAMais);

                //panoramaRetorno.RelatorioIgrejasNoPeriodo = resultSetRetorno; 
                panoramaRetorno.RelatorioIgrejasNoPeriodo = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja == 0).ToList();
                panoramaRetorno.RelatorioIgrejasJaPreenchidoNoPeriodo = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja > 0).ToList();
                panoramaRetorno.SomatorioRelatoriosJaLancados = resultSetRetorno.Sum(rel => rel.QuantidadeJovens);
                panoramaRetorno.SomatorioRelatoriosJaLancadosAM = resultSetRetorno.Sum(am => am.QuantidadeAlgoAMais);
                panoramaRetorno.QuantidadeIgrejasSemRelatorio = QuantidadeIgrejasSemRelatorio;

                //var percentual = ( (decimal) QuantidadeIgrejasSemRelatorio / resultSetRetorno.Count() * 100 );
                var percentualIgrejasSemRelatorio = ((decimal)QuantidadeIgrejasSemRelatorio / resultSetRetorno.Count() * 100);

                var percentualIgrejasPreenchidas = (int)(100 - percentualIgrejasSemRelatorio);

                panoramaRetorno.PercentualRelatorioPreenchido = $"{percentualIgrejasPreenchidas}";
                panoramaRetorno.PercentualRelatorioNaoPreenchido = ((decimal)100 - percentualIgrejasSemRelatorio).ToString();

                if (QuantidadeIgrejasSemRelatorio == 0) {
                    if (facade.RelatorioNoPeriodoJaEstaProcessado(parametrosPesquisa)) {
                        panoramaRetorno.EhParaFecharRelatorio = false;
                        panoramaRetorno.RelatorioIgrejasJaPreenchidoNoPeriodo.ToList().ForEach(rjl => { rjl.RelatorioJaProcessado = "Sim"; });
                    }
                    else {
                        panoramaRetorno.EhParaFecharRelatorio = true;
                        panoramaRetorno.RelatorioIgrejasJaPreenchidoNoPeriodo.ToList().ForEach(rjl => { rjl.RelatorioJaProcessado = "Sim"; });
                    }
                }
                else
                    panoramaRetorno.EhParaFecharRelatorio = false;

                return panoramaRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/RelatoriosReuniaoFJU/ListaRelatorioIgrejasEstadoLogadoPorParametro")]
        public PanoramaRelatorioReuniaoFJUDTO ListaRelatorioIgrejasEstadoLogadoPorParametro([FromBody] ParametroPesquisaRelatorioIgrejasPeriodo parametros) {
            try {
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                var panoramaRetorno = new PanoramaRelatorioReuniaoFJUDTO();
                var codigoPerfilUsuarioLogado = SessionHelper.RetornaPerfilUsuarioLogado().Code;

                parametros.DataInicial = this.RetornaPeriodoRelatorioSeFinalSemana().DataInicial;
                parametros.DataFinal = this.RetornaPeriodoRelatorioSeFinalSemana().DataFinal;

                var resultSetRetorno = facade.ListaRelatorioIgrejasEstadoPorPeriodo(parametros);

                //panoramaRetorno.RelatorioIgrejasNoPeriodo = resultSetRetorno;
                panoramaRetorno.RelatorioIgrejasNoPeriodo = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja == 0).ToList();
                panoramaRetorno.RelatorioIgrejasJaPreenchidoNoPeriodo = resultSetRetorno.Where(x => x.IdRelatorioReuniaoFJUIgreja > 0).ToList();
                panoramaRetorno.SomatorioRelatoriosJaLancados = resultSetRetorno.Sum(rel => rel.QuantidadeJovens);

                return panoramaRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/RelatoriosReuniaoFJU/ProcessarRelatorioIgrejaEJ")]
        public RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgrejaEJ([FromBody] RelatorioReuniaoFJUIgrejaDTO relatorioASerProcessado) {
            try {
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                DateTime vDataRelatorio;
                string vDataInicial = string.Empty;
                string vDataFinal = string.Empty;

                if (SessionHelper.RetornaSessaoAtual()["PeriodoParametrizado"] != null)
                {
                    vDataRelatorio = (SessionHelper.RetornaSessaoAtual()["PeriodoParametrizado"] != null) ?
                        DateTime.Parse((SessionHelper.RetornaSessaoAtual()["PeriodoParametrizado"] as PeriodoRelatorioParametrizadoEJDTO).DataFinalParametro) :
                        DateTime.Now;
                    vDataInicial = DateTime.Parse((SessionHelper.RetornaSessaoAtual()["PeriodoParametrizado"] as PeriodoRelatorioParametrizadoEJDTO).DataInicialParametro).ToString();
                    vDataFinal = DateTime.Parse((SessionHelper.RetornaSessaoAtual()["PeriodoParametrizado"] as PeriodoRelatorioParametrizadoEJDTO).DataFinalParametro).ToString();
                }
                else {
                    vDataRelatorio = DateTime.Parse(RetornaPeriodoRelatorioSeFinalSemana().DataFinal);
                    vDataInicial = RetornaPeriodoRelatorioSeFinalSemana().DataInicial;
                    vDataFinal = RetornaPeriodoRelatorioSeFinalSemana().DataFinal;
                }
                
                var vDataRelatorioP = vDataRelatorio.ToString();

                var dia = DateTime.Parse(vDataInicial).Day;
                var mes = DateTime.Parse(vDataInicial).Month;
                var ano = DateTime.Parse(vDataInicial).Year;
                var dataInicialFormatada = $"{ano}-{mes}-{dia}";

                var dia1 = DateTime.Parse(vDataFinal).Day;
                var mes1 = DateTime.Parse(vDataFinal).Month;
                var ano1 = DateTime.Parse(vDataFinal).Year;
                var dataFinalFormatada = $"{ano1}-{mes1}-{dia1}";

                var diaRL = DateTime.Parse(vDataRelatorioP).Day;
                var mesRL = DateTime.Parse(vDataRelatorioP).Month;
                var anoRL = DateTime.Parse(vDataRelatorioP).Year;
                var dataRelatorioFormatada = $"{anoRL}-{mesRL}-{diaRL}";

                relatorioASerProcessado.IdEstado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                /*
                relatorioASerProcessado.DataRegistroRelatorio = vDataRelatorio.ToString("yyyy-MM-dd");
                relatorioASerProcessado.DataInicialPeriodoRelatorio = DateTime.Parse(relatorioASerProcessado.DataInicialPeriodoRelatorio).ToString("yyyy-MM-dd");
                relatorioASerProcessado.DataFinalPeriodoRelatorio = DateTime.Parse(relatorioASerProcessado.DataFinalPeriodoRelatorio).ToString("yyyy-MM-dd");*/
                relatorioASerProcessado.DataRegistroRelatorio = dataRelatorioFormatada;
                relatorioASerProcessado.DataInicialPeriodoRelatorio = dataInicialFormatada;
                relatorioASerProcessado.DataFinalPeriodoRelatorio = dataFinalFormatada;

                relatorioASerProcessado.HorarioRelatorio = $"{DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes}:{DateTime.Now.TimeOfDay.Seconds}";
                relatorioASerProcessado.IdReuniaoFJURelatorio = int.Parse(SgfjuConfig.Get("EJ_Code"));

                if (relatorioASerProcessado.IdRelatorioReuniaoFJUIgreja == 0)
                    facade.ProcessarRelatorioIgreja(relatorioASerProcessado);
                else
                    facade.AtualizaRelatorioPeriodo(relatorioASerProcessado);

                return new RespostaProcessamentoRelatorioDTO { SolicitacaoBemSucedida = true, RespostaSoliciticao = "Relatório processado com sucesso!!!" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/RelatoriosReuniaoFJU/AtualizaRelatorioPeriodo")]
        public RespostaProcessamentoRelatorioDTO AtualizaRelatorioPeriodo([FromBody]RelatorioReuniaoFJUIgrejaDTO relatorioASerAtualizado) { 
            try {
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();

                relatorioASerAtualizado.IdEstado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                //relatorioASerAtualizado.DataRelatorio = DateTime.Now.ToString("yyyy-MM-dd");
                relatorioASerAtualizado.HorarioRelatorio = $"{DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes}:{DateTime.Now.TimeOfDay.Seconds}";
                relatorioASerAtualizado.IdReuniaoFJURelatorio = int.Parse(SgfjuConfig.Get("EJ_Code"));

                facade.AtualizaRelatorioPeriodo(relatorioASerAtualizado);

                return new RespostaProcessamentoRelatorioDTO { SolicitacaoBemSucedida = true, RespostaSoliciticao = "Relatório atualizado com sucesso!!!" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/RelatoriosReuniaoFJU/ProcessarFechamentoRelatorioBloco")]
        public RespostaProcessamentoFechamentoRelatorioBlocoDTO ProcessarFechamentoRelatorioBloco() {
            try {
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                var vIdBlocoLogado = SessionHelper.RetornaUsuarioLogado().BlocoUsuario.Id;

                facade.ProcessarFechamentoRelatorioBloco(new ProcessaFechamentoRelatorioBlocoDTO { 
                    IdBlocoFechamentoRelatorio = vIdBlocoLogado,
                    DataInicialRelatorioFJU = RetornaPeriodoRelatorioSeFinalSemana().DataInicial,
                    DataFinalRelatorioFJU = RetornaPeriodoRelatorioSeFinalSemana().DataFinal
                });

                return new RespostaProcessamentoFechamentoRelatorioBlocoDTO { RespostaSoliciticao = "Relatório fechado com sucesso!!!", SolicitacaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/RelatoriosReuniaoFJU/RetornaRelatorioConsolidadoEstadoLogadoPorPeriodo")]
        public RelatorioConsolidadoEstadualSemanal RetornaRelatorioConsolidadoEstadoLogadoPorPeriodo() {
            try {
                RelatorioConsolidadoEstadualSemanal
                    retorno = null; 
                var facade = new FacadeRelatorioReuniaoFJUIgrejaImpl();
                var parametros = new ParametroPesquisaRelatorioIgrejasPeriodo();

                parametros.IdEstado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                parametros.DataInicial = this.RetornaPeriodoRelatorioSeFinalSemana().DataInicial;
                parametros.DataFinal = this.RetornaPeriodoRelatorioSeFinalSemana().DataFinal;

                retorno = facade.RetornaRelatorioConsolidadoEstadoPorPeriodo(parametros);

                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}