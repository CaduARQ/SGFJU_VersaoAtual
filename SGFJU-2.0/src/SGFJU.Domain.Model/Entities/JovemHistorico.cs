using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class JovemHistorico
    {
        public virtual Jovem Jovem { get; set; }
        public virtual Jovem Obreiro { get; set; }
        public virtual StatusAcompanhamento StatusJovem { get; set; }
        public virtual string TextoObservacao { get; set; }
        public virtual DateTime DataHistoricoAcompanhamento { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as JovemHistorico;

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
