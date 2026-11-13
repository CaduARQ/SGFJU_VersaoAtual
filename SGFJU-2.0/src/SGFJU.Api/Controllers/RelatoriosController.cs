using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class RelatoriosController : ControllerBase
    {
        [HttpGet]
        [Route("api/Relatorios/TotaisDashboardNacional")]
        public RelatorioTotaisGeralDTO TotaisDashboardNacional() {
            try {
                var facadeDash = new DashboardRelatorioFacadeImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var totaisNacionalRetorno = new RelatorioTotaisGeralDTO();
                var totaisEstados = facadeDash.RetornaTotaisNacional();

                totaisNacionalRetorno.QuantidadeTotalJovens         = totaisEstados.Sum(tt => tt.QuantidadeTotalJovens);
                totaisNacionalRetorno.QuantidadeTotalJovensAtivos   = totaisEstados.Sum(tt => tt.QuantidadeTotalJovensAtivos);
                totaisNacionalRetorno.QuantidadeTotalJovensIniciantes   = totaisEstados.Sum(tt => tt.QuantidadeTotalJovensIniciantes);
                totaisNacionalRetorno.QuantidadeTotalJovensInativos = totaisEstados.Sum(tt => tt.QuantidadeTotalJovensInativos);
                totaisNacionalRetorno.QuantidadeTotalHomens         = totaisEstados.Sum(tt => tt.QuantidadeTotalHomens);
                totaisNacionalRetorno.QuantidadeTotalBatizadosAguas = totaisEstados.Sum(tt => tt.QuantidadeTotalBatizadosAguas);
                totaisNacionalRetorno.QuantidadeTotalEspiritoSanto  = totaisEstados.Sum(tt => tt.QuantidadeTotalEspiritoSanto);
                totaisNacionalRetorno.QuantidadeTotalMulheres       = totaisEstados.Sum(tt => tt.QuantidadeTotalMulheres);
                totaisNacionalRetorno.QuantidadeTotalObreiros       = totaisEstados.Sum(tt => tt.QuantidadeTotalObreiros);
                totaisNacionalRetorno.QuantidadeTotalColaboradores  = totaisEstados.Sum(tt => tt.QuantidadeTotalColaboradores);
                totaisNacionalRetorno.QuantidadeTotalCPO            = totaisEstados.Sum(tt => tt.QuantidadeTotalCPO);
                totaisNacionalRetorno.QuantidadeJovensAltarJovem    = totaisEstados.Sum(tt => tt.QuantidadeJovensAltarJovem);
                totaisNacionalRetorno.QuantidadeTotalUniversitarios = totaisEstados.Sum(tt => tt.QuantidadeTotalUniversitarios);
                totaisNacionalRetorno.QuantidadeTotalMidia          = totaisEstados.Sum(tt => tt.QuantidadeTotalMidia );
                totaisNacionalRetorno.QuantidadeTotalHelp           = totaisEstados.Sum(tt => tt.QuantidadeTotalHelp );
                totaisNacionalRetorno.QuantidadeTotalSecretarias    = totaisEstados.Sum(tt => tt.QuantidadeTotalSecretarias );
                totaisNacionalRetorno.QuantidadeTotalCultura        = totaisEstados.Sum(tt => tt.QuantidadeTotalCultura );
                totaisNacionalRetorno.QuantidadeTotalEsporte        = totaisEstados.Sum(tt => tt.QuantidadeTotalEsporte );
                totaisNacionalRetorno.QuantidadeTotalAtalaia        = totaisEstados.Sum(tt => tt.QuantidadeTotalAtalaia );
                totaisNacionalRetorno.QuantidadeTotalArcanjos       = totaisEstados.Sum(tt => tt.QuantidadeTotalArcanjos );
                totaisNacionalRetorno.QuantidadeTotalUniforca       = totaisEstados.Sum(tt => tt.QuantidadeTotalUniforca );

                return totaisNacionalRetorno;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Relatorios/ListaTodosTotaisDosEstados")]
        public IList<RelatorioTotaisGeralDTO> ListaTodosTotaisDosEstados() {
            try
            {
                var facadeDash = new DashboardRelatorioFacadeImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var todosTotaisRetornados = facadeDash.ListAll();
                //var totaisEstadoLogado = new List<RelatorioTotaisGeralDTO>();
                
                var totaisEstadoLogado 
                    = facadeDash.ListAll()
                                .Select(rl => new RelatorioTotaisGeralDTO {
                                    IdEstado                      = rl.EstadoRelatorio.Id,
                                    NomeEstado                    = rl.EstadoRelatorio.NomeEstado,
                                    QuantidadeTotalJovens         = rl.QuantidadeTotalJovens,
                                    QuantidadeTotalJovensAtivos   = rl.QuantidadeTotalJovensAtivos,
                                    QuantidadeTotalJovensInativos = rl.QuantidadeTotalJovensInativos,
                                    QuantidadeTotalJovensIniciantes   = rl.QuantidadeTotalJovensIniciantes,
                                    QuantidadeTotalHomens         = rl.QuantidadeTotalHomens,
                                    QuantidadeTotalBatizadosAguasPercent = rl.QuantidadeTotalBatizadosAguas.ToString() + " - " + (rl.QuantidadeTotalBatizadosAguas / rl.QuantidadeTotalJovens * 100),
                                    QuantidadeTotalEspiritoSantoPercent  = rl.QuantidadeTotalEspiritoSanto.ToString() + " - " + (rl.QuantidadeTotalEspiritoSanto / rl.QuantidadeTotalJovens * 100),
                                    QuantidadeTotalBatizadosAguas = rl.QuantidadeTotalBatizadosAguas,
                                    QuantidadeTotalEspiritoSanto = rl.QuantidadeTotalEspiritoSanto,
                                    QuantidadeTotalMulheres       = rl.QuantidadeTotalMulheres,
                                    QuantidadeTotalObreiros       = rl.QuantidadeTotalObreiros,
                                    QuantidadeTotalColaboradores  = rl.QuantidadeTotalColaboradores,
                                    QuantidadeTotalCPO            = rl.QuantidadeTotalCPO,
                                    QuantidadeJovensAltarJovem    = rl.QuantidadeJovensAltarJovem,
                                    QuantidadeTotalUniversitarios = rl.QuantidadeTotalUniversitarios,
                                    QuantidadeTotalMidia          = rl.QuantidadeTotalMidia ,
                                    QuantidadeTotalHelp           = rl.QuantidadeTotalHelp ,
                                    QuantidadeTotalSecretarias    = rl.QuantidadeTotalSecretarias ,
                                    QuantidadeTotalCultura        = rl.QuantidadeTotalCultura ,
                                    QuantidadeTotalEsporte        = rl.QuantidadeTotalEsporte ,
                                    QuantidadeTotalAtalaia        = rl.QuantidadeTotalAtalaia ,
                                    QuantidadeTotalArcanjos       = rl.QuantidadeTotalArcanjos ,
                                    QuantidadeTotalUniforca       = rl.QuantidadeTotalUniforca
                                }); 
                /*
                foreach (var totalEstado in todosTotaisRetornados) {
                    var totalDeJovensNoEstado = totalEstado.QuantidadeTotalJovens;
                    var totalDeJovensBatizadosAguas = totalEstado.QuantidadeTotalBatizadosAguas;
                    var totalDeJovensBatizadosEspiritoSanto = totalEstado.QuantidadeTotalEspiritoSanto;
                    var percentualEstadoAguas = (totalDeJovensBatizadosAguas / totalDeJovensNoEstado * 100);
                    var percentualEstadoEspiritoSanto = (totalDeJovensBatizadosEspiritoSanto / totalDeJovensNoEstado * 100);
                    totaisEstadoLogado.Add(new RelatorioTotaisGeralDTO {
                                    IdEstado                      = totalEstado.EstadoRelatorio.Id,
                                    NomeEstado                    = totalEstado.EstadoRelatorio.NomeEstado,
                                    QuantidadeTotalJovens         = totalEstado.QuantidadeTotalJovens,
                                    QuantidadeTotalHomens         = totalEstado.QuantidadeTotalHomens,
                                    QuantidadeTotalBatizadosAguasPercent = 
                                        totalEstado.QuantidadeTotalBatizadosAguas.ToString() + " - " + (totalEstado.QuantidadeTotalBatizadosAguas / totalEstado.QuantidadeTotalJovens * 100),
                                    QuantidadeTotalEspiritoSantoPercent  = 
                                        totalEstado.QuantidadeTotalEspiritoSanto.ToString() + " - " + (totalEstado.QuantidadeTotalEspiritoSanto / totalEstado.QuantidadeTotalJovens * 100),
                                    QuantidadeTotalBatizadosAguas = totalEstado.QuantidadeTotalBatizadosAguas,
                                    QuantidadeTotalEspiritoSanto  = totalEstado.QuantidadeTotalEspiritoSanto,
                                    QuantidadeTotalMulheres       = totalEstado.QuantidadeTotalMulheres,
                                    QuantidadeTotalObreiros       = totalEstado.QuantidadeTotalObreiros,
                                    QuantidadeTotalColaboradores  = totalEstado.QuantidadeTotalColaboradores,
                                    QuantidadeTotalCPO            = totalEstado.QuantidadeTotalCPO,
                                    QuantidadeJovensAltarJovem    = totalEstado.QuantidadeJovensAltarJovem,
                                    QuantidadeTotalUniversitarios = totalEstado.QuantidadeTotalUniversitarios,
                                    QuantidadeTotalMidia          = totalEstado.QuantidadeTotalMidia ,
                                    QuantidadeTotalHelp           = totalEstado.QuantidadeTotalHelp ,
                                    QuantidadeTotalSecretarias    = totalEstado.QuantidadeTotalSecretarias ,
                                    QuantidadeTotalCultura        = totalEstado.QuantidadeTotalCultura ,
                                    QuantidadeTotalEsporte        = totalEstado.QuantidadeTotalEsporte ,
                                    QuantidadeTotalAtalaia        = totalEstado.QuantidadeTotalAtalaia ,
                                    QuantidadeTotalArcanjos       = totalEstado.QuantidadeTotalArcanjos ,
                                    QuantidadeTotalUniforca       = totalEstado.QuantidadeTotalUniforca});
                }
                */

                return totaisEstadoLogado.ToList();
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Relatorios/ObterTotaisDoEstado")]
        public RelatorioTotaisGeralDTO ObterTotaisDoEstado([FromBody] EstadoDTO estadoParametro) { 
            try {
                var facadeDash = new DashboardRelatorioFacadeImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var totalEstadoSelecionado = facadeDash.RetornaRelatorioTotaisEstado(new Estado { Id = estadoParametro.IdEstado });

                var totalEstadoSelecionadoRetorno = new RelatorioTotaisGeralDTO {
                    IdEstado                      = totalEstadoSelecionado.IdEstado,
                    NomeEstado                    = totalEstadoSelecionado.NomeEstado,
                    QuantidadeTotalJovens         = totalEstadoSelecionado.QuantidadeTotalJovens,
                    QuantidadeTotalJovensAtivos   = totalEstadoSelecionado.QuantidadeTotalJovensAtivos,
                    QuantidadeTotalJovensInativos = totalEstadoSelecionado.QuantidadeTotalJovensInativos,
                    QuantidadeTotalJovensIniciantes = totalEstadoSelecionado.QuantidadeTotalJovensIniciantes,
                    QuantidadeTotalHomens         = totalEstadoSelecionado.QuantidadeTotalHomens,
                    QuantidadeTotalBatizadosAguas = totalEstadoSelecionado.QuantidadeTotalBatizadosAguas,
                    QuantidadeTotalEspiritoSanto  = totalEstadoSelecionado.QuantidadeTotalEspiritoSanto,
                    QuantidadeTotalMulheres       = totalEstadoSelecionado.QuantidadeTotalMulheres,
                    QuantidadeTotalObreiros       = totalEstadoSelecionado.QuantidadeTotalObreiros,
                    QuantidadeTotalColaboradores  = totalEstadoSelecionado.QuantidadeTotalColaboradores,
                    QuantidadeTotalCPO            = totalEstadoSelecionado.QuantidadeTotalCPO,
                    QuantidadeJovensAltarJovem    = totalEstadoSelecionado.QuantidadeJovensAltarJovem,
                    QuantidadeTotalUniversitarios = totalEstadoSelecionado.QuantidadeTotalUniversitarios,
                    QuantidadeTotalMidia          = totalEstadoSelecionado.QuantidadeTotalMidia ,
                    QuantidadeTotalHelp           = totalEstadoSelecionado.QuantidadeTotalHelp ,
                    QuantidadeTotalSecretarias    = totalEstadoSelecionado.QuantidadeTotalSecretarias ,
                    QuantidadeTotalCultura        = totalEstadoSelecionado.QuantidadeTotalCultura ,
                    QuantidadeTotalEsporte        = totalEstadoSelecionado.QuantidadeTotalEsporte ,
                    QuantidadeTotalAtalaia        = totalEstadoSelecionado.QuantidadeTotalAtalaia ,
                    QuantidadeTotalArcanjos       = totalEstadoSelecionado.QuantidadeTotalArcanjos ,
                    QuantidadeTotalUniforca       = totalEstadoSelecionado.QuantidadeTotalUniforca
                };
                
                return totalEstadoSelecionadoRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Relatorios/TotaisDashBoardEstadoLogado")]
        public RelatorioTotaisGeralDTO TotaisDashBoardEstadoLogado() {            
            try{
                var facadeDash = new DashboardRelatorioFacadeImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var totaisEstadoLogado = facadeDash.RetornaRelatorioTotaisEstado(usuarioLogado.EstadoUsuario);
                return totaisEstadoLogado;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Relatorios/TotaisBlocosEstadoLogado")]
        public IList<RelatorioBlocoTotaisGeraisDTO> TotaisBlocosEstadoLogado()
        {
            try{
                var facadeDash         = new DashboardRelatorioFacadeImpl();
                var usuarioLogado      = SessionHelper.RetornaUsuarioLogado();
                var totaisEstadoLogado = facadeDash.RetornaTotaisBlocosPorEstado(usuarioLogado.EstadoUsuario);
                var totaisRetorno = new List<RelatorioBlocoTotaisGeraisDTO>();
                foreach (var blocoReport in totaisEstadoLogado){
                    if (blocoReport.QuantidadeTotalJovens != 0)
                        totaisRetorno.Add(blocoReport);
                }
                
                return totaisRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Relatorios/AtualizarDashboardEstadoLogado")]
        public RespostaRequisicaoDTO AtualizarDashboardEstadoLogado() { 
            try{
                var facadeDash         = new DashboardRelatorioFacadeImpl();
                var usuarioLogado      = SessionHelper.RetornaUsuarioLogado();
                facadeDash.AtualizarDashboard(usuarioLogado.EstadoUsuario);
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Dashboard Atualizado com sucesso !!!" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
