using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class RelatorioTotaisGeralDTO {
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int QuantidadeTotalJovens { get; set; }
        public int QuantidadeTotalHomens { get; set; }
        public int QuantidadeTotalMulheres { get; set; }
        public int QuantidadeTotalBatizadosAguas { get; set; }
        public string QuantidadeTotalBatizadosAguasPercent { get; set; }
        public int QuantidadeTotalEspiritoSanto { get; set; }
        public string QuantidadeTotalEspiritoSantoPercent { get; set; }
        public int QuantidadeJovensAltarJovem { get; set; }
        public int QuantidadeTotalObreiros { get; set; }
        public int QuantidadeTotalColaboradores { get; set; }
        public int QuantidadeTotalCPO { get; set; }
        public int QuantidadeTotalUniversitarios { get; set; }
        public int QuantidadeTotalMidia { get; set; }
        public int QuantidadeTotalHelp { get; set; }
        public int QuantidadeTotalSecretarias { get; set; }
        public int QuantidadeTotalCultura { get; set; }
        public int QuantidadeTotalEsporte { get; set; }
        public int QuantidadeTotalAtalaia { get; set; }
        public int QuantidadeTotalArcanjos { get; set; }
        public int QuantidadeTotalUniforca { get; set; }
        public int QuantidadeTotalJovensAtivos { get; set; }
        public int QuantidadeTotalJovensInativos { get; set; }
        public int QuantidadeTotalJovensIniciantes { get; set; }
        public int QuantidadeTotalAVJovensAcompanhados { get; set; }
        public int QuantidadeTotalAVJovensSemAcompanhamento { get; set; }
    }
}
