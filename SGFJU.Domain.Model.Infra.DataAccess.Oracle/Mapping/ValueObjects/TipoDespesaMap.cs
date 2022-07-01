using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TipoDespesaMap : ClassMap<TipoDespesa>
    {
        public TipoDespesaMap()
        {
            this.Table("SGFJU_TBL_TIPODESPESA");
            this.Id(t => t.Code, "ID_TIPODESPESA").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoTipoDespesa");
        }
    }
}
