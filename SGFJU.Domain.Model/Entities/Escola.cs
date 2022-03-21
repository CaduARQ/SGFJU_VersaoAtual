using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Escola : Entity<Escola>
    {
        public virtual string NomeEscola { get; set; }
        public virtual Estado EstadoEscola { get; set; }
    }
}
