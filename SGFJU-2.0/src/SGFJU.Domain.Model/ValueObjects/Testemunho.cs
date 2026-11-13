using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class Testemunho : ValueObject<Testemunho>
    {
        public virtual char SofreuComDepressao { get; set; }
        public virtual string TempoSofreuDepressao { get; set; }
        public virtual string TempoLivreDepressao { get; set; }
        public virtual char SofreuAutomutilacao { get; set; }
        public virtual string TempoSofreuAutomutilacao { get; set; }
        public virtual string TempoLivreAutomutilacao { get; set; }
        public virtual char SofreuVicio { get; set; }

        public virtual string DescricaoVicio { get; set; }
        public virtual string TempoVicio { get; set; }
        public virtual string TempoLivreVicios { get; set; }
        public virtual char TentouSuicidio { get; set; }
        public virtual int NumeroTentativasSuicidio { get; set; }
        public virtual string MesAnoTentativaSuicidio { get; set; }
        public virtual string DescricaoTentativaSuicidio { get; set; }
        public virtual string TextoTestemunho { get; set; }
        public virtual Jovem JovemTestemunho { get; set; }
    }
}
