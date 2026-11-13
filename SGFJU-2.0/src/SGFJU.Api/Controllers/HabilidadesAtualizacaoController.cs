using SGFJU.Domain.Model.Infra.Util;
using SGFJU.Api.Legado;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace SGFJU.Api.Controllers
{
    public class HabilidadesAtualizacaoController : ControllerBase
    {
        [HttpPost]
        [Route("api/HabilidadesAtualizacao/AdicionarHabilidade")]
        public RespostaRequisicaoHabilidadeDTO AdicionarHabilidade([FromBody] HabilidadeProjetoNivelDTO habilidade)
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();

                if (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] == null)
                {
                    var habilidadesAdicionadas = new List<HabilidadeProjetoNivelDTO>();
                    if (JaEsta(habilidade))
                        return new RespostaRequisicaoHabilidadeDTO { HabilidadeJaAdicionada = true, MensagemRespostaRequisicao = "Habilidade já está adicionada!!!" };

                    habilidadesAdicionadas.Add(habilidade);
                    sessaoAtual.Add("Atualizacao_HabilidadesAdicionadas", habilidadesAdicionadas);
                }
                else
                {
                    if (JaEsta(habilidade))
                        return new RespostaRequisicaoHabilidadeDTO { HabilidadeJaAdicionada = true, MensagemRespostaRequisicao = "Habilidade já está adicionada!!!" };
                    (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Add(habilidade);
                }

                if (habilidade.IdDepartamento != 0)
                    AssociaJovemADepartamento(habilidade);

                return new RespostaRequisicaoHabilidadeDTO { HabilidadeJaAdicionada = false, MensagemRespostaRequisicao = "Habilidade adicionada com sucesso" };
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        private void AssociaJovemADepartamento(HabilidadeProjetoNivelDTO habilidade)
        {
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            if (sessaoAtual["Atualizacao_departamentosAdicionados"] == null)
            {
                var departamentosAdicionadas = new List<DepartamentoProjetoDTO>();
                departamentosAdicionadas.Add(new DepartamentoProjetoDTO { IdDepartamento = habilidade.IdDepartamento });
                sessaoAtual.Add("Atualizacao_departamentosAdicionados", departamentosAdicionadas);
            }
            else
                (sessaoAtual["Atualizacao_departamentosAdicionados"] as IList<DepartamentoProjetoDTO>).Add(new DepartamentoProjetoDTO { IdDepartamento = habilidade.IdDepartamento });
        }        

        [HttpGet]
        [Route("api/HabilidadesAtualizacao/TodasAdicionadasPorProjeto/{idProjeto}")]
        public IList<HabilidadeProjetoNivelDTO> TodasAdicionadasPorProjeto(int idProjeto)
        {
            IList<HabilidadeProjetoNivelDTO> retorno = new List<HabilidadeProjetoNivelDTO>();
            var sessaoAtual = SessionHelper.RetornaSessaoAtual();
            if (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] != null)
                return (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.EhHabilidadeExtra == false).ToList();
            return retorno;
        }
        public bool JaEsta(HabilidadeProjetoNivelDTO habilidadeNivel)
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                if (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] != null)
                {
                    IList<HabilidadeProjetoNivelDTO> habilidadesAdicionadas = new List<HabilidadeProjetoNivelDTO>();
                    if (habilidadeNivel.EhHabilidadeExtra == false)
                        habilidadesAdicionadas = (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.IdHabilidade == habilidadeNivel.IdHabilidade).ToList();
                    else
                    {
                        foreach (var habilidadeSessao in (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>))
                        {
                            if (string.Equals(habilidadeNivel.NomeHabilidade, habilidadeSessao.NomeHabilidade, StringComparison.OrdinalIgnoreCase))
                                habilidadesAdicionadas.Add(habilidadeSessao);
                        }
                    }
                    if (habilidadesAdicionadas.Count() > 0)
                        return true;
                }
                return false;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        // PUT: api/Habilidades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Habilidades/5
        [HttpGet]
        [Route("api/HabilidadesAtualizacao/RemoverHabilidade/{idHabilidade}")]
        public RespostaRequisicaoHabilidadeDTO RemoverHabilidade(int idHabilidade)
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                IList<HabilidadeProjetoNivelDTO> habilidadesParaExcluir = null;
                if (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] != null)
                {
                    if (sessaoAtual["HabilidadesParaExcluir"] == null) {
                        habilidadesParaExcluir = new List<HabilidadeProjetoNivelDTO>();
                        sessaoAtual.Add("HabilidadesParaExcluir", habilidadesParaExcluir);
                    }

                    var habilidadesAdicionadas =
                        (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>);
                    if (habilidadesAdicionadas.Count() > 0) {
                        var habilidadeAExcluir = habilidadesAdicionadas.Where(h => h.IdHabilidade == idHabilidade).FirstOrDefault();
                        habilidadesAdicionadas.Remove(habilidadeAExcluir);
                        (sessaoAtual["HabilidadesParaExcluir"] as IList<HabilidadeProjetoNivelDTO>).Add(habilidadeAExcluir);

                        return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = true };
                    }
                }
                return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = false };
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        [HttpGet]
        [Route("api/HabilidadesAtualizacao/RemoverHabilidadeExtra/{nomeHabilidadeExtra}")]
        public RespostaRequisicaoHabilidadeDTO RemoverHabilidadeExtra(string nomeHabilidadeExtra)
        {
            try
            {
                var sessaoAtual = SessionHelper.RetornaSessaoAtual();
                if (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] != null)
                {
                    var habilidadesAdicionadas =
                        (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Where(h => h.EhHabilidadeExtra == true).ToList();
                    if (habilidadesAdicionadas.Count() > 0)
                    {
                        foreach (var habilidadeExtraSessao in habilidadesAdicionadas)
                        {
                            if (string.Equals(nomeHabilidadeExtra, habilidadeExtraSessao.NomeHabilidade, StringComparison.OrdinalIgnoreCase))
                            {
                                (sessaoAtual["Atualizacao_HabilidadesAdicionadas"] as IList<HabilidadeProjetoNivelDTO>).Remove(habilidadeExtraSessao);
                                return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = true };
                            }
                        }
                    }
                }
                return new RespostaRequisicaoHabilidadeDTO { HabilidadeExcluidaComSucesso = false };
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}
