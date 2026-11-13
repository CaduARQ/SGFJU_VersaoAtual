using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Repositories;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SGFJU.Domain.Model.DomainExceptions;
using NHibernate;
using SGFJU.ServicesLayer.DTO;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using MySql.Data.MySqlClient;
using SGFJU.Domain.Model.Infra.Security;
using System.Globalization;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class UsuarioRepositoryImpl : RepositoryImpl<Usuario>, UsuarioRepository
    {
        private const string NOME_CLASSE = "UsuarioRepositoryImpl";

        public UsuarioDTO RetornaUsuario(UsuarioDTO usuarioParametro) {
            try {
                UsuarioDTO retorno = null;
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                var _DAO = new DAO();
                var comandosDeAtualizacao = new List<string>();
                var SQLQuery = new StringBuilder();
                

                SQLQuery.Append("  SELECT *                           ");
                SQLQuery.Append("	 FROM sgfju_dev.SGFJU_TBL_USUARIO ");

                var SQLWhere = new StringBuilder();
                SQLWhere.Append(" WHERE 1 = 1 AND ID_USUARIO = " + EncryptionHelper.Decrypt(usuarioParametro.IdUsuarioX) );

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();

                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            retorno = new UsuarioDTO {
                                IdUsuario = int.Parse(resultadoReader["ID_USUARIO"].ToString()),
                                IdUsuarioX = usuarioParametro.IdUsuarioX,
                                NomeUsuario = resultadoReader["NOMEUSUARIO"].ToString(),
                                Login = resultadoReader["LOGIN"].ToString(),
                                Pwd = null, // senha nunca é devolvida ao navegador
                                IdPerfilUsuario = int.Parse(resultadoReader["ID_PERFILUSUARIO"].ToString()),
                                PathImagemUsuario = resultadoReader["NOMEARQUIVOPERFIL"].ToString(),
                                IdEstadoUsuario = int.Parse(resultadoReader["ID_ESTADO"].ToString()),
                                IdBloco = (!string.IsNullOrEmpty(resultadoReader["ID_BLOCO"].ToString()))? int.Parse(resultadoReader["ID_BLOCO"].ToString()):0,
                                IdRegiao = (!string.IsNullOrEmpty(resultadoReader["ID_REGIAO"].ToString())) ? int.Parse(resultadoReader["ID_REGIAO"].ToString()):0,
                                IdIgreja = (!string.IsNullOrEmpty(resultadoReader["ID_IGREJA"].ToString())) ? int.Parse(resultadoReader["ID_IGREJA"].ToString()) : 0,
                            };
                        }

                        resultadoReader.Close();
                    }
                }

                return retorno;
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "obterIgrejasDaRegiao", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }
        public void RegistraUsuario(Usuario usuarioNovo) { 
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try {
                        var data = DateTime.Now.ToString("yyyy-MM-dd");
                        var hora = DateTime.Now.Hour.ToString();
                        var siglaEstado = usuarioNovo.EstadoUsuario.SiglaEstado;

                        session.SaveOrUpdate(usuarioNovo);

                        usuarioNovo.NomeArquivoPerfil = $"{siglaEstado}_ID_USUARIO_{usuarioNovo.Id}_{data}{hora}{usuarioNovo.NomeArquivoPerfil}";

                        session.SaveOrUpdate(usuarioNovo);

                        transaction.Commit();
                    }
                    catch (Exception dataException) {
                        var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                        throw new DomainException(mensagemTratada, dataException);
                    }
                }
            }
        }
        public Usuario Logar(string login, string password) {
            
            try {
                using (var session = __sessionFactory.OpenSession()) {

                    var criteria = session.CreateCriteria<Usuario>();
                    criteria.Add(Restrictions.Eq("Login", login));
                    criteria.Add(Restrictions.Eq("Senha", password));
                    return criteria.UniqueResult<Usuario>();
                }
            }
            catch (HibernateException ORM_TierException) {
                string NOME_METODO = "Logar";
                var mensagemDetalhada = $"ORM_tIER.{NOME_CLASSE}.{NOME_METODO} - " + ORM_TierException.Message;
                throw new DomainException(mensagemDetalhada);
            }
            catch (Exception repositoryException) {
                string NOME_METODO = "Logar";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + repositoryException.Message;
                throw new DomainException(mensagemDetalhada);
            }
        }

        public bool LoginJaCadastrado(string pLogin) {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    var criteria = session.CreateCriteria<Usuario>();
                    criteria.Add(Restrictions.Like("Login", pLogin));
                    return (criteria.UniqueResult<Usuario>() != null ? true:false);
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                var erroMessage = string.Format("{0}.{1} - {2}", this.GetType().Name, "ObterJovemInformacoesDetalhadas", dataException.Message);
                throw new DomainException(erroMessage, dataException);
            }
        }

        public IList<UsuarioDTO> RetornaUsuariosEstado(Estado estadoParametro) {
            try {
                using (var session = __sessionFactory.OpenSession()) {

                    var criteria = session.CreateCriteria<Usuario>();
                    criteria.Add(Restrictions.Eq("EstadoUsuario.Id", estadoParametro.Id));
                    return criteria.List<Usuario>()
                                   .Select(u => new UsuarioDTO {
                                       IdUsuario = u.Id,
                                       IdUsuarioX = EncryptionHelper.Encrypt(u.Id.ToString()),
                                       NomeUsuario = u.NomeUsuario,
                                       Login = u.Login,
                                       Pwd = null, // senha nunca é devolvida ao navegador
                                       IdPerfilUsuario = u.PerfilUsuario.Code,
                                       NomePerfil = u.PerfilUsuario.Descricao,
                                       PathImagemUsuario = u.NomeArquivoPerfil,
                                       IdBloco = (u.BlocoUsuario != null)? u.BlocoUsuario.Id:0,
                                       NomeBlocoUsuario = (u.BlocoUsuario != null) ? u.BlocoUsuario.NomeBloco : "",
                                       IdRegiao = (u.RegiaoUsuario != null)? u.RegiaoUsuario.Id:0,
                                       NomeRegiaoUsuario = (u.RegiaoUsuario != null) ? u.RegiaoUsuario.NomeRegiao : "",
                                       IdEstadoUsuario = u.EstadoUsuario.Id,
                                       NomeEstadoUsuario = u.EstadoUsuario.NomeEstado
                                   }).ToList();
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public IList<UsuarioDTO> RetornaUsuariosBloco(Bloco blocoParametro) { 
            try {
                using (var session = __sessionFactory.OpenSession()) {

                    var criteria = session.CreateCriteria<Usuario>();
                    criteria.Add(Restrictions.Eq("BlocoUsuario.Id", blocoParametro.Id));
                    return criteria.List<Usuario>()
                                   .Select(u => new UsuarioDTO {
                                       IdUsuario = u.Id,
                                       NomeUsuario = u.NomeUsuario,
                                       Login = u.Login,
                                       Pwd = null, // senha nunca é devolvida ao navegador
                                       IdPerfilUsuario = u.PerfilUsuario.Code,
                                       NomePerfil = u.PerfilUsuario.Descricao,
                                       PathImagemUsuario = u.NomeArquivoPerfil,
                                       IdBloco = (u.BlocoUsuario != null)? u.BlocoUsuario.Id:0,
                                       IdRegiao = (u.RegiaoUsuario != null)? u.RegiaoUsuario.Id:0,
                                       IdEstadoUsuario = u.EstadoUsuario.Id,
                                       NomeEstadoUsuario = u.EstadoUsuario.NomeEstado
                                   }).ToList();
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }
        public IList<UsuarioDTO> RetornaUsuariosRegiao(Regiao regiaoParametro) { 
            try {
                using (var session = __sessionFactory.OpenSession()) {

                    var criteria = session.CreateCriteria<Usuario>();
                    criteria.Add(Restrictions.Eq("RegiaoUsuario.Id", regiaoParametro.Id));
                    return criteria.List<Usuario>()
                                   .Select(u => new UsuarioDTO {
                                       IdUsuario = u.Id,
                                       NomeUsuario = u.NomeUsuario,
                                       Login = u.Login,
                                       Pwd = null, // senha nunca é devolvida ao navegador
                                       IdPerfilUsuario = u.PerfilUsuario.Code,
                                       NomePerfil = u.PerfilUsuario.Descricao,
                                       PathImagemUsuario = u.NomeArquivoPerfil,
                                       IdBloco = (u.BlocoUsuario != null)? u.BlocoUsuario.Id:0,
                                       IdRegiao = (u.RegiaoUsuario != null)? u.RegiaoUsuario.Id:0,
                                       IdEstadoUsuario = u.EstadoUsuario.Id,
                                       NomeEstadoUsuario = u.EstadoUsuario.NomeEstado
                                   }).ToList();
                }
            }
            catch (Exception dataException) {
                var mensagemTratada = ExceptionManager.ExceptionManager.FormatExceptionMessage(dataException, "CAMADA_ORM");
                throw new DomainException(mensagemTratada, dataException);
            }
        }

        public IList<UsuarioDTO> PesquisaUsuariosPorParametro(PesquisaGeralDTO parametroPesquisa) {
            try {
                var retorno = new List<UsuarioDTO>();
                var _DAO = new DAO();
                var tinfo = CultureInfo.CurrentCulture.TextInfo;
                var SQLQuery = new StringBuilder();
                var SQLWhere = new StringBuilder();
                MySqlConnection conexao = null;
                MySqlDataReader resultadoReader = null;
                SQLWhere.Append(" WHERE 1 = 1 ");

                SQLQuery.Append("SELECT U.*, PU.* FROM SGFJU_DEV.SGFJU_TBL_USUARIO U INNER JOIN SGFJU_DEV.SGFJU_TBL_PERFILUSUARIO PU ON U.ID_PERFILUSUARIO = PU.ID_PERFILUSUARIO ");

                if (parametroPesquisa.IdEstado != 0) {
                    SQLWhere.Append(" AND ID_ESTADO = " + parametroPesquisa.IdEstado);
                }

                if (parametroPesquisa.IdBloco != 0) {
                    SQLWhere.Append(" AND ID_BLOCO = " + parametroPesquisa.IdBloco);
                }

                if (parametroPesquisa.IdRegiao != 0) {
                    SQLWhere.Append(" AND ID_REGIAO = " + parametroPesquisa.IdRegiao);
                }

                using (conexao = _DAO.GetConnection()) {
                    conexao.Open();
                    using (resultadoReader = _DAO.ExecuteQuery(SQLQuery.ToString() + SQLWhere.ToString(), ref conexao)) {
                        while (resultadoReader.Read()) {
                            retorno.Add(new UsuarioDTO {
                                IdUsuarioX = EncryptionHelper.Encrypt(resultadoReader["ID_USUARIO"].ToString()),
                                IdUsuario = int.Parse(resultadoReader["ID_USUARIO"].ToString()),
                                NomeUsuario = resultadoReader["NOMEUSUARIO"].ToString(),
                                Login = resultadoReader["LOGIN"].ToString(),
                                IdPerfilUsuario = int.Parse(resultadoReader["ID_PERFILUSUARIO"].ToString()),
                                NomePerfil = resultadoReader["NOMEPERFILUSUARIO"].ToString(),
                                PathImagemUsuario = resultadoReader["NOMEARQUIVOPERFIL"].ToString(),
                                IdBloco = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("ID_BLOCO"))) ?
                                                              int.Parse(resultadoReader["ID_BLOCO"].ToString()) :
                                                              0,
                                IdRegiao = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("ID_REGIAO"))) ?
                                                              int.Parse(resultadoReader["ID_REGIAO"].ToString()) :
                                                              0,
                                IdEstadoUsuario = (!resultadoReader.IsDBNull(resultadoReader.GetOrdinal("ID_ESTADO"))) ?
                                                              int.Parse(resultadoReader["ID_ESTADO"].ToString()) :
                                                              0
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
