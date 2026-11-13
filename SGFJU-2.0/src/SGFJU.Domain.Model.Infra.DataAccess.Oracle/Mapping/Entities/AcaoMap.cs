using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class AcaoMap : ClassMap<Acao> {
        public AcaoMap() {
            this.Table("SGFJU_TBL_ACAO");
            this.Id(t => t.Id, "ID_ACAO").GeneratedBy.Identity();
            this.Map(X => X.NomeAcao);
            this.Map(X => X.DataAcao);
            this.Map(X => X.HoraInicio);
            this.Map(X => X.HoraFim);
            this.References<Estado>(t => t.EstadoAcao)
                .Column("ID_ESTADO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<TipoAcao>(t => t.TipoAcao)
                .Column("ID_TIPOACAO")
                .Cascade
                .None()
                .Not
                .LazyLoad();

            HasManyToMany(x => x.DespesasAcao)
                .Cascade.None()
                .Table("SGFJU_TBL_ACAO_DESPESA")
                .Not.LazyLoad();
        }
    }
}
