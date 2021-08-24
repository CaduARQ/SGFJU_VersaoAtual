using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.Domain.UI.Controllers
{
    public class IdiomasAtualizacaoController : ApiController {
        [HttpPost]
        [Route("api/IdiomasAtualizacao/AdicionarIdioma")]
        public RespostaRequisicaoIdiomaDTO AdicionarIdioma([FromBody] IdiomaNivelDTO idioma)
        {
            try
            {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);

                if (sessaoAtual["Atualizacao_IdiomasAdicionados"] == null)
                {
                    var idiomasAdicionados = new List<IdiomaNivelDTO>();
                    if (JaEsta(idioma))
                        return new RespostaRequisicaoIdiomaDTO { IdiomaJaAdicionado = true, MensagemRespostaRequisicao = "Idioma já adicionado" };

                    idiomasAdicionados.Add(idioma);
                    sessaoAtual.Add("Atualizacao_IdiomasAdicionados", idiomasAdicionados);
                }
                else
                {
                    if (JaEsta(idioma))
                        return new RespostaRequisicaoIdiomaDTO { IdiomaJaAdicionado = true, MensagemRespostaRequisicao = "Idioma já adicionado" };

                    (sessaoAtual["Atualizacao_IdiomasAdicionados"] as IList<IdiomaNivelDTO>).Add(idioma);
                }
                return new RespostaRequisicaoIdiomaDTO { IdiomaJaAdicionado = false, MensagemRespostaRequisicao = "Idioma cadastrado com sucesso!!!" };
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public bool JaEsta([FromBody] IdiomaNivelDTO idioma)
        {
            try
            {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                if (sessaoAtual["Atualizacao_IdiomasAdicionados"] != null)
                {
                    if (idioma.EhIdiomaExtra)
                    {
                        foreach (var idiomaNaSessao in (sessaoAtual["Atualizacao_IdiomasAdicionados"] as IList<IdiomaNivelDTO>))
                        {
                            if (string.Equals(idioma.DescricaoIdioma, idiomaNaSessao.DescricaoIdioma, StringComparison.OrdinalIgnoreCase))
                                return true;
                        }
                        return false;
                    }
                    else
                    {
                        var idiomasAdicionadas = (sessaoAtual["Atualizacao_IdiomasAdicionados"] as IList<IdiomaNivelDTO>).Where(h => h.CodigoIdioma == idioma.CodigoIdioma);
                        if (idiomasAdicionadas.Count() > 0)
                            return true;
                    }
                }
                return false;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/IdiomasAtualizacao/TodosIdiomasJaAdicionados")]
        public IList<IdiomaNivelDTO> TodosIdiomasJaAdicionados()
        {
            try
            {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                IList<IdiomaNivelDTO> retorno = new List<IdiomaNivelDTO>();
                if (sessaoAtual["Atualizacao_IdiomasAdicionados"] != null)
                    return (sessaoAtual["Atualizacao_IdiomasAdicionados"] as IList<IdiomaNivelDTO>);

                return retorno;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/IdiomasAtualizacao/RemoveIdioma/{idIdioma}")]
        public RespostaRequisicaoIdiomaDTO RemoveIdioma(int idIdioma)
        {
            try
            {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                IList<IdiomaNivelDTO> idiomasParaExcluir = null;
                if (sessaoAtual["Atualizacao_IdiomasAdicionados"] != null)
                {
                    if (sessaoAtual["IdiomasParaExcluir"] == null) {
                        idiomasParaExcluir = new List<IdiomaNivelDTO>();
                        sessaoAtual.Add("IdiomasParaExcluir", idiomasParaExcluir);
                    }

                    var idiomaAExcluir = (sessaoAtual["Atualizacao_IdiomasAdicionados"] as IList<IdiomaNivelDTO>).Where(i => i.CodigoIdioma == idIdioma).FirstOrDefault();
                    if (idiomaAExcluir != null){
                        (sessaoAtual["Atualizacao_IdiomasAdicionados"] as IList<IdiomaNivelDTO>).Remove(idiomaAExcluir);
                        (sessaoAtual["IdiomasParaExcluir"] as IList<IdiomaNivelDTO>).Add(idiomaAExcluir);

                        return new RespostaRequisicaoIdiomaDTO { IdiomaExcluidoComSucesso = true };
                    }
                    return new RespostaRequisicaoIdiomaDTO { IdiomaExcluidoComSucesso = false };
                }
                return new RespostaRequisicaoIdiomaDTO { IdiomaExcluidoComSucesso = false };
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}
