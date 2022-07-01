using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class DespesaMap : ClassMap<Despesa>
    {
        public DespesaMap()
        {
            this.Table("SGFJU_TBL_DESPESA");
            this.Id(t => t.Id, "ID_DESPESA").GeneratedBy.Identity();
            this.Map(X => X.Valor);
            this.Map(X => X.Data);
            this.Map(X => X.Descricao);
            this.Map(X => X.NumeroDoCupom);
            this.Map(X => X.NomeArquivoNota);
            this.References<Estado>(t => t.EstadoDespesa)
                .Column("ID_ESTADO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<TipoDespesa>(t => t.TipoDaDespesa)
                .Column("ID_TIPODESPESA")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
