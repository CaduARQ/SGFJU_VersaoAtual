using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class Idioma : ValueObjectType<Idioma>
    {
        public Idioma()
        {
            this.IdiomasQueOJovemFala = new List<JovemIdioma>();
        }
        public virtual string NomeIdioma { get; set; }
        public virtual IList<JovemIdioma> IdiomasQueOJovemFala
        { get; set; }
    }
}
