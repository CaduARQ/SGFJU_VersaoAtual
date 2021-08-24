using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class IgrejaCoordenador : Entity<IgrejaCoordenador> {
        public virtual Igreja IgrejaFJU { get; set; }
        public virtual Jovem CoordenadorFJU { get; set; }
        public virtual int TotalMesesCoordenandoFJU { get; set; }
        public virtual int TotalAnosCoordenandoFJU { get; set; }
        public virtual int MesesCoordenandoIgrejaAtualFJU { get; set; } //
        public virtual int AnosCoordenandoIgrejaAtualFJU { get; set; } //
        public virtual int QuantidadeJovensEncontroAnterior { get; set; } 
        public virtual int QuantidadeJovensEncontroAtual { get; set; } 
        public virtual char FoiEntrevistadoEstadualFJU { get; set; } //
        public virtual string MesAnoEntrevistaEstadual { get; set; }
        public virtual string NomeEstadualEntrevistou { get; set; }
        public virtual DateTime DataEntradaCoordenador { get; set; } //
        public virtual DateTime? DataSaidaCoordenador { get; set; } //
        public virtual DateTime? DataTrocaCoordenador { get; set; }//
        public virtual string NomePastorEfetuouTroca { get; set; } //
        public virtual string MotivoTrocaCoordenador { get; set; } //
        public virtual string NomeNovoCoordenador { get; set; } //

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as IgrejaCoordenador;

            return ((i.CoordenadorFJU.Id == this.CoordenadorFJU.Id)
                 && (i.IgrejaFJU.Id == this.IgrejaFJU.Id));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 9999;
        }
    }
}
