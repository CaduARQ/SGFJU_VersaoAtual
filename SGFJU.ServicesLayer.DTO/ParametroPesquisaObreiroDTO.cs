using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ParametroPesquisaObreiroDTO
    {
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public int IdObreiro { get; set; }
        public string NomeObreiro { get; set; }
    }
}
