using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class RelatorioConsolidadoBlocoSemanal
    {
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int IdRelatorioConsolidadoBlocoFJU { get; set; }
        public int QuantidadeJovens { get; set; }
        public int QuantidadeBatizadosAguas { get; set; }
        public int QuantidadeBatizadosEspiritoSanto { get; set; }
        public int QuantidadeAlgoAMais { get; set; }
        public int QuantidadeJovensLevantadosObra { get; set; }
        public int QuantidadeObreirasCasaramPastor { get; set; }
        public int QuantidadeJovensIndicadosCPO { get; set; }
        public int QuantidadeObreiros { get; set; }
        public int QuantidadeSaidaObreirosFJU { get; set; }
        public int QuantidadeJovensCadastradosNovos { get; set; }
        public string DataConsolidacaoRelatorio { get; set; }
        public string DataInicialPeriodoRelatorio { get; set; }
        public string DataFinalPeriodoRelatorio { get; set; }
        public string HorarioRelatorioConsolidado { get; set; }
        public string NomeCoordenadorPreencheuRelatorio { get; set; }
        public string NomeReuniaoFJURelatorio { get; set; }
        public string RelatorioJaLancado { get; set; }
    }
}
