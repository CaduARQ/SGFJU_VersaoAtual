using NHibernate;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;
using SGFJU.Domain.Model.Repositories;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation
{
    public class RepositoryImpl<TEntity> : Repository<TEntity>
        where TEntity : SGFJU.Domain.Model.Entities.Entity<TEntity>
    {
        protected ISessionFactory __sessionFactory;
        private const string NOME_CLASSE = "RepositoryImpl";

        // A SessionFactory do NHibernate é cara de construir e thread-safe: antes ela era recriada
        // a cada repositório instanciado (a cada requisição). Agora é criada uma única vez.
        private static readonly Lazy<ISessionFactory> __sharedSessionFactory =
            new Lazy<ISessionFactory>(() => FluentSessionFactory.CreateFactory(SGFJU.Domain.Model.Infra.Util.SgfjuConfig.ConnectionString));

        public RepositoryImpl() {
            __sessionFactory = __sharedSessionFactory.Value;
        }
        public virtual void Save(TEntity aggregateRoot) {
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try {
                        session.SaveOrUpdate(aggregateRoot);
                        transaction.Commit();
                    }
                    catch (Exception exception) {
                        var stack = exception.StackTrace;
                        var sourceExc = exception.Source;
                        var innerExcStr = exception.Message;
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                   $" StackTrace: {stack}: \n\n" +
                                                   $" Source: {sourceExc}  \n\n" +
                                                   $" Inner Exception: {innerExcStr} \n\n " +
                                                   "--------------------------------------";
                        transaction.Rollback();
                        string NOME_METODO = "Save";
                        var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exception.Message;
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }
        }
        public void SaveBatch(IList<TEntity> entities) {
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {
                    try {                        
                        foreach (var newEntity in entities) {
                            session.SaveOrUpdate(newEntity);
                        }
                        transaction.Commit();
                    }
                    catch (Exception exception) {
                        var mensagemErroformatada = ExceptionManager.ExceptionManager.FormatExceptionMessage(exception, "CAMADA_ORM");
                        transaction.Rollback();
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }
        }
        public void Delete(int id) {
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {                    
                    try {
                        var entityForExclude = session.Get<TEntity>(id);
                        session.Delete(entityForExclude);
                        transaction.Commit();
                    }
                    catch (Exception exception) {
                        var stack = exception.StackTrace;
                        var sourceExc = exception.Source;
                        var innerExcStr = exception.Message;
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                   $" StackTrace: {stack}: \n\n" +
                                                   $" Source: {sourceExc}  \n\n" +
                                                   $" Inner Exception: {innerExcStr} \n\n " +
                                                   "--------------------------------------";
                        transaction.Rollback();
                        string NOME_METODO = "Delete";
                        var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exception.Message;
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }
        }
        public TEntity GetByID(int id) {            
            try { 
                using (var session = __sessionFactory.OpenSession()) {
                    return session.Get<TEntity>(id);
                }
            }
            catch (Exception exception) {
                var stack = exception.StackTrace;
                var sourceExc = exception.Source;
                var innerExcStr = exception.Message;
                var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                           $" StackTrace: {stack}: \n\n" +
                                           $" Source: {sourceExc}  \n\n" +
                                           $" Inner Exception: {innerExcStr} \n\n " +
                                           "--------------------------------------";
                string NOME_METODO = "GetByID";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exception.Message;
                throw new DomainException(mensagemErroformatada);
            }
        }
        public IList<TEntity> ListAll() {
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    return session.CreateCriteria<TEntity>().List<TEntity>();
                }
            }
            catch (Exception exception) {
                var stack = exception.StackTrace;
                var sourceExc = exception.Source;
                var innerExcStr = exception.Message;
                var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                           $" StackTrace: {stack}: \n\n" +
                                           $" Source: {sourceExc}  \n\n" +
                                           $" Inner Exception: {innerExcStr} \n\n " +
                                           "--------------------------------------";
                string NOME_METODO = "ListaAll";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exception.Message;
                //throw new DomainException(mensagemErroformatada);
                throw new Exception(mensagemDetalhada);
            }
        }
        public void SaveValueObject<TValueObject>(TValueObject valueObject) where TValueObject : class {
            using (var session = __sessionFactory.OpenSession()) {
                using (var transaction = session.BeginTransaction()) {                    
                    try {
                        session.SaveOrUpdate(valueObject);
                        transaction.Commit();
                    }
                    catch (Exception exception) {
                        var stack = exception.StackTrace;
                        var sourceExc = exception.Source;
                        var innerExcStr = exception.Message;
                        var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                                   $" StackTrace: {stack}: \n\n" +
                                                   $" Source: {sourceExc}  \n\n" +
                                                   $" Inner Exception: {innerExcStr} \n\n " +
                                                   "--------------------------------------";
                        transaction.Rollback();
                        string NOME_METODO = "SaveValueObject";
                        var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exception.Message;
                        throw new DomainException(mensagemErroformatada);
                    }
                }
            }            
        }
        public IList<TValueObject> ListAllValueObjects<TValueObject>() where TValueObject : class {
            
            try {
                using (var session = __sessionFactory.OpenSession()) {
                    return session.CreateCriteria<TValueObject>().List<TValueObject>();
                }
            }
            catch (Exception exception) {
                var stack = exception.StackTrace;
                var sourceExc = exception.Source;
                var innerExcStr = exception.Message;
                var mensagemErroformatada = "Camada ORM Erro ocorrido \n\n " +
                                           $" StackTrace: {stack}: \n\n" +
                                           $" Source: {sourceExc}  \n\n" +
                                           $" Inner Exception: {innerExcStr} \n\n " +
                                           "--------------------------------------";
                string NOME_METODO = "ListAllValueObjects";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exception.Message;
                throw new DomainException(mensagemErroformatada);
            }
        }
    }
}
