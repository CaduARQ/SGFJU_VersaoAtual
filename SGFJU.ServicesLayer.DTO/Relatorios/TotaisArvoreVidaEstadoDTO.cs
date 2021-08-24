using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class TotaisArvoreVidaEstadoDTO
    {
        public int IdRelatorioAV { get; set; }
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int QuantidadeObreiros { get; set; }
        public int QuantidadeJovens { get; set; }
        public int QuantidadeObreirosQueAcompanham { get; set; }
        public int QuantidadeJovensAcompanhados { get; set; }
        public int QuantidadeJovensSemAcompanhamento { get; set; }
        public string MediaAcompanhamentoJovensPorObreiro { get; set; }
    }
}
