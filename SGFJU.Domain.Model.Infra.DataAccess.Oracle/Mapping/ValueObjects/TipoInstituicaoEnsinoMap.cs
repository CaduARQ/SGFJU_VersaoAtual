using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class TipoInstituicaoEnsinoMap : ClassMap<TipoInstituicaoEnsino>
    {
        public TipoInstituicaoEnsinoMap()
        {
            this.Table("SGFJU_TBL_TIPOINSTITUICAOENSINO");
            this.Id(t => t.Codigo, "ID_TIPO_INSTITUICAO_ENSINO").GeneratedBy.Assigned();
            this.Map(t => t.Descricao, "DescricaoTipoInstituicaoensino");
        }
    }
}
