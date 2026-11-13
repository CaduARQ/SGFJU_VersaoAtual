using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class CursosAtualizacaoController : ControllerBase
    {
        public void Post([FromBody] CursoDTO curso)
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();

                if (sessaoAtual["Atualizacao_cursosAdicionados"] == null)
                {
                    var cursosAdicionados = new List<CursoRelacionadoProjeto>();
                    cursosAdicionados.Add(new CursoRelacionadoProjeto
                    {
                        NomeCurso = curso.NomeCurso,
                        ProjetoRelacionado = new Projeto { Code = curso.IdProjetoRelacionado, NomeProjeto = curso.NomeProjeto }
                    });
                    sessaoAtual.Add("Atualizacao_cursosAdicionados", cursosAdicionados);
                }
                else
                    (sessaoAtual["Atualizacao_cursosAdicionados"] as IList<CursoRelacionadoProjeto>)
                        .Add(new CursoRelacionadoProjeto
                        {
                            NomeCurso = curso.NomeCurso,
                            ProjetoRelacionado = new Projeto { Code = curso.IdProjetoRelacionado, NomeProjeto = curso.NomeProjeto }
                        });
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/CursosAtualizacao/TodosCursosJaAdicionados")]
        public IList<CursoDTO> TodosCursosJaAdicionados()
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                IList<CursoDTO> retorno = new List<CursoDTO>();
                if (sessaoAtual["Atualizacao_cursosAdicionados"] != null)
                    return (sessaoAtual["Atualizacao_cursosAdicionados"] as IList<CursoRelacionadoProjeto>)
                                .Select(c => new CursoDTO
                                {
                                    NomeCurso = c.NomeCurso,
                                    NomeProjeto = c.ProjetoRelacionado.NomeProjeto,
                                    IdProjetoRelacionado = c.ProjetoRelacionado.Code
                                }).ToList();
                return retorno;
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }

        [HttpGet]
        [Route("api/CursosAtualizacao/RemoveCurso/{nomeCurso}")]
        public RespostaRequisicaoCursoDTO RemoveCurso(string nomeCurso)
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                List<CursoRelacionadoProjeto> listaDeCursosParaExclusao = null;
                if (sessaoAtual["Atualizacao_cursosAdicionados"] != null)
                {
                    var cursosQueEstaoNaSessao = (sessaoAtual["Atualizacao_cursosAdicionados"] as IList<CursoRelacionadoProjeto>);

                    if (sessaoAtual["cursosParaExcluir"] == null) {
                        listaDeCursosParaExclusao = new List<CursoRelacionadoProjeto>();
                        sessaoAtual.Add("cursosParaExcluir", listaDeCursosParaExclusao);
                    }
                    int indiceParaExcluir = -1;
                    foreach (var cursoSessao in cursosQueEstaoNaSessao)
                    {
                        indiceParaExcluir++;
                        if (string.Equals(cursoSessao.NomeCurso, nomeCurso, StringComparison.OrdinalIgnoreCase))
                        {
                            //cursosQueEstaoNaSessao.Remove(cursoSessao);
                            (sessaoAtual["Atualizacao_cursosAdicionados"] as IList<CursoRelacionadoProjeto>).RemoveAt(indiceParaExcluir);
                            (sessaoAtual["cursosParaExcluir"] as List<CursoRelacionadoProjeto>).Add(cursoSessao);
                            return new RespostaRequisicaoCursoDTO { CursoExcluidoComSucesso = true };
                        }
                    }
                }
                return new RespostaRequisicaoCursoDTO { CursoExcluidoComSucesso = false };
            }
            catch (Exception controllerExc) {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(controllerExc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(mensagemTratada);
            }
        }
    }
}
