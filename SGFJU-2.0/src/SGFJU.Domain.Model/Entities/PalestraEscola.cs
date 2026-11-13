using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class PalestraEscola : Entity<PalestraEscola>
    {
        public virtual string NomePalestraRealizada { get; set; }
        public virtual string DataRealizacaoPalestra { get; set; }
        public virtual int TotalAlunosPalestra { get; set; }
        public virtual int TotalAlunosAtendidos { get; set; }
        public virtual int QuantidadePalestrasRealizadas { get; set; }
        public virtual string UrlDriveFotosPalestra { get; set; }
        public virtual Escola EscolaPalestra { get; set; }
        public virtual Igreja IgrejaProximaEscola { get; set; }
        public virtual Palestra PalestraRealizada { get; set; }
    }
}