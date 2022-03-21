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
    public class PatrimonioRepositoryImpl : RepositoryImpl<ItemPatrimonio>, PatrimonioRepository
    {
        public IList<ItemPatrimonioDTO> ListarPatrimonioPorParametro(ParametroPesquisaPatrimonioDTO parametros) {
            
            try {
                var retorno = new List<ItemPatrimonioDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;

                var SQLQuery = new StringBuilder();
                SQLQuery.Append("  SELECT PTM.*,                                                       ");
                SQLQuery.Append("         CTP.DESCRICAOCATEGORIAPATRIMOPNIO                            ");
                SQLQuery.Append("	FROM      sgfju_dev.SGFJU_TBL_PATRIMONIO           PTM             ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_CATEGORIAPATRIMONIO CTP             ");
                SQLQuery.Append("			ON PTM.ID_CATEGORIAPATRIMONIO = CTP.ID_CATEGORIAPATRIMONIO ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 ");

                
                if (parametros.IdEstado != 0)
                {
                    SQLWhere.Append(" AND PTM.ID_ESTADO = " + parametros.IdEstado.ToString() + " ");
                }

                if (parametros.IdItemPatrimonio != 0)
                {
                    SQLWhere.Append(" AND PTM.ID_PATRIMONIO = " + parametros.IdItemPatrimonio.ToString() + " ");
                }

                if (parametros.IdCategoriaItem != 0)
                {
                    SQLWhere.Append(" AND PTM.ID_CATEGORIAPATRIMONIO = " + parametros.IdCategoriaItem.ToString() + " ");
                }

                if (!string.IsNullOrEmpty(parametros.NomeItemPatrimonio)) {
                    SQLWhere.Append($" AND PTM. LIKE '%{parametros.NomeItemPatrimonio}%' ");
                }

                if (!string.IsNullOrEmpty(parametros.DescricaoPatrimonio)) {
                    SQLWhere.Append($" AND PTM.DescricaoPatrimonio LIKE '%{parametros.DescricaoPatrimonio}%' ");
                }

                if (!string.IsNullOrEmpty(parametros.Modelo)) {
                    SQLWhere.Append($" AND PTM.Modelo LIKE '%{parametros.Modelo}%' ");
                }

                if (!string.IsNullOrEmpty(parametros.Marca)) {
                    SQLWhere.Append($" AND PTM.Marca LIKE '%{parametros.Marca}%' ");
                }

                if (!string.IsNullOrEmpty(parametros.DataCompra)) {
                    SQLWhere.Append($" AND DATE(PTM.DataCompra) = '{parametros.DataCompra}' ");
                }

                if (!string.IsNullOrEmpty(parametros.LocalCompra)) {
                    SQLWhere.Append($" AND PTM.LocalCompra LIKE '%{parametros.LocalCompra}%' ");
                }

                using (conexao = _DAO.GetConnection()){
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {                        
                        while (resultadoReader.Read()) {
                            retorno.Add(new ItemPatrimonioDTO {
                                IdEstado = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                IdItemPatrimonio  = int.Parse(resultadoReader["ID_PATRIMONIO"].ToString()),
                                NomeItemPatrimonio = resultadoReader["NomeItemPatrimonio"].ToString(),
                                DescricaoPatrimonio = resultadoReader["DescricaoPatrimonio"].ToString(),
                                Modelo = resultadoReader["Modelo"].ToString(),
                                Marca = resultadoReader["Marca"].ToString(),
                                LocalCompra = resultadoReader["LocalCompra"].ToString(),
                                DataCompra = resultadoReader["DataCompra"].ToString(),
                                ValorUnitario = resultadoReader["ValorUnitario"].ToString(),
                                Quantidade = int.Parse(resultadoReader["Quantidade"].ToString()),
                                CodigoCategoriaItem = int.Parse(resultadoReader["ID_CATEGORIAPATRIMONIO"].ToString()),
                                DescricaoCategoriaItem = resultadoReader["DescricaoCategoriaItem"].ToString(),
                                NomeArquivoCartaDoacao = resultadoReader["NomeArquivoCartaDoacao"].ToString(),
                                NomeArquivoPDFNotaFiscal = resultadoReader["NomeArquivoPDFNotaFiscal"].ToString(),
                                NomeArquivoImagemItem1 = resultadoReader["NomeArquivoImagemItem1"].ToString(),
                                NomeArquivoImagemItem2 = resultadoReader["NomeArquivoImagemItem2"].ToString(),
                                NomeArquivoImagemItem3 = resultadoReader["NomeArquivoImagemItem3"].ToString(),
                                NomeArquivoImagemItem4 = resultadoReader["NomeArquivoImagemItem4"].ToString(),
                                NomeArquivoImagemItem5 = resultadoReader["NomeArquivoImagemItem5"].ToString()                                
                            });
                        }
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}