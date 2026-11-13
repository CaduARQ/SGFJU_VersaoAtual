using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class JovemObreiro
    {
        public virtual Jovem Jovem { get; set; }
        public virtual Jovem Obreiro { get; set; }
        public virtual DateTime DataInicioAcompanhamento { get; set; }
        public virtual DateTime? DataTerminoAcompanhamento { get; set; }
        public virtual DateTime? DataAssociacao { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as JovemObreiro;

            return ((i.Jovem.Id == this.Jovem.Id)
                 && (i.Obreiro.Id == this.Obreiro.Id));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 9999;
        }
    }
}
