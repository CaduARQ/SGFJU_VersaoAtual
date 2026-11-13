using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class GerenciamentoDespesasRepositoryImpl : RepositoryImpl<Despesa>, GerenciamentoDespesasRepository
    {
        public IList<DespesaDTO> ListarDespesasRegistradasHojePorEstado(EstadoDTO estadoDespesas = null) {
            try
            {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                var retorno = new List<DespesaDTO>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                if(estadoDespesas != null)
                    sqlQuery.Append($" SELECT D.*, TD.* FROM SGFJU_DEV.SGFJU_TBL_DESPESA D INNER JOIN SGFJU_DEV.SGFJU_TBL_TIPODESPESA TD ON D.ID_TIPODESPESA = TD.ID_TIPODESPESA  WHERE Date(Data) = DATE(NOW()) AND ID_ESTADO = {estadoDespesas.IdEstado} ");
                else
                    sqlQuery.Append(" SELECT D.*, TD.* FROM SGFJU_DEV.SGFJU_TBL_DESPESA D INNER JOIN SGFJU_DEV.SGFJU_TBL_TIPODESPESA TD ON D.ID_TIPODESPESA = TD.ID_TIPODESPESA WHERE Date(Data) = DATE(NOW()) ");

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao))
                    {
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new DespesaDTO
                            {
                                IdDespesa = int.Parse(resultadoReader["ID_DESPESA"].ToString()),
                                IdEstadoDespesa = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                Descricao = tinfo.ToTitleCase(resultadoReader["Descricao"].ToString()),
                                Valor = decimal.Parse(resultadoReader["Valor"].ToString()),
                                Data = DateTime.Parse(resultadoReader["Data"].ToString()).ToString("dd/MM/yyyy"),
                                NumeroDoCupom = resultadoReader["NumeroDoCupom"].ToString(),
                                NomeArquivoNota = resultadoReader["NomeArquivoNota"].ToString(),
                                IdTipoDespesa = int.Parse(resultadoReader["ID_TIPODESPESA"].ToString()),
                                DescricaoTipoDespesa = resultadoReader["DescricaoTipoDespesa"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public IList<DespesaDTO> ListaDespesasPorParametro(ParametroDespesasDTO parametrosPesquisa) {
            try
            {
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var sqlQuery = new StringBuilder();
                var retorno = new List<DespesaDTO>();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                
                sqlQuery.Append(" SELECT * FROM SGFJU_DEV.SGFJU_TBL_DESPESA D INNER JOIN SGFJU_DEV.SGFJU_TBL_TIPODESPESA TD ON D.ID_TIPODESPESA = TD.ID_TIPODESPESA WHERE 1=1 ");

                if (parametrosPesquisa.IdEstadoDespesa != 0)
                {
                    sqlQuery.Append($" AND D.ID_ESTADO = {parametrosPesquisa.IdEstadoDespesa} ");
                }

                if (parametrosPesquisa.Valor != 0)
                {
                    sqlQuery.Append($" AND D.Valor = {parametrosPesquisa.Valor} ");
                }

                if (!string.IsNullOrEmpty(parametrosPesquisa.Data)) {
                    sqlQuery.Append($" AND Date(D.Data) = DATE('{parametrosPesquisa.Data}') ");
                }

                if (!string.IsNullOrEmpty(parametrosPesquisa.NumeroDoCupom)) {
                    sqlQuery.Append($" AND D.Valor = '{parametrosPesquisa.NumeroDoCupom}' ");
                }

                if (!string.IsNullOrEmpty(parametrosPesquisa.Descricao))
                {
                    sqlQuery.Append($" AND D.Descricao LIKE '%{parametrosPesquisa.Descricao}%' ");
                }

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(sqlQuery.ToString(), ref conexao))
                    {
                        while (resultadoReader.Read())
                        {
                            retorno.Add(new DespesaDTO
                            {
                                IdEstadoDespesa = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                Descricao = tinfo.ToTitleCase(resultadoReader["Descricao"].ToString()),
                                Valor = decimal.Parse(resultadoReader["Valor"].ToString()),
                                Data = DateTime.Parse(resultadoReader["Data"].ToString()).ToString("dd/MM/yyyy"),
                                NumeroDoCupom = resultadoReader["NumeroDoCupom"].ToString(),
                                NomeArquivoNota = resultadoReader["NomeArquivoNota"].ToString(),
                                IdTipoDespesa = int.Parse(resultadoReader["ID_TIPODESPESA"].ToString()),
                                DescricaoTipoDespesa = resultadoReader["DescricaoTipoDespesa"].ToString()
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
    }
}
