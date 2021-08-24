using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class CursoRelacionadoProjetoMap : ClassMap<CursoRelacionadoProjeto>
    {
        public CursoRelacionadoProjetoMap()
        {
            this.Table("SGFJU_TBL_JOVEM_CURSO_REL_PROJ");
            this.Id(t => t.Code, "ID_JOVEM_CURSO_REL_PROJETO").GeneratedBy.Identity();
            this.References<Jovem>(t => t.Jovem)
                .Column("ID_JOVEM")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.Map(t => t.NomeCurso);
            this.References<Projeto>(t => t.ProjetoRelacionado)
                .Column("ID_PROJETO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
