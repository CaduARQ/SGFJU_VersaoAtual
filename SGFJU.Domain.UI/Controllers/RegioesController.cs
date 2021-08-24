using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
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
    public class RegioesController : ApiController
    {

        [HttpGet]
        [Route("api/regioes/ObterPorBloco/{idBloco}")]
        public IList<RegiaoDTO> ObterPorBloco(int idBloco) {
            try {
                var facade = new FacadeEstadoImpl();
                var regioesDoBloco = facade.obterRegioesDoBloco(new Bloco { Id = idBloco })
                                           .Select(r => new RegiaoDTO { 
                                               idBloco = idBloco,
                                               IdRegiao = r.Id,
                                               NomeRegiao = r.NomeRegiao
                                           });
                return regioesDoBloco.ToList(); 
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/regioes/RegistraNovaRegiao")]
        public RespostaRequisicaoDTO RegistraNovaRegiao([FromBody] RegiaoDTO novaRegiao) { 
            try {
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                var facade = new FacadeBaseImpl<Regiao>();
                facade.Save(new Regiao { 
                    NomeRegiao = novaRegiao.NomeRegiao,
                    BlocoRegiao = new Bloco { Id = novaRegiao.idBloco }
                });

                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} cadastrou uma nova Região de nome {novaRegiao.NomeRegiao} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Região cadastrado com sucesso!" };
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/regioes/ObterPorEstadoLogado")]
        public IList<RegiaoDTO> ObterPorEstadoLogado()
        {
            try
            {
                var facade = new FacadeEstadoImpl();
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                var regioesDoEstado = facade.ObterRegioesPorEstado(new Estado { Id = idEstadoLogado });

                return regioesDoEstado;
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
