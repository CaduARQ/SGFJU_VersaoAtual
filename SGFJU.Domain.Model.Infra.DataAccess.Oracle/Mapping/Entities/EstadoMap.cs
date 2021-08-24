using System;
using System.Collections.Generic;
using System.Text;
using SGFJU.Domain.Model.Entities;
using FluentNHibernate.Mapping;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class EstadoMap : ClassMap<Estado>{
        public EstadoMap() {
            this.Table("SGFJU_TBL_ESTADO");
            this.Id(t => t.Id, "ID_ESTADO").GeneratedBy.Identity();
            this.Map(t => t.NomeEstado);
            this.Map(t => t.SiglaEstado);
        }
    }
}
