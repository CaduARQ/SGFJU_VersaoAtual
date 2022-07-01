using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ParametroDespesasDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Data { get; set; }
        public string NumeroDoCupom { get; set; }
        public int IdEstadoDespesa { get; set; }
    }
}
