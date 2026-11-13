using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class HistoricoTransferenciaDTO
    {
        public int IdJovem { get; set; }
        public string NomeJovem { get; set; }
        public int IdIgrejaOrigem { get; set; }
        public string NomeIgrejaOrigem { get; set; }
        public int IdIgrejaDestino { get; set; }
        public string NomeIgrejaDestino { get; set; }
        public string DataTransferencia { get; set; }
    }
}
