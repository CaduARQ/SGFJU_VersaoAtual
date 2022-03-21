using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class IgrejaMap : ClassMap<Igreja>
    {
        public IgrejaMap()
        {
            this.Table("SGFJU_TBL_IGREJA");
            this.Id(t => t.Id, "ID_IGREJA").GeneratedBy.Identity();
            this.Map(t => t.NomeIgreja);
            this.References<Regiao>(t => t.RegiaoIgreja)
                .Column("ID_REGIAO")
                .Cascade
                .None()
                .Not
                .LazyLoad();

            this.References<Bloco>(t => t.TipoIgreja)
                .Column("ID_TIPOIGREJA")
                .Cascade
                .None()
                .Not
                .LazyLoad();

            HasMany(x => x.IgrejaQueCoordena)
                .AsBag()
                .Cascade.All()
                .Inverse()
                .Table("SGFJU_TBL_IGREJA_COORDENADOR");
        }
    }
}
