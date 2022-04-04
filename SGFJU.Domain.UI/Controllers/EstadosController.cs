using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.UI.Helpers;
using SGFJU.Interfaces;
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
    public class EstadosController : ApiController
    {
        [HttpPost]
        [Route("api/estados/ObterPastoresPorEstado/")]
        public IList<JovemDTO> ObterPastoresPorEstado([FromBody] IgrejaDTO parametro) {
            try {
                var facade = new FacadeJovemImpl();
                return facade.ObterPastoresPorEstado(new Estado { Id = parametro.IdEstado });
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpPost]
        [Route("api/estados/retornaHierarquiaIgrejasEstado/")]
        public IList<JsTreeDTO> retornaHierarquiaIgrejasEstado([FromBody] EstadoDTO estadoParametro) { 
            try {
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
                var caminhoPastaArquivoJSON_Estados = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + "States.txt");
                //var noPaiEstado = new JsTreeDTO { id = estadoParametro.IdEstado.ToString(), text = estadoParametro.NomeEstado };
                var todosEstados = (new FacadeEstadoImpl()).ListAllValueObjectsFromJson<EstadoDTO>(caminhoPastaArquivoJSON_Estados);
                
                var hierarquiaRetorno = new List<JsTreeDTO>();

                foreach (var _estado in todosEstados.Where(e => e.SiglaEstado == "SP").ToList()){
                    var noPaiEstado = new JsTreeDTO { id = _estado.IdEstado.ToString(), text = _estado.NomeEstado, parentId = "#" };
                    hierarquiaRetorno.Add(noPaiEstado);

                    var caminhoArquivoJSON_Blocos = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + _estado.SiglaEstado + "_Blocos.txt");
                    var blocosDoEstado = (new FacadeEstadoImpl()).ListAllValueObjectsFromJson<BlocoDTO>(caminhoArquivoJSON_Blocos);
                    var caminhoArquivoJSON_Igrejas = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + usuarioLogado.EstadoUsuario.SiglaEstado + "_Igrejas.txt");
                    var igrejasDoEstado = (new FacadeEstadoImpl()).ListAllValueObjectsFromJson<IgrejaDTO>(caminhoArquivoJSON_Igrejas);

                    foreach (var bloco in blocosDoEstado)
                    {
                        hierarquiaRetorno.Add(new JsTreeDTO
                        {
                            id = bloco.idBloco.ToString(),
                            text = bloco.NomeBloco,
                            parentId = noPaiEstado.id.ToString()
                        });

                        /*
                        var igrejasDoBloco = igrejasDoEstado.Where(ig => ig.IdBlocoJovem == bloco.idBloco).ToList();

                        foreach (var igreja in igrejasDoBloco)
                        {
                            hierarquiaRetorno.Add(new JsTreeDTO
                            {
                                id = igreja.IdIgreja.ToString(),
                                text = igreja.NomeIgreja,
                                parent = bloco.idBloco.ToString()
                            }); ;
                        }*/
                    }
                }

                return hierarquiaRetorno;
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpGet]
        [Route("api/Estados/ObterInformacoresIgrejaEstadoLogado/")]
        public IList<IgrejaCoordenadorDTO> ObterInformacoresIgrejaEstadoLogado() {
            try {
                var estadoUsuarioLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario;
                var facade = new FacadeEstadoImpl();
                var informacoesIgrejasEstado = facade.RetornaInformacoesIgrejasEstado(estadoUsuarioLogado);
                foreach (var infoIgrejas in informacoesIgrejasEstado){
                    if (infoIgrejas.TotalMesesCoordenandoFJU > 0 &&
                        infoIgrejas.TotalAnosCoordenandoFJU > 0)
                        infoIgrejas.PeriodoCoordenando = infoIgrejas.TotalAnosCoordenandoFJU + " ano(s) e " + ((infoIgrejas.TotalMesesCoordenandoFJU > 1) ? " meses" : " mês");
                    else if (infoIgrejas.TotalMesesCoordenandoFJU > 0 &&
                             infoIgrejas.TotalAnosCoordenandoFJU <= 0)
                        infoIgrejas.PeriodoCoordenando = infoIgrejas.TotalMesesCoordenandoFJU + ((infoIgrejas.TotalMesesCoordenandoFJU > 1) ? infoIgrejas.TotalMesesCoordenandoFJU + " meses" : infoIgrejas.TotalMesesCoordenandoFJU + " mês");
                    else if (infoIgrejas.TotalMesesCoordenandoFJU <= 0 &&
                             infoIgrejas.TotalAnosCoordenandoFJU > 0)
                        infoIgrejas.PeriodoCoordenando = infoIgrejas.TotalAnosCoordenandoFJU + " ano(s)";
                }
                return informacoesIgrejasEstado;
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpGet]
        [Route("api/Estados/ObterPastoresEstadoLogado")]
        public IList<JovemDTO> ObterPastoresEstadoLogado() { 
            try {
                var estadoUsuarioLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario;
                var facade = new FacadeJovemImpl();
                var pastoresEstadoRetorno = facade.ObterPastoresPorEstado(estadoUsuarioLogado);
                
                return pastoresEstadoRetorno.Select(pr => new JovemDTO { 
                    Id = pr.Id,
                    Nome = pr.Nome,
                    NomeArquivoFoto = pr.NomeArquivoFoto
                }).ToList();
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpGet]
        [Route("api/Estados/ObterIgrejasPorEstadoLogado")]
        public IList<IgrejaDTO> ObterIgrejasPorEstadoLogado() {
            try {
                var estadoUsuarioLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario;
                var estadoFacade = new FacadeEstadoImpl();
                return estadoFacade.obterTodasIgrejasDoEstado(estadoUsuarioLogado);
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpPost]
        [Route("api/Estados/ExcluirBloco")]
        public RespostaRequisicaoDTO ExcluirBloco([FromBody] BlocoDTO blocoParaExclusao)
        {
            try
            {
                var facade = new FacadeEstadoImpl();
                var vBlocoParametro = new Bloco { Id = blocoParaExclusao.idBloco };
                var podeExcluirBloco = true; //facade.PodeExcluirBloco(vBlocoParametro).PodeExcluir;

                if (podeExcluirBloco) {
                    facade.ExcluirBlocoDoEstado(vBlocoParametro);
                    AtualizaJSONBlocos();

                    var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                    SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                    {
                        DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                        DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} excluiu o Bloco de ID {blocoParaExclusao.idBloco} ",
                        HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                        IdUsuario = usuarioLogado.Id,
                        SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                    });
                }
                else {
                    return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Bloco não pode ser excluida pois existem jovens associados à ela !", RequisicaoBemSucedida = false };
                }

                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Bloco excluido com sucesso !!!", RequisicaoBemSucedida = true };
            }
            catch (Exception exc)
            {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        protected void AtualizaJSONBlocos()
        {
            try
            {
                var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
                var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];

                var facade = new FacadeEstadoImpl();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var nomeArquvioBloco = usuarioLogado.EstadoUsuario.SiglaEstado + "_Blocos.txt";
                var caminhoPastaArquivosOndeSerializar = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArquvioBloco);
                var blocosEstado = facade.obterBlocosDoEstado(usuarioLogado.EstadoUsuario).Select(b => new BlocoDTO
                {
                    idBloco = b.Id,
                    NomeBloco = b.NomeBloco,
                    IdEstadoBloco = b.EstadoBloco.Id
                });
                (serializer as JSONSerializer).SerializeToJSON(blocosEstado, caminhoPastaArquivosOndeSerializar);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Estados/ExcluirRegiao")]
        public RespostaRequisicaoDTO ExcluirRegiao([FromBody] RegiaoDTO regiaoParaExclusao)
        {
            try
            {
                var facade = new FacadeEstadoImpl();
                var vRegiaoParametro = new Regiao { Id = regiaoParaExclusao.IdRegiao };
                var podeExcluirRegiao = facade.PodeExcluirRegiao(vRegiaoParametro).PodeExcluir;

                if (podeExcluirRegiao) {
                    facade.ExcluirRegiaoDoEstado(vRegiaoParametro);
                    AtualizaJSONRegioes();

                    var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                    SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                    {
                        DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                        DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} excluiu a Região de ID {regiaoParaExclusao.IdRegiao} ",
                        HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                        IdUsuario = usuarioLogado.Id,
                        SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                    });
                }
                else {
                    return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Região não pode ser excluida pois existem jovens associados à ela !", RequisicaoBemSucedida = false };
                }

                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Região excluida com sucesso !!!", RequisicaoBemSucedida = true };
            }
            catch (Exception exc)
            {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpPost]
        [Route("api/Estados/AtualizarRegiao")]
        public RespostaRequisicaoDTO AtualizarRegiao([FromBody] RegiaoDTO regiaoAtualizacao)
        {
            try
            {
                var idEstadoLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                var facade = new FacadeEstadoImpl();
                facade.AtualizarRegiaoDoEstado(regiaoAtualizacao);

                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} atualizou a Região de ID {regiaoAtualizacao.IdRegiao} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                AtualizaJSONRegioes();
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Região atualizada com sucesso!" };
            }
            catch (Exception exc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }

        protected void AtualizaJSONRegioes() {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
            var facade = new FacadeEstadoImpl();
            var nomeArqvuivoRegiao = usuarioLogado.EstadoUsuario.SiglaEstado + "_Regioes.txt";
            var caminhoPastaArquivosOndeSerializar = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArqvuivoRegiao);
            var regioesEstado = facade.obterTodasRegioesDoEstado(usuarioLogado.EstadoUsuario).Select(r => new RegiaoDTO
            {
                idBloco = r.BlocoRegiao.Id,
                IdRegiao = r.Id,
                NomeRegiao = r.NomeRegiao
            });
            (serializer as JSONSerializer).SerializeToJSON(regioesEstado, caminhoPastaArquivosOndeSerializar);
        }

        [HttpPost]
        [Route("api/Estados/ExcluirIgreja")]
        public RespostaRequisicaoDTO ExcluirIgreja([FromBody] IgrejaDTO igrejaParaExclusao) {
            try {
                var facade = new FacadeEstadoImpl();
                var vIgrejaParametro = new Igreja { Id = igrejaParaExclusao.IdIgreja };
                var podeExcluirIgreja = facade.PodeExcluirIgreja(vIgrejaParametro).PodeExcluir;

                if (podeExcluirIgreja) {
                    facade.ExcluirIgrejaDoEstado(vIgrejaParametro);

                    var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                    SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                    {
                        DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                        DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} excluiu a Igreja de ID {igrejaParaExclusao.IdIgreja} ",
                        HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                        IdUsuario = usuarioLogado.Id,
                        SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                    });

                    AtualizaJSONIgrejas();
                }
                else {
                    return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Igreja não pode ser excluida pois existem jovens associados à ela !", RequisicaoBemSucedida = false };
                }

                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Igreja excluida com sucesso !!!", RequisicaoBemSucedida = true };
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        [HttpPost]
        [Route("api/Estados/CadastrarIgreja")]
        public RespostaRequisicaoDTO CadastrarIgreja([FromBody] IgrejaDTO pNovaIgreja) {
            try {
                var facade = new FacadeBaseImpl<Igreja>();
                if (JaExisteIgrejaNaRegiao(pNovaIgreja)) {
                    return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Já existe uma igreja nesta região com este nome !", RequisicaoBemSucedida = false };
                }
                else {
                    var vIgrejaNova = new Igreja
                    {
                        NomeIgreja = pNovaIgreja.NomeIgreja,
                        RegiaoIgreja = new Regiao { Id = pNovaIgreja.IdRegiao }
                    };
                    facade.Save(vIgrejaNova);

                    var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                    SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                    {
                        DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                        DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} cadastrou uma nova Igreja de nome  {pNovaIgreja.NomeIgreja} ",
                        HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                        IdUsuario = usuarioLogado.Id,
                        SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                    });

                    AtualizaJSONIgrejas();
                }
                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Igreja cadastrada com sucesso !!!", RequisicaoBemSucedida = true };
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        private bool JaExisteIgrejaNaRegiao(IgrejaDTO igrejaAVerificar) {
            try {
                var facade = new FacadeEstadoImpl();
                return facade.JaExisteIgrejaNaRegiao(igrejaAVerificar);
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }

        protected void AtualizaJSONIgrejas() {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
            var facade = new FacadeEstadoImpl();

            var nomeArqvuivoRegiao = usuarioLogado.EstadoUsuario.SiglaEstado + "_Igrejas.txt";
                var caminhoPastaArquivosOndeSerializar = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArqvuivoRegiao);
            var igrejasEstado = facade.obterTodasIgrejasDoEstado(usuarioLogado.EstadoUsuario).Select(igj => new IgrejaDTO
            {
                IdEstado = usuarioLogado.EstadoUsuario.Id,
                //IdRegiao = igre
                //IdIgreja = igj.Id,
                NomeIgreja = igj.NomeIgreja
            });
            (serializer as JSONSerializer).SerializeToJSON(igrejasEstado, caminhoPastaArquivosOndeSerializar);
        }

        [HttpPost]
        [Route("api/Estados/PesquisarIgrejasPorParametro")]
        public IList<IgrejaDTO> PesquisarIgrejasPorParametro([FromBody]IgrejaDTO parametros) {
            try {
                var estadoUsuarioLogado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario;
                var estadoFacade = new FacadeEstadoImpl();
                return estadoFacade.PesquisarIgrejasPorParametro(parametros);
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }
    }
}
