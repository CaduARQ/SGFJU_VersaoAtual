using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Common;

namespace SGFJU.Testes.LeraningTests.NHibernate
{
    [TestFixture]
    public class NHibernateLearningTests
    {
        private string connectionString;

        [SetUp]
        public void Setup()
        {
            this.connectionString = "Data Source = XE; User Id = system; Password = FJU07;"; //ConfigurationManager.AppSettings["banco"];
        }

        [Test]
        public void Consigo_Abrir_UmaSessao() {
            var factory = FluentSessionFactory.CreateFactory(this.connectionString);
            var sessaoIniciada = factory.OpenSession();
            Assert.IsTrue(sessaoIniciada.IsConnected);
        }
    }
}
