using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class JovemAcompanhamentoDTO
    {
        public int IdJovem { get; set; }
        public string NomeJovem { get; set; }
        public string DataInicioAcompanhamento { get; set; }
        public string DataAssociacao { get; set; }
    }
}
