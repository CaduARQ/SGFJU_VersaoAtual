using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class RelatorioReuniaoFJUIgrejaMap : ClassMap<RelatorioReuniaoFJUIgreja>
    {
        public RelatorioReuniaoFJUIgrejaMap() {
            this.Table("SGFJU_TBL_RELATORIO_REUNIAO_FJU_IGREJA");
            this.Id(t => t.Id, "ID_RELATORIO_FJU_IGREJA").GeneratedBy.Identity();
            this.Map(x => x.QuantidadeJovens);
            this.Map(x => x.QuantidadeBatizadosAguas);
            this.Map(x => x.QuantidadeBatizadosEspiritoSanto);
            this.Map(x => x.QuantidadeAlgoAMais);
            this.Map(x => x.QuantidadeJovensLevantadosObra);
            this.Map(x => x.QuantidadeObreirasCasaramPastor);
            this.Map(x => x.QuantidadeJovensIndicadosCPO);
            this.Map(x => x.QuantidadeObreiros);
            this.Map(x => x.QuantidadeSaidaObreirosFJU);
            this.Map(x => x.QuantidadeJovensCadastradosNovos);
            this.Map(x => x.DataRegistroRelatorio);
            this.Map(x => x.DataInicialPeriodoRelatorio);
            this.Map(x => x.DataFinalPeriodoRelatorio);
            this.Map(x => x.HorarioRelatorio);
            this.Map(x => x.NomeCoordenadorPreencheuRelatorio);
            this.References<Igreja>(t => t.IgrejaRelatorio)
                .Column("ID_IGREJA")
                .Cascade
                .None().Not.LazyLoad();
            this.References<ReuniaoFJU>(t => t.ReuniaoFJURelatorio)
                .Column("ID_REUNIAOFJU")
                .Cascade
                .None().Not.LazyLoad();
        }
    }
}
