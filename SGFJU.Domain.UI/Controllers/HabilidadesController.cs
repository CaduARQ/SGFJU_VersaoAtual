using SGFJU.Domain.Model.Infra.ExceptionManager;
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
    public class HabilidadesController : ApiController
    {
        [HttpGet]
        [Route("api/Habilidades/TodosHabilidadesExtrasJaAdicionados")]
        public IList<HabilidadeProjetoNivelDTO> TodosHabilidadesExtrasJaAdicionados() {
            try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                IList<HabilidadeProjetoNivelDTO> retorno = new List<HabilidadeProjetoNivelDTO>();
                if (sessaoAtual["HabilidadesAdicionadas"] != null)
                    return (sessaoAtual["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.EhHabilidadeExtra == true).ToList();

                return retorno;
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }

        [HttpPost]
        [Route("api/Habilidades/AdicionarHabilidade")]
        public RespostaRequisicaoHabilidadeDTO AdicionarHabilidade([FromBody] HabilidadeProjetoNivelDTO habilidade) { 
            try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);

                if (sessaoAtual["HabilidadesAdicionadas"] == null) {
                    var habilidadesAdicionadas = new List<HabilidadeProjetoNivelDTO>();
                    if (JaEsta(habilidade))
                        return new RespostaRequisicaoHabilidadeDTO { HabilidadeJaAdicionada = true, MensagemRespostaRequisicao = "Habilidade já está adicionada!!!" };
                    
                    habilidadesAdicionadas.Add(habilidade);
                    sessaoAtual.Add("HabilidadesAdicionadas", habilidadesAdicionadas);
                }
                else {
                    if (JaEsta(habilidade))
                        return new RespostaRequisicaoHabilidadeDTO { HabilidadeJaAdicionada = true, MensagemRespostaRequisicao = "Habilidade já está adicionada!!!" };
                    (sessaoAtual["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Add(habilidade);
                }

                if (habilidade.IdDepartamento != 0)
                    AssociaJovemADepartamento(habilidade);

                return new RespostaRequisicaoHabilidadeDTO { HabilidadeJaAdicionada = false, MensagemRespostaRequisicao = "Habilidade adicionada com sucesso" };
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }

        private void AssociaJovemADepartamento(HabilidadeProjetoNivelDTO habilidade) {
            var sessaoAtual = (System.Web.HttpContext.Current.Session);
            if (sessaoAtual["departamentosAdicionados"] == null) {
                var departamentosAdicionadas = new List<DepartamentoProjetoDTO>();
                departamentosAdicionadas.Add(new DepartamentoProjetoDTO {  IdDepartamento = habilidade.IdDepartamento });
                sessaoAtual.Add("departamentosAdicionados", departamentosAdicionadas);
            }
            else
                (sessaoAtual["departamentosAdicionados"] as IList<DepartamentoProjetoDTO>).Add(new DepartamentoProjetoDTO { IdDepartamento = habilidade.IdDepartamento });
        }

        [HttpGet]
        [Route("api/habilidades/TodasAdicionadasPorProjeto/{idProjeto}")]
        public IList<HabilidadeProjetoNivelDTO> TodasAdicionadasPorProjeto(int idProjeto) {
            IList<HabilidadeProjetoNivelDTO> retorno = new List<HabilidadeProjetoNivelDTO>();
            var sessaoAtual = (System.Web.HttpContext.Current.Session);
            if (sessaoAtual["HabilidadesAdicionadas"] != null)
                return  (sessaoAtual["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.EhHabilidadeExtra == false).ToList();
            return retorno;
        }
        public bool JaEsta(HabilidadeProjetoNivelDTO habilidadeNivel) {
            try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                if (sessaoAtual["HabilidadesAdicionadas"] != null) {
                    IList<HabilidadeProjetoNivelDTO> habilidadesAdicionadas = new List<HabilidadeProjetoNivelDTO>();
                    
                    habilidadesAdicionadas = (sessaoAtual["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.IdHabilidade == habilidadeNivel.IdHabilidade).ToList();
                    
                    if (habilidadesAdicionadas.Count() > 0)
                        return true;
                }
                return false;
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }

        // PUT: api/Habilidades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Habilidades/5
        [HttpGet]
        [Route("api/Habilidades/RemoverHabilidade/{idHabilidade}")]
        public RespostaRequisicaoHabilidadeDTO RemoverHabilidade(int idHabilidade) {
            try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                if (sessaoAtual["HabilidadesAdicionadas"] != null) {
                    var habilidadesAdicionadas = 
                        (sessaoAtual["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>);
                    if (habilidadesAdicionadas.Count() > 0) {
                        var habilidadeAExcluir = habilidadesAdicionadas.Where(h => h.IdHabilidade == idHabilidade).FirstOrDefault();
                        habilidadesAdicionadas.Remove(habilidadeAExcluir);
                        return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = true };
                    }                        
                }
                return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = false };
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/Habilidades/RemoverHabilidadeExtra/{nomeHabilidadeExtra}")]
        public RespostaRequisicaoHabilidadeDTO RemoverHabilidadeExtra(string nomeHabilidadeExtra) {
            try {
                var sessaoAtual = (System.Web.HttpContext.Current.Session);
                if (sessaoAtual["HabilidadesAdicionadas"] != null) {
                    var habilidadesAdicionadas =
                        (sessaoAtual["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.EhHabilidadeExtra == true).ToList();
                    if (habilidadesAdicionadas.Count() > 0){
                        foreach (var habilidadeExtraSessao in habilidadesAdicionadas) {
                            if (string.Equals(nomeHabilidadeExtra, habilidadeExtraSessao.NomeHabilidade, StringComparison.OrdinalIgnoreCase)) {
                                (sessaoAtual["HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Remove(habilidadeExtraSessao);
                                return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = true };
                            }                                
                        }
                    }
                }
                return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = false };
            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
            }
        }

        [HttpPost]
        [Route("api/Habilidades/ListarHabilidadesPorProjeto/")]
        public IList<HabilidadeProjetoDTO> ListarHabilidadesPorProjeto([FromBody] ProjetoDTO projetoParametro) {
            try {
                var listaRetorno = new List<HabilidadeProjetoDTO>();
                var listaHabilidadesEsporte = new List<HabilidadeProjetoDTO> {
                    new HabilidadeProjetoDTO{ IdHabilidade = 65, NomeHabilidade = "Jiu-Jitsu" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 66, NomeHabilidade = "Boxe" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 67, NomeHabilidade = "Muay Thay" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 68, NomeHabilidade = "Taekwondo" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 69, NomeHabilidade = "Futebol" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 70, NomeHabilidade = "Volley" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 71, NomeHabilidade = "Basquete" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 72, NomeHabilidade = "Esporte de Mesa" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 73, NomeHabilidade = "Surf" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 74, NomeHabilidade = "Skate" }
                };
                var listaHabilidadesMidia = new List<HabilidadeProjetoDTO> {
                    new HabilidadeProjetoDTO{ IdHabilidade = 76, NomeHabilidade = "Fotográfia" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 77, NomeHabilidade = "Jornalismo" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 78, NomeHabilidade = "Marketing" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 79, NomeHabilidade = "Áudio Visual" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 80, NomeHabilidade = "Design Gráfico" }
                };
                var listaHabilidadesCultura = new List<HabilidadeProjetoDTO> {
                    new HabilidadeProjetoDTO{ IdHabilidade = 40, NomeHabilidade = "HipHop" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 41, NomeHabilidade = "Popping" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 42, NomeHabilidade = "BreakDance" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 43, NomeHabilidade = "Locking" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 44, NomeHabilidade = "AllStyle" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 45, NomeHabilidade = "StreetDance" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 46, NomeHabilidade = "BalletClassico" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 47, NomeHabilidade = "NeoClassico" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 48, NomeHabilidade = "Jazz" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 49, NomeHabilidade = "EstiloLivre" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 50, NomeHabilidade = "BalletTeatral" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 51, NomeHabilidade = "Tenor" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 52, NomeHabilidade = "Baritono" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 53, NomeHabilidade = "TonBaixo" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 54, NomeHabilidade = "Soprano" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 55, NomeHabilidade = "MezzoSoprano" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 56, NomeHabilidade = "Contralto" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 57, NomeHabilidade = "Teclado" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 58, NomeHabilidade = "Violao" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 59, NomeHabilidade = "Baixo" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 60, NomeHabilidade = "Guitarra" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 61, NomeHabilidade = "Cavaquinho" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 62, NomeHabilidade = "Violino" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 63, NomeHabilidade = "Bateria" },
                    new HabilidadeProjetoDTO{ IdHabilidade = 64, NomeHabilidade = "Percurssao" }
                };

                if (projetoParametro.IdProjeto == 12)
                    return listaHabilidadesEsporte;
                else if (projetoParametro.IdProjeto == 18)
                    return listaHabilidadesCultura;
                else if (projetoParametro.IdProjeto == 16)
                    return listaHabilidadesMidia;

                return listaRetorno;
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
