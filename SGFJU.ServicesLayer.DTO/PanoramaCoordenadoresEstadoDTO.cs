using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class PanoramaCoordenadoresEstadoDTO
    {
        public IList<IgrejaCoordenadorDTO> ListaCoordenadoresEstado { get; set; }
        public int QuantidadeIgrejaSemCoordenador { get; set; }
        public int QuantidadeIgrejaComCoordenador { get; set; }
        public int QuantidadeIgrejaSemFJU { get; set; }
    }
}
