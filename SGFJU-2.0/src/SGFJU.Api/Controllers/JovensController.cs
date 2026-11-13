using SGFJU.Domain.Model.Infra.Util;
using Newtonsoft.Json;
using NodaTime;
using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace SGFJU.Api.Controllers
{
    public class JovensController : ControllerBase
    {
        [HttpGet]
        [Route("api/Jovens/Todos")]
        public IList<TodosJovensDTO> Todos() {
            try {
                var facade = (new FacadeJovemImpl());
                IList<TodosJovensDTO> todosDTO = new List<TodosJovensDTO>();
                var caminhoPastaArquivosSerializadosEstados = SgfjuConfig.Get("PathArquivosObjetosSerializados");
                var nomeArquivoEstadosSerializados = "Todos.txt";
                var todosJovensSerializados = AmbienteLegado.MapPath(caminhoPastaArquivosSerializadosEstados + "/" + nomeArquivoEstadosSerializados);
                var ret = facade.ListAll().Select(J => new TodosJovensDTO
                {
                    IdEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.Id,
                    NomeEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.NomeEstado,
                    IdBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.Id,
                    NomeBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.NomeBloco,
                    IdRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                    NomeRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.NomeRegiao,
                    IdIgreja = J.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                    NomeIgrejaJovem = J.IgrejaAQualJovemPertence.NomeIgreja,
                    IdJovem = J.Id,
                    NomeJovem = J.Nome,
                    DataNascimento = J.DataNascimento.ToString("dd/MM/yyyy")
                });

                return ret.ToList();
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Jovens/TodosPorEstadoLogado")]
        public IList<TodosJovensDTO> TodosPorEstadoLogado()
        {
            try
            {
                var facade = (new FacadeJovemImpl());
                IList<TodosJovensDTO> todosDTO = new List<TodosJovensDTO>();
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var caminhoPastaArquivosSerializadosEstados = SgfjuConfig.Get("PathArquivosObjetosSerializados");
                var nomeArquivoEstadosSerializados = "Todos.txt";
                var todosJovensSerializados = AmbienteLegado.MapPath(caminhoPastaArquivosSerializadosEstados + "/" + nomeArquivoEstadosSerializados);
                //facade.ListAllValueObjectsFromJson<TodosJovensDTO>(todosJovensSerializados).Where(j => j.IdEstado == usuarioLogado.EstadoUsuario.Id).OrderBy(j => j.NomeBlocoJovem).ToList();
                var ret = facade.ObterJovensPorEstado(usuarioLogado.EstadoUsuario)
                                .Select(J => new TodosJovensDTO
                                {
                                    IdEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.Id,
                                    NomeEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.NomeEstado,
                                    IdBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.Id,
                                    NomeBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.NomeBloco,
                                    IdRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                                    NomeRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.NomeRegiao,
                                    IdIgreja = J.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                                    NomeIgrejaJovem = J.IgrejaAQualJovemPertence.NomeIgreja,
                                    IdJovem = J.Id,
                                    NomeJovem = J.Nome,
                                    DataNascimento = J.DataNascimento.ToString("dd/MM/yyyy")
                                }).ToList();
                    
                return ret;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/PesquisarPorParametro")]
        public IList<TodosJovensDTO> PesquisarPorParametro([FromBody] ParametroPesquisaTodosJovensDTO parametroPesquisaTodosJovens ) {
            try {
                var facade = (new FacadeJovemImpl());
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var usuarioLogado = (sessaoAtual["UsuarioLogado"] as Usuario);
                var caminhoPastaArquivosSerializadosEstados = SgfjuConfig.Get("PathArquivosObjetosSerializados");
                var nomeArquivoEstadosSerializados = "Todos.txt";
                var todosJovensSerializados = AmbienteLegado.MapPath(caminhoPastaArquivosSerializadosEstados + "/" + nomeArquivoEstadosSerializados);
                //var resultSetTodosJovens = facade.ListAllValueObjectsFromJson<TodosJovensDTO>(todosJovensSerializados).OrderBy(j => j.NomeJovem).ToList();

                parametroPesquisaTodosJovens.IdEstado = ( parametroPesquisaTodosJovens.IdEstado == 0 )?usuarioLogado.EstadoUsuario.Id:parametroPesquisaTodosJovens.IdEstado;

                var resultSetTodosJovens = facade.ObterJovensPorParametro(parametroPesquisaTodosJovens);

                foreach (var jovemRetornado in resultSetTodosJovens) {
                    var caminhoArquivoFotoJovem = "";
                    var ehPathInvalido = false;

                    if (string.IsNullOrEmpty(jovemRetornado.NomeArquivoFoto)) {
                        jovemRetornado.FotoEstaNoDiretorio = "N";
                    }
                    else {
                        //caminhoArquivoFotoJovem = AmbienteLegado.MapPath("/SGFJU2.0/FotosJovens" + "/" + jovemRetornado.NomeArquivoFoto);
                        try {
                            caminhoArquivoFotoJovem = AmbienteLegado.MapPath("/SGFJU2.0/FotosJovens" + "/" + jovemRetornado.NomeArquivoFoto);
                        }
                        catch (Exception excSec) {
                            ehPathInvalido = true;
                        }

                        if (ehPathInvalido) {
                            jovemRetornado.FotoEstaNoDiretorio = "N";
                        }
                        else {
                            if (System.IO.File.Exists(caminhoArquivoFotoJovem)) {
                                jovemRetornado.FotoEstaNoDiretorio = "S";
                            }
                            else {
                                jovemRetornado.FotoEstaNoDiretorio = "N";
                            }
                        }
                    }
                }

                if (parametroPesquisaTodosJovens.FotoEstaNoDiretorio != "" &&
                    parametroPesquisaTodosJovens.FotoEstaNoDiretorio != null) {
                    resultSetTodosJovens = resultSetTodosJovens.Where(p => p.FotoEstaNoDiretorio == parametroPesquisaTodosJovens.FotoEstaNoDiretorio).ToList();
                }

                sessaoAtual.Add("ExisteUltimaPesquisaTJ", true);
                sessaoAtual.Add("ResultSetUltimaPesquisaTJ", resultSetTodosJovens);

                return resultSetTodosJovens;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        //
        [HttpPost]
        [Route("api/Jovens/PesquisarPorParametroTJ")]
        public IList<TodosJovensDTO> PesquisarPorParametroTJ([FromBody] ParametroPesquisaTodosJovensDTO parametroPesquisaTodosJovens)
        {
            try
            {
                var facade = (new FacadeJovemImpl());
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var usuarioLogado = (sessaoAtual["UsuarioLogado"] as Usuario);

                var resultSetTodosJovens = facade.ObterJovensPorParametro(parametroPesquisaTodosJovens);

                foreach (var jovemRetornado in resultSetTodosJovens)
                {
                    var caminhoArquivoFotoJovem = "";
                    var ehPathInvalido = false;

                    if (string.IsNullOrEmpty(jovemRetornado.NomeArquivoFoto))
                    {
                        jovemRetornado.FotoEstaNoDiretorio = "N";
                    }
                    else
                    {
                        //caminhoArquivoFotoJovem = AmbienteLegado.MapPath("/SGFJU2.0/FotosJovens" + "/" + jovemRetornado.NomeArquivoFoto);
                        try
                        {
                            caminhoArquivoFotoJovem = AmbienteLegado.MapPath("/SGFJU2.0/FotosJovens" + "/" + jovemRetornado.NomeArquivoFoto);
                        }
                        catch (Exception excSec)
                        {
                            ehPathInvalido = true;
                        }

                        if (ehPathInvalido)
                        {
                            jovemRetornado.FotoEstaNoDiretorio = "N";
                        }
                        else
                        {
                            if (System.IO.File.Exists(caminhoArquivoFotoJovem))
                            {
                                jovemRetornado.FotoEstaNoDiretorio = "S";
                            }
                            else
                            {
                                jovemRetornado.FotoEstaNoDiretorio = "N";
                            }
                        }
                    }
                }

                if (parametroPesquisaTodosJovens.FotoEstaNoDiretorio != "" &&
                    parametroPesquisaTodosJovens.FotoEstaNoDiretorio != null)
                {
                    resultSetTodosJovens = resultSetTodosJovens.Where(p => p.FotoEstaNoDiretorio == parametroPesquisaTodosJovens.FotoEstaNoDiretorio).ToList();
                }

                sessaoAtual.Add("ExisteUltimaPesquisaTJ", true);
                sessaoAtual.Add("ResultSetUltimaPesquisaTJ", resultSetTodosJovens);

                return resultSetTodosJovens;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
        //

        [HttpGet]
        [Route("api/Jovens/ObterDadosPesquisados")]
        public IList<TodosJovensDTO> ObterDadosPesquisados() {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                return (sessaoAtual["DadosPesquisaSessao"] as IList<TodosJovensDTO>).ToList();
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/ObterJovemAtualizacao")]
        public JovemDTO ObterJovemAtualizacao([FromBody] TodosJovensDTO jovemParaAtualizar) {
            LoggerHelper.WriteLogError("--Rastreando entrou no método -> ObterJovemAtualizacao();");
            try {
                LoggerHelper.WriteLogError("--Rastreando erro chamou -> ObterJovemAtualizacao();");

                var facade = (new FacadeJovemImpl());
                var jovemRetorno = facade.ObterJovemInformacoesDetalhadas(new Jovem { Id = jovemParaAtualizar.IdJovem });

                if (jovemRetorno != null) {
                    //jovemRetorno.IgrejaAQualJovemPertence.IdEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.Id;
                    //jovemRetorno.IgrejaAQualJovemPertence.NomeEstado = SessionHelper.RetornaUsuarioLogado().EstadoUsuario.NomeEstado;
                    SessionHelper.RetornaSessaoAtual().Add("JovemParaAtualizar", jovemRetorno);
                    if (jovemRetorno.ProjetosAosQuaisJovemEstaLigado.Count > 0) {
                        SessionHelper.RetornaSessaoAtual()
                        .Add("ProjetoAnterior", new JovemProjeto { 
                            Projeto = new Projeto { Code = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjeto },
                            ProjetoAnterior = (jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjetoAnterior != 0)? new Projeto { Code = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjetoAnterior }:null,
                            AnosProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].AnosProjeto,
                            MesesProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].MesesProjeto,
                            PertenceuOutroProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].PertenceuOutroProjeto,
                            TempoProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].TempoProjeto
                        });
                    }
                    
                    SessionHelper.RetornaSessaoAtual().Add("Atualizacao_HabilidadesAdicionadas", jovemRetorno.HabilidadesJovemPossui);
                    SessionHelper.RetornaSessaoAtual().Add("Atualizacao_IdiomasAdicionados", jovemRetorno.IdiomasQueOJovemFala);
                    SessionHelper.RetornaSessaoAtual()
                                 .Add("Atualizacao_cursosAdicionados", 
                                      jovemRetorno.CursosRelacionados
                                                  .Select(c => new CursoRelacionadoProjeto { 
                                                          Code      = c.Code,
                                                          NomeCurso = c.NomeCurso,
                                                          ProjetoRelacionado = new Projeto { 
                                                              Code        = c.IdProjetoRelacionado,
                                                              NomeProjeto = c.NomeProjeto
                                                          }
                                                  }).ToList());
                    
                    /*
                    var dataCadastro = DateTime.Parse(jovemRetorno.DataCadastro);
                    var dataUltimaAtualizacao = (!string.IsNullOrEmpty(jovemRetorno.DataUltimaAtualizacao)) ?
                                                   DateTime.Parse(jovemRetorno.DataUltimaAtualizacao) : new Nullable<DateTime>(); 
                    var dataAtual = DateTime.Now;

                    LocalDate start = new LocalDate(dataCadastro.Year, dataCadastro.Month, dataCadastro.Day);
                    LocalDate end = new LocalDate(dataAtual.Year, dataAtual.Month, dataAtual.Day);

                    LocalDate dataUltimaAtualizacaoDate = LocalDate.MinIsoValue;
                    LocalDate startUltimaAtualizacao = LocalDate.MinIsoValue;
                    LocalDate endUltimaAtualizacao = new LocalDate(dataAtual.Year, dataAtual.Month, dataAtual.Day);
                    int mesesDesdeUltimaAtualizacao = 0;

                    if (dataUltimaAtualizacao.HasValue) { 
                    }
                    
                        dataUltimaAtualizacaoDate = new LocalDate(dataUltimaAtualizacao.Value.Year,
                                                                  dataUltimaAtualizacao.Value.Month,
                                                                  dataUltimaAtualizacao.Value.Day);*/
                    


                    /*
                    Period periodDataCadastro = Period.Between(start, end);
                    int mesesDesdeCadastro = periodDataCadastro.Months;

                    if (mesesDesdeCadastro >= 6 && dataUltimaAtualizacaoDate == LocalDate.MinIsoValue) {
                        jovemRetorno.FichaEstaExpirada = true;
                        jovemRetorno.PeriodicidadeFichaJovem = $"A ficha está expirada desde {periodDataCadastro.Days}";
                    }
                    else if (mesesDesdeUltimaAtualizacao >= 6) {
                        jovemRetorno.FichaEstaExpirada = true;
                        jovemRetorno.PeriodicidadeFichaJovem = $"A ficha está expirada desde {periodDataCadastro.Days}";
                    }
                    else if (mesesDesdeCadastro < 6) {
                        jovemRetorno.FichaEstaExpirada = false;
                        jovemRetorno.PeriodicidadeFichaJovem = $"A ficha expira em {periodDataCadastro.Days}";
                    }

                    */
                }

                return jovemRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/ObterJovemAtualizacao2")]
        public JovemDTO ObterJovemAtualizacao2([FromBody] TodosJovensDTO jovemParaAtualizar) {
            try {

                var facade = (new FacadeJovemImpl());
                var jovemRetorno = facade.ObterJovemInformacoesDetalhadas(new Jovem { Id = jovemParaAtualizar.IdJovem });
                //throw new Exception("erro provocado ");

                if (jovemRetorno != null) {

                    SessionHelper.RetornaSessaoAtual().Add("JovemParaAtualizar", jovemRetorno);
                    if (jovemRetorno.ProjetosAosQuaisJovemEstaLigado.Count > 0)
                    {
                        SessionHelper.RetornaSessaoAtual()
                        .Add("ProjetoAnterior", new JovemProjeto
                        {
                            Projeto = new Projeto { Code = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjeto },
                            ProjetoAnterior = (jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjetoAnterior != 0) ? new Projeto { Code = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].idProjetoAnterior } : null,
                            AnosProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].AnosProjeto,
                            MesesProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].MesesProjeto,
                            PertenceuOutroProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].PertenceuOutroProjeto,
                            TempoProjeto = jovemRetorno.ProjetosAosQuaisJovemEstaLigado[0].TempoProjeto
                        });

                        SessionHelper.RetornaSessaoAtual().Add("Atualizacao_HabilidadesAdicionadas", jovemRetorno.HabilidadesJovemPossui);
                        SessionHelper.RetornaSessaoAtual().Add("Atualizacao_IdiomasAdicionados", jovemRetorno.IdiomasQueOJovemFala);
                        SessionHelper.RetornaSessaoAtual()
                                     .Add("Atualizacao_cursosAdicionados",
                                          jovemRetorno.CursosRelacionados
                                                      .Select(c => new CursoRelacionadoProjeto
                                                      {
                                                          Code = c.Code,
                                                          NomeCurso = c.NomeCurso,
                                                          ProjetoRelacionado = new Projeto
                                                          {
                                                              Code = c.IdProjetoRelacionado,
                                                              NomeProjeto = c.NomeProjeto
                                                          }
                                                      }).ToList());
                    }

                }

                return jovemRetorno;
            }
            catch (FacadeException excFacade)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(excFacade, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
            catch (Exception excObterJovem) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(excObterJovem, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/ExcluirJovem")]
        public RespostaRequisicaoDTO ExcluirJovem([FromBody] TodosJovensDTO jovemParaExcluir) { 
            try {
                var facade = (new FacadeJovemImpl());
                facade.ExcluirInformacoesJovem(new Jovem { Id = jovemParaExcluir.IdJovem });

                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} excluiu o jovem de ID {jovemParaExcluir.IdJovem} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Jovem excluido com sucesso!", RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/TranferirJovem")]
        public RespostaRequisicaoDTO TranferirJovem([FromBody] TodosJovensDTO jovemParaTranferir)
        {
            try {
                var facade = (new FacadeJovemImpl());
                facade.TransferirJovem(new TodosJovensDTO { IdJovem = jovemParaTranferir.IdJovem, IdIgreja = jovemParaTranferir.IdIgreja });
                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Jovem tranferido com sucesso!", RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/TranferirJovensEntreIgrejas")]
        public RespostaRequisicaoDTO TranferirJovensEntreIgrejas([FromBody] TranfereJovensEntreIgrejasDTO transferirDTO) { 
            try {
                var facade = (new FacadeJovemImpl());
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var mensagemTransferencia = (transferirDTO.TransferirTodos) ? " todos os " : " alguns ";
                facade.TransferirJovensEntreIgrejas(transferirDTO.IdIgrejaOrigem, 
                                                    transferirDTO.IdIgrejaDestino, 
                                                    transferirDTO.TransferirTodos, 
                                                    transferirDTO.JovensParaTransferir,
                                                    usuarioLogado.Id);

                SessionHelper.ObterLoogerParaController().WriteUserAction(new LogUsuarioDTO
                {
                    DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                    DescricaoAcaoUsuario = $"O usuário {usuarioLogado.Login} transferiu {mensagemTransferencia} jovens da igreja de ID {transferirDTO.IdIgrejaOrigem} para a igreja de destino de ID {transferirDTO.IdIgrejaDestino} ",
                    HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos",
                    IdUsuario = usuarioLogado.Id,
                    SiglaEstadoUsuario = usuarioLogado.EstadoUsuario.SiglaEstado
                });

                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Transferência realizada com sucesso!", RequisicaoBemSucedida = true };
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/ConsultaGeral")]
        public IList<TodosJovensDTO> ConsultaGeral([FromBody] ConsultaGeralDTO parametrosConsultaGeral) {
            try {
                var facade = new FacadeJovemImpl();
                var codigoADM = int.Parse(SgfjuConfig.Get("CodeADM"));
                var usuarioLogado = SessionHelper.RetornaUsuarioLogado();
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();

                if (usuarioLogado.PerfilUsuario.Code != codigoADM)
                    parametrosConsultaGeral.IdEstado = usuarioLogado.EstadoUsuario.Id;

                if (sessaoAtual["ParametrosHabilidadeConsultaGeral"] != null) {
                    var listaParametrosHabilidades = (sessaoAtual["ParametrosHabilidadeConsultaGeral"] as IList<HabilidadeProjetoNivelDTO>);
                    foreach (var habilidadeParametro in listaParametrosHabilidades){
                        parametrosConsultaGeral.ParametrosHabilidade.Add(habilidadeParametro);
                    }
                }    

                var resultSetConsultaGeral = facade.ListaJovensConsultaGeral(parametrosConsultaGeral);
                
                foreach (var jovemRetornado in resultSetConsultaGeral) {
                    var caminhoArquivoFotoJovem = "";
                    var ehPathInvalido = false;

                    if (string.IsNullOrEmpty(jovemRetornado.NomeArquivoFoto)) {
                        jovemRetornado.FotoEstaNoDiretorio = "N";
                    }
                    else {
                        try {
                            caminhoArquivoFotoJovem = AmbienteLegado.MapPath("/SGFJU2.0/FotosJovens" + "/" + jovemRetornado.NomeArquivoFoto);
                        }
                        catch (Exception excSec) {
                            ehPathInvalido = true;
                        }

                        if (ehPathInvalido) {
                            jovemRetornado.FotoEstaNoDiretorio = "N";
                        }
                        else {
                            if (System.IO.File.Exists(caminhoArquivoFotoJovem)) {
                                jovemRetornado.FotoEstaNoDiretorio = "S";
                            }
                            else {
                                jovemRetornado.FotoEstaNoDiretorio = "N";
                            }
                        }
                    }
                }

                sessaoAtual.Add("ExisteUltimaPesquisa", true);
                sessaoAtual.Add("ResultSetUltimaPesquisa", resultSetConsultaGeral);
                sessaoAtual.Remove("ParametrosHabilidadeConsultaGeral");

                return resultSetConsultaGeral;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/AdicionaParametroHabilidadePesquisaGeral")]
        public RespostaRequisicaoDTO AdicionaParametroHabilidadePesquisaGeral([FromBody] HabilidadeProjetoNivelDTO habilidadeProjetoParametro) {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var listaParametrosHabilidadeConsultaGeral = new List<HabilidadeProjetoNivelDTO>();

                if (!ParametroJaEstaAdicionado(habilidadeProjetoParametro)){
                    if (sessaoAtual["ParametrosHabilidadeConsultaGeral"] != null)
                        (sessaoAtual["ParametrosHabilidadeConsultaGeral"] as IList<HabilidadeProjetoNivelDTO>).Add(habilidadeProjetoParametro);
                    else {
                        listaParametrosHabilidadeConsultaGeral.Add(habilidadeProjetoParametro);
                        sessaoAtual.Add("ParametrosHabilidadeConsultaGeral", listaParametrosHabilidadeConsultaGeral);
                    }
                }
                else
                    return new RespostaRequisicaoDTO { RequisicaoBemSucedida = false, MensagemRespostaRequisicao = "Parâmetro já adicionado" };
                
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Parâmetro adicionado com sucesso!" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = false, MensagemRespostaRequisicao = "Houve algum erro na solicitação!" };
            }
        }

        [HttpGet]
        [Route("api/Jovens/RetornaParametrosHabilidadeAdicionados")]
        public IList<HabilidadeProjetoNivelDTO> RetornaParametrosHabilidadeAdicionados() {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var listaParametrosHabilidadeConsultaGeral = (sessaoAtual["ParametrosHabilidadeConsultaGeral"] as IList<HabilidadeProjetoNivelDTO>).ToList();

                if (listaParametrosHabilidadeConsultaGeral != null && 
                    listaParametrosHabilidadeConsultaGeral.Count >0) {
                    foreach (var habilidadeSelecionada in listaParametrosHabilidadeConsultaGeral){
                        habilidadeSelecionada.NomeHabilidade = string.Format("Jovens que possuem habilidade em: {0}", habilidadeSelecionada.NomeHabilidade);
                    }
                }

                return (listaParametrosHabilidadeConsultaGeral == null)? null: listaParametrosHabilidadeConsultaGeral;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        private bool ParametroJaEstaAdicionado(HabilidadeProjetoNivelDTO habilidadeNivel) {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                if (sessaoAtual["ParametrosHabilidadeConsultaGeral"] != null) {
                    IList<HabilidadeProjetoNivelDTO> habilidadesAdicionadas = new List<HabilidadeProjetoNivelDTO>();
                    
                    habilidadesAdicionadas = (sessaoAtual["ParametrosHabilidadeConsultaGeral"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.IdHabilidade == habilidadeNivel.IdHabilidade).ToList();
                    
                    if (habilidadesAdicionadas.Count() > 0)
                        return true;
                }
                return false;
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/Jovens/ObterUltimaPesquisa/")]
        public UltimaPesquisaDTO<TodosJovensDTO> ObterUltimaPesquisa() {
            try {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var objetoRetorno = new UltimaPesquisaDTO<TodosJovensDTO> { ExisteUltimaPesquisa = false };

                if (sessaoAtual["ExisteUltimaPesquisa"] != null) {
                    objetoRetorno.ExisteUltimaPesquisa = true;
                    objetoRetorno.ResultSetUltimaPesquisa = (sessaoAtual["ResultSetUltimaPesquisa"] as IList<TodosJovensDTO>);
                }

                return objetoRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
        [HttpGet]
        [Route("api/Jovens/ObterUltimaPesquisaTodosJovens/")]
        public UltimaPesquisaDTO<TodosJovensDTO> ObterUltimaPesquisaTodosJovens()
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                var objetoRetorno = new UltimaPesquisaDTO<TodosJovensDTO> { ExisteUltimaPesquisa = false };

                if (sessaoAtual["ExisteUltimaPesquisaTJ"] != null) {
                    objetoRetorno.ExisteUltimaPesquisa = true;
                    objetoRetorno.ResultSetUltimaPesquisa = (sessaoAtual["ResultSetUltimaPesquisaTJ"] as IList<TodosJovensDTO>);
                }

                return objetoRetorno;
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/Jovens/LimpaPesquisaGC")]
        public RespostaRequisicaoDTO LimpaPesquisaGC() {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            sessaoAtual.Remove("ExisteUltimaPesquisa");
            sessaoAtual.Remove("ResultSetUltimaPesquisa");
            return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Limpeza de pesquisa realizada com sucesso" };
        }

        [HttpGet]
        [Route("api/Jovens/LimpaPesquisaTJ")]
        public RespostaRequisicaoDTO LimpaPesquisaTJ()
        {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            sessaoAtual.Remove("ExisteUltimaPesquisaTJ");
            sessaoAtual.Remove("ResultSetUltimaPesquisaTJ");
            return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Limpeza de pesquisa realizada com sucesso" };
        }

        [HttpPost]
        [Route("api/Jovens/ArmazenaDataAlterada")]
        public void ArmazenaDataAlterada([FromBody] JovemDTO jovemParametro) {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            sessaoAtual.Add("DataNascimentoAlterada", jovemParametro.DataNascimento);
        }

        [HttpPost]
        [Route("api/Jovens/ArmazenaDataPreenchimentoAlterada")]
        public void ArmazenaDataPreenchimentoAlterada([FromBody] JovemDTO jovemParametro)
        {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            sessaoAtual.Add("DataPreenchimentoAlterada", jovemParametro.DataPreenchimentoFormulario);
        }

        [HttpPost]
        [Route("api/Jovens/ArmazenaDataCasamentoAlterada")]
        public void ArmazenaDataCasamentoAlterada([FromBody] JovemDTO jovemParametro)
        {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            sessaoAtual.Add("DataCasamentoAlterada", jovemParametro.DataCasamento);
        }

        [HttpPost]
        [Route("api/Jovens/SolicitarAutorizacaoCompraCamisa")]
        public RespostaAprovacaoCompraCamisa SolicitarAutorizacaoCompraCamisa([FromBody] IList<AutorizacaoCompraCamisaDTO> pSolicitacoesCompraCamisa) {
            try {
                var facade = new FacadeJovemImpl();
                var autorizacoesCondedidas = new List<AutorizacaoCompraCamisaDTO>();

                /*
                if (pSolicitacoesCompraCamisa[0].QuemEstaSolicitando == "Obreiro") {
                    if (facade.AindaPodeSolicitarCamisa(pSolicitacoesCompraCamisa[0].IdJovem))
                        return new RespostaAprovacaoCompraCamisa { SolicitacaoBemSucedida = false, RespostaSoliciticao = "As duas camisa à que o obreiro tem direito, já foram solicitadas !" };
                }
                else if (pSolicitacoesCompraCamisa[0].QuemEstaSolicitando == "Jovem") {
                    if (facade.JaExistemSolicitacoesCadastradas(pSolicitacoesCompraCamisa[0].IdJovem))
                        return new RespostaAprovacaoCompraCamisa { SolicitacaoBemSucedida = false, RespostaSoliciticao = "Já foi solicitado autorização de camisa para este jovem!" };
                }*/

                /*
                ************************************************************************
                * **********************************************************************

                if (pSolicitacoesCompraCamisa[0].QuemEstaSolicitando == "Jovem") {
                    if (facade.JaExistemSolicitacoesCadastradas(pSolicitacoesCompraCamisa[0].IdJovem))
                        return new RespostaAprovacaoCompraCamisa { SolicitacaoBemSucedida = false, RespostaSoliciticao = "Já foi solicitado autorização de camisa para este jovem!" };
                }*/

                foreach (var solicitacao in pSolicitacoesCompraCamisa) {
                    if (solicitacao.OrigemCompraCamisa == "S") {
                        var hashCodigoCamisa = Guid.NewGuid().ToByteArray()[0];
                        solicitacao.CodigoAutorizacaoCompraCamisa = $"CASGFJU{solicitacao.IdJovem}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Millisecond}{hashCodigoCamisa}";
                    }
                    autorizacoesCondedidas.Add(new AutorizacaoCompraCamisaDTO { CodigoAutorizacaoCompraCamisa = solicitacao.CodigoAutorizacaoCompraCamisa, NomeCamisaAutorizada = solicitacao.NomeCamisaAutorizada });
                }

                var autorizacaoRetorno = facade.SolicitarAutorizacaoCompraCamisa(pSolicitacoesCompraCamisa);

                autorizacaoRetorno.AutorizacoesConcedidas = autorizacoesCondedidas;
                return autorizacaoRetorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/PesquisaAutorizacoesCamisaFJUPorParametro")]
        public IList<JovemAutorizacaoCamisaDTO> PesquisaAutorizacoesCamisaFJUPorParametro([FromBody] ConsultaGeralDTO parametrosConsultaGeral) { 
            try {
                var facade = new FacadeJovemImpl();
                var retornoController = facade.PesquisaAutorizacoesCamisaFJUPorParametro(parametrosConsultaGeral);
                return retornoController;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/RetornaCodigoAutorizacaoCamisaSGFJU")]
        public string RetornaCodigoAutorizacaoCamisaSGFJU([FromBody] JovemDTO pjovemParametro) {
            return $"CASGFJU{pjovemParametro.Id}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Millisecond}";
        }

        //
        [HttpPost]
        [Route("api/Jovens/VerificaCodigoArcacenter")]
        public RespostaAprovacaoCompraCamisa VerificaCodigoArcacenter([FromBody] AutorizacaoCompraCamisaDTO codigoArcaCenter) {
            try {
                var facade = new FacadeJovemImpl();
                return facade.VerificaCodigoArcacenter(codigoArcaCenter);
            }
            catch (Exception controllerExc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpPost]
        [Route("api/Jovens/AlteraClassificacaoJovem")]
        public RespostaRequisicaoDTO AlteraClassificacaoJovem([FromBody]JovemDTO jovemParametro) {
            try {
                var facade = new FacadeJovemImpl();
                facade.AlteraClassificacaoJovem(jovemParametro);
                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Alteração de classificação realizada com sucesso !" };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
