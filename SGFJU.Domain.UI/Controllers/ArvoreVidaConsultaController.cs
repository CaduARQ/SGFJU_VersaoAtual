using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.UI.Helpers;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.Domain.UI.Controllers
{
    public class ArvoreVidaConsultaController : ApiController
    {
        [HttpGet]
        [Route("api/ArvoreVidaConsulta/ListaJovensAcompanhadosPorPerfilLogado")]
        public IList<TodosJovensDTO> ListaJovensAcompanhadosPorPerfilLogado() {
            try {
                var facade = new FacadeArvoreVidaImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                IList<TodosJovensDTO> retorno = null;

                switch (usuarioLogado.PerfilUsuario.Descricao) {
                    case "Secretárias Estadual":
                        retorno = facade.ListaJovensEmAcompanhamentoPorParametro(new PesquisaGeralDTO { IdEstado = usuarioLogado.EstadoUsuario.Id });
                        break;
                    case "Secretária de Bloco":
                        retorno = facade.ListaJovensEmAcompanhamentoPorParametro(new PesquisaGeralDTO { IdBloco = usuarioLogado.BlocoUsuario.Id });
                        break;
                    case "Secretária de Região":
                        retorno = facade.ListaJovensEmAcompanhamentoPorParametro(new PesquisaGeralDTO { IdRegiao = usuarioLogado.RegiaoUsuario.Id });
                        break;
                }

                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVidaConsulta/ListaJovensAcompanhadosPorParametro")]
        public IList<TodosJovensDTO> ListaJovensAcompanhadosPorParametro([FromBody] PesquisaGeralDTO parametroPesquisa) {
            try {
                var facade = new FacadeArvoreVidaImpl();
                var sessao = SessionHelper.RetornaSessaoAtual();
                var retornoJovensSendoAcompanhados = facade.ListaJovensEmAcompanhamentoPorParametro(parametroPesquisa);
                sessao.Add("JovensSendoAcompanhados", retornoJovensSendoAcompanhados);
                return retornoJovensSendoAcompanhados;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVidaConsulta/ObterObreiroPorIDX")]
        public ObreiroDTO ObterObreiroPorIDX([FromBody] IdXDTO idxObreiroParametro) {
            try {
                var facade = new FacadeArvoreVidaImpl();
                var sessao = SessionHelper.RetornaSessaoAtual();
                var soTeste = EncryptionHelper.Encrypt("136");
                idxObreiroParametro.IdX = soTeste;
                var obreiroRetorno = facade.ObterObreiroPorIDX(idxObreiroParametro);
                return obreiroRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/ArvoreVidaConsulta/ListaObreirosComRamosPorEstado")]
        public IList<ObreiroDTO> ListaObreirosComRamosPorEstado() {
            try {
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var caminhoPastaArquivosSerializados =
                    System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"])
                    + "\\" + usuarioLogado.EstadoUsuario.SiglaEstado + "_AV.txt";
                var obreirosAV = (new FacadeBaseImpl<Estado>()).ListAllValueObjectsFromJson<ObreiroDTO>(caminhoPastaArquivosSerializados);
                return obreirosAV;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVidaConsulta/ListaObreirosComRamosPorParametro")]
        public IList<ObreiroDTO> ListaObreirosComRamosPorParametro([FromBody] PesquisaGeralDTO parametrosPesquisa) {
            try {
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var caminhoPastaArquivosSerializados =
                    System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"])
                    + "\\" + usuarioLogado.EstadoUsuario.SiglaEstado + "_AV.txt";
                var obreirosAV = (new FacadeBaseImpl<Estado>()).ListAllValueObjectsFromJson<ObreiroDTO>(caminhoPastaArquivosSerializados);
                IList<ObreiroDTO> resultadoPesquisa = null;

                if (parametrosPesquisa.IdEstado != 0) {
                    resultadoPesquisa = obreirosAV.Where(ob => ob.IdEstado == parametrosPesquisa.IdEstado).ToList();
                }

                if (parametrosPesquisa.IdBloco != 0) {
                    resultadoPesquisa = resultadoPesquisa.Where(bl => bl.IdBloco == parametrosPesquisa.IdBloco).ToList();
                }

                if (parametrosPesquisa.IdRegiao != 0) {
                    resultadoPesquisa = resultadoPesquisa.Where(reg => reg.IdRegiao == parametrosPesquisa.IdRegiao).ToList();
                }

                if (parametrosPesquisa.IdIgreja != 0) {
                    resultadoPesquisa = resultadoPesquisa.Where(ig => ig.IdIgreja == parametrosPesquisa.IdIgreja).ToList();
                }

                return resultadoPesquisa;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVidaConsulta/ListarObreirosSemRamosAVPorParametro")]
        public IList<ObreiroDTO> ListarObreirosSemRamosAVPorParametro([FromBody] PesquisaGeralDTO parametrosPesquisa) {
            try {
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var obreirosAV = (new FacadeArvoreVidaImpl()).ListarObreirosSemRamosAVPorParametro(parametrosPesquisa);
                return obreirosAV;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
