using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class IdiomaNivelDTO
    {
        public int CodigoIdioma { get; set; }
        public string DescricaoIdioma { get; set; }
        public int CodigoNivel { get; set; }
        public string DescricaoNivel { get; set; }
        public bool EhIdiomaExtra { get; set; }
    }
}
