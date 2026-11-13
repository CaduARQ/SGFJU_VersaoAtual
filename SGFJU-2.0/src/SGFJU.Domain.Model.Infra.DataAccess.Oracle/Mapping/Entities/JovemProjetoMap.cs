using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class JovemProjetoMap : ClassMap<JovemProjeto>
    {
        public JovemProjetoMap()
        {
            Not.LazyLoad();
            Table("SGFJU_TBL_JOVEM_PROJETO");
            CompositeId()
              .KeyReference(x => x.Jovem, "ID_JOVEM")
              .KeyReference(x => x.Projeto, "ID_PROJETO");
            Map(T => T.TempoProjeto);
            Map(T => T.AnosProjeto);
            Map(T => T.MesesProjeto);
            Map(T => T.PertenceuOutroProjeto);
            References<Projeto>(t => t.ProjetoAnterior)
                .Column("ID_PROJETO_ANTERIOR")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
