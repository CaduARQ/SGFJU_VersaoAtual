using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class JovemHabilidadeProjetoMap : ClassMap<JovemHabilidadeProjeto>
    {
        public JovemHabilidadeProjetoMap()
        {
            Not.LazyLoad();
            this.Table("SGFJU_TBL_JOVEM_HABILIDADE");
            this.CompositeId()
                .KeyReference(t => t.Jovem, "ID_JOVEM")
                .KeyReference(T => T.Habilidade, "ID_HABILIDADE");
            this.References<Nivel>(t => t.Nivel)
                .Column("ID_NIVEL")
                .Cascade
                .None().Not.LazyLoad();
        }
    }
}
