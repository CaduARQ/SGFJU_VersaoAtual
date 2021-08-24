using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class DashboardArvoreVidaMap : ClassMap<DashboardArvoreVida>
    {
        public DashboardArvoreVidaMap()
        {
            this.Table("SGFJU_TBL_DASHBOARD_ARVOREVIDA_ESTADO");
            this.Id(t => t.Id, "ID_TOTAIS_AV_ESTADO").GeneratedBy.Identity();
            this.Map(r => r.QuantidadeJovens);
            this.Map(r => r.QuantidadeObreiros);
            this.Map(r => r.QuantidadeObreirosQueAcompanham);
            this.Map(r => r.QuantidadeJovensAcompanhados);
            this.Map(r => r.QuantidadeJovensSemAcompanhamento);
            this.Map(r => r.MediaAcompanhamentoJovensPorObreiro);
            this.References<Estado>(r => r.EstadoRelatorio)
                .Column("ID_ESTADO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
