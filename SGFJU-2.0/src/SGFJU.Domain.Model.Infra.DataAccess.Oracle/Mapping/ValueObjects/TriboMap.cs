using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TriboMap : ClassMap<Tribo>
    {
        public TriboMap()
        {
            this.Table("SGFJU_TBL_TRIBO");
            this.Id(t => t.Code, "ID_TRIBO").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "NomeTribo");
        }
    }
}
