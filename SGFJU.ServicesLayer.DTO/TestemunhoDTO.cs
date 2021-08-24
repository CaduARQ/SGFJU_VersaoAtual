using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class TestemunhoDTO
    {
        public int Code { get; set; }
        public char SofreuComDepressao { get; set; }
        public string TempoSofreuDepressao { get; set; }
        public string TempoLivreDepressao { get; set; }
        public char SofreuAutomutilacao { get; set; }
        public string TempoSofreuAutomutilacao { get; set; }
        public virtual string TempoLivreAutomutilacao { get; set; }
        public char SofreuVicio { get; set; }

        public string DescricaoVicio { get; set; }
        public string TempoVicio { get; set; }
        public string TempoLivreVicios { get; set; }
        public char TentouSuicidio { get; set; }
        public int NumeroTentativasSuicidio { get; set; }
        public string MesAnoTentativaSuicidio { get; set; }
        public string DescricaoTentativaSuicidio { get; set; }
        public string TextoTestemunho { get; set; }
    }
}
