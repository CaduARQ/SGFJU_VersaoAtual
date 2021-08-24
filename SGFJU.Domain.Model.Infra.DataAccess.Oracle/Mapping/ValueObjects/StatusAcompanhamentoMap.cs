using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class StatusAcompanhamentoMap : ClassMap<StatusAcompanhamento> {
        public StatusAcompanhamentoMap() {
            this.Table("SGFJU_TBL_STATUSACOMPANHAMENTO");
            this.Id(t => t.Codigo, "ID_STATUSACOMPANHAMENTO").GeneratedBy.Assigned();
            this.Map(t => t.Descricao, "DescricaoStatusAcompanhamento");
        }
    }
}
