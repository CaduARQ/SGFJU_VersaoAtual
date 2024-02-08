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
    public class DashboardRelatorioBlocoRepositoryImpl : RepositoryImpl<DashboardRelatorioBloco>, DashboardRelatorioBlocoRepository
    {
        public IList<RelatorioBlocoTotaisGeraisDTO> RetornaTotaisBlocosNacional(){
            try {
                var retorno = new List<RelatorioBlocoTotaisGeraisDTO>();
                using (var session = __sessionFactory.OpenSession()){
                    var totaisNacional =  base.ListAll();
                    foreach (var totalBloco in totaisNacional){
                        retorno.Add(new RelatorioBlocoTotaisGeraisDTO
                        {
                            IdBloco                      = totalBloco.BlocoRelatorio.Id,
                            QuantidadeTotalJovens         = totalBloco.QuantidadeTotalJovens,
                            QuantidadeTotalJovensAtivos   = totalBloco.QuantidadeTotalJovensAtivos,
                            QuantidadeTotalJovensInativos = totalBloco.QuantidadeTotalJovensInativos,
                            QuantidadeTotalJovensIniciantes = totalBloco.QuantidadeTotalJovensIniciantes,
                            QuantidadeTotalHomens         = totalBloco.QuantidadeTotalHomens,
                            QuantidadeTotalBatizadosAguas = totalBloco.QuantidadeTotalBatizadosAguas,
                            QuantidadeTotalEspiritoSanto  = totalBloco.QuantidadeTotalEspiritoSanto,
                            QuantidadeTotalMulheres       = totalBloco.QuantidadeTotalMulheres,
                            QuantidadeTotalObreiros       = totalBloco.QuantidadeTotalObreiros,
                            QuantidadeTotalColaboradores  = totalBloco.QuantidadeTotalColaboradores,
                            QuantidadeTotalCPO            = totalBloco.QuantidadeTotalCPO,
                            QuantidadeJovensAltarJovem    = totalBloco.QuantidadeJovensAltarJovem,
                            QuantidadeTotalUniversitarios = totalBloco.QuantidadeTotalUniversitarios,
                            QuantidadeTotalMidia          = totalBloco.QuantidadeTotalMidia ,
                            QuantidadeTotalHelp           = totalBloco.QuantidadeTotalHelp ,
                            QuantidadeTotalSecretarias    = totalBloco.QuantidadeTotalSecretarias ,
                            QuantidadeTotalCultura        = totalBloco.QuantidadeTotalCultura ,
                            QuantidadeTotalEsporte        = totalBloco.QuantidadeTotalEsporte ,
                            QuantidadeTotalAtalaia        = totalBloco.QuantidadeTotalAtalaia ,
                            QuantidadeTotalArcanjos       = totalBloco.QuantidadeTotalArcanjos ,
                            QuantidadeTotalUniforca       = totalBloco.QuantidadeTotalUniforca ,
                            QuantidadeTotalAVJovensAcompanhados = totalBloco.QuantidadeTotalAVJovensAcompanhados,
                            QuantidadeTotalAVJovensSemAcompanhamento = totalBloco.QuantidadeTotalAVJovensSemAcompanhamento
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
        public RelatorioBlocoTotaisGeraisDTO RetornaRelatorioTotaisPorbloco(Bloco blocoParametro) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    var HQLQuery = string
                                      .Format("select rd " +
                                              "  from DashboardRelatorioBloco as rb " +
                                              " where rb.BlocoRelatorio.Id = {0} ", blocoParametro.Id.ToString());
                    var relatorio = session.CreateQuery(HQLQuery).UniqueResult<DashboardRelatorioBloco>();
                    return new RelatorioBlocoTotaisGeraisDTO { 
                        IdBloco                      = relatorio.BlocoRelatorio.Id,
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
                dao.ExecuteNonqueryProcedure("SGFJU_DEV.ATUALIZA_TOTAIS_DASHBOARD_BLOCO", parametros);
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "AtualizarDashboard", "CAMADA_ORM.Repository");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}
