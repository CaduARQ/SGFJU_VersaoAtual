using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class ClassificacaoInstituicaoEnsinoMap : ClassMap<ClassificacaoInstituicaoEnsino>
    {
        public ClassificacaoInstituicaoEnsinoMap()
        {
            this.Table("SGFJU_TBL_CLASSIFICACAOINSTITUICAOENSINO");
            this.Id(t => t.Codigo, "ID_CLASSIFICACAO_INSTITUICAO_ENSINO").GeneratedBy.Assigned();
            this.Map(t => t.Descricao, "DescricaoClassificacaoInstituicaoEnsino");
        }
    }
}
