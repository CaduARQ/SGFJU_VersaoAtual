using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class BlocoMap : ClassMap<Bloco>
    {
        public BlocoMap()
        {
            this.Table("SGFJU_TBL_BLOCO");
            this.Id(t => t.Id, "ID_BLOCO").GeneratedBy.Identity();
            this.Map(t => t.NomeBloco);
            this.References<Estado>(t => t.EstadoBloco)
                .Column("ID_ESTADO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
