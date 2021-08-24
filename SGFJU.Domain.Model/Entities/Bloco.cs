using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Bloco : Entity<Bloco>{
        public virtual string NomeBloco { get; set; }
        
        public virtual Estado EstadoBloco { get; set; }
    }
}
