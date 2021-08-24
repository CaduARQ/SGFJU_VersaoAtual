using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class DashboardArvoreVida : Entity<DashboardArvoreVida>
    {
        public virtual Estado EstadoRelatorio { get; set; }
        public virtual int QuantidadeObreiros { get; set; }
        public virtual int QuantidadeJovens { get; set; }
        public virtual int QuantidadeObreirosQueAcompanham { get; set; }
        public virtual int QuantidadeJovensAcompanhados { get; set; }
        public virtual int QuantidadeJovensSemAcompanhamento { get; set; }
        public virtual decimal MediaAcompanhamentoJovensPorObreiro { get; set; }
    }
}
