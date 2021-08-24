using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class RegiaoMap : ClassMap<Regiao>
    {
        public RegiaoMap()
        {
            this.Table("SGFJU_TBL_REGIAO");
            this.Id(t => t.Id, "ID_REGIAO").GeneratedBy.Identity();
            this.Map(t => t.NomeRegiao);
            this.HasMany(x => x.Igrejas)
                .Access
                .CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan().Not.LazyLoad()
                .AsBag();
            this.References<Bloco>(t => t.BlocoRegiao)
                .Column("ID_BLOCO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
