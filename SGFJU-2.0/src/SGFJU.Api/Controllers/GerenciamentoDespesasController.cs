using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class GerenciamentoDespesasController : ControllerBase
    {
        [HttpGet]
        [Route("api/GerenciamentoDespesas/ObterDespesasDataAtualEstadoLogado")]
        public IList<DespesaDTO> ObterDespesasDataAtualEstadoLogado() {
            try {
                var facade = new GerenciamentoDespesasFacadeImpl();
                var retorno = facade.ListarDespesasRegistradasHojePorEstado(new EstadoDTO { IdEstado = SessionHelper.RetornaEstadoUsuarioLogado().Id });

                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
        [HttpPost]
        [Route("api/GerenciamentoDespesas/RegistraAcaoComDespesas")]
        public RespostaRequisicaoDTO RegistraAcaoComDespesas([FromBody] AcaoComDespesasDTO acaoComSuasDespesas) {
            try {
                var facade = new FacadeBaseImpl<Acao>();
                var novaAcao = new Acao { 
                    NomeAcao = acaoComSuasDespesas.NomeAcao,
                    DataAcao = DateTime.Parse(acaoComSuasDespesas.DataAcao),
                    HoraInicio = acaoComSuasDespesas.HoraInicio,
                    HoraFim = acaoComSuasDespesas.HoraFim,
                    EstadoAcao = new Estado { Id = acaoComSuasDespesas.IdEstadoAcao },
                    TipoAcao = new TipoAcao { Code = acaoComSuasDespesas.IdTipoAcao }
                };

                foreach (var despesa in acaoComSuasDespesas.DespesasRelacionadas) {
                    novaAcao.addDespesaDaAcao(new Despesa { 
                        Id = despesa.IdDespesa
                    });
                }

                facade.Save(novaAcao);

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Ação com despesas registrada com sucesso!!!" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
