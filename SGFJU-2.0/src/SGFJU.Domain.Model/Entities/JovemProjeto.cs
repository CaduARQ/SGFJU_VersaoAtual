using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class JovemProjeto{
        public virtual Jovem Jovem { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual string TempoProjeto { get; set; }
        public virtual int AnosProjeto { get; set; }
        public virtual int MesesProjeto { get; set; }
        public virtual char PertenceuOutroProjeto { get; set; }
        public virtual Projeto ProjetoAnterior { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var i = obj as JovemProjeto;

            return ((i.Jovem.Id == this.Jovem.Id)
                 && (i.Projeto.Code == this.Projeto.Code));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 9999;
        }

    }
}
