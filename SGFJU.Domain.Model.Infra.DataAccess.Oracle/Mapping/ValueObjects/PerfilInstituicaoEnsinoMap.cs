using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class PerfilInstituicaoEnsinoMap : ClassMap<PerfilInstituicaoEnsino>
    {
        public PerfilInstituicaoEnsinoMap()
        {
            this.Id(t => t.Codigo, "ID_PERFIL_INSTITUICAO_ENSINO").GeneratedBy.Assigned();
            this.Map(t => t.Descricao, "DescricaoPerfilInstituicaoEnsino");
        }
    }
}
