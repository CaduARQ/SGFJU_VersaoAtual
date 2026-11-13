using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class JovemIdiomaMap : ClassMap<JovemIdioma>
    {
        public JovemIdiomaMap()
        {
            Not.LazyLoad();
            Table("SGFJU_TBL_JOVEM_IDIOMA");
            CompositeId()
              .KeyReference(x => x.Jovem, "ID_JOVEM")
              .KeyReference(x => x.Idioma, "ID_IDIOMA");
            this.References<Nivel>(x => x.Nivel)
                .Column("ID_NIVEL")
                .Cascade
                .None().Not.LazyLoad();
        }        
    }
}
