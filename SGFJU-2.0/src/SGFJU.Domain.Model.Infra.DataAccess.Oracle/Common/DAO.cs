using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.DomainExceptions;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Common
{
    public class DAO
    {
        private string __stringConnection;
        public DAO()
        {
            this.__stringConnection = SGFJU.Domain.Model.Infra.Util.SgfjuConfig.ConnectionString;
        }

        public MySqlConnection GetConnection() {
            try {
                return new MySqlConnection { ConnectionString = this.__stringConnection };
            }
            catch (MySqlException excSpecificMySqlDB) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(excSpecificMySqlDB, "GetConnection", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
            catch (Exception exc) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exc, "GetConnection", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
        }
        public MySqlDataReader ExecuteQuery(string sqlQuery, ref MySqlConnection connectionToBeUsed) {
            try {
                var command = connectionToBeUsed.CreateCommand();
                command.CommandText = sqlQuery;
                command.CommandTimeout = 99999; 

                return command.ExecuteReader();
            }
            catch (MySqlException excSpecificMySqlDB) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(excSpecificMySqlDB, "ExecuteQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
            catch (Exception exc) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exc, "ExecuteQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
        }
        public void ExecuteNonQuery(string sqlQuery) {
            try {
                using (var conexao = new MySqlConnection { ConnectionString = this.__stringConnection }) {
                    conexao.Open();
                    var command = conexao.CreateCommand();
                    var transaction = conexao.BeginTransaction();

                    command.CommandText = sqlQuery;
                    command.Transaction = transaction;

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
            catch (MySqlException excSpecificMySqlDB) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(excSpecificMySqlDB, "ExecuteNonQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
            catch (Exception exc) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exc, "ExecuteNonQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
        }

        public void ExecuteNonQuery(IList<string> commands) {
            try {
                using (var conexao = new MySqlConnection { ConnectionString = this.__stringConnection }) {
                    conexao.Open();
                    var command = conexao.CreateCommand();
                    var transaction = conexao.BeginTransaction();
                    try {
                        foreach (var SQLCmd in commands) {
                            command.CommandText = SQLCmd;
                            command.Transaction = transaction;

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (MySqlException excSpecificMySqlDB) {
                        transaction.Rollback();
                        var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(excSpecificMySqlDB, "ExecuteNonQuery", "CAMADA_ORM.DAO");
                        throw new DomainException(mensagemErroformatada);
                    }
                    catch (Exception exc) {
                        transaction.Rollback();
                        var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exc, "ExecuteNonQuery", "CAMADA_ORM.DAO");
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }
            catch (Exception objException) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(objException, "ExecuteNonQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
        }
        public void ExecuteNonQuery(MySqlConnection conexaoAtiva, IList<string> commands) {
            try {
                var command = conexaoAtiva.CreateCommand();
                var transaction = conexaoAtiva.BeginTransaction();

                foreach (var SQLCmd in commands)
                {
                    command.CommandText = SQLCmd;
                    command.Transaction = transaction;

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (MySqlException excSpecificMySqlDB) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(excSpecificMySqlDB, "ExecuteNonQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
            catch (Exception exc) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exc, "ExecuteNonQuery", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
        }

        public void ExecuteNonqueryProcedure(string nomeProcedure, IList<KeyValuePair<string, string>> parametrosEValores) {
            try {
                using (var conexao = new MySqlConnection { ConnectionString = this.__stringConnection }) {
                    conexao.Open();

                    var command = conexao.CreateCommand();
                    var transaction = conexao.BeginTransaction();

                    command.CommandText = nomeProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;

                    if (parametrosEValores.Count > 0) {
                        foreach (var parametro in parametrosEValores) {
                            command.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }
                    }

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
            catch (MySqlException excSpecificMySqlDB) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(excSpecificMySqlDB, "ExecuteNonqueryProcedure", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
            catch (Exception exc) {
                var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exc, "ExecuteNonqueryProcedure", "CAMADA_ORM.DAO");
                throw new DomainException(mensagemErroformatada);
            }
        }
    }
}
