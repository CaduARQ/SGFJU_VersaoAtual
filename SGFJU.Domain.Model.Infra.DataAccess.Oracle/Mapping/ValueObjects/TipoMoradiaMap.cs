using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TipoMoradiaMap : ClassMap<TipoMoradia> {
        public TipoMoradiaMap() {
            this.Table("SGFJU_TBL_TIPOMORADIA");
            this.Id(t => t.Code, "ID_TIPOMORADIA").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoTipoMoradia");
        }
    }
}
