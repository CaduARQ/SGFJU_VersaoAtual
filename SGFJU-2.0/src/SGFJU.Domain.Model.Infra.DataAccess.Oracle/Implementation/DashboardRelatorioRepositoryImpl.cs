using NHibernate.Criterion;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class DashboardRelatorioRepositoryImpl : RepositoryImpl<DashboardRelatorio>, DashboardRelatorioRepository
    {
        public IList<RelatorioTotaisGeralDTO> RetornaTotaisNacional(){
            try {
                var retorno = new List<RelatorioTotaisGeralDTO>();
                using (var session = __sessionFactory.OpenSession()){
                    var totaisNacional =  base.ListAll();
                    foreach (var totalEstado in totaisNacional){
                        retorno.Add(new RelatorioTotaisGeralDTO {
                            IdEstado                      = totalEstado.EstadoRelatorio.Id,
                            NomeEstado                    = totalEstado.EstadoRelatorio.NomeEstado,
                            QuantidadeTotalJovens         = totalEstado.QuantidadeTotalJovens,
                            QuantidadeTotalJovensAtivos   = totalEstado.QuantidadeTotalJovensAtivos,
                            QuantidadeTotalJovensInativos = totalEstado.QuantidadeTotalJovensInativos,
                            QuantidadeTotalJovensIniciantes = totalEstado.QuantidadeTotalJovensIniciantes,
                            QuantidadeTotalHomens         = totalEstado.QuantidadeTotalHomens,
                            QuantidadeTotalBatizadosAguas = totalEstado.QuantidadeTotalBatizadosAguas,
                            QuantidadeTotalEspiritoSanto  = totalEstado.QuantidadeTotalEspiritoSanto,
                            QuantidadeTotalMulheres       = totalEstado.QuantidadeTotalMulheres,
                            QuantidadeTotalObreiros       = totalEstado.QuantidadeTotalObreiros,
                            QuantidadeTotalColaboradores  = totalEstado.QuantidadeTotalColaboradores,
                            QuantidadeTotalCPO            = totalEstado.QuantidadeTotalCPO,
                            QuantidadeJovensAltarJovem    = totalEstado.QuantidadeJovensAltarJovem,
                            QuantidadeTotalUniversitarios = totalEstado.QuantidadeTotalUniversitarios,
                            QuantidadeTotalMidia          = totalEstado.QuantidadeTotalMidia ,
                            QuantidadeTotalHelp           = totalEstado.QuantidadeTotalHelp ,
                            QuantidadeTotalSecretarias    = totalEstado.QuantidadeTotalSecretarias ,
                            QuantidadeTotalCultura        = totalEstado.QuantidadeTotalCultura ,
                            QuantidadeTotalEsporte        = totalEstado.QuantidadeTotalEsporte ,
                            QuantidadeTotalAtalaia        = totalEstado.QuantidadeTotalAtalaia ,
                            QuantidadeTotalArcanjos       = totalEstado.QuantidadeTotalArcanjos ,
                            QuantidadeTotalUniforca       = totalEstado.QuantidadeTotalUniforca ,
                            QuantidadeTotalAVJovensAcompanhados = totalEstado.QuantidadeTotalAVJovensAcompanhados,
                            QuantidadeTotalAVJovensSemAcompanhamento = totalEstado.QuantidadeTotalAVJovensSemAcompanhamento
                        });
                    }
                }
                return retorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public RelatorioTotaisGeralDTO RetornaRelatorioTotaisEstado(Estado estadoParametro) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    var HQLQuery = string
                                      .Format("select rd " +
                                              "  from DashboardRelatorio as rd " +
                                              " where rd.EstadoRelatorio.Id = {0} ", estadoParametro.Id.ToString());
                    var relatorio = session.CreateQuery(HQLQuery).UniqueResult<DashboardRelatorio>();
                    return new RelatorioTotaisGeralDTO { 
                        IdEstado                      = relatorio.EstadoRelatorio.Id,
                        NomeEstado                    = relatorio.EstadoRelatorio.NomeEstado,
                        QuantidadeTotalJovens         = relatorio.QuantidadeTotalJovens,
                        QuantidadeTotalJovensAtivos   = relatorio.QuantidadeTotalJovensAtivos,
                        QuantidadeTotalJovensInativos = relatorio.QuantidadeTotalJovensInativos,
                        QuantidadeTotalJovensIniciantes = relatorio.QuantidadeTotalJovensIniciantes,
                        QuantidadeTotalHomens         = relatorio.QuantidadeTotalHomens,
                        QuantidadeTotalBatizadosAguas = relatorio.QuantidadeTotalBatizadosAguas,
                        QuantidadeTotalEspiritoSanto  = relatorio.QuantidadeTotalEspiritoSanto,
                        QuantidadeTotalMulheres       = relatorio.QuantidadeTotalMulheres,
                        QuantidadeTotalObreiros       = relatorio.QuantidadeTotalObreiros,
                        QuantidadeTotalColaboradores  = relatorio.QuantidadeTotalColaboradores,
                        QuantidadeTotalCPO            = relatorio.QuantidadeTotalCPO,
                        QuantidadeJovensAltarJovem    = relatorio.QuantidadeJovensAltarJovem,
                        QuantidadeTotalUniversitarios = relatorio.QuantidadeTotalUniversitarios,
                        QuantidadeTotalMidia          = relatorio.QuantidadeTotalMidia ,
                        QuantidadeTotalHelp           = relatorio.QuantidadeTotalHelp ,
                        QuantidadeTotalSecretarias    = relatorio.QuantidadeTotalSecretarias ,
                        QuantidadeTotalCultura        = relatorio.QuantidadeTotalCultura ,
                        QuantidadeTotalEsporte        = relatorio.QuantidadeTotalEsporte ,
                        QuantidadeTotalAtalaia        = relatorio.QuantidadeTotalAtalaia ,
                        QuantidadeTotalArcanjos       = relatorio.QuantidadeTotalArcanjos ,
                        QuantidadeTotalUniforca       = relatorio.QuantidadeTotalUniforca ,
                        QuantidadeTotalAVJovensAcompanhados = relatorio.QuantidadeTotalAVJovensAcompanhados,
                        QuantidadeTotalAVJovensSemAcompanhamento = relatorio.QuantidadeTotalAVJovensSemAcompanhamento
                    };
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public RelatorioTotaisGeralDTO RetornaRelatorioTotaisPorbloco(Bloco blocoParametro) {
            try {
                return null;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<RelatorioBlocoTotaisGeraisDTO> RetornaTotaisBlocosPorEstado(Estado estadoParametro) {
            try
            {
                using (var session = __sessionFactory.OpenSession())
                {
                    IList<RelatorioBlocoTotaisGeraisDTO> retorno = null;
                    var HQLQuery = string
                                      .Format("select drb " +
                                              "  from      DashboardRelatorioBloco as drb " +
                                              " inner join drb.BlocoRelatorio      as blc " +
                                              " where blc.EstadoBloco.Id = {0} ", estadoParametro.Id.ToString());
                    var relatorio = session.CreateQuery(HQLQuery).List<DashboardRelatorioBloco>();
                    if (relatorio.Count > 0) {
                        retorno = new List<RelatorioBlocoTotaisGeraisDTO>();
                        foreach (var dashBloco in relatorio){
                            retorno.Add(
                                new RelatorioBlocoTotaisGeraisDTO
                                {
                                    IdEstado                       = estadoParametro.Id,
                                    IdBloco                        = dashBloco.Id,
                                    NomeBloco                      = dashBloco.BlocoRelatorio.NomeBloco,
                                    QuantidadeTotalJovens          = dashBloco.QuantidadeTotalJovens,
                                    QuantidadeTotalJovensAtivos    = dashBloco.QuantidadeTotalJovensAtivos,
                                    QuantidadeTotalJovensInativos  = dashBloco.QuantidadeTotalJovensInativos,
                                    QuantidadeTotalJovensIniciantes = dashBloco.QuantidadeTotalJovensIniciantes,
                                    QuantidadeTotalHomens          = dashBloco.QuantidadeTotalHomens,
                                    QuantidadeTotalBatizadosAguas  = dashBloco.QuantidadeTotalBatizadosAguas,
                                    QuantidadeTotalEspiritoSanto   = dashBloco.QuantidadeTotalEspiritoSanto,
                                    QuantidadeTotalMulheres        = dashBloco.QuantidadeTotalMulheres,
                                    QuantidadeTotalObreiros        = dashBloco.QuantidadeTotalObreiros,
                                    QuantidadeTotalColaboradores   = dashBloco.QuantidadeTotalColaboradores,
                                    QuantidadeTotalCPO             = dashBloco.QuantidadeTotalCPO,
                                    QuantidadeJovensAltarJovem     = dashBloco.QuantidadeJovensAltarJovem,
                                    QuantidadeTotalUniversitarios  = dashBloco.QuantidadeTotalUniversitarios,
                                    QuantidadeTotalMidia           = dashBloco.QuantidadeTotalMidia,
                                    QuantidadeTotalHelp            = dashBloco.QuantidadeTotalHelp,
                                    QuantidadeTotalSecretarias     = dashBloco.QuantidadeTotalSecretarias,
                                    QuantidadeTotalCultura         = dashBloco.QuantidadeTotalCultura,
                                    QuantidadeTotalEsporte         = dashBloco.QuantidadeTotalEsporte,
                                    QuantidadeTotalAtalaia         = dashBloco.QuantidadeTotalAtalaia,
                                    QuantidadeTotalArcanjos        = dashBloco.QuantidadeTotalArcanjos,
                                    QuantidadeTotalUniforca        = dashBloco.QuantidadeTotalUniforca
                                });
                        };
                    }

                    return retorno;
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public void AtualizarDashboard(Estado estadoParametro) {
            try {
                var dao = new DAO();
                var parametros = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("pID_ESTADO", estadoParametro.Id.ToString()) };
                dao.ExecuteNonqueryProcedure("SGFJU_DEV.ATUALIZA_TOTAIS_DASHBOARD_ESTADO", parametros);
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "AtualizarDashboard", "CAMADA_ORM.Repository");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}
