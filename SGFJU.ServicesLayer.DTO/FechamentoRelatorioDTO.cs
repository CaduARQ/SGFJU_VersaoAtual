using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class FechamentoRelatorioDTO
    {
        public int IdEstadoFechamentoRelatorio { get; set; }
        public int IdReuniaoFechamentoRelatorio { get; set; }
        public string DataInicialRelatorioFJU { get; set; }
        public string DataFinalRelatorioFJU { get; set; }
    }
}
