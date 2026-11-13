using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class DashboardRelatorioMap : ClassMap<DashboardRelatorio> {
        public DashboardRelatorioMap() {
            this.Table("SGFJU_TBL_RELATORIO_DASHBOARD_ESTADO");
            this.Id(t => t.Id, "ID_TOTAIS_ESTADO").GeneratedBy.Identity();
            this.Map(r => r.QuantidadeTotalJovens);
            this.Map(r => r.QuantidadeTotalJovensAtivos);
            this.Map(r => r.QuantidadeTotalJovensInativos);
            this.Map(r => r.QuantidadeTotalJovensIniciantes);
            this.Map(r => r.QuantidadeTotalJovensAfastados);
            this.Map(r => r.QuantidadeTotalJovensSemClassificacao);
            this.Map(r => r.QuantidadeTotalHomens );
            this.Map(r => r.QuantidadeTotalMulheres );
            this.Map(r => r.QuantidadeTotalBatizadosAguas );
            this.Map(r => r.QuantidadeTotalEspiritoSanto );
            this.Map(r => r.QuantidadeJovensAltarJovem );
            this.Map(r => r.QuantidadeTotalObreiros );
            this.Map(r => r.QuantidadeTotalColaboradores );
            this.Map(r => r.QuantidadeTotalCPO );
            this.Map(r => r.QuantidadeTotalUniversitarios );
            this.Map(r => r.QuantidadeTotalMidia );
            this.Map(r => r.QuantidadeTotalHelp );
            this.Map(r => r.QuantidadeTotalSecretarias );
            this.Map(r => r.QuantidadeTotalCultura );
            this.Map(r => r.QuantidadeTotalEsporte );
            this.Map(r => r.QuantidadeTotalAtalaia );
            this.Map(r => r.QuantidadeTotalArcanjos );
            this.Map(r => r.QuantidadeTotalUniforca );
            this.Map(r => r.QuantidadeTotalAVJovensAcompanhados);
            this.Map(r => r.QuantidadeTotalAVJovensSemAcompanhamento);
            this.References<Estado>(r => r.EstadoRelatorio)
                .Column("ID_ESTADO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
