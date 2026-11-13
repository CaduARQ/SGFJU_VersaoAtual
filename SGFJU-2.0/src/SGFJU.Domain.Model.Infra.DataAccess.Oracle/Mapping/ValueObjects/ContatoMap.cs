using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class ContatoMap : ClassMap<Contato>{
        public ContatoMap() {
            this.Table("SGFJU_TBL_CONTATO");
            this.Id(t => t.Code, "ID_CONTATO").GeneratedBy.Identity();
            this.Map(t => t.TelefoneFixo);
            this.Map(t => t.Whatsapp);
            this.Map(t => t.TelefoneEmergencia);
            this.Map(t => t.NomeContatoEmergencia);
        }
    }
}
