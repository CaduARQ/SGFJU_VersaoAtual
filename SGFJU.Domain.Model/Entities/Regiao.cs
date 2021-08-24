using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Regiao : Entity<Regiao> {

        private IList<Igreja> _igrejas;

        public Regiao(){
            this._igrejas = new List<Igreja>();
        }

        public virtual IEnumerable<Igreja> Igrejas
        { get { return _igrejas; } }

        public virtual void AddIgreja(Igreja igreja)
        {
            igreja.RegiaoIgreja = this;
            this._igrejas.Add(igreja);
        }

        public virtual string NomeRegiao { get; set; }

        public virtual Bloco BlocoRegiao { get; set; }
    }
}
