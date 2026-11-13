using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class PatrimonioHistorico
    {
        public virtual ItemPatrimonio ItemPatrimonio { get; set; }
        public virtual string DescricaoHistorico { get; set; }
        public virtual DateTime DataHistoricoPatrimonio { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as PatrimonioHistorico;

            return (i.ItemPatrimonio.Id == this.ItemPatrimonio.Id);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 9999;
        }
    }
}
