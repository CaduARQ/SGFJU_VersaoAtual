using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class ItemPatrimonioMap : ClassMap<ItemPatrimonio>
    {
        public ItemPatrimonioMap()
        {
            this.Table("SGFJU_TBL_PATRIMONIO");
            this.Id(t => t.Id, "ID_PATRIMONIO").GeneratedBy.Identity();

            this.Map(p => p.NomeItemPatrimonio);
            this.Map(p => p.DescricaoPatrimonio);
            this.Map(p => p.Modelo);
            this.Map(p => p.Marca); 
            this.Map(p => p.DataCompra);
            this.Map(p => p.ValorUnitario);
            this.Map(p => p.Quantidade);
            this.Map(p => p.NomeArquivoCartaDoacao);
            this.Map(p => p.NomeArquivoPDFNotaFiscal);
            this.Map(p => p.NomeArquivoImagemItem1);
            this.Map(p => p.NomeArquivoImagemItem2);
            this.Map(p => p.NomeArquivoImagemItem3); 
            this.Map(p => p.NomeArquivoImagemItem4);
            this.Map(p => p.NomeArquivoImagemItem5);

            this.References<CategoriaItemPatrimonio>(p => p.CategoriaItem)
                .Column("ID_CATEGORIAPATRIMONIO")
                .Cascade
                .None().Not.LazyLoad();

            this.References<Estado>(p => p.EstadoItemPatrimonio)
                .Column("ID_ESTADO")
                .Cascade
                .None().Not.LazyLoad();

            HasMany(x => x.HistoricoDoPatrimonio)
                .AsBag()
                .Cascade.All()
                .Table("SGFJU_TBL_HISTORICO_ITEM_PATRIMONIO");
        }
    }
}
