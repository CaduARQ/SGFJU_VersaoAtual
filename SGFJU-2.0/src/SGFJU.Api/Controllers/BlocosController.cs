using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Api.Legado;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class BlocosController : ControllerBase
    {
        // GET: api/Blocos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/blocos/ObterPorEstado/{idEstado}")]
        public IList<Bloco> ObterPorEstado(int idEstado) {            
            try {
                var facade = new FacadeEstadoImpl();
                var blocosDoEstado = facade.obterBlocosDoEstado(new Estado { Id = idEstado });
                TextInfo tInfo = CultureInfo.CurrentCulture.TextInfo;

                foreach (var _bloco in blocosDoEstado){
                    _bloco.NomeBloco = tInfo.ToTitleCase(_bloco.NomeBloco.ToLower());
                }

                return blocosDoEstado;
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/blocos/ObterPorEstadoLogado")]
        public IList<BlocoDTO> ObterPorEstadoLogado() {
            try {
                var facade = new FacadeEstadoImpl();
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var usuarioLogado = (sessaoAtual["UsuarioLogado"] as Usuario);
                var caminhoPastaArquivosSerializadosEstados = SgfjuConfig.Get("PathArquivosObjetosSerializados");
                var nomeArquivoBlocosSerializados = usuarioLogado.EstadoUsuario.SiglaEstado + "_Blocos.txt";
                var todosBlocosEstadoLogadoSerializados = AmbienteLegado.MapPath(caminhoPastaArquivosSerializadosEstados + "/" + nomeArquivoBlocosSerializados);
                var blocosDoEstado = facade.ListAllValueObjectsFromJson<BlocoDTO>(todosBlocosEstadoLogadoSerializados);
                TextInfo tInfo = CultureInfo.CurrentCulture.TextInfo;

                foreach (var _bloco in blocosDoEstado){
                    _bloco.NomeBloco = tInfo.ToTitleCase(_bloco.NomeBloco.ToLower());
                    _bloco.EstadoBloco = usuarioLogado.EstadoUsuario.NomeEstado;
                }

                return blocosDoEstado;
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

        [HttpPost]
        [Route("api/blocos/RegistraNovoBloco")]
        public RespostaRequisicaoDTO RegistraNovoBloco([FromBody] BlocoDTO novoBloco) {
            try {
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                var facade = new FacadeBaseImpl<Bloco>();
                facade.Save(new Bloco { 
                    NomeBloco = novoBloco.NomeBloco,
                    EstadoBloco = new Estado { Id = idEstadoLogado }
                });
                AtualizaJSONBlocos();
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Bloco cadastrado com sucesso!" };
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

        protected void AtualizaJSONBlocos() {
            try {
                var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
                var caminhoPastaArquivosSerializados = SgfjuConfig.Get("PathArquivosObjetosSerializados");

                var facade = new FacadeEstadoImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var nomeArquvioBloco = usuarioLogado.EstadoUsuario.SiglaEstado + "_Blocos.txt";
                var caminhoPastaArquivosOndeSerializar = AmbienteLegado.MapPath(caminhoPastaArquivosSerializados + "/" + nomeArquvioBloco);
                var blocosEstado = facade.obterBlocosDoEstado(usuarioLogado.EstadoUsuario).Select(b => new BlocoDTO
                {
                    idBloco = b.Id,
                    NomeBloco = b.NomeBloco,
                    IdEstadoBloco = b.EstadoBloco.Id
                });
                (serializer as JSONSerializer).SerializeToJSON(blocosEstado, caminhoPastaArquivosOndeSerializar);
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

        [HttpPost]
        [Route("api/Bloco/AtualizarBloco")]
        public RespostaRequisicaoDTO AtualizarBloco([FromBody] BlocoDTO blocoAtualizacao) { 
            try {
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                var facade = new FacadeEstadoImpl();
                facade.AtualizarBlocoDoEstado(blocoAtualizacao);
                AtualizaJSONBlocos();
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Bloco atualizado com sucesso!" };
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }
    }
}
