using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class PatrimonioHistoricoMap : ClassMap<PatrimonioHistorico>
    {
        public PatrimonioHistoricoMap()
        {
            Not.LazyLoad();
            this.Table("SGFJU_TBL_HISTORICO_ITEM_PATRIMONIO");
            this.CompositeId()
                .KeyReference(t => t.ItemPatrimonio, "ID_PATRIMONIO");

            this.Map(x => x.DataHistoricoPatrimonio);
            this.Map(x => x.DescricaoHistorico);

        }
    }
}
