using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class PalestraEscolaDTO
    {
        public PalestraEscolaDTO() {
            this.ContatosAlunosPalestra = new List<ContatoAlunoDTO>();
        }
        public EscolaDTO Escola { get; set; }
        public int IdPalestraEscola { get; set; }
        public int IdIgrejaProximaEscola { get; set; }
        public int IdPalestraREalizada { get; set; }
        public string NomePalestraRealizada { get; set; }
        public string DataRealizacaoPalestra { get; set; }
        public int TotalAlunosPalestra { get; set; }
        public int TotalAlunosAtendidos { get; set; }
        public int QuantidadePalestrasRealizadas { get; set; }
        public string UrlDriveFotosPalestra { get; set; }
        public IList<ContatoAlunoDTO> ContatosAlunosPalestra { get; set; }
    }
}
