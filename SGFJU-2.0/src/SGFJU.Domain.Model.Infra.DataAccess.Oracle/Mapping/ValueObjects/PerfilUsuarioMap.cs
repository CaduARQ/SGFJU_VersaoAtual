using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class PerfilUsuarioMap : ClassMap<PerfilUsuario>
    {
        public PerfilUsuarioMap()
        {
            this.Table("SGFJU_TBL_PERFILUSUARIO");
            this.Id(t => t.Code, "ID_PERFILUSUARIO").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "NomePerfilUsuario");
        }
    }
}
