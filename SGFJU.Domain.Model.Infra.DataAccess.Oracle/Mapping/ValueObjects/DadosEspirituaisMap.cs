using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class DadosEspirituaisMap : ClassMap<DadosEspirituais>{
        public DadosEspirituaisMap()
        {
            this.Table("SGFJU_TBL_DADOSESPIRITUAIS");
            this.Id(t => t.Code, "ID_DADOSESPIRITUAIS").GeneratedBy.Identity();
            this.Map(t => t.EhMembroIURD);
            this.Map(t => t.MesAnoChegadaIURD);
            this.Map(t => t.AnoChegadaiurd);
            this.Map(t => t.MesChegadaiurd);
            this.Map(t => t.EhBatizadoEspiritoSanto);
            this.Map(t => t.MesAnoBatismoEspiritoSanto);
            this.Map(t => t.OcasiaoBatismoEspiritoSanto);
            this.Map(t => t.ComoConheceuIURD);
            this.Map(t => t.JaSeAfastou);
            this.Map(t => t.MotivoSeAfastou);
            this.Map(t => t.MesAnoAfastamento);
            this.Map(t => t.TempoAfastamento);
            this.Map(t => t.TempoEstaFirme);
            this.Map(t => t.TemFamiliaresIURD);
            this.Map(t => t.DescricaoFamiliaresIURD);
            this.Map(t => t.EhBatizadoAguas);
            this.Map(t => t.MesAnoBatismoAguas);
            this.Map(t => t.BatismoAguasIURD);
            this.Map(t => t.DescricaoModoChegouFJU);
            this.Map(t => t.MesAnoEntradaFJU);
            this.Map(t => t.MotivoEntradaFJU);
            this.Map(t => t.PossuiBiblia);
            this.Map(t => t.PossuiBibliaNoCelular);
            this.Map(t => t.LeuTodaBiblia);

            this.References<FrequenciaLeitura>(t => t.FrequenciaLeituraBiblia)
                .Column("ID_FREQUENCIALEITURA")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
