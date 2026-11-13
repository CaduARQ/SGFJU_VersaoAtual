using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class DashboardRelatorio : Entity<DashboardRelatorio> {
        public virtual int QuantidadeTotalJovens { get; set; }
        public virtual int QuantidadeTotalJovensAtivos { get; set; }
        public virtual int QuantidadeTotalJovensInativos { get; set; }
        public virtual int QuantidadeTotalJovensIniciantes { get; set; }
        public virtual int QuantidadeTotalJovensAfastados { get; set; }
        public virtual int QuantidadeTotalJovensSemClassificacao { get; set; }
        public virtual int QuantidadeTotalHomens { get; set; }
        public virtual int QuantidadeTotalMulheres { get; set; }
        public virtual int QuantidadeTotalBatizadosAguas { get; set; }
        public virtual int QuantidadeTotalEspiritoSanto { get; set; }
        public virtual int QuantidadeJovensAltarJovem { get; set; }
        public virtual int QuantidadeTotalObreiros { get; set; }
        public virtual int QuantidadeTotalColaboradores { get; set; }
        public virtual int QuantidadeTotalCPO { get; set; }
        public virtual int QuantidadeTotalUniversitarios { get; set; }
        public virtual int QuantidadeTotalMidia { get; set; }
        public virtual int QuantidadeTotalHelp { get; set; }
        public virtual int QuantidadeTotalSecretarias { get; set; }
        public virtual int QuantidadeTotalCultura { get; set; }
        public virtual int QuantidadeTotalEsporte { get; set; }
        public virtual int QuantidadeTotalAtalaia { get; set; }
        public virtual int QuantidadeTotalArcanjos { get; set; }
        public virtual int QuantidadeTotalUniforca { get; set; }
        public virtual int QuantidadeTotalAVJovensAcompanhados { get; set; }
        public virtual int QuantidadeTotalAVJovensSemAcompanhamento { get; set; }
        public virtual Estado EstadoRelatorio { get; set; }
    }
}
