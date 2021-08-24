using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.Entities
{
    public class IgrejaCoordenadorMap : ClassMap<IgrejaCoordenador>
    {
        public IgrejaCoordenadorMap()
        {            
            Not.LazyLoad();
            this.Table("SGFJU_TBL_IGREJA_COORDENADOR");
            this.CompositeId()
                .KeyReference(t => t.CoordenadorFJU, "ID_JOVEM")
                .KeyReference(T => T.IgrejaFJU, "ID_IGREJA");                
            this.Map(x => x.TotalMesesCoordenandoFJU);
            this.Map(x => x.TotalAnosCoordenandoFJU);
            this.Map(x => x.MesesCoordenandoIgrejaAtualFJU);
            this.Map(x => x.AnosCoordenandoIgrejaAtualFJU);
            this.Map(x => x.QuantidadeJovensEncontroAnterior);
            this.Map(x => x.QuantidadeJovensEncontroAtual);
            this.Map(x => x.FoiEntrevistadoEstadualFJU);
            this.Map(x => x.MesAnoEntrevistaEstadual);
            this.Map(x => x.NomeEstadualEntrevistou);
            this.Map(x => x.DataEntradaCoordenador);
            this.Map(x => x.DataSaidaCoordenador);
            this.Map(x => x.DataTrocaCoordenador);
            this.Map(x => x.NomePastorEfetuouTroca);
            this.Map(x => x.MotivoTrocaCoordenador);
            this.Map(x => x.NomeNovoCoordenador);
        }
    }
}
