using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class EscolaDTO
    {
        public int IdEscola { get; set; }
        public string NomeEscola { get; set; }
        public EstadoDTO EstadoEscola { get; set; }
    }
}