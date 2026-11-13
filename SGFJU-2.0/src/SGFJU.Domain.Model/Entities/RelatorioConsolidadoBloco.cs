using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class RelatorioConsolidadoBloco : Entity<RelatorioConsolidadoBloco>
    {
        public virtual int TotalQuantidadeJovens { get; set; }
        public virtual int TotalQuantidadeBatizadosAguas { get; set; }
        public virtual int TotalQuantidadeBatizadosEspiritoSanto { get; set; }
        public virtual int TotalQuantidadeAlgoAMais { get; set; }

        public virtual int TotalQuantidadeJovensLevantadosObra { get; set; }
        public virtual int TotalQuantidadeObreirasCasaramPastor { get; set; }
        public virtual int TotalQuantidadeJovensIndicadosCPO { get; set; }
        public virtual int TotalQuantidadeObreiros { get; set; }
        public virtual int TotalQuantidadeSaidaObreirosFJU { get; set; }
        public virtual int TotalQuantidadeJovensCadastradosNovos { get; set; }
        public virtual DateTime DataConsolidacaoRelatorio { get; set; }
        public virtual DateTime DataInicialPeriodoRelatorio { get; set; }
        public virtual DateTime DataFinalPeriodoRelatorio { get; set; }
        public virtual string HorarioRelatorioConsolidado { get; set; }
        public virtual string NomeCoordenadorPreencheuRelatorio { get; set; }
        public virtual Bloco BlocoRelatorioConsolidado { get; set; }

    }
}
