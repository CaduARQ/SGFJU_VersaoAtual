using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class InstituicaoEnsinoMap : ClassMap<InstituicaoEnsino>
    {
        public InstituicaoEnsinoMap()
        {
            this.Id(t => t.Id, "ID_INSTITUICAOENSINO").GeneratedBy.Identity();
            this.Map(t => t.NomeInstituicaoEnsino);
            this.Map(t => t.Endereco);
            this.Map(t => t.Contato);
            this.Map(t => t.NomeContato);
            this.References<Igreja>(t => t.IgrejaInstituicao)
                .Column("ID_IGREJA")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<PerfilInstituicaoEnsino>(t => t.PerfilInstituicao)
                .Column("ID_PERFIL_INSTITUICAO_ENSINO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.References<TipoInstituicaoEnsino>(t => t.TipoInstituicao)
                .Column("ID_TIPO_INSTITUICAO_ENSINO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
