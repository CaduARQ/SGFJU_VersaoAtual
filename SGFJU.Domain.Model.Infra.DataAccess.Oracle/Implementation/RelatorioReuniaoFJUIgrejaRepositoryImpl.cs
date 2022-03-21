using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class RelatorioReuniaoFJUIgrejaRepositoryImpl : RepositoryImpl<RelatorioReuniaoFJUIgreja>, RelatorioReuniaoFJUIgrejaRepository {
        public RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgreja(RelatorioReuniaoFJUIgrejaDTO relatorioASeremProcessados) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    using (var transaction = session.BeginTransaction()) {
                        var horario = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
                        session.Save(new RelatorioReuniaoFJUIgreja
                        {
                            IgrejaRelatorio = new Igreja { Id = relatorioASeremProcessados.IdIgrejaRelatorio },
                            ReuniaoFJURelatorio = new ValueObjects.ReuniaoFJU { Code = relatorioASeremProcessados.IdReuniaoFJURelatorio },
                            QuantidadeJovens = relatorioASeremProcessados.QuantidadeJovens,
                            DataRelatorio = DateTime.Now,
                            HorarioRelatorio = horario
                        });
                        transaction.Commit();
                    }
                }

                return new RespostaProcessamentoRelatorioDTO { SolicitacaoBemSucedida = true };
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public RespostaProcessamentoRelatorioDTO AtualizaRelatorioPeriodo(RelatorioReuniaoFJUIgrejaDTO relatorioASerAtualizado) { 
            var _DAO = new DAO();
            var comandosDeProcessamentoRelatorio = new List<string>();
            MySqlConnection conexao = null;
            var SQLQuery = new StringBuilder();
            var SQLCommandTemplate = "";

            using (conexao = _DAO.GetConnection()) {
                conexao.Open();

                SQLCommandTemplate = " UPDATE SGFJU_DEV.SGFJU_TBL_RELATORIO_REUNIAO_FJU_IGREJA " +
                                        $"   SET QUANTIDADEJOVENS = {relatorioASerAtualizado.QuantidadeJovens} " +
                                        $" WHERE ID_IGREJA = {relatorioASerAtualizado.IdIgrejaRelatorio} " +
                                        $"   AND DATARELATORIO '{DateTime.Parse(relatorioASerAtualizado.DataRelatorio).ToString("yyyy-MM-dd")}' ;";
                comandosDeProcessamentoRelatorio.Add(SQLCommandTemplate);
                _DAO.ExecuteNonQuery(conexao, comandosDeProcessamentoRelatorio);
            }
            return new RespostaProcessamentoRelatorioDTO { SolicitacaoBemSucedida = true };
        }
        public RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgrejas(IList<RelatorioReuniaoFJUIgrejaDTO> relatoriosASeremProcessados) {
            try {
                /*
                var _DAO = new DAO();
                var comandosDeProcessamentoRelatorio = new List<string>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                var SQLCommandTemplate = "";

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    foreach (var relatorio in relatoriosASeremProcessados) {
                        var horario = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
                        SQLCommandTemplate = "INSERT INTO SGFJU_DEV.SGFJU_TBL_RELATORIO_REUNIAO_FJU_IGREJA " +
                                             $"VALUES ({relatorio.IdIgrejaRelatorio}, {relatorio.IdReuniaoFJURelatorio}, {relatorio.QuantidadeJovens}, '{DateTime.Now.ToString("yyyy-MM-dd")}', '{horario}'); ";
                        comandosDeProcessamentoRelatorio.Add(SQLCommandTemplate);
                    }
                    _DAO.ExecuteNonQuery(conexao, comandosDeProcessamentoRelatorio);
                }*/
                using (var session = __sessionFactory.OpenSession()) {
                    using (var transaction = session.BeginTransaction()) {
                        foreach (var relatorio in relatoriosASeremProcessados) {
                            var horario = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
                            session.Save(new RelatorioReuniaoFJUIgreja {
                                IgrejaRelatorio = new Igreja { Id = relatorio.IdIgrejaRelatorio },
                                ReuniaoFJURelatorio = new ValueObjects.ReuniaoFJU { Code = relatorio.IdReuniaoFJURelatorio },
                                QuantidadeJovens = relatorio.QuantidadeJovens,
                                QuantidadeBatizadosAguas = relatorio.QuantidadeBatizadosAguas,
                                QuantidadeBatizadosEspiritoSanto = relatorio.QuantidadeBatizadosEspiritoSanto,
                                QuantidadeAlgoAMais = relatorio.QuantidadeAlgoAMais,
                                DataRelatorio = DateTime.Now,
                                HorarioRelatorio = horario
                            });
                        }
                        transaction.Commit();
                    }
                }

                return new RespostaProcessamentoRelatorioDTO { SolicitacaoBemSucedida = true };
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public RespostaProcessamentoFechamentoRelatorioDTO ProcessarFechamentoRelatorioDTO(FechamentoRelatorioDTO parametroFechamentoRelatorio) {
            try {
                var dao = new DAO();
                var parametros = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("pID_ESTADO", parametroFechamentoRelatorio.IdEstadoFechamentoRelatorio.ToString()) ,
                    new KeyValuePair<string, string>("pID_REUNIAOFJU", parametroFechamentoRelatorio.IdReuniaoFechamentoRelatorio.ToString()),
                    new KeyValuePair<string, string>("pDataIniclalRelatorios", parametroFechamentoRelatorio.DataInicialRelatorioFJU),
                    new KeyValuePair<string, string>("pDataFinalRelatorios", parametroFechamentoRelatorio.DataFinalRelatorioFJU)
                };
                dao.ExecuteNonqueryProcedure("SGFJU_DEV.PROCESSA_FECHAMENTO_RELATORIO_ESTADO", parametros);

                return new RespostaProcessamentoFechamentoRelatorioDTO { SolicitacaoBemSucedida = true };
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

         public IList<RelatorioReuniaoFJUIgrejaDTO> ListaRelatorioIgrejasEstadoPorPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo parametrosPesquisa) {
            try {
                var retornoConsultaGeral = new List<RelatorioReuniaoFJUIgrejaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                var SQLWhere = new StringBuilder();
                var SQLOrderBy = " ORDER BY QUANTIDADEJOVENS";
                SQLWhere.Append(" WHERE 1 = 1 ");
                var vDataInicial = DateTime.Parse(parametrosPesquisa.DataInicial).ToString("yyyy-MM-dd");
                var vDataFinal = DateTime.Parse(parametrosPesquisa.DataFinal).ToString("yyyy-MM-dd");

                SQLQuery.Append("SELECT ED.ID_ESTADO,                                                                 ");
                SQLQuery.Append("       ED.NOMEESTADO,                                                                ");
                SQLQuery.Append("       BL.ID_BLOCO,                                                                  ");
                SQLQuery.Append("       BL.NOMEBLOCO,                                                                 ");
                SQLQuery.Append("       REG.ID_REGIAO,                                                                ");
                SQLQuery.Append("       REG.NOMEREGIAO,                                                               ");
                SQLQuery.Append("       IGJ.ID_IGREJA,                                                                ");
                SQLQuery.Append("       IGJ.NOMEIGREJA,                                                               ");
                SQLQuery.Append("       IFNULL(RJALANCA.ID_RELATORIO_FJU_IGREJA, 0) AS 'ID_RELATORIO_FJU_IGREJA',     ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENS, 0) AS 'QUANTIDADEJOVENS',                   ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENS, 0) AS 'QUANTIDADEBATIZADOSAGUAS',           ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENS, 0) AS 'QUANTIDADEBATIZADOSESPIRITOSANTO',   ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENS, 0) AS 'QUANTIDADEALGOAMAIS',                ");
                SQLQuery.Append("       RJALANCA.DATARELATORIO,                                                       ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENS, 'NAOLANCADO') AS 'JA_LANCADO_OU_NAO'        ");
                SQLQuery.Append("  FROM      SGFJU_DEV.SGFJU_TBL_IGREJA IGJ                                           ");
                SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO REG                                           ");
                SQLQuery.Append("         ON IGJ.ID_REGIAO = REG.ID_REGIAO                                            ");
                SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO  BL                                            ");
                SQLQuery.Append("         ON REG.ID_BLOCO = BL.ID_BLOCO                                               ");
                SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO ED                                            ");
                SQLQuery.Append("         ON BL.ID_ESTADO = ED.ID_ESTADO                                              ");
                SQLQuery.Append("  LEFT JOIN ( SELECT RRFJU.ID_IGREJA,                                                ");
                SQLQuery.Append("                     RRFJU.ID_RELATORIO_FJU_IGREJA,                                  ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEJOVENS,                                         ");
                SQLQuery.Append("                     RRFJU.DATARELATORIO                                             ");
                SQLQuery.Append("                FROM SGFJU_DEV.SGFJU_TBL_RELATORIO_REUNIAO_FJU_IGREJA RRFJU          ");
                SQLQuery.Append($"               WHERE DATE(RRFJU.DATARELATORIO) BETWEEN '{vDataInicial}' AND '{vDataFinal}') RJALANCA ");
                SQLQuery.Append("         ON IGJ.ID_IGREJA = RJALANCA.ID_IGREJA ");

                if (parametrosPesquisa.IdEstado != 0) {
                    SQLWhere.Append($" AND ED.ID_ESTADO = {parametrosPesquisa.IdEstado} ");
                }

                if (parametrosPesquisa.IdBloco != 0) {
                    SQLWhere.Append(" AND BL.ID_BLOCO = " + parametrosPesquisa.IdBloco.ToString() + " ");
                }

                if (parametrosPesquisa.IdRegiao != 0) {
                    SQLWhere.Append(" AND REG.ID_REGIAO = " + parametrosPesquisa.IdRegiao.ToString() + " ");
                }

                if (parametrosPesquisa.IdIgreja != 0) {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + parametrosPesquisa.IdIgreja.ToString() + " ");
                }

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + SQLOrderBy, ref conexao))
                    {
                        while (resultadoReader.Read())
                        {
                            retornoConsultaGeral.Add(new RelatorioReuniaoFJUIgrejaDTO
                            {
                                IdRelatorioReuniaoFJUIgreja = int.Parse(resultadoReader["ID_RELATORIO_FJU_IGREJA"].ToString()),
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                IdBloco = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiao = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                IdIgrejaRelatorio = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                QuantidadeJovens = int.Parse(resultadoReader["QUANTIDADEJOVENS"].ToString()),
                                QuantidadeBatizadosAguas = int.Parse(resultadoReader["QUANTIDADEBATIZADOSAGUAS"].ToString()),
                                QuantidadeBatizadosEspiritoSanto = int.Parse(resultadoReader["QUANTIDADEBATIZADOSESPIRITOSANTO"].ToString()),
                                QuantidadeAlgoAMais = int.Parse(resultadoReader["QUANTIDADEALGOAMAIS"].ToString())
                            });
                        }
                    }
                }

                return retornoConsultaGeral;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public bool RelatorioDaIgrejaJaLancadoNoPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo periodoEmQuestao) { 
            try {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var vDataInicial = DateTime.Parse(periodoEmQuestao.DataInicial).ToString("yyyy-MM-dd");
                var vDataFinal = DateTime.Parse(periodoEmQuestao.DataFinal).ToString("yyyy-MM-dd");
                var SQLQuery = $"SELECT COUNT(*) AS QTDSOLICITACOESCAMISA FROM SGFJU_DEV.SGFJU_TBL_RELATORIO_REUNIAO_FJU_IGREJA WHERE ID_IGREJA = {periodoEmQuestao.IdIgreja} " +
                               $" AND ( DATE(DATARELATORIO) BETWEEN '{vDataInicial}' AND '{vDataFinal}' ) ";

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery, ref conexao)) {
                        while (resultadoReader.Read()) {
                            var qtdSolicitacoes = int.Parse(resultadoReader["QTDSOLICITACOESCAMISA"].ToString());
                            if (qtdSolicitacoes > 0)
                                return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}
