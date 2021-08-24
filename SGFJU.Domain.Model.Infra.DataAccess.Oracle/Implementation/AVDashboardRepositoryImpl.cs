using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class AVDashboardRepositoryImpl : RepositoryImpl<Jovem>, AVDashboardRepository
    {
        public IList<TotaisArvoreVidaEstadoDTO> ListaTotaisArvoreVidaGeral() {
			try {
                var retornoDashAVTotais = new List<TotaisArvoreVidaEstadoDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                SQLQuery.Append("SELECT DAVE.*, EST.NOMEESTADO FROM SGFJU_DEV.SGFJU_TBL_DASHBOARD_ARVOREVIDA_ESTADO DAVE INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO EST ON DAVE.ID_ESTADO = EST.ID_ESTADO ");

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {                            
                            retornoDashAVTotais.Add(new TotaisArvoreVidaEstadoDTO
                            {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                QuantidadeJovens = int.Parse(resultadoReader["QuantidadeJovens"].ToString()),
                                QuantidadeObreiros =  int.Parse(resultadoReader["QuantidadeObreiros"].ToString()),
                                QuantidadeObreirosQueAcompanham = int.Parse(resultadoReader["QuantidadeObreirosQueAcompanham"].ToString()),
                                QuantidadeJovensAcompanhados = int.Parse(resultadoReader["QuantidadeJovensAcompanhados"].ToString()),
                                QuantidadeJovensSemAcompanhamento = int.Parse(resultadoReader["QuantidadeJovensSemAcompanhamento"].ToString()),
                                MediaAcompanhamentoJovensPorObreiro = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("MediaAcompanhamentoJovensPorObreiro")))?
                                                                         resultadoReader["MediaAcompanhamentoJovensPorObreiro"].ToString() : "0"
                            });
                        }
                    }
                };

                return retornoDashAVTotais;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public TotaisArvoreVidaEstadoDTO ListaTotaisArvoreVidaPorEstado(EstadoDTO pEstadoDTO) {
            try
            {
                TotaisArvoreVidaEstadoDTO retornoDashAVTotais = null;
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var SQLQuery = new StringBuilder();
                SQLQuery.Append($"SELECT DAVE.*, EST.NOMEESTADO FROM SGFJU_DEV.SGFJU_TBL_DASHBOARD_ARVOREVIDA_ESTADO DAVE INNER JOIN SGFJU_DEV.SGFJU_TBL_ESTADO EST ON DAVE.ID_ESTADO = EST.ID_ESTADO WHERE DAVE.ID_ESTADO = {pEstadoDTO.IdEstado} ");

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao))
                    {
                        while (resultadoReader.Read())
                        {
                            retornoDashAVTotais = new TotaisArvoreVidaEstadoDTO {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                NomeEstado = resultadoReader["NOMEESTADO"].ToString(),
                                QuantidadeJovens = int.Parse(resultadoReader["QuantidadeJovens"].ToString()),
                                QuantidadeObreiros = int.Parse(resultadoReader["QuantidadeObreiros"].ToString()),
                                QuantidadeObreirosQueAcompanham = int.Parse(resultadoReader["QuantidadeObreirosQueAcompanham"].ToString()),
                                QuantidadeJovensAcompanhados = int.Parse(resultadoReader["QuantidadeJovensAcompanhados"].ToString()),
                                QuantidadeJovensSemAcompanhamento = int.Parse(resultadoReader["QuantidadeJovensSemAcompanhamento"].ToString()),
                                MediaAcompanhamentoJovensPorObreiro = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("MediaAcompanhamentoJovensPorObreiro"))) ?
                                                                         resultadoReader["MediaAcompanhamentoJovensPorObreiro"].ToString() : "0"
                            };
                        }
                    }
                };

                return retornoDashAVTotais;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}
