using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class Livro : ValueObjectType<Livro>
    {
        public Livro()
        {
            this.JovensQueLeram = new List<Jovem>();
        }
        public virtual string NomeLivro { get; set; }
        public virtual IList<Jovem> JovensQueLeram 
        { get; set; }
    }
}
