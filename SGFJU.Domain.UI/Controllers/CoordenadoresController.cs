using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
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
    public class CoordenadoresController : ApiController
    {
        [HttpGet]
        [Route("api/Coordenadores/ListaTodosPorEstadoLogado")]
        public IList<IgrejaCoordenadorDTO> ListaTodosPorEstadoLogado() {
            try {
                var estadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                var facade = new FacadeCoordenadorImpl();

                return facade.ListarCoordenadoresPorEstado(new EstadoDTO { IdEstado = estadoLogado });
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Coordenadores/TrocaCoordenador")]
        public RespostaRequisicaoDTO TrocaCoordenador([FromBody] IgrejaCoordenadorDTO dadosTrocaCoordenador) {
            try {
                var facade = new FacadeCoordenadorImpl();

                facade.TrocarCoordenador(new IgrejaCoordenador 
                {
                    Id = dadosTrocaCoordenador.IdIgrejaCoordenador,
                    DataSaidaCoordenador = DateTime.Parse(dadosTrocaCoordenador.DataSaidaCoordenador),
                    MotivoTrocaCoordenador = dadosTrocaCoordenador.MotivoTrocaCoordenador,
                    NomePastorEfetuouTroca = dadosTrocaCoordenador.NomePastorEfetuouTroca,
                    NomeNovoCoordenador = dadosTrocaCoordenador.NomeNovoCoordenador
                });

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Coordenadores/ObterCoordenadorAtualizacao")]
        public IgrejaCoordenadorDTO ObterCoordenadorAtualizacao([FromBody] IgrejaCoordenadorDTO coordenadorParametro) { 
            try {
                var facade = new FacadeCoordenadorImpl();
                var CoordenadorRetorno = facade.ObterCoordenadorInformacoesDetalhadas(coordenadorParametro);

                if(CoordenadorRetorno != null) 
                    SessionHelper.RetornaSessaoAtual().Add("CoordenadorAtualizacaoSessao", CoordenadorRetorno);

                return CoordenadorRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Coordenadores/PesquisarCoordenadorPorParametro")]
        public IList<IgrejaCoordenadorDTO> PesquisarCoordenadorPorParametro([FromBody] IgrejaCoordenadorParametroDTO parametroPesquisaCoordenador) {
            try {
                var facade = new FacadeCoordenadorImpl();
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                parametroPesquisaCoordenador.IdEstado = (parametroPesquisaCoordenador.IdEstado == 0)? idEstadoLogado : parametroPesquisaCoordenador.IdEstado;

                var ret = facade.PesquisarCoordenadorPorParametro(parametroPesquisaCoordenador);


                //return facade.PesquisarCoordenadorPorParametro(parametroPesquisaCoordenador);
                return ret;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Coordenadores/ArmazenaDataAlterada")]
        public void ArmazenaDataAlterada([FromBody] JovemDTO jovemParametro)
        {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            sessaoAtual.Add("Coordenadores_DataNascimentoAlterada", jovemParametro.DataNascimento);
        }

        [HttpPost]
        [Route("api/Coordenadores/ArmazenaDataAssumiurFJUAlterada")]
        public void ArmazenaDataAssumiurFJUAlterada([FromBody] IgrejaCoordenadorDTO parametro)
        {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            sessaoAtual.Add("Coordenadores_DataAssumiurFJUAlterada", parametro.DataEntradaCoordenador);
        }

        [HttpPost]
        [Route("api/Coordenadores/IgrejaPossuiCoordenador")]
        public RespostaRequisicaoDTO IgrejaPossuiCoordenador(IgrejaCoordenadorDTO igrejaCoordenadorParametro)
        {
            var facade = new FacadeEstadoImpl();
            if (facade.IgrejaPossuiCoordenador(new IgrejaCoordenador
                {
                    IgrejaFJU = new Igreja { Id = igrejaCoordenadorParametro.IdIgreja }
                }) )
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = false, MensagemRespostaRequisicao = "Já existe um coordenador associado à esta igreja, para substituí-lo, efetue a troca do mesmo." };
            return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true };
        }

        [HttpPost]
        [Route("api/Coordenadores/InformarIgrejaSemCoordenador")]
        public RespostaRequisicaoDTO InformarIgrejaSemCoordenador([FromBody] IgrejaDTO igrejaSemCoordenador) {
            try {
                var facade = new FacadeCoordenadorImpl();
                facade.InformarIgrejaSemCoordenador(new Igreja { Id = igrejaSemCoordenador.IdIgreja });

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Coordenadores/RetornaPanoramaCoordenadoresEstadoLogado")]
        public PanoramaCoordenadoresEstadoDTO RetornaPanoramaCoordenadoresEstadoLogado() {
            try {
                PanoramaCoordenadoresEstadoDTO retorno = new PanoramaCoordenadoresEstadoDTO();
                var facade = new FacadeCoordenadorImpl();
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                retorno.ListaCoordenadoresEstado = facade.ObterPanoramaGeralCoordenadorPorEstado(new EstadoDTO { IdEstado = idEstadoLogado });
                retorno.QuantidadeIgrejaSemCoordenador = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdCoordenadorFJU == 0 && cd.IdIgrejaCoordenador == 0));
                retorno.QuantidadeIgrejaComCoordenador = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdCoordenadorFJU != 0 && cd.IdIgrejaCoordenador != 0));
                retorno.QuantidadeIgrejaSemFJU = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdIgrejaCoordenador > 0 && cd.IdCoordenadorFJU == 0));

                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Coordenadores/RetornaPanoramaCoordenadoresPorEstado")]
        public PanoramaCoordenadoresEstadoDTO RetornaPanoramaCoordenadoresPorEstado([FromBody] EstadoDTO estadoParametro)
        {
            try
            {
                PanoramaCoordenadoresEstadoDTO retorno = new PanoramaCoordenadoresEstadoDTO();
                var facade = new FacadeCoordenadorImpl();
                retorno.ListaCoordenadoresEstado = facade.ObterPanoramaGeralCoordenadorPorEstado(estadoParametro);
                retorno.QuantidadeIgrejaSemCoordenador = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdCoordenadorFJU == 0 && cd.IdIgrejaCoordenador == 0));
                retorno.QuantidadeIgrejaComCoordenador = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdCoordenadorFJU != 0 && cd.IdIgrejaCoordenador != 0));
                retorno.QuantidadeIgrejaSemFJU = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdIgrejaCoordenador > 0 && cd.IdCoordenadorFJU == 0));

                return retorno;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Coordenadores/RetornaPanoramaCoordenadoresNacional")]
        public PanoramaCoordenadoresEstadoDTO RetornaPanoramaCoordenadoresNacional() { 
            try {
                PanoramaCoordenadoresEstadoDTO retorno = new PanoramaCoordenadoresEstadoDTO();
                var facade = new FacadeCoordenadorImpl();
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                retorno.ListaCoordenadoresEstado = facade.ObterPanoramaGeralCoordenadorNacional();
                retorno.QuantidadeIgrejaSemCoordenador = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdCoordenadorFJU == 0 && cd.IdIgrejaCoordenador == 0));
                retorno.QuantidadeIgrejaComCoordenador = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdCoordenadorFJU != 0 && cd.IdIgrejaCoordenador != 0));
                retorno.QuantidadeIgrejaSemFJU = retorno.ListaCoordenadoresEstado.Count(cd => (cd.IdIgrejaCoordenador > 0 && cd.IdCoordenadorFJU == 0));

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
