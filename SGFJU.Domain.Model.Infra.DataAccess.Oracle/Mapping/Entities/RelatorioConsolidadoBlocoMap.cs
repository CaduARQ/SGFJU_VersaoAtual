using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class RelatorioConsolidadoBlocoMap : ClassMap<RelatorioConsolidadoBloco>
    {
        public RelatorioConsolidadoBlocoMap()
        {
            this.Table("SGFJU_TBL_RELATORIO_CONSOLIDADO_BLOCO");
            this.Id(t => t.Id, "ID_RELATORIOCONSOLIDADO_BLOCO_FJU").GeneratedBy.Identity();
            this.Map(x => x.TotalQuantidadeJovens);
            this.Map(x => x.TotalQuantidadeBatizadosAguas);
            this.Map(x => x.TotalQuantidadeBatizadosEspiritoSanto);
            this.Map(x => x.TotalQuantidadeAlgoAMais);
            this.Map(x => x.TotalQuantidadeJovensLevantadosObra);
            this.Map(x => x.TotalQuantidadeObreirasCasaramPastor);
            this.Map(x => x.TotalQuantidadeJovensIndicadosCPO);
            this.Map(x => x.TotalQuantidadeObreiros);
            this.Map(x => x.TotalQuantidadeSaidaObreirosFJU);
            this.Map(x => x.TotalQuantidadeJovensCadastradosNovos);
            this.Map(x => x.DataConsolidacaoRelatorio);
            this.Map(x => x.DataInicialPeriodoRelatorio);
            this.Map(x => x.DataFinalPeriodoRelatorio);
            this.Map(x => x.HorarioRelatorioConsolidado);
            this.Map(x => x.NomeCoordenadorPreencheuRelatorio);
            this.References<Bloco>(t => t.BlocoRelatorioConsolidado)
                .Column("ID_BLOCO")
                .Cascade
                .None().Not.LazyLoad();
        }
    }
}
