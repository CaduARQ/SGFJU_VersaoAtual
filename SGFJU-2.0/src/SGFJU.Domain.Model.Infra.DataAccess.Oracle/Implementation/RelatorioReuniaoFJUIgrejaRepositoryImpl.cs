using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
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
                            /**/
                            QuantidadeJovens = relatorioASeremProcessados.QuantidadeJovens,
                            QuantidadeBatizadosAguas = relatorioASeremProcessados.QuantidadeBatizadosAguas,
                            QuantidadeBatizadosEspiritoSanto = relatorioASeremProcessados.QuantidadeBatizadosEspiritoSanto,
                            QuantidadeAlgoAMais = relatorioASeremProcessados.QuantidadeAlgoAMais,
                            QuantidadeJovensLevantadosObra = relatorioASeremProcessados.QuantidadeJovensLevantadosObra,
                            QuantidadeObreirasCasaramPastor = relatorioASeremProcessados.QuantidadeObreirasCasaramPastor,
                            QuantidadeJovensIndicadosCPO = relatorioASeremProcessados.QuantidadeJovensIndicadosCPO,
                            QuantidadeObreiros = relatorioASeremProcessados.QuantidadeObreiros,
                            QuantidadeSaidaObreirosFJU = relatorioASeremProcessados.QuantidadeSaidaObreirosFJU,
                            QuantidadeJovensCadastradosNovos = relatorioASeremProcessados.QuantidadeJovensCadastradosNovos,
                            /**/
                            DataRegistroRelatorio = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                            DataInicialPeriodoRelatorio = DateTime.Parse(relatorioASeremProcessados.DataInicialPeriodoRelatorio),
                            DataFinalPeriodoRelatorio = DateTime.Parse(relatorioASeremProcessados.DataFinalPeriodoRelatorio),
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
                                     $"   SET QUANTIDADEJOVENS = {relatorioASerAtualizado.QuantidadeJovens}, " +
                                     $" QuantidadeBatizadosAguas = {relatorioASerAtualizado.QuantidadeBatizadosAguas}, " +
                                     $" QuantidadeBatizadosEspiritoSanto = {relatorioASerAtualizado.QuantidadeBatizadosEspiritoSanto}, " +
                                     $" QuantidadeAlgoAMais = {relatorioASerAtualizado.QuantidadeAlgoAMais}," +
                                     $" QuantidadeJovensLevantadosObra = {relatorioASerAtualizado.QuantidadeJovensLevantadosObra}," +
                                     $" QuantidadeObreirasCasaramPastor = {relatorioASerAtualizado.QuantidadeObreirasCasaramPastor}," +
                                     $" QuantidadeJovensIndicadosCPO = {relatorioASerAtualizado.QuantidadeJovensIndicadosCPO}," +
                                     $" QuantidadeObreiros = {relatorioASerAtualizado.QuantidadeObreiros}," +
                                     $" QuantidadeSaidaObreirosFJU = {relatorioASerAtualizado.QuantidadeSaidaObreirosFJU}," +
                                     $" QuantidadeJovensCadastradosNovos = {relatorioASerAtualizado.QuantidadeJovensCadastradosNovos}" +
                                     $" WHERE ID_RELATORIO_FJU_IGREJA = {relatorioASerAtualizado.IdRelatorioReuniaoFJUIgreja} ;";
                comandosDeProcessamentoRelatorio.Add(SQLCommandTemplate);
                _DAO.ExecuteNonQuery(conexao, comandosDeProcessamentoRelatorio);
            }
            return new RespostaProcessamentoRelatorioDTO { SolicitacaoBemSucedida = true };
        }
        public RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgrejas(IList<RelatorioReuniaoFJUIgrejaDTO> relatoriosASeremProcessados) {
            try {
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
                                /**/
                                QuantidadeJovensLevantadosObra = relatorio.QuantidadeJovensLevantadosObra,
                                QuantidadeObreirasCasaramPastor = relatorio.QuantidadeObreirasCasaramPastor,
                                QuantidadeJovensIndicadosCPO = relatorio.QuantidadeJovensIndicadosCPO,
                                QuantidadeObreiros = relatorio.QuantidadeObreiros,
                                QuantidadeSaidaObreirosFJU = relatorio.QuantidadeSaidaObreirosFJU,
                                QuantidadeJovensCadastradosNovos = relatorio.QuantidadeJovensCadastradosNovos,
                                /**/
                                DataRegistroRelatorio = DateTime.Now,
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

        public RespostaProcessamentoFechamentoRelatorioEstadoDTO ProcessarFechamentoRelatorioEstado(FechamentoRelatorioEstadoDTO parametroFechamentoRelatorio) {
            try {
                var dao = new DAO();
                var parametros = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("pID_ESTADO", parametroFechamentoRelatorio.IdEstadoFechamentoRelatorio.ToString()) ,
                    new KeyValuePair<string, string>("pDataIniclalRelatorios", formataDataCulturaEnUS(parametroFechamentoRelatorio.DataInicialRelatorioFJU)),
                    new KeyValuePair<string, string>("pDataFinalRelatorios", formataDataCulturaEnUS(parametroFechamentoRelatorio.DataFinalRelatorioFJU))
                };
                dao.ExecuteNonqueryProcedure("SGFJU_DEV.PROCESSA_FECHAMENTO_RELATORIO_ESTADO", parametros);

                return new RespostaProcessamentoFechamentoRelatorioEstadoDTO { SolicitacaoBemSucedida = true };
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public RespostaProcessamentoFechamentoRelatorioBlocoDTO ProcessarFechamentoRelatorioBloco(ProcessaFechamentoRelatorioBlocoDTO parametroFechamentoRelatorioBloco) {
            try {
                var dao = new DAO();
                var parametros = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("pID_BLOCO", parametroFechamentoRelatorioBloco.IdBlocoFechamentoRelatorio.ToString()) ,
                    new KeyValuePair<string, string>("pDataIniclalPeriodoRelatorio", formataDataCulturaEnUS(parametroFechamentoRelatorioBloco.DataInicialRelatorioFJU)),
                    new KeyValuePair<string, string>("pDataFinalPeriodoRelatorio", formataDataCulturaEnUS(parametroFechamentoRelatorioBloco.DataFinalRelatorioFJU))
                };
                dao.ExecuteNonqueryProcedure("SGFJU_DEV.PROCESSA_FECHAMENTO_RELATORIO_BLOCO", parametros);

                return new RespostaProcessamentoFechamentoRelatorioBlocoDTO { SolicitacaoBemSucedida = true };
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
                DateTime a;
                DateTime b;

                (new ErrorLoggerImpl(@"C:\inetpub\wwwroot\SGFJU2.0\LogWebApp\ErrorApp.txt")).WriteLog($"chegando no método=> DataIni:{parametrosPesquisa.DataInicial} e DataFin: {parametrosPesquisa.DataFinal}");

                var elementosDataInicial = parametrosPesquisa.DataInicial.Split('/');
                var elementosDataFinal = parametrosPesquisa.DataFinal.Split('/');

                var aaaI = DateTime.TryParseExact(parametrosPesquisa.DataInicial, "MM/dd/yyyy", null, DateTimeStyles.None, out a);
                var aaaF = DateTime.TryParseExact(parametrosPesquisa.DataFinal, "MM/dd/yyyy", null, DateTimeStyles.None, out b);

                (new ErrorLoggerImpl(@"C:\inetpub\wwwroot\SGFJU2.0\LogWebApp\ErrorApp.txt"))
                    .WriteLog($"após TryParseExact=> variável a:{a.ToString("MM/dd/yyyy")} e variável b: {b.ToString("MM/dd/yyyy")}");

                var vDataInicial = a.ToString("MM/dd/yyyy");
                var vDataFinal = b.ToString("MM/dd/yyyy");

                var dia = elementosDataInicial[0];
                var mes = elementosDataInicial[1];
                var ano = elementosDataInicial[2];
                var dataInicialFormatada = $"{ano}-{mes}-{dia}";

                var dia1 = elementosDataFinal[0];
                var mes1 = elementosDataFinal[1];
                var ano1 = elementosDataFinal[2];
                var dataFinalFormatada = $"{ano1}-{mes1}-{dia1}";

                (new ErrorLoggerImpl(@"C:\inetpub\wwwroot\SGFJU2.0\LogWebApp\ErrorApp.txt"))
                    .WriteLog($"após formatações DataIni:{dataInicialFormatada} e DFinal: {dataFinalFormatada}");

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
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEBATIZADOSAGUAS, 0) AS 'QUANTIDADEBATIZADOSAGUAS',   ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEBATIZADOSESPIRITOSANTO, 0) AS 'QUANTIDADEBATIZADOSESPIRITOSANTO',   ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEALGOAMAIS, 0) AS 'QUANTIDADEALGOAMAIS',             ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENSLEVANTADOSOBRA, 0) AS 'QUANTIDADEJOVENSLEVANTADOSOBRA',     ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEOBREIRASCASARAMPASTOR, 0) AS 'QUANTIDADEOBREIRASCASARAMPASTOR',   ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENSINDICADOSCPO, 0) AS 'QUANTIDADEJOVENSINDICADOSCPO',         ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEOBREIROS, 0) AS 'QUANTIDADEOBREIROS',                             ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADESAIDAOBREIROSFJU, 0) AS 'QUANTIDADESAIDAOBREIROSFJU',             ");
                SQLQuery.Append("       IFNULL(RJALANCA.QUANTIDADEJOVENSCADASTRADOSNOVOS, 0) AS 'QUANTIDADEJOVENSCADASTRADOSNOVOS', ");
                SQLQuery.Append("       RJALANCA.DATAREGISTRORELATORIO,                                                             ");
                SQLQuery.Append("       RJALANCA.DATAINICIALPERIODORELATORIO,                                         ");
                SQLQuery.Append("       RJALANCA.DATAFINALPERIODORELATORIO,                                           ");
                SQLQuery.Append("       RJALANCA.HORARIORELATORIO,                                                    ");
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
                SQLQuery.Append("                     RRFJU.QUANTIDADEBATIZADOSAGUAS,                                 ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEBATIZADOSESPIRITOSANTO,                         ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEALGOAMAIS,                                      ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEJOVENSLEVANTADOSOBRA,                           ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEOBREIRASCASARAMPASTOR,                          ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEJOVENSINDICADOSCPO,                             ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEOBREIROS,                                       ");
                SQLQuery.Append("                     RRFJU.QUANTIDADESAIDAOBREIROSFJU,                               ");
                SQLQuery.Append("                     RRFJU.QUANTIDADEJOVENSCADASTRADOSNOVOS,                         ");
                SQLQuery.Append("                     RRFJU.DATAREGISTRORELATORIO,                                    ");
                SQLQuery.Append("                     RRFJU.DATAINICIALPERIODORELATORIO,                              ");
                SQLQuery.Append("                     RRFJU.DATAFINALPERIODORELATORIO,                                ");
                SQLQuery.Append("                     RRFJU.HORARIORELATORIO                                          ");
                SQLQuery.Append("                FROM SGFJU_DEV.SGFJU_TBL_RELATORIO_REUNIAO_FJU_IGREJA RRFJU          ");
                SQLQuery.Append($"               WHERE DATE(RRFJU.DataInicialPeriodoRelatorio) = '{dataInicialFormatada}' AND DATE(RRFJU.DataFinalPeriodoRelatorio) = '{dataFinalFormatada}') RJALANCA ");
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
                 
                (new ErrorLoggerImpl(@"C:\inetpub\wwwroot\SGFJU2.0\LogWebApp\ErrorApp.txt")).WriteLog(SQLQuery.ToString() + SQLWhere.ToString() + SQLOrderBy);

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
                                QuantidadeAlgoAMais = int.Parse(resultadoReader["QUANTIDADEALGOAMAIS"].ToString()),
                                QuantidadeJovensLevantadosObra = int.Parse(resultadoReader["QUANTIDADEJOVENSLEVANTADOSOBRA"].ToString()),
                                QuantidadeObreirasCasaramPastor = int.Parse(resultadoReader["QUANTIDADEOBREIRASCASARAMPASTOR"].ToString()),
                                QuantidadeJovensIndicadosCPO = int.Parse(resultadoReader["QUANTIDADEJOVENSINDICADOSCPO"].ToString()),
                                QuantidadeObreiros = int.Parse(resultadoReader["QUANTIDADEOBREIROS"].ToString()),
                                QuantidadeSaidaObreirosFJU = int.Parse(resultadoReader["QUANTIDADESAIDAOBREIROSFJU"].ToString()),
                                QuantidadeJovensCadastradosNovos = int.Parse(resultadoReader["QUANTIDADEJOVENSCADASTRADOSNOVOS"].ToString()),
                                DataRegistroRelatorio = resultadoReader["DATAREGISTRORELATORIO"].ToString(),
                                DataInicialPeriodoRelatorio = resultadoReader["DATAINICIALPERIODORELATORIO"].ToString(),
                                DataFinalPeriodoRelatorio = resultadoReader["DATAFINALPERIODORELATORIO"].ToString(),
                                HorarioRelatorio = resultadoReader["HORARIORELATORIO"].ToString()
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
                               $" AND ( DATE(DATAREGISTRORELATORIO) = '{vDataInicial}' AND DATE(DATAREGISTRORELATORIO) = '{vDataFinal}' ) ";

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
        public bool RelatorioNoPeriodoJaEstaProcessado(ParametroPesquisaRelatorioIgrejasPeriodo parametrosVerificacao) {
            try {
                var retornoConsultaGeral = new List<JovemAutorizacaoCamisaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var vDataInicial = formataDataCulturaEnUS(parametrosVerificacao.DataInicial);
                var vDataFinal = formataDataCulturaEnUS(parametrosVerificacao.DataFinal);
                var SQLQuery = $"SELECT COUNT(*) as 'EstaConsolidado' FROM SGFJU_DEV.#NOME_TABELA# WHERE 1=1 " +
                               $" AND ( DATE(DataInicialPeriodoRelatorio) = '{vDataInicial}' AND DATE(DataFinalPeriodoRelatorio) = '{vDataFinal}' ) ";

                if (parametrosVerificacao.IdEstado != 0) {
                    SQLQuery = SQLQuery.Replace("#NOME_TABELA#", "SGFJU_TBL_RELATORIO_CONSOLIDADO_ESTADO");
                    SQLQuery += $" AND ID_ESTADO = {parametrosVerificacao.IdEstado} ";
                }

                if (parametrosVerificacao.IdBloco != 0) {
                    SQLQuery = SQLQuery.Replace("#NOME_TABELA#", "SGFJU_TBL_RELATORIO_CONSOLIDADO_BLOCO");
                    SQLQuery += $" AND ID_BLOCO = {parametrosVerificacao.IdBloco}";
                }

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery, ref conexao)) {
                        while (resultadoReader.Read()) {
                            var vEstaConsolidado = int.Parse(resultadoReader["EstaConsolidado"].ToString());
                            if (vEstaConsolidado > 0)
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
        public RelatorioConsolidadoEstadualSemanal RetornaRelatorioConsolidadoEstadoPorPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo parametros) {
            try {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                RelatorioConsolidadoEstadualSemanal
                                retorno = null; 
                var vDataInicial = formataDataCulturaEnUS(parametros.DataInicial);
                var vDataFinal = formataDataCulturaEnUS(parametros.DataFinal);
                var SQLQueryE = $"SELECT CE.*, E.NOMEESTADO FROM SGFJU_DEV.SGFJU_TBL_RELATORIO_CONSOLIDADO_ESTADO CE INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO E ON CE.ID_ESTADO =  E.ID_ESTADO  WHERE 1=1 " +
                               $" AND ( DATE(DATAINICIALPERIODORELATORIO) = '{vDataInicial}' AND DATE(DATAFINALPERIODORELATORIO) = '{vDataFinal}' ) ";
                var SQLQueryB = $"SELECT CB.*, B.NOMEBLOCO FROM SGFJU_DEV.SGFJU_TBL_RELATORIO_CONSOLIDADO_BLOCO CB INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO B ON CB.ID_BLOCO =  B.ID_BLOCO WHERE 1=1 " +
                               $" AND ( DATE(DATAINICIALPERIODORELATORIO) = '{vDataInicial}' AND DATE(DATAFINALPERIODORELATORIO) = '{vDataFinal}' ) ";

                if (parametros.IdEstado != 0) {
                    SQLQueryE += $" AND CE.ID_ESTADO = {parametros.IdEstado} ";
                }

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();

                    using (resultadoReader = _DAO.ExecuteQuery(SQLQueryE, ref conexao)) {
                        while (resultadoReader.Read()) {
                            retorno = new RelatorioConsolidadoEstadualSemanal {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                IdRelatorioConsolidadoEstadoFJU = int.Parse(resultadoReader["ID_RELATORIOCONSOLIDADO_ESTADO_FJU"].ToString()),
                                QuantidadeJovens = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENS"].ToString()),
                                QuantidadeBatizadosAguas = int.Parse(resultadoReader["TOTALQUANTIDADEBATIZADOSAGUAS"].ToString()),
                                QuantidadeBatizadosEspiritoSanto = int.Parse(resultadoReader["TOTALQUANTIDADEBATIZADOSESPIRITOSANTO"].ToString()),
                                QuantidadeAlgoAMais = int.Parse(resultadoReader["TOTALQUANTIDADEALGOAMAIS"].ToString()),
                                QuantidadeJovensLevantadosObra = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENSLEVANTADOSOBRA"].ToString()),
                                QuantidadeObreirasCasaramPastor = int.Parse(resultadoReader["TOTALQUANTIDADEOBREIRASCASARAMPASTOR"].ToString()),
                                QuantidadeJovensIndicadosCPO = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENSINDICADOSCPO"].ToString()),
                                QuantidadeObreiros = int.Parse(resultadoReader["TOTALQUANTIDADEOBREIROS"].ToString()),
                                QuantidadeSaidaObreirosFJU = int.Parse(resultadoReader["TOTALQUANTIDADESAIDAOBREIROSFJU"].ToString()),
                                QuantidadeJovensCadastradosNovos = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENSCADASTRADOSNOVOS"].ToString()),
                                DataConsolidacaoRelatorio = resultadoReader["DataConsolidacaoRelatorio"].ToString(),
                                DataInicialPeriodoRelatorio = resultadoReader["DATAINICIALPERIODORELATORIO"].ToString(),
                                DataFinalPeriodoRelatorio = resultadoReader["DATAFINALPERIODORELATORIO"].ToString(),
                                HorarioRelatorioConsolidado = resultadoReader["HORARIORELATORIOCONSOLIDADO"].ToString()
                            };
                        }
                    }

                    using (resultadoReader = _DAO.ExecuteQuery(SQLQueryB, ref conexao)) {
                        while (resultadoReader.Read()) {
                            retorno.RelatorioConsolidadoBlocos.Add( new RelatorioConsolidadoBlocoSemanal {
                                IdBloco = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                IdRelatorioConsolidadoBlocoFJU = int.Parse(resultadoReader["ID_RELATORIOCONSOLIDADO_BLOCO_FJU"].ToString()),
                                QuantidadeJovens = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENS"].ToString()),
                                QuantidadeBatizadosAguas = int.Parse(resultadoReader["TOTALQUANTIDADEBATIZADOSAGUAS"].ToString()),
                                QuantidadeBatizadosEspiritoSanto = int.Parse(resultadoReader["TOTALQUANTIDADEBATIZADOSESPIRITOSANTO"].ToString()),
                                QuantidadeAlgoAMais = int.Parse(resultadoReader["TOTALQUANTIDADEALGOAMAIS"].ToString()),
                                QuantidadeJovensLevantadosObra = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENSLEVANTADOSOBRA"].ToString()),
                                QuantidadeObreirasCasaramPastor = int.Parse(resultadoReader["TOTALQUANTIDADEOBREIRASCASARAMPASTOR"].ToString()),
                                QuantidadeJovensIndicadosCPO = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENSINDICADOSCPO"].ToString()),
                                QuantidadeObreiros = int.Parse(resultadoReader["TOTALQUANTIDADEOBREIROS"].ToString()),
                                QuantidadeSaidaObreirosFJU = int.Parse(resultadoReader["TOTALQUANTIDADESAIDAOBREIROSFJU"].ToString()),
                                QuantidadeJovensCadastradosNovos = int.Parse(resultadoReader["TOTALQUANTIDADEJOVENSCADASTRADOSNOVOS"].ToString()),
                                DataConsolidacaoRelatorio = resultadoReader["DataConsolidacaoRelatorio"].ToString(),
                                DataInicialPeriodoRelatorio = resultadoReader["DATAINICIALPERIODORELATORIO"].ToString(),
                                DataFinalPeriodoRelatorio = resultadoReader["DATAFINALPERIODORELATORIO"].ToString(),
                                HorarioRelatorioConsolidado = resultadoReader["HORARIORELATORIOCONSOLIDADO"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        /// <summary>
        /// método abaixo é solução temporária
        /// </summary>
        /// <returns></returns>
        public string formataDataCulturaEnUS(string dataParametro) {
            var elementosDataParametro = dataParametro.Split('/');
            var dia = elementosDataParametro[0];
            var mes = elementosDataParametro[1];
            var ano = elementosDataParametro[2];
            var vDataFormatadaRetorno = $"{ano}-{mes}-{dia}";

            return vDataFormatadaRetorno;
        }
    }
}
