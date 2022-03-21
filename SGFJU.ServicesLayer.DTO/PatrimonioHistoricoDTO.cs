using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class PatrimonioHistoricoDTO
    {
        public int IdItemPatrimonio { get; set; }
        public string DescricaoHistorico { get; set; }
        public DateTime DataHistoricoPatrimonio { get; set; }
    }
}
