using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            this.Table("SGFJU_TBL_LIVRO");
            this.Id(t => t.Code, "ID_LIVRO").GeneratedBy.Identity();
            this.Map(t => t.NomeLivro);
            HasManyToMany(x => x.JovensQueLeram)
                .Cascade.None()
                .Inverse()
                .Table("SGFJU_TBL_JOVEM_LIVROLIDO");
        }
    }
}
