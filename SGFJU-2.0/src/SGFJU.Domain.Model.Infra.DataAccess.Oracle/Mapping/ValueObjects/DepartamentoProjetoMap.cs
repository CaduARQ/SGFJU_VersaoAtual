using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class DepartamentoProjetoMap : ClassMap<DepartamentoProjeto>
    {
        public DepartamentoProjetoMap()
        {
            this.Table("SGFJU_TBL_DEPARTAMENTO_PROJETO");
            this.Id(t => t.Code, "ID_DEPARTAMENTO_PROJETO").GeneratedBy.Identity();
            this.Map(T => T.NomeDepartamentoProjeto);
            this.References<Projeto>(x => x.Projeto)
                .Column("ID_PROJETO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            HasManyToMany(x => x.JovensLigadosAoDepartamento)
                .Cascade.None()
                .Inverse()
                .Table("SGFJU_TBL_JOVEM_DEPTO_PROJETO");
        }
    }
}
