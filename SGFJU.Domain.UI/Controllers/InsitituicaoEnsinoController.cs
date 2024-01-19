using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.ValueObjects;
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
    public class InsitituicaoEnsinoController : ApiController
    {
        [HttpPost]
        [Route("api/InsitituicaoEnsino/RegistrarInstituicaoEnsino")]
        public RespostaRequisicaoDTO RegistrarInstituicaoEnsino([FromBody] InstituicaoEnsinoDTO instituicaoEnsinoParametro)
        {
            try
            {
                var facade = new FacadeBaseImpl<InstituicaoEnsino>();
                var novaInstituicaoEnsino = new InstituicaoEnsino();

                novaInstituicaoEnsino.NomeInstituicaoEnsino = instituicaoEnsinoParametro.NomeInstituicaoEnsino;
                novaInstituicaoEnsino.Endereco = instituicaoEnsinoParametro.Endereco;
                novaInstituicaoEnsino.Contato = instituicaoEnsinoParametro.Contato;
                novaInstituicaoEnsino.NomeContato = instituicaoEnsinoParametro.NomeContato;
                novaInstituicaoEnsino.FuncaoContatoInstituicaoEnsino = instituicaoEnsinoParametro.FuncaoContatoInstituicaoEnsino;
                novaInstituicaoEnsino.IgrejaInstituicao = new Igreja { Id = instituicaoEnsinoParametro.IdIgrejaInstituicao };
                novaInstituicaoEnsino.PerfilInstituicao = new PerfilInstituicaoEnsino { Codigo = instituicaoEnsinoParametro.IdPerfilInstituicao };
                novaInstituicaoEnsino.TipoInstituicao = new TipoInstituicaoEnsino { Codigo = instituicaoEnsinoParametro.IdTipoInstituicao };
                novaInstituicaoEnsino.ClassificacaoInstituicao = new ClassificacaoInstituicaoEnsino { Codigo = instituicaoEnsinoParametro.IdClassificacaoInstituicao };

                facade.Save(novaInstituicaoEnsino);
                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Instituição registrada com sucesso!!!", RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/InsitituicaoEnsino/RecuperaInstituicaoEnsinoParaAtualizacao")]
        public InstituicaoEnsinoDTO RecuperaInstituicaoEnsinoParaAtualizacao([FromBody]InstituicaoEnsinoDTO pInstituicaoASerAtualizada)
        {
            try
            {
                var facade = new InsituicaoEnsinoFacadeImpl();
                var a = facade.ListarPorParametro(new ParametroPesquisaInstituicaoEnsinoDTO { IdInstituicaoEnsino = pInstituicaoASerAtualizada.IdInstituicaoEnsino })[0];

                return a;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/InsitituicaoEnsino/AtualizarInstituicaoEnsino")]
        public RespostaRequisicaoDTO AtualizarInstituicaoEnsino([FromBody] InstituicaoEnsinoDTO instituicaoEnsinoParametro) {
            try {
                var facade = new FacadeBaseImpl<InstituicaoEnsino>();
                var instituicaoParaAtualizar = facade.GetByID(instituicaoEnsinoParametro.IdInstituicaoEnsino);

                instituicaoParaAtualizar.NomeInstituicaoEnsino = instituicaoEnsinoParametro.NomeInstituicaoEnsino;
                instituicaoParaAtualizar.Endereco = instituicaoEnsinoParametro.Endereco;
                instituicaoParaAtualizar.Contato = instituicaoEnsinoParametro.Contato;
                instituicaoParaAtualizar.NomeContato = instituicaoEnsinoParametro.NomeContato;
                instituicaoParaAtualizar.FuncaoContatoInstituicaoEnsino = instituicaoEnsinoParametro.FuncaoContatoInstituicaoEnsino;
                instituicaoParaAtualizar.PerfilInstituicao = new PerfilInstituicaoEnsino { Codigo = instituicaoEnsinoParametro.IdPerfilInstituicao };
                instituicaoParaAtualizar.TipoInstituicao = new TipoInstituicaoEnsino { Codigo = instituicaoEnsinoParametro.IdTipoInstituicao };
                instituicaoParaAtualizar.ClassificacaoInstituicao = new ClassificacaoInstituicaoEnsino { Codigo = instituicaoEnsinoParametro.IdClassificacaoInstituicao };
                instituicaoParaAtualizar.IgrejaInstituicao = new Igreja { Id = instituicaoEnsinoParametro.IdIgrejaInstituicao };


                facade.Save(instituicaoParaAtualizar);
                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Instituição atualizada com sucesso!!!", RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/InsitituicaoEnsino/ExcluirInstituicaoEnsino")]
        public RespostaRequisicaoDTO ExcluirInstituicaoEnsino(InstituicaoEnsinoDTO instituicaoASerExcluida)
        {
            try
            {
                var facade = new InsituicaoEnsinoFacadeImpl();
                return facade.ExcluirInstituicaoEnsino(instituicaoASerExcluida);
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/InsitituicaoEnsino/ListaTodasInstituicoesEstadoLogado")]
        public IList<InstituicaoEnsinoDTO> ListaTodasInstituicoesEstadoLogado() {
            try {
                var _facade = new InsituicaoEnsinoFacadeImpl();
                var idEstado = SessionHelper.RetornaEstadoUsuarioLogado().Id;
                var retorno = _facade.ListarPorParametro(new ParametroPesquisaInstituicaoEnsinoDTO { IdEstado = idEstado }).ToList();

                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/InsitituicaoEnsino/ListaTodasInstituicoesEnsino")]
        public IList<InstituicaoEnsinoDTO> ListaTodasInstituicoesEnsino() {
            try {
                var _facade = new InsituicaoEnsinoFacadeImpl();
                var retorno = _facade.ListarPorParametro(new ParametroPesquisaInstituicaoEnsinoDTO {}).ToList();

                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/InsitituicaoEnsino/ListarPorParametro")]
        public IList<InstituicaoEnsinoDTO> ListarPorParametro([FromBody] ParametroPesquisaInstituicaoEnsinoDTO parametroPesquisa) {
            try {
                var _facade = new InsituicaoEnsinoFacadeImpl();
                var retorno = _facade.ListarPorParametro(parametroPesquisa);

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
