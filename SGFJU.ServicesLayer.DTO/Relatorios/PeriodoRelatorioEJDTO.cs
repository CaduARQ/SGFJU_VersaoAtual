using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class PeriodoRelatorioEJDTO
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public bool PeriodoEletivoLancamento { get; set; }
    }
}
