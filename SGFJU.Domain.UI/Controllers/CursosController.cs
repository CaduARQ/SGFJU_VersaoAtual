using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.Domain.UI.Controllers
{
    public class CursosController : ApiController
    {
        public void Post([FromBody] CursoDTO curso) {
			try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);

                if (sessaoAtual["cursosAdicionados"] == null)
                {
                    var cursosAdicionados = new List<CursoRelacionadoProjeto>();
                    cursosAdicionados.Add(new CursoRelacionadoProjeto { 
                        NomeCurso = curso.NomeCurso,
                        ProjetoRelacionado = new Projeto { Code = curso.IdProjetoRelacionado, NomeProjeto = curso.NomeProjeto }
                    });
                    sessaoAtual.Add("cursosAdicionados", cursosAdicionados);
                }
                else
                    (sessaoAtual["cursosAdicionados"] as IList<CursoRelacionadoProjeto>)
                        .Add(new CursoRelacionadoProjeto { 
                            NomeCurso = curso.NomeCurso,
                            ProjetoRelacionado = new Projeto { Code = curso.IdProjetoRelacionado, NomeProjeto = curso.NomeProjeto }
                        });
            }
			catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/Cursos/TodosCursosJaAdicionados")]
        public IList<CursoDTO> TodosCursosJaAdicionados() {
            try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                IList<CursoDTO> retorno = new List<CursoDTO>();
                if (sessaoAtual["cursosAdicionados"] != null)
                    return (sessaoAtual["cursosAdicionados"] as IList<CursoRelacionadoProjeto>)
                                .Select(c => new CursoDTO { 
                                    NomeCurso = c.NomeCurso,
                                    NomeProjeto = c.ProjetoRelacionado.NomeProjeto,
                                    IdProjetoRelacionado = c.ProjetoRelacionado.Code
                                }).ToList();
                return retorno;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/Cursos/RemoveCurso/{nomeCurso}")]
        public RespostaRequisicaoCursoDTO RemoveCurso(string nomeCurso) {
            try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                if (sessaoAtual["cursosAdicionados"] != null) {
                    var cursosQueEstaoNaSessao = (sessaoAtual["cursosAdicionados"] as IList<CursoRelacionadoProjeto>);
                    foreach (var cursoSessao in cursosQueEstaoNaSessao){
                        if (string.Equals(cursoSessao.NomeCurso, nomeCurso, StringComparison.OrdinalIgnoreCase)) {
                            cursosQueEstaoNaSessao.Remove(cursoSessao);
                            return new RespostaRequisicaoCursoDTO{ CursoExcluidoComSucesso = true };
                        }
                    }
                }
                return new RespostaRequisicaoCursoDTO { CursoExcluidoComSucesso = false };
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }
    }
}
