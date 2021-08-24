using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class CoordenadorRepositoryImpl : RepositoryImpl<IgrejaCoordenador>, CoordenadorRepository
    {
        public IList<IgrejaCoordenadorDTO> PesquisarCoordenadorPorParametro(IgrejaCoordenadorParametroDTO parametroPesquisaCoordenador) {
            try {
                var retorno = new List<IgrejaCoordenadorDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         JV.DATANASCIMENTO,                                       ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                                      ");
                SQLQuery.Append("         JV.ID_TIPOESTADOCIVIL,                                   ");
                SQLQuery.Append("         JV.NOMECONJUGE,                                          ");
                SQLQuery.Append("         JV.CONJUGEEHOBREIRO,                                     ");
                SQLQuery.Append("         JV.POSSUIFILHOS,                                         ");
                SQLQuery.Append("         JV.QUANTIDADEFILHOS,                                     ");
                SQLQuery.Append("         JV.GOSTADEALGUEM,                                        ");
                SQLQuery.Append("         JV.NAMORAATUALMENTE,                                     ");
                SQLQuery.Append("         JV.NOMEPRETENDENTE,                                      ");
                SQLQuery.Append("         JV.EHPASTOR,                                             ");
                SQLQuery.Append("         ED.ID_ESTADO,                                            ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.ID_BLOCO,                                             ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.ID_REGIAO,                                           ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.ID_IGREJA,                                           ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                //SQLQuery.Append("         CT.WHATSAPP,                                             ");
                SQLQuery.Append("         SIFJ.EHOBREIRO,                                          ");
                SQLQuery.Append("         SIFJ.MESANOFOILEVANTADOOBREIRO,                          ");
                SQLQuery.Append("         SIFJ.DESEJAFAZEROBRANOALTAR,                             ");
                SQLQuery.Append("         SIFJ.FOIPASTOR,                                          ");
                SQLQuery.Append("         SIFJ.MOTIVOSAIDAPASTOR,                                  ");
                SQLQuery.Append("         SIFJ.MESANOSAIDAOBRA,                                    ");
                SQLQuery.Append("         IGJC.ID_IGREJA_COORDENADOR,                              ");
                SQLQuery.Append("         IGJC.TotalMesesCoordenandoFJU,                           ");
                SQLQuery.Append("         IGJC.TotalAnosCoordenandoFJU,                            ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAnterior,                   ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAtual,                      ");
                SQLQuery.Append("         IGJC.MesesCoordenandoIgrejaAtualFJU,                     ");
                SQLQuery.Append("         IGJC.AnosCoordenandoIgrejaAtualFJU,                      ");
                SQLQuery.Append("         IGJC.FoiEntrevistadoEstadualFJU,                         ");
                SQLQuery.Append("         IGJC.MesAnoEntrevistaEstadual,                           ");
                SQLQuery.Append("         IGJC.NomeEstadualEntrevistou,                            ");
                SQLQuery.Append("         IGJC.DataEntradaCoordenador,                             ");
                SQLQuery.Append("         IGJC.DataSaidaCoordenador,                               ");
                SQLQuery.Append("         IGJC.DataTrocaCoordenador,                               ");
                SQLQuery.Append("         IGJC.NomePastorEfetuouTroca,                             ");
                SQLQuery.Append("         IGJC.MotivoTrocaCoordenador,                             ");
                SQLQuery.Append("         IGJC.NomeNovoCoordenador                                 ");
                SQLQuery.Append("	FROM       sgfju_dev.SGFJU_TBL_JOVEM JV                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA_COORDENADOR IGJC         ");
                SQLQuery.Append("			ON JV.ID_JOVEM = IGJC.ID_JOVEM                         ");
                //SQLQuery.Append("	LEFT JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                //SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

                if (parametroPesquisaCoordenador.IdEstado != 0) {
                    SQLWhere.Append(" AND ED.ID_ESTADO = " + parametroPesquisaCoordenador.IdEstado.ToString() + " ");
                }

                if (parametroPesquisaCoordenador.IdBlocoJovem != 0) {
                    SQLWhere.Append(" AND BL.ID_BLOCO = " + parametroPesquisaCoordenador.IdBlocoJovem.ToString() + " ");
                }

                if (parametroPesquisaCoordenador.IdRegiaoJovem != 0) {
                    SQLWhere.Append(" AND REG.ID_REGIAO = " + parametroPesquisaCoordenador.IdRegiaoJovem.ToString() + " ");
                }

                if (parametroPesquisaCoordenador.IdIgreja != 0) {
                    SQLWhere.Append(" AND IGJ.ID_IGREJA = " + parametroPesquisaCoordenador.IdIgreja.ToString() + " ");
                }
                
                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new IgrejaCoordenadorDTO
                            {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = resultadoReader["NOMEBLOCO"].ToString(),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = resultadoReader["nomeregiao"].ToString(),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = resultadoReader["NOMEIGREJA"].ToString(),
                                NomeArquivoFotoFormatado = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("NOMEARQUIVOFOTO"))) ?
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + resultadoReader["NOMEARQUIVOFOTO"].ToString() :
                                                              ConfigurationManager.AppSettings["HOST_PROD"] + "UsuarioNaoSelecionado.png",

                                IdIgrejaCoordenador = int.Parse(resultadoReader["ID_IGREJA_COORDENADOR"].ToString()),

                                IdCoordenadorFJU = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                NomeCoordenador = resultadoReader["NOME"].ToString(),

                                NomeTipoCoordenador = (bool.Parse(resultadoReader["EHPASTOR"].ToString())) ? "Pastor" : "Obreiro",

                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),

                                IdEstadoCivil = (!string.IsNullOrEmpty(resultadoReader["ID_TIPOESTADOCIVIL"].ToString())) ?
                                                      int.Parse(resultadoReader["ID_TIPOESTADOCIVIL"].ToString()) : 0,

                                NomeConjuge = resultadoReader["NOMECONJUGE"].ToString(),

                                PossuiFilhos = (!string.IsNullOrEmpty(resultadoReader["POSSUIFILHOS"].ToString())) ?
                                                      char.Parse(resultadoReader["POSSUIFILHOS"].ToString()) : char.MinValue,

                                QuantidadeFilhos = (!string.IsNullOrEmpty(resultadoReader["QUANTIDADEFILHOS"].ToString())) ?
                                                      int.Parse(resultadoReader["QUANTIDADEFILHOS"].ToString()) : 0,

                                ConjugeEhObreiro = (!string.IsNullOrEmpty(resultadoReader["CONJUGEEHOBREIRO"].ToString())) ?
                                                      char.Parse(resultadoReader["CONJUGEEHOBREIRO"].ToString()) : char.MinValue,

                                MesAnoFoiLevantadoObreiro = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString(),

                                GostaDeAlguem = (!string.IsNullOrEmpty(resultadoReader["GOSTADEALGUEM"].ToString())) ?
                                                      char.Parse(resultadoReader["GOSTADEALGUEM"].ToString()) : char.MinValue,

                                NamoraAtualmente = (!string.IsNullOrEmpty(resultadoReader["NAMORAATUALMENTE"].ToString())) ?
                                                      char.Parse(resultadoReader["NAMORAATUALMENTE"].ToString()) : char.MinValue,

                                NomePretendente = resultadoReader["NOMEPRETENDENTE"].ToString(),

                                TotalAnosCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalAnosCoordenandoFJU"].ToString())) ?
                                                                    int.Parse(resultadoReader["TotalAnosCoordenandoFJU"].ToString()) : 0,
                                TotalMesesCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalMesesCoordenandoFJU"].ToString())) ?
                                                                    int.Parse(resultadoReader["TotalMesesCoordenandoFJU"].ToString()) : 0,

                                AnosCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                    int.Parse(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString()) : 0,

                                MesesCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                    int.Parse(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString()) : 0,


                                DataEntradaCoordenador = DateTime.Parse(resultadoReader["DataEntradaCoordenador"].ToString()).ToString("dd/MM/yyyy"),

                                QuantidadeJovensEncontroAnterior = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString())) ?
                                                                    int.Parse(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString()) : 0,
                                QuantidadeJovensEncontroAtual = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAtual"].ToString())) ?
                                                                    int.Parse(resultadoReader["QuantidadeJovensEncontroAtual"].ToString()) : 0,

                                MotivoSaidaPastor = resultadoReader["MOTIVOSAIDAPASTOR"].ToString(),

                                MotivoTrocaCoordenador = resultadoReader["MotivoTrocaCoordenador"].ToString(),

                                NomeNovoCoordenador = resultadoReader["NomeNovoCoordenador"].ToString(),

                                NomePastorEfetuouTroca = resultadoReader["NomePastorEfetuouTroca"].ToString(),

                                FoiEntrevistadoEstadualFJU = (!string.IsNullOrEmpty(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString())) ?
                                                                char.Parse(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString()) : char.MinValue,

                                NomeEstadualEntrevistou = resultadoReader["NomeEstadualEntrevistou"].ToString(),

                                MesAnoEntrevistaEstadual = resultadoReader["MesAnoEntrevistaEstadual"].ToString(),

                                DataSaidaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataSaidaCoordenador"].ToString())) ?
                                                                DateTime.Parse(resultadoReader["DataSaidaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

                                DataTrocaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataTrocaCoordenador"].ToString())) ?
                                                          DateTime.Parse(resultadoReader["DataTrocaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

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
        public IList<IgrejaCoordenadorDTO> ListarCoordenadoresPorEstado(EstadoDTO estadoParametro) {
            try {
                var retorno = new List<IgrejaCoordenadorDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         JV.DATANASCIMENTO,                                       ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                                      ");
                SQLQuery.Append("         JV.ID_TIPOESTADOCIVIL,                                   ");
                SQLQuery.Append("         JV.NOMECONJUGE,                                          ");
                SQLQuery.Append("         JV.CONJUGEEHOBREIRO,                                     ");
                SQLQuery.Append("         JV.POSSUIFILHOS,                                         ");
                SQLQuery.Append("         JV.QUANTIDADEFILHOS,                                     ");
                SQLQuery.Append("         JV.GOSTADEALGUEM,                                        ");
                SQLQuery.Append("         JV.NAMORAATUALMENTE,                                     ");
                SQLQuery.Append("         JV.NOMEPRETENDENTE,                                      ");
                SQLQuery.Append("         JV.EHPASTOR,                                             ");
                //SQLQuery.Append("         TEC.ID_TIPOESTADOCIVIL,                                  ");
                //SQLQuery.Append("         TEC.DESCRICAOTIPOESTADOCIVIL,                            ");
                SQLQuery.Append("         ED.ID_ESTADO,                                            ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.ID_BLOCO,                                             ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.ID_REGIAO,                                           ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.ID_IGREJA,                                           ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                //SQLQuery.Append("         CT.WHATSAPP,                                             ");
                SQLQuery.Append("         SIFJ.EHOBREIRO,                                          ");
                SQLQuery.Append("         SIFJ.MESANOFOILEVANTADOOBREIRO,                          ");
                SQLQuery.Append("         SIFJ.DESEJAFAZEROBRANOALTAR,                             ");
                SQLQuery.Append("         SIFJ.FOIPASTOR,                                          ");
                SQLQuery.Append("         SIFJ.MOTIVOSAIDAPASTOR,                                  ");
                SQLQuery.Append("         SIFJ.MESANOSAIDAOBRA,                                    ");
                SQLQuery.Append("         IGJC.ID_IGREJA_COORDENADOR,                              ");
                SQLQuery.Append("         IGJC.TotalMesesCoordenandoFJU,                           ");
                SQLQuery.Append("         IGJC.TotalAnosCoordenandoFJU,                            ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAnterior,                   ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAtual,                      ");
                SQLQuery.Append("         IGJC.MesesCoordenandoIgrejaAtualFJU,                     ");
                SQLQuery.Append("         IGJC.AnosCoordenandoIgrejaAtualFJU,                      ");
                SQLQuery.Append("         IGJC.FoiEntrevistadoEstadualFJU,                         ");
                SQLQuery.Append("         IGJC.MesAnoEntrevistaEstadual,                           ");
                SQLQuery.Append("         IGJC.NomeEstadualEntrevistou,                            ");
                SQLQuery.Append("         IGJC.DataEntradaCoordenador,                             ");
                SQLQuery.Append("         IGJC.DataSaidaCoordenador,                               ");
                SQLQuery.Append("         IGJC.DataTrocaCoordenador,                               ");
                SQLQuery.Append("         IGJC.NomePastorEfetuouTroca,                             ");
                SQLQuery.Append("         IGJC.MotivoTrocaCoordenador,                             ");
                SQLQuery.Append("         IGJC.NomeNovoCoordenador                                 ");
                SQLQuery.Append("	FROM       sgfju_dev.SGFJU_TBL_JOVEM JV                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA_COORDENADOR IGJC         ");
                SQLQuery.Append("			ON JV.ID_JOVEM = IGJC.ID_JOVEM                         ");
                //SQLQuery.Append("   INNER JOIN SGFJU_DEV.SGFJU_TBL_TIPOESTADOCIVIL TEC             ");
                //SQLQuery.Append("           ON JV.ID_TIPOESTADOCIVIL = TEC.ID_TIPOESTADOCIVIL      ");
                //SQLQuery.Append("	LEFT JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                //SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");                
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE IGJC.DATASAIDACOORDENADOR IS NULL AND ED.ID_ESTADO = " + estadoParametro.IdEstado);

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new IgrejaCoordenadorDTO
                            {
                                IdIgrejaCoordenador = int.Parse(resultadoReader["ID_IGREJA_COORDENADOR"].ToString()),
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = resultadoReader["NOMEBLOCO"].ToString(),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = resultadoReader["nomeregiao"].ToString(),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = resultadoReader["NOMEIGREJA"].ToString(),

                                IdCoordenadorFJU = int.Parse(resultadoReader["ID_JOVEM"].ToString()),

                                NomeCoordenador = resultadoReader["NOME"].ToString(),

                                NomeTipoCoordenador = (bool.Parse(resultadoReader["EHPASTOR"].ToString())) ? "Pastor" : "Obreiro",

                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                NomeConjuge = resultadoReader["NOMECONJUGE"].ToString(),

                                IdEstadoCivil = (!string.IsNullOrEmpty(resultadoReader["ID_TIPOESTADOCIVIL"].ToString())) ? int.Parse(resultadoReader["ID_TIPOESTADOCIVIL"].ToString()) : 0,

                                PossuiFilhos = (!string.IsNullOrEmpty(resultadoReader["POSSUIFILHOS"].ToString())) ?
                                                      char.Parse(resultadoReader["POSSUIFILHOS"].ToString()) : char.MinValue,

                                QuantidadeFilhos = (!string.IsNullOrEmpty(resultadoReader["QUANTIDADEFILHOS"].ToString())) ?
                                                      int.Parse(resultadoReader["QUANTIDADEFILHOS"].ToString()) : 0,

                                ConjugeEhObreiro = (!string.IsNullOrEmpty(resultadoReader["CONJUGEEHOBREIRO"].ToString())) ?
                                                      char.Parse(resultadoReader["CONJUGEEHOBREIRO"].ToString()) : char.MinValue,

                                MesAnoFoiLevantadoObreiro = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString(),

                                GostaDeAlguem = (!string.IsNullOrEmpty(resultadoReader["GOSTADEALGUEM"].ToString())) ?
                                                      char.Parse(resultadoReader["GOSTADEALGUEM"].ToString()) : char.MinValue,

                                NamoraAtualmente = (!string.IsNullOrEmpty(resultadoReader["NAMORAATUALMENTE"].ToString())) ?
                                                      char.Parse(resultadoReader["NAMORAATUALMENTE"].ToString()) : char.MinValue,

                                NomePretendente = resultadoReader["NOMEPRETENDENTE"].ToString(),

                                TotalAnosCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalAnosCoordenandoFJU"].ToString())) ?
                                                             int.Parse(resultadoReader["TotalAnosCoordenandoFJU"].ToString()) :
                                                             0,
                                TotalMesesCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalMesesCoordenandoFJU"].ToString())) ?
                                                              int.Parse(resultadoReader["TotalMesesCoordenandoFJU"].ToString()) :
                                                              0,

                                AnosCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                   int.Parse(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString()) :
                                                                   0,
                                MesesCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                    int.Parse(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString()) :
                                                                    0,

                                DataEntradaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataEntradaCoordenador"].ToString())) ?
                                                            DateTime.Parse(resultadoReader["DataEntradaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

                                QuantidadeJovensEncontroAnterior = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString())) ?
                                                                      int.Parse(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString()) :
                                                                      0,
                                QuantidadeJovensEncontroAtual = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAtual"].ToString())) ?
                                                                   int.Parse(resultadoReader["QuantidadeJovensEncontroAtual"].ToString()) :
                                                                   0,

                                MotivoSaidaPastor = resultadoReader["MOTIVOSAIDAPASTOR"].ToString(),

                                MotivoTrocaCoordenador = resultadoReader["MotivoTrocaCoordenador"].ToString(),

                                NomeNovoCoordenador = resultadoReader["NomeNovoCoordenador"].ToString(),

                                NomePastorEfetuouTroca = resultadoReader["NomePastorEfetuouTroca"].ToString(),

                                FoiEntrevistadoEstadualFJU = (!string.IsNullOrEmpty(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString())) ?
                                                                char.Parse(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString()) :
                                                                char.MinValue,

                                NomeEstadualEntrevistou = resultadoReader["NomeEstadualEntrevistou"].ToString(),

                                MesAnoEntrevistaEstadual = resultadoReader["MesAnoEntrevistaEstadual"].ToString(),

                                DataSaidaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataSaidaCoordenador"].ToString())) ?
                                                                DateTime.Parse(resultadoReader["DataSaidaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

                                DataTrocaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataTrocaCoordenador"].ToString())) ?
                                                          DateTime.Parse(resultadoReader["DataTrocaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

                            });
                        }
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
        public void RegistraCoordenador(IgrejaCoordenador novoCoordenador) {
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try {
                        var data = DateTime.Now.ToString("yyyy-MM-dd");
                        var hora = DateTime.Now.Hour.ToString();
                        var siglaEstado = novoCoordenador.CoordenadorFJU.SiglaEstadoJovem;

                        var novoJovem = novoCoordenador.CoordenadorFJU;
                        var situacaoFJUCoordenador = novoJovem.SituacaoJovemIURDFJU;

                        session.Save(situacaoFJUCoordenador);
                        session.Save(novoJovem);

                        novoJovem.NomeArquivoFoto = $"{siglaEstado}_ID_COORDENADOR_{novoCoordenador.CoordenadorFJU.Id}_{data}{hora}{novoJovem.NomeArquivoFoto}";

                        session.SaveOrUpdate(novoCoordenador);

                        session.SaveOrUpdate(novoJovem);

                        transaction.Commit();
                    }
                    catch (Exception dataException) {
                        var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                        throw new DomainException(mensagemTratada, dataException);
                    }
                }
            }
        }
        public void RegistraCoordenador2(IgrejaCoordenador novoCoordenador)
        {
            using (var session = __sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var data = DateTime.Now.ToString("yyyy-MM-dd");
                        var hora = DateTime.Now.Hour.ToString();
                        var siglaEstado = novoCoordenador.CoordenadorFJU.SiglaEstadoJovem;

                        var novoJovem = novoCoordenador.CoordenadorFJU;
                        var situacaoFJUCoordenador = novoJovem.SituacaoJovemIURDFJU;

                        session.Save(novoCoordenador.CoordenadorFJU.DadosEducacionaisJovem);
                        session.Save(novoCoordenador.CoordenadorFJU.DadosEspirituaisJovem);
                        session.Save(novoCoordenador.CoordenadorFJU.DadosProfissionaisJovem);
                        session.Save(novoCoordenador.CoordenadorFJU.RedeSocialJovem);
                        session.Save(situacaoFJUCoordenador);
                        session.Save(novoJovem);

                        novoJovem.NomeArquivoFoto = $"{siglaEstado}_ID_COORDENADOR_{novoCoordenador.CoordenadorFJU.Id}_{data}{hora}{novoJovem.NomeArquivoFoto}";

                        session.SaveOrUpdate(novoCoordenador);

                        session.SaveOrUpdate(novoJovem);

                        transaction.Commit();
                    }
                    catch (Exception dataException)
                    {
                        var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                        throw new DomainException(mensagemTratada, dataException);
                    }
                }
            }
        }
        public void AssociaObreiroComoCoordenador(IgrejaCoordenador novoCoordenador) {
            try {
                var _DAO = new DAO();
                var sqlCommands = new StringBuilder();
                MySqlConnection conexao = null;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    var sqlcoordenadorIgreja = "INSERT INTO `sgfju_dev`.`sgfju_tbl_igreja_coordenador`" +
                                                "(`ID_JOVEM`, " + 
                                                "`ID_IGREJA`, " +
                                                "`TotalMesesCoordenandoFJU`, " +
                                                "`TotalAnosCoordenandoFJU`, " +
                                                "`QuantidadeJovensEncontroAnterior`, " +
                                                "`QuantidadeJovensEncontroAtual`, " +
                                                "`MesesCoordenandoIgrejaAtualFJU`, " +
                                                "`AnosCoordenandoIgrejaAtualFJU`, " +
                                                "`FoiEntrevistadoEstadualFJU`, " +
                                                "`MesAnoEntrevistaEstadual`, " +
                                                "`NomeEstadualEntrevistou`, " +
                                                "`DataEntradaCoordenador`, " +
                                                "`DataSaidaCoordenador`, " +
                                                "`DataTrocaCoordenador`, " +
                                                "`NomePastorEfetuouTroca`, " +
                                                "`MotivoTrocaCoordenador`, " +
                                                "`NomeNovoCoordenador`, " +
                                                "`Jovem_id`) " +
                                                "VALUES " +
                                                $"({novoCoordenador.CoordenadorFJU.Id}, " +
                                                $"{novoCoordenador.IgrejaFJU.Id}, " +
                                                $"{novoCoordenador.TotalMesesCoordenandoFJU}, " +
                                                $"{novoCoordenador.TotalAnosCoordenandoFJU}, " +
                                                $"{novoCoordenador.QuantidadeJovensEncontroAnterior}, " +
                                                $"{novoCoordenador.QuantidadeJovensEncontroAtual }, " +
                                                $"{novoCoordenador.MesesCoordenandoIgrejaAtualFJU }, " +
                                                $"{novoCoordenador.AnosCoordenandoIgrejaAtualFJU }, " +
                                                $"'{novoCoordenador.FoiEntrevistadoEstadualFJU }', " +
                                                $"'{novoCoordenador.MesAnoEntrevistaEstadual }', " +
                                                $"'{novoCoordenador.NomeEstadualEntrevistou }', " +
                                                $"'{novoCoordenador.DataEntradaCoordenador.ToString("yyyy-MM-dd") }', " +
                                                $"NULL, " +
                                                $"NULL, " +
                                                $"NULL, " +
                                                $"NULL, " +
                                                $"NULL, " +
                                                $"{novoCoordenador.CoordenadorFJU.Id});";

                    var mesAnoLevantadoObra = (!string.IsNullOrEmpty(novoCoordenador.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoFoiLevantadoObreiro)) ?
                                                 novoCoordenador.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoFoiLevantadoObreiro : "null ";
                    var mesAnoSaidaObra = (!string.IsNullOrEmpty(novoCoordenador.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoSaidaObra)) ?
                                                 novoCoordenador.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoSaidaObra : "null ";

                    var sqlAtualizaSituacaoIURD_FJU = "UPDATE SGFJU_DEV.SGFJU_TBL_SITUACAO_IURD_FJU " +
                                                      $"    SET MesAnoFoiLevantadoObreiro = '{mesAnoLevantadoObra}', " +
                                                      $"        MesAnoSaidaObra = '{mesAnoSaidaObra}' " +
                                                      "   WHERE ID_SITUACAO_IURD_FJU = ( SELECT ID_SITUACAO_IURD_FJU " +
                                                      "                                    FROM SGFJU_DEV.SGFJU_TBL_JOVEM " +
                                                      $"                                   WHERE ID_JOVEM = {novoCoordenador.CoordenadorFJU.Id}); ";

                    ///_DAO.ExecuteNonQuery(sqlcoordenadorIgreja);
                    _DAO.ExecuteNonQuery(new List<string> { sqlcoordenadorIgreja, sqlAtualizaSituacaoIURD_FJU }); 
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public void AtualizarCoordenador(IgrejaCoordenador coordenadorParaAtualizacao) {
            try {
                var _DAO = new DAO();
                var sqlCommands = new StringBuilder();
                MySqlConnection conexao = null;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    var sqlcoordenadorIgreja = "UPDATE `sgfju_dev`.`sgfju_tbl_igreja_coordenador`" +
                                                $"SET `TotalMesesCoordenandoFJU` = {coordenadorParaAtualizacao.TotalMesesCoordenandoFJU}, " +
                                                $"`TotalAnosCoordenandoFJU` = {coordenadorParaAtualizacao.TotalAnosCoordenandoFJU}, " +
                                                $"`QuantidadeJovensEncontroAnterior` = {coordenadorParaAtualizacao.QuantidadeJovensEncontroAnterior}, " +
                                                $"`QuantidadeJovensEncontroAtual` = {coordenadorParaAtualizacao.QuantidadeJovensEncontroAtual }, " +
                                                $"`MesesCoordenandoIgrejaAtualFJU` = {coordenadorParaAtualizacao.MesesCoordenandoIgrejaAtualFJU }, " +
                                                $"`AnosCoordenandoIgrejaAtualFJU` = {coordenadorParaAtualizacao.AnosCoordenandoIgrejaAtualFJU }, " +
                                                $"`FoiEntrevistadoEstadualFJU` = '{coordenadorParaAtualizacao.FoiEntrevistadoEstadualFJU }', " +
                                                $"`MesAnoEntrevistaEstadual` = '{coordenadorParaAtualizacao.MesAnoEntrevistaEstadual }', " +
                                                $"`NomeEstadualEntrevistou` = '{coordenadorParaAtualizacao.NomeEstadualEntrevistou }', " +
                                                $"`DataEntradaCoordenador` = '{coordenadorParaAtualizacao.DataEntradaCoordenador.ToString("yyyy-MM-dd") }' " +
                                                $" WHERE ID_JOVEM = {coordenadorParaAtualizacao.CoordenadorFJU.Id};";

                    var sqlAtualizaDadosPessoais = "UPDATE SGFJU_DEV.SGFJU_TBL_JOVEM " +
                                                   $" SET `DataNascimento` = '{coordenadorParaAtualizacao.CoordenadorFJU.DataNascimento.ToString("yyyy-MM-dd")}', " +
                                                   $"     `NomeArquivoFoto` = '{coordenadorParaAtualizacao.CoordenadorFJU.NomeArquivoFoto}', " +
                                                   $"     `ID_TIPOESTADOCIVIL` = {coordenadorParaAtualizacao.CoordenadorFJU.EstadoCivilJovem.Code}, " +
                                                   $"     `NomeConjuge` = '{coordenadorParaAtualizacao.CoordenadorFJU.NomeConjuge}', " +
                                                   $"     `ConjugeEhObreiro` = '{coordenadorParaAtualizacao.CoordenadorFJU.ConjugeEhObreiro}', " +
                                                   $"     `QuantidadeFilhos` = {coordenadorParaAtualizacao.CoordenadorFJU.QuantidadeFilhos}, " +
                                                   $"     `GostaDeAlguem` = '{coordenadorParaAtualizacao.CoordenadorFJU.GostaDeAlguem}', " +
                                                   $"     `NamoraAtualmente` = '{coordenadorParaAtualizacao.CoordenadorFJU.NamoraAtualmente}', " +
                                                   $"     `NomePretendente` = '{coordenadorParaAtualizacao.CoordenadorFJU.NomePretendente}', " +
                                                   $"     `EhPastor` = {coordenadorParaAtualizacao.CoordenadorFJU.EhPastor}" +
                                                   $" WHERE ID_JOVEM = {coordenadorParaAtualizacao.CoordenadorFJU.Id};";

                    var mesAnoLevantadoObra = (!string.IsNullOrEmpty(coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoFoiLevantadoObreiro)) ?
                                                 coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoFoiLevantadoObreiro : "null ";
                    var mesAnoSaidaObra = (!string.IsNullOrEmpty(coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoSaidaObra)) ?
                                                 coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.MesAnoSaidaObra : "null ";

                    var sqlAtualizaSituacaoIURD_FJU = "UPDATE SGFJU_DEV.SGFJU_TBL_SITUACAO_IURD_FJU " +
                                                      $"    SET MesAnoFoiLevantadoObreiro = '{mesAnoLevantadoObra}', " +
                                                      $"        MesAnoSaidaObra = '{mesAnoSaidaObra}' , " +
                                                      $"        EhObreiro = '{coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.EhObreiro}' , " +
                                                      $"        DesejaFazerObraNoAltar = '{coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.DesejaFazerObraNoAltar}' , " +
                                                      $"        FoiPastor = '{coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.FoiPastor}' , " +
                                                      $"        MotivoSaidaPastor = '{coordenadorParaAtualizacao.CoordenadorFJU.SituacaoJovemIURDFJU.MotivoSaidaPastor}' " +
                                                      "   WHERE ID_SITUACAO_IURD_FJU = ( SELECT ID_SITUACAO_IURD_FJU " +
                                                      "                                    FROM SGFJU_DEV.SGFJU_TBL_JOVEM " +
                                                      $"                                   WHERE ID_JOVEM = {coordenadorParaAtualizacao.CoordenadorFJU.Id}); ";

                    _DAO.ExecuteNonQuery(new List<string> { sqlcoordenadorIgreja, sqlAtualizaDadosPessoais,sqlAtualizaSituacaoIURD_FJU }); 
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public void TrocarCoordenador(IgrejaCoordenador coordenadorParaTrocar) {
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try {
                        var igrejaCoordenadorCadastrada = this.ObterIgrejaCoordenadorPorID(coordenadorParaTrocar.Id);
                        igrejaCoordenadorCadastrada.DataSaidaCoordenador = coordenadorParaTrocar.DataSaidaCoordenador;
                        igrejaCoordenadorCadastrada.MotivoTrocaCoordenador = coordenadorParaTrocar.MotivoTrocaCoordenador;
                        igrejaCoordenadorCadastrada.NomePastorEfetuouTroca = coordenadorParaTrocar.NomePastorEfetuouTroca;
                        igrejaCoordenadorCadastrada.NomeNovoCoordenador = coordenadorParaTrocar.NomeNovoCoordenador;
                        igrejaCoordenadorCadastrada.DataTrocaCoordenador = DateTime.Now;

                        session.SaveOrUpdate(igrejaCoordenadorCadastrada);

                        transaction.Commit();
                    }
                    catch (Exception dataException) {
                        var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                        throw new DomainException(mensagemTratada, dataException);
                    }
                }
            }
        }
        public IgrejaCoordenadorDTO ObterCoordenadorInformacoesDetalhadas(IgrejaCoordenadorDTO parametroCoordenador) {
            try
            {
                IgrejaCoordenadorDTO retorno = null;
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         JV.DATANASCIMENTO,                                       ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                                      ");
                SQLQuery.Append("         JV.ID_TIPOESTADOCIVIL,                                   ");
                SQLQuery.Append("         JV.NOMECONJUGE,                                          ");
                SQLQuery.Append("         JV.CONJUGEEHOBREIRO,                                     ");
                SQLQuery.Append("         JV.POSSUIFILHOS,                                         ");
                SQLQuery.Append("         JV.QUANTIDADEFILHOS,                                     ");
                SQLQuery.Append("         JV.GOSTADEALGUEM,                                        ");
                SQLQuery.Append("         JV.NAMORAATUALMENTE,                                     ");
                SQLQuery.Append("         JV.NOMEPRETENDENTE,                                      ");
                SQLQuery.Append("         JV.EHPASTOR,                                             ");
                SQLQuery.Append("         ED.ID_ESTADO,                                            ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.ID_BLOCO,                                             ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.ID_REGIAO,                                           ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.ID_IGREJA,                                           ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                //SQLQuery.Append("         CT.WHATSAPP,                                             ");
                SQLQuery.Append("         SIFJ.EHOBREIRO,                                          ");
                SQLQuery.Append("         SIFJ.MESANOFOILEVANTADOOBREIRO,                          ");
                SQLQuery.Append("         SIFJ.DESEJAFAZEROBRANOALTAR,                             ");
                SQLQuery.Append("         SIFJ.FOIPASTOR,                                          ");
                SQLQuery.Append("         SIFJ.MOTIVOSAIDAPASTOR,                                  ");
                SQLQuery.Append("         SIFJ.MESANOSAIDAOBRA,                                    ");
                SQLQuery.Append("         IGJC.ID_IGREJA_COORDENADOR,                              ");
                SQLQuery.Append("         IGJC.TotalMesesCoordenandoFJU,                           ");
                SQLQuery.Append("         IGJC.TotalAnosCoordenandoFJU,                            ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAnterior,                   ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAtual,                      ");
                SQLQuery.Append("         IGJC.MesesCoordenandoIgrejaAtualFJU,                     ");
                SQLQuery.Append("         IGJC.AnosCoordenandoIgrejaAtualFJU,                      ");
                SQLQuery.Append("         IGJC.FoiEntrevistadoEstadualFJU,                         ");
                SQLQuery.Append("         IGJC.MesAnoEntrevistaEstadual,                           ");
                SQLQuery.Append("         IGJC.NomeEstadualEntrevistou,                            ");
                SQLQuery.Append("         IGJC.DataEntradaCoordenador,                             ");
                SQLQuery.Append("         IGJC.DataSaidaCoordenador,                               ");
                SQLQuery.Append("         IGJC.DataTrocaCoordenador,                               ");
                SQLQuery.Append("         IGJC.NomePastorEfetuouTroca,                             ");
                SQLQuery.Append("         IGJC.MotivoTrocaCoordenador,                             ");
                SQLQuery.Append("         IGJC.NomeNovoCoordenador                                 ");
                SQLQuery.Append("	FROM       sgfju_dev.SGFJU_TBL_JOVEM JV                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA_COORDENADOR IGJC         ");
                SQLQuery.Append("			ON JV.ID_JOVEM = IGJC.ID_JOVEM                         ");
                //SQLQuery.Append("	LEFT JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                //SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE IGJC.DATASAIDACOORDENADOR IS NULL AND JV.ID_JOVEM = " + parametroCoordenador.IdCoordenadorFJU);

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString() , ref conexao)) {                        
                        while (resultadoReader.Read())
                        {
                            retorno = new IgrejaCoordenadorDTO
                            {
                                IdIgrejaCoordenador = int.Parse(resultadoReader["ID_IGREJA_COORDENADOR"].ToString()),
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = tinfo.ToTitleCase( resultadoReader["NOMEESTADO"].ToString() ),

                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = tinfo.ToTitleCase( resultadoReader["NOMEBLOCO"].ToString() ),

                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = tinfo.ToTitleCase( resultadoReader["nomeregiao"].ToString() ),

                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = tinfo.ToTitleCase( resultadoReader["NOMEIGREJA"].ToString() ),

                                IdCoordenadorFJU = int.Parse(resultadoReader["ID_JOVEM"].ToString()),

                                NomeCoordenador = tinfo.ToTitleCase( resultadoReader["NOME"].ToString() ),

                                DataNascimento = (!string.IsNullOrEmpty(resultadoReader["DATANASCIMENTO"].ToString()))? 
                                                    DateTime.Parse(resultadoReader["DATANASCIMENTO"].ToString()).ToString("dd/MM/yyyy"):
                                                    "",

                                NomeTipoCoordenador = (bool.Parse(resultadoReader["EHPASTOR"].ToString())) ? "Pastor" : "Obreiro",

                                NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),

                                NomeConjuge = tinfo.ToTitleCase( resultadoReader["NOMECONJUGE"].ToString() ),

                                IdEstadoCivil = (!string.IsNullOrEmpty(resultadoReader["ID_TIPOESTADOCIVIL"].ToString())) ? int.Parse(resultadoReader["ID_TIPOESTADOCIVIL"].ToString()) : 0,

                                PossuiFilhos = (!string.IsNullOrEmpty(resultadoReader["POSSUIFILHOS"].ToString())) ?
                                                      char.Parse(resultadoReader["POSSUIFILHOS"].ToString()) : char.MinValue,

                                QuantidadeFilhos = (!string.IsNullOrEmpty(resultadoReader["QUANTIDADEFILHOS"].ToString())) ?
                                                      int.Parse(resultadoReader["QUANTIDADEFILHOS"].ToString()) : 0,

                                ConjugeEhObreiro = (!string.IsNullOrEmpty(resultadoReader["CONJUGEEHOBREIRO"].ToString())) ?
                                                      char.Parse(resultadoReader["CONJUGEEHOBREIRO"].ToString()) : char.MinValue,

                                MesAnoFoiLevantadoObreiro = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString(),

                                GostaDeAlguem = (!string.IsNullOrEmpty(resultadoReader["GOSTADEALGUEM"].ToString())) ?
                                                      char.Parse(resultadoReader["GOSTADEALGUEM"].ToString()) : char.MinValue,

                                NamoraAtualmente = (!string.IsNullOrEmpty(resultadoReader["NAMORAATUALMENTE"].ToString())) ?
                                                      char.Parse(resultadoReader["NAMORAATUALMENTE"].ToString()) : char.MinValue,

                                NomePretendente = tinfo.ToTitleCase( resultadoReader["NOMEPRETENDENTE"].ToString() ),

                                DesejaFazerObraNoAltar = (!string.IsNullOrEmpty(resultadoReader["DESEJAFAZEROBRANOALTAR"].ToString())) ?
                                                                char.Parse(resultadoReader["DESEJAFAZEROBRANOALTAR"].ToString()) :
                                                                char.MinValue,

                                FoiPastor = (!string.IsNullOrEmpty(resultadoReader["FOIPASTOR"].ToString())) ?
                                                                char.Parse(resultadoReader["FOIPASTOR"].ToString()) :
                                                                char.MinValue,

                                MesAnoSaiuObra = resultadoReader["MESANOSAIDAOBRA"].ToString(),

                                TotalAnosCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalAnosCoordenandoFJU"].ToString())) ?
                                                             int.Parse(resultadoReader["TotalAnosCoordenandoFJU"].ToString()) :
                                                             0,
                                TotalMesesCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalMesesCoordenandoFJU"].ToString())) ?
                                                              int.Parse(resultadoReader["TotalMesesCoordenandoFJU"].ToString()) :
                                                              0,

                                AnosCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                   int.Parse(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString()) :
                                                                   0,
                                MesesCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                    int.Parse(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString()) :
                                                                    0,

                                DataEntradaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataEntradaCoordenador"].ToString())) ?
                                                            DateTime.Parse(resultadoReader["DataEntradaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

                                QuantidadeJovensEncontroAnterior = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString())) ?
                                                                      int.Parse(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString()) :
                                                                      0,
                                QuantidadeJovensEncontroAtual = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAtual"].ToString())) ?
                                                                   int.Parse(resultadoReader["QuantidadeJovensEncontroAtual"].ToString()) :
                                                                   0,

                                MotivoSaidaPastor = resultadoReader["MOTIVOSAIDAPASTOR"].ToString(),

                                MotivoTrocaCoordenador = resultadoReader["MotivoTrocaCoordenador"].ToString(),

                                NomeNovoCoordenador = tinfo.ToTitleCase( resultadoReader["NomeNovoCoordenador"].ToString() ),

                                NomePastorEfetuouTroca = tinfo.ToTitleCase( resultadoReader["NomePastorEfetuouTroca"].ToString() ),

                                FoiEntrevistadoEstadualFJU = (!string.IsNullOrEmpty(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString())) ?
                                                                char.Parse(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString()) :
                                                                char.MinValue,

                                NomeEstadualEntrevistou = resultadoReader["NomeEstadualEntrevistou"].ToString(),

                                MesAnoEntrevistaEstadual = resultadoReader["MesAnoEntrevistaEstadual"].ToString(),

                                DataSaidaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataSaidaCoordenador"].ToString())) ?
                                                                DateTime.Parse(resultadoReader["DataSaidaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

                                DataTrocaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataTrocaCoordenador"].ToString())) ?
                                                          DateTime.Parse(resultadoReader["DataTrocaCoordenador"].ToString()).ToString("dd/MM/yyyy") : "",

                            };
                        }
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
        public IgrejaCoordenador ObterIgrejaCoordenadorPorID(int idIgrejaCoordenador) {
            try
            {
                IgrejaCoordenador retorno = null;
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT JV.ID_JOVEM,                                             ");
                SQLQuery.Append("         JV.NOME,                                                 ");
                SQLQuery.Append("         JV.DATANASCIMENTO,                                       ");
                SQLQuery.Append("         JV.NOMEARQUIVOFOTO,                                      ");
                SQLQuery.Append("         JV.ID_TIPOESTADOCIVIL,                                   ");
                SQLQuery.Append("         JV.NOMECONJUGE,                                          ");
                SQLQuery.Append("         JV.CONJUGEEHOBREIRO,                                     ");
                SQLQuery.Append("         JV.POSSUIFILHOS,                                         ");
                SQLQuery.Append("         JV.QUANTIDADEFILHOS,                                     ");
                SQLQuery.Append("         JV.GOSTADEALGUEM,                                        ");
                SQLQuery.Append("         JV.NAMORAATUALMENTE,                                     ");
                SQLQuery.Append("         JV.NOMEPRETENDENTE,                                      ");
                SQLQuery.Append("         JV.EHPASTOR,                                             ");
                SQLQuery.Append("         ED.ID_ESTADO,                                            ");
                SQLQuery.Append("         ED.NOMEESTADO,                                           ");
                SQLQuery.Append("         BL.ID_BLOCO,                                             ");
                SQLQuery.Append("         BL.NOMEBLOCO,                                            ");
                SQLQuery.Append("         REG.ID_REGIAO,                                           ");
                SQLQuery.Append("         REG.NOMEREGIAO,                                          ");
                SQLQuery.Append("         IGJ.ID_IGREJA,                                           ");
                SQLQuery.Append("         IGJ.NOMEIGREJA,                                          ");
                //SQLQuery.Append("         CT.WHATSAPP,                                             ");
                SQLQuery.Append("         SIFJ.ID_SITUACAO_IURD_FJU,                               ");
                SQLQuery.Append("         SIFJ.EHOBREIRO,                                          ");
                SQLQuery.Append("         SIFJ.MESANOFOILEVANTADOOBREIRO,                          ");
                SQLQuery.Append("         SIFJ.DESEJAFAZEROBRANOALTAR,                             ");
                SQLQuery.Append("         SIFJ.FOIPASTOR,                                          ");
                SQLQuery.Append("         SIFJ.MOTIVOSAIDAPASTOR,                                  ");
                SQLQuery.Append("         SIFJ.MESANOSAIDAOBRA,                                    ");
                SQLQuery.Append("         IGJC.ID_IGREJA_COORDENADOR,                              ");
                SQLQuery.Append("         IGJC.TotalMesesCoordenandoFJU,                           ");
                SQLQuery.Append("         IGJC.TotalAnosCoordenandoFJU,                            ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAnterior,                   ");
                SQLQuery.Append("         IGJC.QuantidadeJovensEncontroAtual,                      ");
                SQLQuery.Append("         IGJC.MesesCoordenandoIgrejaAtualFJU,                     ");
                SQLQuery.Append("         IGJC.AnosCoordenandoIgrejaAtualFJU,                      ");
                SQLQuery.Append("         IGJC.FoiEntrevistadoEstadualFJU,                         ");
                SQLQuery.Append("         IGJC.MesAnoEntrevistaEstadual,                           ");
                SQLQuery.Append("         IGJC.NomeEstadualEntrevistou,                            ");
                SQLQuery.Append("         IGJC.DataEntradaCoordenador,                             ");
                SQLQuery.Append("         IGJC.DataSaidaCoordenador,                               ");
                SQLQuery.Append("         IGJC.DataTrocaCoordenador,                               ");
                SQLQuery.Append("         IGJC.NomePastorEfetuouTroca,                             ");
                SQLQuery.Append("         IGJC.MotivoTrocaCoordenador,                             ");
                SQLQuery.Append("         IGJC.NomeNovoCoordenador                                 ");
                SQLQuery.Append("	FROM       sgfju_dev.SGFJU_TBL_JOVEM JV                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA_COORDENADOR IGJC         ");
                SQLQuery.Append("			ON JV.ID_JOVEM = IGJC.ID_JOVEM                         ");
                //SQLQuery.Append("	LEFT JOIN sgfju_dev.SGFJU_TBL_CONTATO CT                      ");
                //SQLQuery.Append("			ON JV.ID_CONTATO = CT.ID_CONTATO                       ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_SITUACAO_IURD_FJU SIFJ          ");
                SQLQuery.Append("		    ON SIFJ.ID_SITUACAO_IURD_FJU = JV.ID_SITUACAO_IURD_FJU ");
                SQLQuery.Append("    LEFT JOIN sgfju_dev.SGFJU_TBL_DADOSESPIRITUAIS DESP           ");
                SQLQuery.Append("           ON DESP.ID_DADOSESPIRITUAIS = JV.ID_DADOSESPIRITUAIS   ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ                      ");
                SQLQuery.Append("			ON JV.ID_IGREJA = IGJ.ID_IGREJA                        ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG                      ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO                       ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL                       ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO                           ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED                       ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO                          ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE IGJC.ID_IGREJA_COORDENADOR = " + idIgrejaCoordenador);

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                        while (resultadoReader.Read())
                        {
                            retorno = new IgrejaCoordenador
                            {
                                Id = int.Parse(resultadoReader["ID_IGREJA_COORDENADOR"].ToString()),
                                CoordenadorFJU = new Jovem
                                {
                                    Id = int.Parse(resultadoReader["ID_JOVEM"].ToString()),
                                    Nome = resultadoReader["NOME"].ToString(),
                                    IgrejaAQualJovemPertence = new Igreja { Id = int.Parse(resultadoReader["ID_IGREJA"].ToString()) },
                                    DataNascimento = (!string.IsNullOrEmpty(resultadoReader["DATANASCIMENTO"].ToString())) ?
                                                        DateTime.Parse(resultadoReader["DATANASCIMENTO"].ToString()) :
                                                        DateTime.MinValue,
                                    NomeArquivoFoto = resultadoReader["NOMEARQUIVOFOTO"].ToString(),
                                    NomeConjuge = resultadoReader["NOMECONJUGE"].ToString(),
                                    EstadoCivilJovem = (!string.IsNullOrEmpty(resultadoReader["ID_TIPOESTADOCIVIL"].ToString())) ?
                                                          new TipoEstadoCivil { Codigo = int.Parse(resultadoReader["ID_TIPOESTADOCIVIL"].ToString()) } : null,
                                    EhPastor = bool.Parse(resultadoReader["EHPASTOR"].ToString()),
                                    PossuiFilhos = (!string.IsNullOrEmpty(resultadoReader["POSSUIFILHOS"].ToString())) ?
                                                      char.Parse(resultadoReader["POSSUIFILHOS"].ToString()) : char.MinValue,

                                    QuantidadeFilhos = (!string.IsNullOrEmpty(resultadoReader["QUANTIDADEFILHOS"].ToString())) ?
                                                      int.Parse(resultadoReader["QUANTIDADEFILHOS"].ToString()) : 0,

                                    ConjugeEhObreiro = (!string.IsNullOrEmpty(resultadoReader["CONJUGEEHOBREIRO"].ToString())) ?
                                                      char.Parse(resultadoReader["CONJUGEEHOBREIRO"].ToString()) : char.MinValue,



                                    GostaDeAlguem = (!string.IsNullOrEmpty(resultadoReader["GOSTADEALGUEM"].ToString())) ?
                                                      char.Parse(resultadoReader["GOSTADEALGUEM"].ToString()) : char.MinValue,

                                    NamoraAtualmente = (!string.IsNullOrEmpty(resultadoReader["NAMORAATUALMENTE"].ToString())) ?
                                                      char.Parse(resultadoReader["NAMORAATUALMENTE"].ToString()) : char.MinValue,

                                    NomePretendente = resultadoReader["NOMEPRETENDENTE"].ToString(),

                                    SituacaoJovemIURDFJU = new SituacaoIURDFJU
                                    {

                                        Code = int.Parse(resultadoReader["ID_SITUACAO_IURD_FJU"].ToString()),

                                        MesAnoFoiLevantadoObreiro = resultadoReader["MESANOFOILEVANTADOOBREIRO"].ToString(),

                                        DesejaFazerObraNoAltar = (!string.IsNullOrEmpty(resultadoReader["DESEJAFAZEROBRANOALTAR"].ToString())) ?
                                                                char.Parse(resultadoReader["DESEJAFAZEROBRANOALTAR"].ToString()) :
                                                                char.MinValue,

                                        FoiPastor = (!string.IsNullOrEmpty(resultadoReader["FOIPASTOR"].ToString())) ?
                                                                char.Parse(resultadoReader["FOIPASTOR"].ToString()) :
                                                                char.MinValue,
                                        MesAnoSaidaObra = resultadoReader["MESANOSAIDAOBRA"].ToString(),

                                        MotivoSaidaPastor = resultadoReader["MOTIVOSAIDAPASTOR"].ToString()

                                    },
                                },

                                IgrejaFJU = new Igreja { Id = int.Parse(resultadoReader["ID_IGREJA"].ToString()) },


                                TotalAnosCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalAnosCoordenandoFJU"].ToString())) ?
                                                             int.Parse(resultadoReader["TotalAnosCoordenandoFJU"].ToString()) :
                                                             0,
                                TotalMesesCoordenandoFJU = (!string.IsNullOrEmpty(resultadoReader["TotalMesesCoordenandoFJU"].ToString())) ?
                                                              int.Parse(resultadoReader["TotalMesesCoordenandoFJU"].ToString()) :
                                                              0,

                                AnosCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                   int.Parse(resultadoReader["AnosCoordenandoIgrejaAtualFJU"].ToString()) :
                                                                   0,
                                MesesCoordenandoIgrejaAtualFJU = (!string.IsNullOrEmpty(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString())) ?
                                                                    int.Parse(resultadoReader["MesesCoordenandoIgrejaAtualFJU"].ToString()) :
                                                                    0,

                                DataEntradaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataEntradaCoordenador"].ToString())) ?
                                                            DateTime.Parse(resultadoReader["DataEntradaCoordenador"].ToString()) : DateTime.MinValue,

                                QuantidadeJovensEncontroAnterior = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString())) ?
                                                                      int.Parse(resultadoReader["QuantidadeJovensEncontroAnterior"].ToString()) :
                                                                      0,
                                QuantidadeJovensEncontroAtual = (!string.IsNullOrEmpty(resultadoReader["QuantidadeJovensEncontroAtual"].ToString())) ?
                                                                   int.Parse(resultadoReader["QuantidadeJovensEncontroAtual"].ToString()) :
                                                                   0,

                                MotivoTrocaCoordenador = resultadoReader["MotivoTrocaCoordenador"].ToString(),

                                NomeNovoCoordenador = resultadoReader["NomeNovoCoordenador"].ToString(),

                                NomePastorEfetuouTroca = resultadoReader["NomePastorEfetuouTroca"].ToString(),

                                FoiEntrevistadoEstadualFJU = (!string.IsNullOrEmpty(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString())) ?
                                                                char.Parse(resultadoReader["FoiEntrevistadoEstadualFJU"].ToString()) :
                                                                char.MinValue,

                                NomeEstadualEntrevistou = resultadoReader["NomeEstadualEntrevistou"].ToString(),

                                MesAnoEntrevistaEstadual = resultadoReader["MesAnoEntrevistaEstadual"].ToString(),

                                DataSaidaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataSaidaCoordenador"].ToString())) ?
                                                                DateTime.Parse(resultadoReader["DataSaidaCoordenador"].ToString()) : new Nullable<DateTime>(),

                                DataTrocaCoordenador = (!string.IsNullOrEmpty(resultadoReader["DataTrocaCoordenador"].ToString())) ?
                                                          DateTime.Parse(resultadoReader["DataTrocaCoordenador"].ToString()) : new Nullable<DateTime>()

                            };
                        }
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

        public void InformarIgrejaSemCoordenador(Igreja igrejaSemCoordenador) {
            try {
                var _DAO = new DAO();
                var sqlInformarIgrejaSemCoordenador = "";
                MySqlConnection conexao = null;

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    sqlInformarIgrejaSemCoordenador = "INSERT INTO `SGFJU_DEV`.`SGFJU_TBL_IGREJA_COORDENADOR` (`ID_JOVEM`, `ID_IGREJA`) VALUES( NULL, " + igrejaSemCoordenador.Id + ");";
                    _DAO.ExecuteNonQuery(sqlInformarIgrejaSemCoordenador); 
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorPorEstado(EstadoDTO estadoParametro) {
            try {
                var retorno = new List<IgrejaCoordenadorDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var queryPanoramaGeral = "SELECT ED.ID_ESTADO, " +
                                         "        ED.NOMEESTADO, " +
                                         "         BL.ID_BLOCO, " +
                                         "        BL.NOMEBLOCO, " +
                                         "        REG.ID_REGIAO, " +
                                         "        REG.NOMEREGIAO, " +
                                         "        IGJ.ID_IGREJA, " +
                                         "        IGJ.NOMEIGREJA, " +
                                         "        IFNULL(ICOORD.ID_IGREJA_COORDENADOR, 0) as 'ID_IGREJA_COORDENADOR', " +
                                         "        IFNULL(ICOORD.ID_JOVEM, 0) as 'ID_COORDENADOR', " +
                                         "        JV.NOME " +
                                         "  FROM SGFJU_DEV.SGFJU_TBL_IGREJA IGJ " +
                                         " INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO REG " +
                                         "         ON IGJ.ID_REGIAO = REG.ID_REGIAO " +
                                         " INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO BL " +
                                         "         ON REG.ID_BLOCO = BL.ID_BLOCO " +
                                         " INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO ED " +
                                         "         ON BL.ID_ESTADO = ED.ID_ESTADO " +
                                         "  LEFT JOIN SGFJU_DEV.SGFJU_TBL_IGREJA_COORDENADOR ICOORD " +
                                         "         ON IGJ.ID_IGREJA = ICOORD.ID_IGREJA " +
                                         "LEFT JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JV " +
                                         "       ON ICOORD.ID_JOVEM = JV.ID_JOVEM " +
                                        $"  WHERE ED.ID_ESTADO = {estadoParametro.IdEstado} ;";

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(queryPanoramaGeral, ref conexao)) {
                        while (resultadoReader.Read()) {
                            retorno.Add(new IgrejaCoordenadorDTO {
                                IdIgrejaCoordenador = int.Parse(resultadoReader["ID_IGREJA_COORDENADOR"].ToString()),
                                IdCoordenadorFJU = int.Parse(resultadoReader["ID_COORDENADOR"].ToString()),
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = resultadoReader["NOMEBLOCO"].ToString(),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = resultadoReader["nomeregiao"].ToString(),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = resultadoReader["NOMEIGREJA"].ToString(),
                                Nome = resultadoReader["NOME"].ToString()
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

        public IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorNacional() {
            try
            {
                var retorno = new List<IgrejaCoordenadorDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var queryPanoramaGeral = "SELECT ED.ID_ESTADO, " +
                                         "        ED.NOMEESTADO, " +
                                         "         BL.ID_BLOCO, " +
                                         "        BL.NOMEBLOCO, " +
                                         "        REG.ID_REGIAO, " +
                                         "        REG.NOMEREGIAO, " +
                                         "        IGJ.ID_IGREJA, " +
                                         "        IGJ.NOMEIGREJA, " +
                                         "        IFNULL(ICOORD.ID_IGREJA_COORDENADOR, 0) as 'ID_IGREJA_COORDENADOR', " +
                                         "        IFNULL(ICOORD.ID_JOVEM, 0) as 'ID_COORDENADOR', " +
                                         "        JV.NOME " +
                                         "  FROM SGFJU_DEV.SGFJU_TBL_IGREJA IGJ " +
                                         " INNER JOIN SGFJU_DEV.SGFJU_TBL_REGIAO REG " +
                                         "         ON IGJ.ID_REGIAO = REG.ID_REGIAO " +
                                         " INNER JOIN SGFJU_DEV.SGFJU_TBL_BLOCO BL " +
                                         "         ON REG.ID_BLOCO = BL.ID_BLOCO " +
                                         " INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO ED " +
                                         "         ON BL.ID_ESTADO = ED.ID_ESTADO " +
                                         "  LEFT JOIN SGFJU_DEV.SGFJU_TBL_IGREJA_COORDENADOR ICOORD " +
                                         "         ON IGJ.ID_IGREJA = ICOORD.ID_IGREJA " +
                                         "LEFT JOIN SGFJU_DEV.SGFJU_TBL_JOVEM JV " +
                                         "       ON ICOORD.ID_JOVEM = JV.ID_JOVEM " ;

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(queryPanoramaGeral, ref conexao))
                    {
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new IgrejaCoordenadorDTO
                            {
                                IdIgrejaCoordenador = int.Parse(resultadoReader["ID_IGREJA_COORDENADOR"].ToString()),
                                IdCoordenadorFJU = int.Parse(resultadoReader["ID_COORDENADOR"].ToString()),
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                IdBlocoJovem = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                NomeBlocoJovem = resultadoReader["NOMEBLOCO"].ToString(),
                                IdRegiao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                NomeRegiaoJovem = resultadoReader["nomeregiao"].ToString(),
                                IdIgreja = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                NomeIgreja = resultadoReader["NOMEIGREJA"].ToString(),
                                Nome = resultadoReader["NOME"].ToString()
                            });
                        }
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
    }
}
