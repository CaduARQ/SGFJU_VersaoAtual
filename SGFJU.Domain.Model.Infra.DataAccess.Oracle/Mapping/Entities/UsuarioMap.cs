using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            this.Table("SGFJU_TBL_USUARIO");
            this.Id(t => t.Id, "ID_USUARIO").GeneratedBy.Identity();
            this.Map(t => t.NomeUsuario);
            this.Map(t => t.Login);
            this.Map(t => t.Senha);
            this.Map(t => t.NomeArquivoPerfil);
            this.References<Estado>(t => t.EstadoUsuario)
                .Column("ID_ESTADO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<PerfilUsuario>(t => t.PerfilUsuario)
                .Column("ID_PERFILUSUARIO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<Bloco>(t => t.BlocoUsuario)
                .Column("ID_BLOCO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<Regiao>(t => t.RegiaoUsuario)
                .Column("ID_REGIAO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<Igreja>(t => t.IgrejaUsuario)
                .Column("ID_IGREJA")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
