using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class RedeSocialMap : ClassMap<RedeSocial>{
        public RedeSocialMap()
        {
            this.Table("SGFJU_TBL_REDESOCIAL");
            this.Id(t => t.Code, "ID_REDESOCIAL").GeneratedBy.Identity();
            this.Map(t => t.Instagram);
            this.Map(t => t.Facebook);
            this.Map(t => t.Twitter);
            this.Map(t => t.Email);
            this.Map(t => t.EhSeguidorOficialFJU);
            this.Map(t => t.EhSeguidorYoutube);
            this.Map(t => t.EhSeguidorTelegram);
            this.Map(t => t.EhAssinanteUNIVER);
            this.Map(t => t.FrequenciaAssisteUNIVER);
            this.Map(t => t.EhLeitorBlogBM);
            this.Map(t => t.EhLeitorUniversalorg);
            this.Map(t => t.PossuiCelularComInternet);
            this.Map(t => t.PossuiComputador);
        }
    }
}
