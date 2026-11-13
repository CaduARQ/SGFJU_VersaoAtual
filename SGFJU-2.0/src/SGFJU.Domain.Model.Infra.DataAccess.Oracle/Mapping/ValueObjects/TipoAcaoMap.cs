using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TipoAcaoMap : ClassMap<TipoAcao>
    {
        public TipoAcaoMap()
        {
            this.Table("SGFJU_TBL_TIPOACAO");
            this.Id(t => t.Code, "ID_TIPOACAO").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoTipoAcao");
        }
    }
}
