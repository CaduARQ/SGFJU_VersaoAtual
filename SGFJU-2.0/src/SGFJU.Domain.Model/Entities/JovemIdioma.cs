using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class JovemIdioma
    {
        public virtual Jovem Jovem { get; set; }
        public virtual Idioma Idioma { get; set; }
        public virtual Nivel Nivel { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as JovemIdioma;

            return ((i.Jovem.Id == this.Jovem.Id)
                 && (i.Idioma.Code == this.Idioma.Code));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 9999;
        }
    }
}
