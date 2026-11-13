using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TipoIgrejaMap : ClassMap<TipoIgreja>
    {
        public TipoIgrejaMap()
        {
            this.Table("SGFJU_TBL_TIPOIGREJA");
            this.Id(t => t.Code, "ID_TIPOIGREJA").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoTipoIgreja");
        }
    }
}
