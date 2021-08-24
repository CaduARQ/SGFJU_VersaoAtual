using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class ReuniaoFJU : ValueObjectType<ReuniaoFJU>
    {
        public ReuniaoFJU()
        {
            this.JovensQueAssistem = new List<Jovem>();
        }
        public virtual string NomeReuniaoFJU { get; set; }
        public virtual IList<Jovem> JovensQueAssistem 
        { get; set; }
    }
}
