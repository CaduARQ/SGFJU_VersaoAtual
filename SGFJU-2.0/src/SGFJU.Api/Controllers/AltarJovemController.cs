using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
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
    public class AltarJovemController : ControllerBase
    {
        [HttpPost]
        [Route("api/AltarJovem/ObterJovensAltarJovemPorParametro")]
        public IList<AltarJovemDTO> ObterJovensAltarJovemPorParametro([FromBody] AltarJovemParametroPesquisaDTO parametro) {
            try {
                var facade = new AltarJovemFacadeImpl();

                

                return facade.ObterJovensAltarJovemPorParametro(parametro);
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/AltarJovem/ObterTodosJovensAltarJovemPorEstado")]
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorEstado([FromBody] EstadoDTO estado) {
            try {
                var facade = new AltarJovemFacadeImpl();

                return facade.ObterTodosJovensAltarJovemPorEstado(estado);
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/AltarJovem/ObterTodosJovensAltarJovemPorEstadoLogado")]
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorEstadoLogado()
        {
            try
            {
                var facade = new AltarJovemFacadeImpl();
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;

                return facade.ObterTodosJovensAltarJovemPorEstado(new EstadoDTO { IdEstado = idEstadoLogado });
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/AltarJovem/ObterTodosBR")]
        public IList<AltarJovemDTO> ObterTodosBR()
        {
            try
            {
                var facade = new AltarJovemFacadeImpl();

                return facade.ObterTodosBR();
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/AltarJovem/ObterTodosJovensAltarJovemPorBloco")]
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorBloco([FromBody] BlocoDTO bloco){
            try {
                var facade = new AltarJovemFacadeImpl();

                return facade.ObterTodosJovensAltarJovemPorBloco(bloco);
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/AltarJovem/ObterTodosJovensAltarJovemAgua")]
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemAgua(){
            try {
                var facade = new AltarJovemFacadeImpl();

                return facade.ObterTodosJovensAltarJovemAgua();
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/AltarJovem/ObterTodosJovensAltarJovemOleo")]
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemOleo(){
            try {
                var facade = new AltarJovemFacadeImpl();

                return facade.ObterTodosJovensAltarJovemOleo();
            }
            catch (Exception) {

                throw;
            }
        }

        [HttpPost]
        [Route("api/AltarJovem/ObterTodosJovensAltarJovemSal")]
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemSal(){
            try {
                var facade = new AltarJovemFacadeImpl();

                return facade.ObterTodosJovensAltarJovemSal();
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/AltarJovem/ObterTodosJovensAltarJovemLuz")]
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemLuz(){
            try {
                var facade = new AltarJovemFacadeImpl();

                return facade.ObterTodosJovensAltarJovemLuz();
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/AltarJovem/ListaJovensLevantadosParaOAltarPorParametro")]
        public IList<TodosJovensDTO> ListaJovensLevantadosParaOAltarPorParametro([FromBody] AltarJovemParametroPesquisaDTO parametrosPesquisa) {
            try {
                var facade = new AltarJovemFacadeImpl();
                var nomePerfilUsuarioLogado = SessionHelper.RetornaPerfilUsuarioLogado().Descricao;

                if (nomePerfilUsuarioLogado != "Administrador") {
                    if (parametrosPesquisa != null) {
                        if (parametrosPesquisa.IdEstado == 0)
                            parametrosPesquisa.IdEstado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                    }
                }

                return facade.ListaJovensLevantadosParaOAltarPorParametro(parametrosPesquisa);
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
