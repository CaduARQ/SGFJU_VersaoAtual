using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class JovemHistoricoMap : ClassMap<JovemHistorico>
    {
        public JovemHistoricoMap()
        {
            Not.LazyLoad();
            this.Table("SGFJU_TBL_ARVOREVIDA_HISTORICOACOMPANHAMENTO");
            this.CompositeId()
                .KeyReference(t => t.Jovem, "ID_JOVEM")
                .KeyReference(T => T.Obreiro, "ID_OBREIRO");
            this.Map(x => x.TextoObservacao);
            this.Map(x => x.DataHistoricoAcompanhamento);
            this.References<StatusAcompanhamento>(t => t.StatusJovem)
                .Column("ID_STATUSACOMPANHAMENTO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
