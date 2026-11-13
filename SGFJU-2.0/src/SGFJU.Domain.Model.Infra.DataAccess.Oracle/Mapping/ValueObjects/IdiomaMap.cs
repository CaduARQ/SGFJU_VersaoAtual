using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class IdiomaMap : ClassMap<Idioma>
    {
        public IdiomaMap()
        {
                      
            this.Table("SGFJU_TBL_IDIOMA");
            this.Id(t => t.Code, "ID_IDIOMA").GeneratedBy.Identity();
            this.Map(t => t.NomeIdioma);
            HasMany(x => x.IdiomasQueOJovemFala)
                .AsBag()
                .Cascade.All()
                .Inverse()
                .Table("SGFJU_TBL_JOVEM_IDIOMA");        
        }
    }
}
