using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Palestra : Entity<Palestra>
    {
        public virtual string NomePalestra { get; set; }
    }
}
