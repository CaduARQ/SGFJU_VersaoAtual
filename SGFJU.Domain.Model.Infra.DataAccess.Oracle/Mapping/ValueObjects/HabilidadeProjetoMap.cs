using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class HabilidadeProjetoMap : ClassMap<HabilidadeProjeto>
    {
        public HabilidadeProjetoMap()
        {
            this.Table("SGFJU_TBL_HABILIDADE");
            this.Id(t => t.Code, "ID_HABILIDADE").GeneratedBy.Identity();
            this.Map(t => t.NomeHabilidade);
            this.References<Projeto>(t => t.ProjetoRelacionado)
                .Column("ID_PROJETO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<DepartamentoProjeto>(t => t.DepartamentoRelacionado)
                .Column("ID_DEPARTAMENTO_PROJETO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            //ok
            HasMany(x => x.HabilidadesJovemPossui)
                .AsBag()
                .Cascade.All()
                .Inverse()
                .Table("SGFJU_TBL_JOVEM_HABILIDADE");
        }
    }
}
