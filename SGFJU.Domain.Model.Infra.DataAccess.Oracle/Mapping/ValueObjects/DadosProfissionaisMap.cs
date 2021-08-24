using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class DadosProfissionaisMap : ClassMap<DadosProfissionais>
    {
        public DadosProfissionaisMap()
        {
            this.Table("SGFJU_TBL_DADOS_PROFISSIONAIS");
            this.Id(t => t.Code, "ID_DADOS_PROFISSIONAIS").GeneratedBy.Identity();
            this.Map(t => t.TrabalhaAtualmente);
            this.Map(t => t.NomeEmpresa);
            this.Map(t => t.Profissao);
            this.Map(t => t.EnderecoEmpresa);
        }
    }
}
