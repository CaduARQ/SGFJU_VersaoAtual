using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using confDefault = System.Configuration;

using SGFJU.Domain.Model.Entities;

using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities;
using SGFJU.Domain.Model.DomainExceptions;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Common
{
    public static class FluentSessionFactory
    {
        private const string NOME_CLASSE = "FluentSessionFactory";
        public static ISessionFactory CreateFactory(string connectionString)
        {
            try
            {
                return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                //.Database(
                //    OracleClientConfiguration.Oracle10.ConnectionString(connectionString)
                //                                      .Provider<NHibernate.Connection.DriverConnectionProvider>()
                // )
                .Mappings(
                    m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetAssembly(typeof(EstadoMap)))
                    .AddFromAssembly(Assembly.GetAssembly(typeof(Estado)))
                )
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
            }
            catch (HibernateException ORM_TierException)
            {
                string NOME_METODO = "CreateFactory";
                var mensagemDetalhada = $"ORM_tIER.{NOME_CLASSE}.{NOME_METODO} - " + ORM_TierException.Message;
                throw new DomainException(mensagemDetalhada);
            }
            catch (Exception repositoryException)
            {
                string NOME_METODO = "CreateFactory";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + repositoryException.Message;
                throw new DomainException(mensagemDetalhada);
            }
        }

        private static void BuildSchema(Configuration config)
        {
            SchemaExport schema = new SchemaExport(config);
            SchemaUpdate schemaUpdate = new SchemaUpdate(config);

            try
            {
                //schema.Drop(false, true);
                //schema.Create(false, true);

                //schemaUpdate.Execute(false, true);
            }
            catch (HibernateException ORM_TierException)
            {
                string NOME_METODO = "CreateFactory";
                var mensagemDetalhada = $"ORM_tIER.{NOME_CLASSE}.{NOME_METODO} - " + ORM_TierException.Message;
                throw new DomainException(mensagemDetalhada);
            }
            catch (Exception repositoryException)
            {
                string NOME_METODO = "CreateFactory";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + repositoryException.Message;
                throw new DomainException(mensagemDetalhada);
            }

            //SchemaUpdate schemaUpdate = new SchemaUpdate(config);
            //schemaUpdate.Execute(false, true);
        }
    }
}
