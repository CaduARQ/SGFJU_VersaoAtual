using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TestemunhoMap : ClassMap<Testemunho>
    {
        public TestemunhoMap()
        {
            this.Table("SGFJU_TBL_TESTEMUNHO");
            this.Id(t => t.Code, "ID_TESTEMUNHO").GeneratedBy.Identity();
            this.Map(t => t.SofreuComDepressao);
            this.Map(t => t.TempoSofreuDepressao);
            this.Map(t => t.TempoLivreDepressao);
            this.Map(t => t.SofreuAutomutilacao);
            this.Map(t => t.TempoSofreuAutomutilacao);
            this.Map(t => t.TempoLivreAutomutilacao);
            this.Map(t => t.SofreuVicio);
            this.Map(t => t.DescricaoVicio);
            this.Map(t => t.TempoVicio);
            this.Map(t => t.TempoLivreVicios);
            this.Map(t => t.TentouSuicidio);
            this.Map(t => t.NumeroTentativasSuicidio);
            this.Map(t => t.MesAnoTentativaSuicidio);
            this.Map(t => t.DescricaoTentativaSuicidio);
            this.Map(t => t.TextoTestemunho);
            this.References<Jovem>(t => t.JovemTestemunho)
                .Column("ID_JOVEM")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
