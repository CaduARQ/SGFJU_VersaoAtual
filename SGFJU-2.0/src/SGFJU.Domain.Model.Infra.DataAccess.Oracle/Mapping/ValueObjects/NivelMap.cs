using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class NivelMap : ClassMap<Nivel>
    {
        public NivelMap()
        {
            this.Table("SGFJU_TBL_NIVEL");
            this.Id(t => t.Code, "ID_NIVEL").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoNivel");
        }
    }
}
