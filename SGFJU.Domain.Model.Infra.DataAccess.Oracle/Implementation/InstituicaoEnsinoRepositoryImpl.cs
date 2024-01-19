using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class InstituicaoEnsinoRepositoryImpl : RepositoryImpl<InstituicaoEnsino>, InstituicaoEnsinoRepository
    {
        public IList<InstituicaoEnsinoDTO> ListarPorParametro(ParametroPesquisaInstituicaoEnsinoDTO parametroPesquisa)
        {

            try
            {
                var _DAO = new DAO();
                var SQLQuery = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var retorno = new List<InstituicaoEnsinoDTO>();

                SQLQuery.Append("SELECT IE.ID_INSTITUICAOENSINO,  ");
                SQLQuery.Append("       IE.NomeInstituicaoEnsino, ");
                SQLQuery.Append("       IE.Endereco,              ");
                SQLQuery.Append("       IE.Contato,");
                SQLQuery.Append("       IE.NomeContato,");
                SQLQuery.Append("       IE.FuncaoContatoInstituicaoEnsino,");
                SQLQuery.Append("       ED.ID_ESTADO,");
                SQLQuery.Append("       ED.NOMEESTADO,");
                SQLQuery.Append("       BL.ID_BLOCO,");
                SQLQuery.Append("       BL.NOMEBLOCO,");
                SQLQuery.Append("       REG.ID_REGIAO,");
                SQLQuery.Append("       REG.NOMEREGIAO,");
                SQLQuery.Append("       IE.ID_IGREJA,");
                SQLQuery.Append("       IGJ.NOMEIGREJA,");
                SQLQuery.Append("       IE.ID_PERFIL_INSTITUICAO_ENSINO,");
                SQLQuery.Append("       PE.DescricaoPerfilInstituicaoEnsino,");
                SQLQuery.Append("       IE.ID_TIPO_INSTITUICAO_ENSINO,");
                SQLQuery.Append("       TIE.DescricaoTipoInstituicaoEnsino,");
                SQLQuery.Append("       IE.ID_CLASSIFICACAO_INSTITUICAO_ENSINO,");
                SQLQuery.Append("       CIE.DescricaoClassificacaoInstituicaoEnsino");
                SQLQuery.Append("  FROM SGFJU_DEV.SGFJU_TBL_INSTITUICAOENSINO IE ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_IGREJA IGJ    ");
                SQLQuery.Append("			ON IE.ID_IGREJA = IGJ.ID_IGREJA      ");
                SQLQuery.Append("	INNER JOIN sgfju_dev.SGFJU_TBL_REGIAO REG    ");
                SQLQuery.Append("			ON IGJ.ID_REGIAO = REG.ID_REGIAO     ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_BLOCO  BL     ");
                SQLQuery.Append("		   ON REG.ID_BLOCO = BL.ID_BLOCO         ");
                SQLQuery.Append("   INNER JOIN sgfju_dev.SGFJU_TBL_ESTADO ED     ");
                SQLQuery.Append("		   ON BL.ID_ESTADO = ED.ID_ESTADO        ");
                SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_PERFILINSTITUICAOENSINO PE ");
                SQLQuery.Append("         ON IE.ID_PERFIL_INSTITUICAO_ENSINO = PE.ID_PERFIL_INSTITUICAO_ENSINO ");
                SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_TIPOINSTITUICAOENSINO TIE ");
                SQLQuery.Append("         ON IE.ID_TIPO_INSTITUICAO_ENSINO = TIE.ID_TIPO_INSTITUICAO_ENSINO ");
                SQLQuery.Append(" INNER JOIN SGFJU_DEV.SGFJU_TBL_CLASSIFICACAOINSTITUICAOENSINO CIE ");
                SQLQuery.Append("         ON IE.ID_CLASSIFICACAO_INSTITUICAO_ENSINO = CIE.ID_CLASSIFICACAO_INSTITUICAO_ENSINO ");
                SQLQuery.Append(" WHERE 1=1 ");

                if (parametroPesquisa.IdEstado > 0)
                    SQLQuery.Append($" AND ED.ID_ESTADO = {parametroPesquisa.IdEstado} ");

                if (parametroPesquisa.IdBloco != 0)
                    SQLQuery.Append(" AND BL.ID_BLOCO = " + parametroPesquisa.IdBloco.ToString() + " ");                

                if (parametroPesquisa.IdRegiao != 0) 
                    SQLQuery.Append(" AND REG.ID_REGIAO = " + parametroPesquisa.IdRegiao.ToString() + " ");                

                if (parametroPesquisa.IdIgreja != 0) 
                    SQLQuery.Append(" AND IGJ.ID_IGREJA = " + parametroPesquisa.IdIgreja.ToString() + " ");
                //
                if (parametroPesquisa.IdInstituicaoEnsino > 0)
                    SQLQuery.Append($" AND IE.ID_INSTITUICAOENSINO = {parametroPesquisa.IdInstituicaoEnsino} ");

                if (parametroPesquisa.IdTipoInstituicao > 0)
                    SQLQuery.Append($" AND TIE.ID_TIPO_INSTITUICAO_ENSINO = {parametroPesquisa.IdTipoInstituicao}");

                if (parametroPesquisa.IdPerfilInstituicao > 0)
                    SQLQuery.Append($" AND PE.ID_PERFIL_INSTITUICAO_ENSINO = {parametroPesquisa.IdPerfilInstituicao}");

                if (parametroPesquisa.IdClassificacaoInstituicao > 0)
                    SQLQuery.Append($" AND IE.ID_CLASSIFICACAO_INSTITUICAO_ENSINO = {parametroPesquisa.IdClassificacaoInstituicao}");

                if (!string.IsNullOrEmpty(parametroPesquisa.FuncaoContatoInstituicaoEnsino))
                    SQLQuery.Append($" AND PE.FuncaoContatoInstituicaoEnsino = '{parametroPesquisa.FuncaoContatoInstituicaoEnsino}'");

                using (conexao = _DAO.GetConnection())
                {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString(), ref conexao))
                    {
                        if (resultadoReader.HasRows)
                            while (resultadoReader.Read())
                            {
                                retorno.Add(new InstituicaoEnsinoDTO
                                {
                                    IdInstituicaoEnsino = int.Parse(resultadoReader["ID_INSTITUICAOENSINO"].ToString()),
                                    NomeInstituicaoEnsino = resultadoReader["NomeInstituicaoEnsino"].ToString(),
                                    Endereco = resultadoReader["Endereco"].ToString(),
                                    Contato = resultadoReader["Contato"].ToString(),
                                    NomeContato = resultadoReader["NomeContato"].ToString(),
                                    FuncaoContatoInstituicaoEnsino = resultadoReader["FuncaoContatoInstituicaoEnsino"].ToString(),
                                    IdEstadoInstituicao = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                    NomeEstadoInstituicao = resultadoReader["NOMEESTADO"].ToString(),
                                    IdBlocoInstituicao = int.Parse(resultadoReader["ID_BLOCO"].ToString()),
                                    NomeBlocoInstituicao = resultadoReader["NOMEBLOCO"].ToString(),
                                    IdRegiaoInstituicao = int.Parse(resultadoReader["ID_REGIAO"].ToString()),
                                    NomeRegiaoInstituicao = resultadoReader["NOMEREGIAO"].ToString(),
                                    IdIgrejaInstituicao = int.Parse(resultadoReader["ID_IGREJA"].ToString()),
                                    NomeIgrejaInstituicao = resultadoReader["NOMEIGREJA"].ToString(),
                                    IdPerfilInstituicao = int.Parse(resultadoReader["ID_PERFIL_INSTITUICAO_ENSINO"].ToString()),
                                    DescricaoPerfilInstituicao = resultadoReader["DescricaoPerfilInstituicaoEnsino"].ToString(),
                                    IdTipoInstituicao = int.Parse(resultadoReader["ID_TIPO_INSTITUICAO_ENSINO"].ToString()),
                                    DescricaoTipoInstituicao = resultadoReader["DescricaoTipoInstituicaoEnsino"].ToString(),
                                    IdClassificacaoInstituicao = int.Parse(resultadoReader["ID_CLASSIFICACAO_INSTITUICAO_ENSINO"].ToString()),
                                    DescricaoClassificacaoInstituicao = resultadoReader["DescricaoClassificacaoInstituicaoEnsino"].ToString()
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

        public RespostaRequisicaoDTO ExcluirInstituicaoEnsino(InstituicaoEnsinoDTO instituicaoASerExcluida)
        {
            try
            {
                var _DAO = new DAO();
                var comandosDeExclusao = new List<string> {
                    $"DELETE FROM SGFJU_DEV.SGFJU_TBL_INSTITUICAOENSINO WHERE ID_INSTITUICAOENSINO = {instituicaoASerExcluida.IdInstituicaoEnsino};"
                };

                _DAO.ExecuteNonQuery(comandosDeExclusao);

                return new RespostaRequisicaoDTO { MensagemRespostaRequisicao = "Instituição excluida com sucesso!", RequisicaoBemSucedida = true };
            }
            catch (Exception dataException)
            {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
    }
}
