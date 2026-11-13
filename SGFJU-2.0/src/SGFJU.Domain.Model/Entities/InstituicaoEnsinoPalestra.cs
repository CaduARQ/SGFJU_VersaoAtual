using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class InstituicaoEnsinoPalestra
    {
        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }
        public virtual Palestra Palestra { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as InstituicaoEnsinoPalestra;

            return ((i.InstituicaoEnsino.Id == this.InstituicaoEnsino.Id)
                 && (i.Palestra.Id == this.Palestra.Id));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 9999;
        }
    }
}
