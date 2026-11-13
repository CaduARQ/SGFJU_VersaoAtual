using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Api.Legado;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class IgrejasController : ControllerBase
    {
        
        [HttpGet]
        [Route("api/igrejas/ObterPorRegiao/{idRegiao}")]
        public IList<IgrejaDTO> ObterPorRegiao(int idRegiao) {
            try {
                var facade = new FacadeEstadoImpl();
                var igrejasDaRegiao = facade.obterIgrejasDaRegiao(new Regiao { Id = idRegiao })
                                            .Select(i => new IgrejaDTO { 
                                                IdRegiao = idRegiao,
                                                IdIgreja = i.Id,
                                                NomeIgreja = i.NomeIgreja
                                            });
                return igrejasDaRegiao.ToList();
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/igrejas/CadastrarCoordenadorIgreja")]
        public RespostaRequisicaoDTO CadastrarCoordenadorIgreja([FromBody] IgrejaCoordenadorDTO igrejaCoordenadorParametro) {
            try {
                var facade = new FacadeBaseImpl<IgrejaCoordenador>();

                if (IgrejaPossuiCoordenador(igrejaCoordenadorParametro)) {
                    return new RespostaRequisicaoDTO { 
                        RequisicaoBemSucedida = false, 
                        MensagemRespostaRequisicao = "Igreja já possui Coordenador !!!" 
                    };
                }

                facade.Save(new IgrejaCoordenador {
                    CoordenadorFJU                   = new Jovem { Id = igrejaCoordenadorParametro.IdCoordenadorFJU },
                    IgrejaFJU                        = new Igreja { Id = igrejaCoordenadorParametro.IdIgreja },
                    //MesesCoordenandoFJU              = igrejaCoordenadorParametro.MesesCoordenandoFJU,
                    //AnosCoordenandoFJU               = igrejaCoordenadorParametro.AnosCoordenandoFJU,
                    QuantidadeJovensEncontroAnterior = igrejaCoordenadorParametro.QuantidadeJovensEncontroAnterior,
                    QuantidadeJovensEncontroAtual    = igrejaCoordenadorParametro.QuantidadeJovensEncontroAtual
                });

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Coordenador cadastrado com sucesso !!!" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        private bool IgrejaPossuiCoordenador(IgrejaCoordenadorDTO igrejaCoordenadorParametro) {
            var facade = new FacadeEstadoImpl();
            return facade.IgrejaPossuiCoordenador(new IgrejaCoordenador
                    {
                        IgrejaFJU = new Igreja { Id = igrejaCoordenadorParametro.IdIgreja },
                        CoordenadorFJU = new Jovem { Id = igrejaCoordenadorParametro.IdCoordenadorFJU }
                    });
        }

        [HttpPost]
        [Route("api/igrejas/ObterObreirosPorIgreja/")]
        public IList<JovemDTO> ObterObreirosPorIgreja([FromBody] IgrejaDTO parametro) { 
            try {
                var facade = new FacadeJovemImpl();
                var sessao = SessionHelper.RetornaSessaoAtual();
                var obreirosIgreja = facade.ObterObreirosPorIgreja(new Igreja { Id = parametro.IdIgreja });
                sessao.Add("ObreirosIgrejaSelecionada", obreirosIgreja);
                return obreirosIgreja;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/igrejas/ObterObreiroSessaoPorId/")]
        public JovemDTO ObterObreiroSessaoPorId([FromBody] JovemDTO parametroConsulta) {
            try {
                var obreirosNaSessao = (SessionHelper.RetornaSessaoAtual()["ObreirosIgrejaSelecionada"] as IList<JovemDTO>);
                var obreiroSelecionado = obreirosNaSessao.Where(jv => jv.Id == parametroConsulta.Id).Single();
                SessionHelper.RetornaSessaoAtual().Add("CoordenadorSelecionado", new Jovem {
                    Id = obreiroSelecionado.Id,
                    Nome = obreiroSelecionado.Nome,
                    NomeArquivoFoto = obreiroSelecionado.NomeArquivoFotoFormatado,
                    NomeConjuge = obreiroSelecionado.NomeConjuge,
                    DataNascimento = DateTime.ParseExact(obreiroSelecionado.DataNascimento, "dd/MM/yyyy", null),
                    QuantidadeFilhos = obreiroSelecionado.QuantidadeFilhos,
                    PossuiFilhos = obreiroSelecionado.PossuiFilhos,
                    ConjugeEhObreiro = obreiroSelecionado.ConjugeEhObreiro,
                    EstadoCivilJovem = new TipoEstadoCivil {
                        Code = obreiroSelecionado.idEstadoCivilJovem, 
                        Descricao = obreiroSelecionado.DescricaoEstadoCivilJovem 
                    },
                    SituacaoJovemIURDFJU = new SituacaoIURDFJU {
                        FoiPastor = obreiroSelecionado.SituacaoJovemIURDFJU.FoiObreiro,
                        MotivoSaidaPastor = obreiroSelecionado.SituacaoJovemIURDFJU.MotivoSaidaPastor,
                        DesejaFazerObraNoAltar = obreiroSelecionado.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar,
                        MesAnoFoiLevantadoObreiro = obreiroSelecionado.SituacaoJovemIURDFJU.MesAnoFoiLevantadoObreiro,
                        MesAnoSaidaObra = obreiroSelecionado.SituacaoJovemIURDFJU.MesAnoSaiuObra
                    }
                });
                return obreiroSelecionado;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/igrejas/AtualizarIgreja")]
        public RespostaRequisicaoDTO AtualizarIgreja([FromBody] IgrejaDTO igrejaParaAtualizacao) {
            try {
                var facade = new FacadeEstadoImpl();

                facade.AtualizarIgreja(igrejaParaAtualizacao);

                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();                
                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"Atualização da Igreja de ID {igrejaParaAtualizacao.IdIgreja} e nome {igrejaParaAtualizacao.NomeIgreja} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                AtualizaJSONIgrejas();
                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Igreja atualizada com sucesso !", RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
        protected void AtualizaJSONIgrejas() {
            try {
                var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
                var caminhoPastaArquivosSerializados = SgfjuConfig.Get("PathArquivosObjetosSerializados");
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var facade = new FacadeEstadoImpl();

                var nomeArqvuivoRegiao = usuarioLogado.EstadoUsuario.SiglaEstado + "_Igrejas.txt";
                var caminhoPastaArquivosOndeSerializar = AmbienteLegado.MapPath(caminhoPastaArquivosSerializados + "/" + nomeArqvuivoRegiao);
                var igrejasEstado = facade.obterTodasIgrejasDoEstado(usuarioLogado.EstadoUsuario).Select(igj => new IgrejaDTO
                {
                    IdEstado = usuarioLogado.EstadoUsuario.Id,
                    //IdRegiao = igre
                    //IdIgreja = igj.Id,
                    NomeIgreja = igj.NomeIgreja
                });
                (serializer as JSONSerializer).SerializeToJSON(igrejasEstado, caminhoPastaArquivosOndeSerializar);
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
