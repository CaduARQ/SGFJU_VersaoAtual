using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class PanoramaRelatorioReuniaoFJUDTO
    {
        public int SomatorioRelatoriosJaLancados { get; set; }
        public int SomatorioRelatoriosJaLancadosAM { get; set; }
        public int QuantidadeIgrejasSemRelatorio { get; set; }
        public IList<RelatorioReuniaoFJUIgrejaDTO> RelatorioIgrejasNoPeriodo { get; set; }
        public string PercentualRelatorioPreenchido { get; set; }
        public string PercentualRelatorioNaoPreenchido { get; set; }
    }
}
