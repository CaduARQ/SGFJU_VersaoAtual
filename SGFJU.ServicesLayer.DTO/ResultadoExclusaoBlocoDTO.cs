using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ResultadoExclusaoBlocoDTO
    {
        public bool PodeExcluir { get; set; }
        public int QuantidadeRegioes { get; set; }
        public int QuantidadeIgrejas { get; set; }
        public int QuantidadeJovens { get; set; }
    }
}
