using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class JovemAutorizacaoMap : ClassMap<JovemAutorizacao>
    {
        public JovemAutorizacaoMap()
        {
            this.Table("SGFJU_TBL_JOVEM_AUTORIZACAO");
            this.Id(t => t.Id, "ID_AUTORIZACAO").GeneratedBy.Identity();
            /*
            this.CompositeId()
                .KeyReference(t => t.JovemAutorizado, "ID_JOVEM")
                .KeyReference(t => t.Id, "ID_AUTORIZACAO");*/

            this.Map(x => x.NomeAutorizadorCompraCamisa);
            this.Map(x => x.DataAutorizacaoCompraCamisa);
            this.Map(x => x.CodigoAutorizacaoCompraCamisa);
            this.Map(x => x.NomeCamisaAutorizada);
            this.Map(x => x.OrigemCompraCamisa);
            this.References<Jovem>(t => t.JovemAutorizado)
                .Column("ID_JOVEM")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}
