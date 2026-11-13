using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class RelatorioBlocosController : ControllerBase
    {
        [HttpGet]
        [Route("api/RelatorioBlocos/TotaisDashboardNacional")]
        public RelatorioBlocoTotaisGeraisDTO TotaisDashboardNacional() {
            try {
                var facadeDash = new DashboardRelatorioBlocoFacadeImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var totaisNacionalRetorno = new RelatorioBlocoTotaisGeraisDTO();
                var totaisEstados = facadeDash.RetornaTotaisBlocosNacional();

                totaisNacionalRetorno.QuantidadeTotalJovens = totaisEstados.Sum(tt => tt.QuantidadeTotalJovens);
                totaisNacionalRetorno.QuantidadeTotalJovensAtivos = totaisEstados.Sum(tt => tt.QuantidadeTotalJovensAtivos);
                totaisNacionalRetorno.QuantidadeTotalJovensIniciantes = totaisEstados.Sum(tt => tt.QuantidadeTotalJovensIniciantes);
                totaisNacionalRetorno.QuantidadeTotalJovensInativos = totaisEstados.Sum(tt => tt.QuantidadeTotalJovensInativos);
                totaisNacionalRetorno.QuantidadeTotalHomens = totaisEstados.Sum(tt => tt.QuantidadeTotalHomens);
                totaisNacionalRetorno.QuantidadeTotalBatizadosAguas = totaisEstados.Sum(tt => tt.QuantidadeTotalBatizadosAguas);
                totaisNacionalRetorno.QuantidadeTotalEspiritoSanto = totaisEstados.Sum(tt => tt.QuantidadeTotalEspiritoSanto);
                totaisNacionalRetorno.QuantidadeTotalMulheres = totaisEstados.Sum(tt => tt.QuantidadeTotalMulheres);
                totaisNacionalRetorno.QuantidadeTotalObreiros = totaisEstados.Sum(tt => tt.QuantidadeTotalObreiros);
                totaisNacionalRetorno.QuantidadeTotalColaboradores = totaisEstados.Sum(tt => tt.QuantidadeTotalColaboradores);
                totaisNacionalRetorno.QuantidadeTotalCPO = totaisEstados.Sum(tt => tt.QuantidadeTotalCPO);
                totaisNacionalRetorno.QuantidadeJovensAltarJovem = totaisEstados.Sum(tt => tt.QuantidadeJovensAltarJovem);
                totaisNacionalRetorno.QuantidadeTotalUniversitarios = totaisEstados.Sum(tt => tt.QuantidadeTotalUniversitarios);
                totaisNacionalRetorno.QuantidadeTotalMidia = totaisEstados.Sum(tt => tt.QuantidadeTotalMidia);
                totaisNacionalRetorno.QuantidadeTotalHelp = totaisEstados.Sum(tt => tt.QuantidadeTotalHelp);
                totaisNacionalRetorno.QuantidadeTotalSecretarias = totaisEstados.Sum(tt => tt.QuantidadeTotalSecretarias);
                totaisNacionalRetorno.QuantidadeTotalCultura = totaisEstados.Sum(tt => tt.QuantidadeTotalCultura);
                totaisNacionalRetorno.QuantidadeTotalEsporte = totaisEstados.Sum(tt => tt.QuantidadeTotalEsporte);
                totaisNacionalRetorno.QuantidadeTotalAtalaia = totaisEstados.Sum(tt => tt.QuantidadeTotalAtalaia);
                totaisNacionalRetorno.QuantidadeTotalArcanjos = totaisEstados.Sum(tt => tt.QuantidadeTotalArcanjos);
                totaisNacionalRetorno.QuantidadeTotalUniforca = totaisEstados.Sum(tt => tt.QuantidadeTotalUniforca);

                return totaisNacionalRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
