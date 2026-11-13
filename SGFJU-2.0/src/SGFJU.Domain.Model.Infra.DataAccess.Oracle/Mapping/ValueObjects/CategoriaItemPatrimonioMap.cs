using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class CategoriaItemPatrimonioMap : ClassMap<CategoriaItemPatrimonio>
    {
        public CategoriaItemPatrimonioMap()
        {
            this.Table("SGFJU_TBL_CATEGORIAPATRIMONIO");
            this.Id(t => t.Code, "ID_CATEGORIAPATRIMONIO").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoCategoriaPatrimonio");
        }
    }
}
