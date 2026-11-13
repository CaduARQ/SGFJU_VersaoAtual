using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class FrequenciaLeituraMap : ClassMap<FrequenciaLeitura>
    {
        public FrequenciaLeituraMap()
        {
            this.Table("SGFJU_TBL_FREQUENCIALEITURA");
            this.Id(t => t.Code, "ID_FREQUENCIALEITURA").GeneratedBy.Identity();
            this.Map(t => t.Descricao, "DescricaoFrequenciaLeitura");
        }
    }
}
