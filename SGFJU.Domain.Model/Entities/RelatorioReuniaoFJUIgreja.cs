using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class RelatorioReuniaoFJUIgreja : Entity<RelatorioReuniaoFJUIgreja>
    {
        public virtual int QuantidadeJovens { get; set; }
        public virtual int QuantidadeBatizadosAguas { get; set; }
        public virtual int QuantidadeBatizadosEspiritoSanto { get; set; }
        public virtual int QuantidadeAlgoAMais { get; set; }
        public virtual DateTime DataRelatorio { get; set; }
        public virtual string HorarioRelatorio { get; set; }
        public virtual string NomeCoordenadorPreencheuRelatorio { get; set; }
        public virtual Igreja IgrejaRelatorio { get; set; }
        public virtual ReuniaoFJU ReuniaoFJURelatorio { get; set; }
    }
}
