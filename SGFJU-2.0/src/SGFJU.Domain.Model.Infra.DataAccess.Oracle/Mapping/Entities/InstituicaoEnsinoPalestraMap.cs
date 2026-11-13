using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class InstituicaoEnsinoPalestraMap : ClassMap<InstituicaoEnsinoPalestra>
    {
        public InstituicaoEnsinoPalestraMap()
        {
            Not.LazyLoad();
            Table("SGFJU_TBL_INSTITUICAOENSINO_PALESTRA");
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
