using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class RelatorioReuniaoFJUIgrejaDTO
    {
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public int IdIgrejaRelatorio { get; set; }
        public string NomeIgreja { get; set; }
        public int IdRelatorioReuniaoFJUIgreja { get; set; }
        public int IdReuniaoFJURelatorio { get; set; }
        public int QuantidadeJovens { get; set; }
        public int QuantidadeBatizadosAguas { get; set; }
        public int QuantidadeBatizadosEspiritoSanto { get; set; }
        public int QuantidadeAlgoAMais { get; set; }

        public string DataRelatorio { get; set; }
        public string HorarioRelatorio { get; set; }
        public string NomeCoordenadorPreencheuRelatorio { get; set; }
        public string NomeReuniaoFJURelatorio { get; set; }
        public string RelatorioJaLancado { get; set; }
    }
}
