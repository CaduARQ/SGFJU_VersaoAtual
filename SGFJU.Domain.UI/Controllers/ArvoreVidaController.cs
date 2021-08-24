using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Domain.UI.Helpers;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SGFJU.Domain.UI.Controllers
{
    public class ArvoreVidaController : ApiController
    {
        [HttpPost]
        [Route("api/ArvoreVida/AssociaJovensAObreiro")]
        public RespostaRequisicaoDTO AssociaJovensAObreiro([FromBody] AssociacaoJovensObreiroDTO associacaoJovensObreiro) {
            try {
                var facade = new FacadeArvoreVidaImpl();
                facade.AssociaJovensAObreiro(associacaoJovensObreiro.JovensAcompanhados, associacaoJovensObreiro.ObreiroQueAcompanha);

                //AtualizaJSONArvoreVidaObreirosComRamos(associacaoJovensObreiro.JovensAcompanhados, associacaoJovensObreiro.ObreiroQueAcompanha);
                //Task JSONRegerado = Task.WhenAll(AtualizaJSONEstadoLogado());
                
                AtualizaJSONEstadoLogado();

                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} associou o(s) jovem(ns) de ID(s) {string.Join(",", associacaoJovensObreiro.JovensAcompanhados)} ao Obreiro de ID {associacaoJovensObreiro.ObreiroQueAcompanha.IdObreiro} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                //AtualizaJSONArvoreVidaObreirosComRamos();

                //remover dados utilizados da sessão
                SessionHelper.RetornaSessaoAtual().Remove("ObreirosPesquisadosPorParametro");
                SessionHelper.RetornaSessaoAtual().Remove("JovensJaAcompanhadosPorObreiro");
                SessionHelper.RetornaSessaoAtual().Remove("JovensSemAcompanhamento");

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/RegistraHistoricoJovem")]
        public RespostaRequisicaoDTO RegistraHistoricoJovem([FromBody]ItemAcompanhamentoHistoricoDTO historicoDoJovem) {
            try {
                var facade = new FacadeArvoreVidaImpl();
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                //var resultadoValidacaoDataHistorico = validaPeriodicidadeDataRegistroHistorio();
                var vIdJovem = (sessaoAtual["AcompanhamentoJovemSessao"] as AcompanhamentoJovemDTO).IdJovemEmAcompanhamento;
                ///var resultadoValidacaoDataHistoricoBD = facade.EhDataHistoricoAcompanhamentoValida(DateTime.Now.ToString("yyyy-MM-dd"), vIdJovem);

                /*
                if (!resultadoValidacaoDataHistorico.EhDataValida)
                    return new RespostaRequisicaoDTO { RequisicaoBemSucedida = false, MensagemRespostaRequisicao = resultadoValidacaoDataHistorico.MensagemValidacao };

                if(!resultadoValidacaoDataHistoricoBD.EhDataValida)
                    return new RespostaRequisicaoDTO { RequisicaoBemSucedida = false, MensagemRespostaRequisicao = resultadoValidacaoDataHistoricoBD.MensagemValidacao };
                */

                facade.RegistraHistoricoJovem(new JovemHistorico {
                    Jovem = new Jovem { Id = vIdJovem },
                    Obreiro = new Jovem { Id = (sessaoAtual["AcompanhamentoJovemSessao"] as AcompanhamentoJovemDTO).IdObreiro },
                    TextoObservacao = historicoDoJovem.TextoHistorico,
                    StatusJovem = new StatusAcompanhamento { Code = historicoDoJovem.IdStatusAcompanhamento },
                    DataHistoricoAcompanhamento = DateTime.Now
                });

                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} registrou o histórioco do jovem de ID  {historicoDoJovem.IdJovem} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                sessaoAtual.Remove("AcompanhamentoJovemSessao");

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Registro de histórico realizado com sucesso !" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/ObterHistorico")]
        public ItemAcompanhamentoHistoricoDTO ObterHistorico([FromBody] ItemAcompanhamentoHistoricoDTO itemParametro) {
            try {
                var acompanhamentoNaSessao = (SessionHelper.RetornaSessaoAtual()["AcompanhamentoJovemSessao"] as AcompanhamentoJovemDTO);
                var itemRetorno = acompanhamentoNaSessao.HistoricoAcompanhamento.Where(hi => hi.IdHistorico == itemParametro.IdHistorico).Single();

                return itemRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
        //

        public DataValidaHistoricoDTO validaPeriodicidadeDataRegistroHistorio() {
            var dataAtual = DateTime.Now;
            var mesAtual = DateTime.Now.Month;
            var mesPassado = (DateTime.Now.Month - 1);
            var diaLimite = 15;
            var dataLimiteInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
            var dataLimiteFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 15);

            if (mesAtual == mesPassado)
                return new DataValidaHistoricoDTO { EhDataValida = false, MensagemValidacao = "Data de registro de histórico não pode ser retroativa !" };

            if (dataAtual >= dataLimiteInicio &&
                dataAtual <= dataLimiteFim)
                return new DataValidaHistoricoDTO { EhDataValida = true, MensagemValidacao = "Data é valida" };
            else
                return new DataValidaHistoricoDTO { EhDataValida = false, MensagemValidacao = "Data de registro deve estar entre o dia 15 do mês atual, e o dia 15 do próximo mês !" };
        }

        [HttpPost]
        [Route("api/ArvoreVida/ListaJovensAcompanhadosPorObreiro")]
        public IList<TodosJovensDTO> ListaJovensAcompanhadosPorObreiro([FromBody] ObreiroDTO obreiro) { 
            try {
                var facade = new FacadeArvoreVidaImpl();                
                return facade.ListaJovensAcompanhadosPorObreiro(obreiro);
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/ListaJovensAcompanhadosPorObreiroSafe")]
        public IList<TodosJovensDTO> ListaJovensAcompanhadosPorObreiroSafe([FromBody] ObreiroDTO obreiro)
        {
            try
            {
                var facade = new FacadeArvoreVidaImpl();
                obreiro.IdObreiro = int.Parse( EncryptionHelper.Decrypt(obreiro.IdObreiroX) );
                var jovensJaEmAcompanhamentoPorObreiro = facade.ListaJovensAcompanhadosPorObreiro(obreiro);
                SessionHelper.RetornaSessaoAtual().Add("JovensJaAcompanhadosPorObreiro", jovensJaEmAcompanhamentoPorObreiro);
                return jovensJaEmAcompanhamentoPorObreiro;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/ArvoreVida/RetornaObreiroQueAcompanhaJovem")]
        public ObreiroDTO RetornaObreiroQueAcompanhaJovem([FromBody] Jovem jovemParametro) { 
            try {
                var facade = new FacadeArvoreVidaImpl();
                return facade.RetornaObreiroQueAcompanhaJovem(jovemParametro);
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/PesquisaObreiroPorParametro")]
        public IList<ObreiroDTO> PesquisaObreiroPorParametro([FromBody] ParametroPesquisaObreiroDTO parametroPesquisaObreiro) {
            try {
                var facade = new FacadeArvoreVidaImpl();
                var resultSetObreiros = facade.PesquisaObreiroPorParametro(parametroPesquisaObreiro);

                SessionHelper.RetornaSessaoAtual().Add("ObreirosPesquisadosPorParametro", resultSetObreiros);

                ConfiguraFotoNaLista(ref resultSetObreiros);

                return resultSetObreiros;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/ListaJovensIgrejaObreiroSemAcompanhamento")]
        public IList<TodosJovensDTO> ListaJovensIgrejaObreiroSemAcompanhamento([FromBody] ObreiroDTO obreiroParametro)
        {
            try
            {
                var facade = new FacadeArvoreVidaImpl();
                var jovensSemAcompanhamento = facade.ListaJovensIgrejaObreiroSemAcompanhamento(obreiroParametro);
                SessionHelper.RetornaSessaoAtual().Add("JovensSemAcompanhamento", jovensSemAcompanhamento);
                return jovensSemAcompanhamento;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/ArvoreVida/ListaTodosObreirosPorEstadoLogado")]
        public IList<ObreiroDTO> ListaTodosObreirosPorEstadoLogado() {
            try {
                var facade = new FacadeArvoreVidaImpl();
                var idEstadoUsuarioLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                return facade.PesquisaObreiroPorParametro(new ParametroPesquisaObreiroDTO { IdEstado = idEstadoUsuarioLogado });
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/ArvoreVida/ListaTodosObreirosPorBlocoLogado")]
        public IList<ObreiroDTO> ListaTodosObreirosPorBlocoLogado() {
            try {
                var facade = new FacadeArvoreVidaImpl();
                var idBlocoLogado = SessionHelper.RetornaUsuarioLogado().BlocoUsuario.Id;
                var resultSetObreirosBlocoLogado =
                    facade.PesquisaObreiroPorParametro(new ParametroPesquisaObreiroDTO { IdBloco = idBlocoLogado });

                foreach (var jovemRetornado in resultSetObreirosBlocoLogado) {
                    var caminhoArquivoFotoJovem = "";
                    var ehPathInvalido = false;

                    if (string.IsNullOrEmpty(jovemRetornado.NomeArquivoFoto)) {
                        jovemRetornado.FotoEstaNoDiretorio = "N";
                    }
                    else {
                        try {
                            caminhoArquivoFotoJovem = System.Web.Hosting.HostingEnvironment.MapPath("/SGFJU2.0/FotosJovens" + "\\" + jovemRetornado.NomeArquivoFoto);
                        }
                        catch (Exception excSec) {
                            ehPathInvalido = true;
                        }

                        if (ehPathInvalido) {
                            jovemRetornado.FotoEstaNoDiretorio = "N";
                        }
                        else {
                            if (File.Exists(caminhoArquivoFotoJovem)) {
                                jovemRetornado.FotoEstaNoDiretorio = "S";
                            }
                            else {
                                jovemRetornado.FotoEstaNoDiretorio = "N";
                            }
                        }
                    }                    
                }

                return resultSetObreirosBlocoLogado;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/PesquisaObreiroPorNome")]
        public IList<ObreiroDTO> PesquisaObreiroPorNome([FromBody] ObreiroDTO obreiroParametro){
            try {
                var facade = new FacadeArvoreVidaImpl();
                var resultSetObreiros =
                    facade.PesquisaObreiroPorParametro(new ParametroPesquisaObreiroDTO { 
                        NomeObreiro = obreiroParametro.NomeObreiro,
                        IdEstado = (obreiroParametro.PesquisarPorEstadoOuBloco == "Estado")? SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id:0,
                        IdBloco = (obreiroParametro.PesquisarPorEstadoOuBloco == "Bloco") ? SessionHelper.RetornaUsuarioLogado().BlocoUsuario.Id : 0,
                    });

                ConfiguraFotoNaLista(ref resultSetObreiros);

                return resultSetObreiros;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        private void ConfiguraFotoNaLista(ref IList<ObreiroDTO> resultSetObreirosRef) {
            foreach (var jovemRetornado in resultSetObreirosRef) {
                var caminhoArquivoFotoJovem = "";
                var ehPathInvalido = false;

                if (string.IsNullOrEmpty(jovemRetornado.NomeArquivoFoto)) {
                    jovemRetornado.FotoEstaNoDiretorio = "N";
                }
                else {
                    try {
                        caminhoArquivoFotoJovem = System.Web.Hosting.HostingEnvironment.MapPath("/SGFJU2.0/FotosJovens" + "\\" + jovemRetornado.NomeArquivoFoto);
                    }
                    catch (Exception excSec) {
                        ehPathInvalido = true;
                    }

                    if (ehPathInvalido) {
                        jovemRetornado.FotoEstaNoDiretorio = "N";
                    }
                    else {
                        if (File.Exists(caminhoArquivoFotoJovem)) {
                            jovemRetornado.FotoEstaNoDiretorio = "S";
                        }
                        else {
                            jovemRetornado.FotoEstaNoDiretorio = "N";
                        }
                    }
                }                    
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/RetornaHistoricoAcompanhamentoJovem")]
        public AcompanhamentoJovemDTO RetornaHistoricoAcompanhamentoJovem([FromBody] JovemDTO jovemParametro) {
            try {
                var facade = new FacadeArvoreVidaImpl();
                jovemParametro.Id = int.Parse( EncryptionHelper.Decrypt(jovemParametro.IdX));
                var retorno = facade.RetornaHistoricoAcompanhamentoJovem(jovemParametro);
                SessionHelper.RetornaSessaoAtual().Add("AcompanhamentoJovemSessao", retorno);
                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/ArvoreVida/DesassociaJovensDeObreiro")]
        public RespostaRequisicaoDTO DesassociaJovensDeObreiro([FromBody] DesassociacaoJovensObreiroDTO desassociacaoJovensObreiro) { 
            try {
                var facade = new FacadeArvoreVidaImpl();
                facade.DesassociaJovensDeObreiro(desassociacaoJovensObreiro.JovensAcompanhados, desassociacaoJovensObreiro.ObreiroQueAcompanhava);

                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} desassociou o(s) jovem(ns) de ID(s) {string.Join(",", desassociacaoJovensObreiro.JovensAcompanhados)} ao Obreiro de ID {desassociacaoJovensObreiro.ObreiroQueAcompanhava.IdObreiro} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        private void AtualizaJSONArvoreVidaObreirosComRamos(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanha) {
            try {
                var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
                var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];

                var facade = new FacadeEstadoImpl();
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var nomeArquvioBloco = usuarioLogado.EstadoUsuario.SiglaEstado + "_AV.txt";
                var caminhoPastaArquivosOndeSerializar = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArquvioBloco);

                var obreirosComRamosAV = facade.ListAllValueObjectsFromJson<ObreiroDTO>(caminhoPastaArquivosOndeSerializar);
                var obreiroJaEstaNaLista = ( obreirosComRamosAV.Where(ob => ob.IdObreiro == ObreiroQueAcompanha.IdObreiro).Count() > 0);
                var obreiroCujosJovensForamAssociados =
                    (sessaoAtual["ObreirosPesquisadosPorParametro"] as IList<ObreiroDTO>)
                            .Where(obr => obr.IdObreiro == ObreiroQueAcompanha.IdObreiro).Single();

                var jovensComDadosCompletosFiltradosDaSessao = new List<JovemDTO>();
                foreach (var jovemAcompanhadoPeloObreiro in JovensAcompanhados) {
                    var jovemSelecionado = 
                        ( sessaoAtual["JovensSemAcompanhamento"] as IList<TodosJovensDTO>)
                            .Where(jv => jv.IdJovem == jovemAcompanhadoPeloObreiro.IdJovem ).Single();

                    jovensComDadosCompletosFiltradosDaSessao.Add(new JovemDTO { 
                        Id = jovemSelecionado.IdJovem,
                        Nome = jovemSelecionado.NomeJovem,
                        NomeArquivoFoto = jovemSelecionado.NomeArquivoFoto,
                        NomeArquivoFotoFormatado 
                                        = (! string.IsNullOrEmpty(jovemSelecionado.NomeArquivoFoto)) ?
                                                    ConfigurationManager.AppSettings["HOST_PROD"] + jovemSelecionado.NomeArquivoFoto :
                                                    ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",
                    });
                }

                if (obreiroJaEstaNaLista) {
                    obreirosComRamosAV.Remove(obreiroCujosJovensForamAssociados);

                    IList<TodosJovensDTO> jovensQueJaSaoAcompanhadosPeloObreiroSessao = null;

                    if(sessaoAtual["JovensJaAcompanhadosPorObreiro"] != null)
                        jovensQueJaSaoAcompanhadosPeloObreiroSessao = ( sessaoAtual["JovensJaAcompanhadosPorObreiro"] as List<TodosJovensDTO>);
                    else
                        jovensQueJaSaoAcompanhadosPeloObreiroSessao = (new FacadeArvoreVidaImpl()).ListaJovensAcompanhadosPorObreiro(ObreiroQueAcompanha).ToList();


                    var jovensQueJaSaoAcompanhadosPeloObreiro = new List<JovemDTO>();

                    foreach (var jovemRamoObreiro in jovensQueJaSaoAcompanhadosPeloObreiroSessao) {
                        jovensQueJaSaoAcompanhadosPeloObreiro.Add(new JovemDTO {
                            Id = jovemRamoObreiro.IdJovem,
                            Nome = jovemRamoObreiro.NomeJovem,
                            NomeArquivoFoto = jovemRamoObreiro.NomeArquivoFoto,
                            NomeArquivoFotoFormatado
                                        = (!string.IsNullOrEmpty(jovemRamoObreiro.NomeArquivoFoto)) ?
                                                    ConfigurationManager.AppSettings["HOST_PROD"] + jovemRamoObreiro.NomeArquivoFoto :
                                                    ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",
                        });
                    }

                    (obreiroCujosJovensForamAssociados.JovensQueObreiroAcompanha as List<JovemDTO>).AddRange(jovensQueJaSaoAcompanhadosPeloObreiro);
                    (obreiroCujosJovensForamAssociados.JovensQueObreiroAcompanha as List<JovemDTO> ).AddRange(jovensComDadosCompletosFiltradosDaSessao);

                    obreirosComRamosAV.Add(obreiroCujosJovensForamAssociados);
                }
                else {
                    (obreiroCujosJovensForamAssociados.JovensQueObreiroAcompanha as List<JovemDTO>).AddRange(jovensComDadosCompletosFiltradosDaSessao);

                    obreirosComRamosAV.Add(obreiroCujosJovensForamAssociados);
                }


                obreirosComRamosAV.Add(obreiroCujosJovensForamAssociados);

                (serializer as JSONSerializer).SerializeToJSON(obreirosComRamosAV, caminhoPastaArquivosOndeSerializar);
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

        private void AtualizaJSONEstadoLogado() {
            try {
                var siglaEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.SiglaEstado;
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                var nomeEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.NomeEstado;
                var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
                var facadeAV = new FacadeArvoreVidaImpl();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                var nomeArquvioDestinoSerializar = 
                    System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"]) + "\\" + siglaEstadoLogado + "_AV.txt";
                var nomeArquvioDestinoSerializarTE = 
                    System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"]) + "\\" + siglaEstadoLogado + "_TempoGeracaoJSON.txt";
                var obreirosComRamosEstado = facadeAV.ListaObreirosComRamosPorParametro(new PesquisaGeralDTO { IdEstado = idEstadoLogado });
                (serializer as JSONSerializer).SerializeToJSON(obreirosComRamosEstado, nomeArquvioDestinoSerializar);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                //// Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                (serializer as JSONSerializer)
                    .SerializeToJSON(new
                    {
                        TempoDecorridoSerializacao = elapsedTime,
                        Estado = nomeEstadoLogado,
                        QuantidadeObreirosComRamos = obreirosComRamosEstado.Count
                    }, nomeArquvioDestinoSerializarTE);

                //return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "JSON Gerado com sucesso" };
            }
            catch (Exception exc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

    }
}
