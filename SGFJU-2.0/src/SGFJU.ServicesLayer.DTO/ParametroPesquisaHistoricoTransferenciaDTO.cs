using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ParametroPesquisaHistoricoTransferenciaDTO
    {
        public int IdJovem { get; set; }
        public int IdIgrejaOrigem { get; set; }
        public int IdIgrejaDestino { get; set; }
        public int IdUsuarioRealizouTransferencia { get; set; }
        public string DataTransferencia { get; set; }
    }
}
