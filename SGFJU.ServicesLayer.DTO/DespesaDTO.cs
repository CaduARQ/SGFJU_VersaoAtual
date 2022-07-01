using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class DespesaDTO
    {
        public int IdDespesa { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Data { get; set; }
        public string NumeroDoCupom { get; set; }
        public string NomeArquivoNota { get; set; }
        public int IdEstadoDespesa { get; set; }
        public int IdTipoDespesa { get; set; }
        public string DescricaoTipoDespesa { get; set; }

    }
}
