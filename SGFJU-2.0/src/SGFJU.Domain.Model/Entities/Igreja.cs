using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Igreja : Entity<Igreja> {

        public Igreja() {
            this.IgrejaQueCoordena = new List<IgrejaCoordenador>();
        }
        public virtual string NomeIgreja { get; set; }
        public virtual Regiao RegiaoIgreja { get; set; }
        public virtual TipoIgreja TipoIgreja { get; set; }
        public virtual IList<IgrejaCoordenador> IgrejaQueCoordena
        { get; set; }
    }
}
