using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class PalestraMap : ClassMap<Palestra>
    {
        public PalestraMap()
        {
            this.Table("SGFJU_TBL_PALESTRA");
            this.Id(t => t.Id, "ID_PALESTRA").GeneratedBy.Assigned();
            this.Map(t => t.NomePalestra, "NomePalestra");
        }
    }
}
