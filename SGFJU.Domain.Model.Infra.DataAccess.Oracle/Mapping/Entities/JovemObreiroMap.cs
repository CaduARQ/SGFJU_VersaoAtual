using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class JovemObreiroMap : ClassMap<JovemObreiro>
    {
        public JovemObreiroMap()
        {
            //Not.LazyLoad();
            LazyLoad();
            this.Table("SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO");
            this.CompositeId()
                .KeyReference(t => t.Jovem, "ID_JOVEM")
                .KeyReference(T => T.Obreiro, "ID_OBREIRO");                
            this.Map(x => x.DataInicioAcompanhamento);
            this.Map(x => x.DataTerminoAcompanhamento);
            this.Map(x => x.DataAssociacao);
        }
    }
}
