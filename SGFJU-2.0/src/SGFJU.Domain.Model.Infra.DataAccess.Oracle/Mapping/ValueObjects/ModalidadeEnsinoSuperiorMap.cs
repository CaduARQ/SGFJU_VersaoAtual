using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class ModalidadeEnsinoSuperiorMap : ClassMap<ModalidadeEnsinoSuperior>
    {
        public ModalidadeEnsinoSuperiorMap()
        {
            this.Table("SGFJU_TBL_MODALIDADE_NS");
            this.Id(t => t.Code, "ID_MODALIDADE_NIVEL_SUPERIOR").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoModalidadeEnsinoSupri");
        }
    }
}
