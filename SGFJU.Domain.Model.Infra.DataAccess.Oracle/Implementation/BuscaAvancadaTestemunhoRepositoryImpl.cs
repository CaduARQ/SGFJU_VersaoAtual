using MySql.Data.MySqlClient;

using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Infra.Security;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class BuscaAvancadaTestemunhoRepositoryImpl : RepositoryImpl<Jovem>, BuscaAvancadaTestemunhoRepository {
        public IList<RetornoBuscaAvancadaDTO> BuscaAvancadaTestemunhoPorParametro(BuscaAvancadaParametroDTO parametrosBuscaAvancada) {
			try {
                var retorno = new List<RetornoBuscaAvancadaDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                var SQL_FULL_TEXT = new StringBuilder();
                var SQLOrderBy = " ORDER BY JV.NOME ASC";
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                          ");
                SQLQuery.Append("         JV.NOME,                              ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                   ");
                SQLQuery.Append("         ED.NOMEESTADO,                        ");
                SQLQuery.Append("         BL.NOMEBLOCO,                         ");
                SQLQuery.Append("         REG.NOMEREGIAO,                       ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                       ");
                SQLQuery.Append("         CT.WHATSAPP,                          ");
                SQLQuery.Append("         TES.ID_TESTEMUNHO,                    ");
                SQLQuery.Append("         TES.TEXTOTESTEMUNHO                   ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_JOVEM JV      ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CONTATO CT   ");
                SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO    ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ   ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA     ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG   ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO    ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL    ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO        ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED    ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_TESTEMUNHO TES    ");
                SQLQuery.Append("		   ON JV.ID_JOVEM = TES.ID_JOVEM ");
                //SQLQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_SITUACAO_IURD_FJU SIT ");
                //SQLQuery.Append("           ON JV.ID_SITUACAO_IURD_FJU = SIT.ID_SITUACAO_IURD_FJU ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append("   WHERE 1 = 1 ");

                if (parametrosBuscaAvancada.IdEstado != 0) {
                    SQLWhere.Append(" AND ED.ID_ESTADO = " + parametrosBuscaAvancada.IdEstado);
                }

                if (parametrosBuscaAvancada.IdBloco != 0) {
                    SQLWhere.Append(" AND BL.ID_BLOCO = " + parametrosBuscaAvancada.IdBloco);
                }

                if (parametrosBuscaAvancada.IdRegiao != 0) {
                    SQLWhere.Append(" AND REG.ID_REGIAO = " + parametrosBuscaAvancada.IdRegiao);
                }

                if (parametrosBuscaAvancada.IdIgreja != 0) {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + parametrosBuscaAvancada.IdIgreja);
                }

                SQL_FULL_TEXT.Append(" AND MATCH ( TES.TEXTOTESTEMUNHO )");
                SQL_FULL_TEXT.Append($"  AGAINST ('{parametrosBuscaAvancada.PalavrasChaveConcatenadasPesquisa}') ");

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() + SQL_FULL_TEXT.ToString() + SQLOrderBy, ref conexao)) {                        
                        while (resultadoReader.Read()) {
                            retorno.Add(new RetornoBuscaAvancadaDTO {
                                IdX = EncryptionHelper.Encrypt(resultadoReader["ID_JOVEM"].ToString()),
                                Nome = tinfo.ToTitleCase(resultadoReader["Nome"].ToString()),
                                NomeEstado = tinfo.ToTitleCase(resultadoReader["NOMEESTADO"].ToString()),
                                NomeBloco = tinfo.ToTitleCase(resultadoReader["NOMEBLOCO"].ToString()),
                                NomeRegiao = tinfo.ToTitleCase(resultadoReader["NOMEREGIAO"].ToString()),
                                NomeIgreja = tinfo.ToTitleCase(resultadoReader["NOMEIGREJA"].ToString()),
                                IdTestemunho = int.Parse(resultadoReader["ID_TESTEMUNHO"].ToString()),
                                TextoTestemunho = resultadoReader["TEXTOTESTEMUNHO"].ToString()
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
    }
}
