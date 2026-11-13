using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class TotalJovensPorBlocoDTO{
        public int IdEStado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int TotalJovensBloco { get; set; }
    }
}
