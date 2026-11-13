using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class BuscaAvancadaParametroDTO {
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public string IdX { get; set; }
        public string PalavrasChaveConcatenadasPesquisa { get; set; }
        public IList<string> PalavrasChavePesquisa { get; set; }
        public char SofreuVicio { get; set; }
        public char SofreuAutomutilacao { get; set; }
        public char SofreuDepressao { get; set; }
        public char Sexo { get; set; }
    }
}