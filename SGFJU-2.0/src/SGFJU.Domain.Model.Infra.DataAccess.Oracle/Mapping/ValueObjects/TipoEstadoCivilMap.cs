using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using SGFJU.Domain.Model.ValueObjects;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TipoEstadoCivilMap : ClassMap<TipoEstadoCivil> {
        public TipoEstadoCivilMap() {
            this.Table("SGFJU_TBL_TIPOESTADOCIVIL");
            this.Id(t => t.Code, "ID_TIPOESTADOCIVIL").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoTipoEstadoCivil");
        }
    }
}
