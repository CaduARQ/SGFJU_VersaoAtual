using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class ProjetoMap : ClassMap<Projeto>
    {
        public ProjetoMap()
        {
            this.Table("SGFJU_TBL_PROJETO");
            this.Id(t => t.Code, "ID_PROJETO").GeneratedBy.Identity();
            this.Map(T => T.NomeProjeto);
            this.HasMany(x => x.Departamentos)
                .Access
                .CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan().Not.LazyLoad()
                .AsBag();
            HasMany(x => x.ProjetosAosQuaisJovemEstaLigado)
                .AsBag()
                .Cascade.All()
                .Inverse()
                .Table("SGFJU_TBL_JOVEM_PROJETO");
        }
    }
}
