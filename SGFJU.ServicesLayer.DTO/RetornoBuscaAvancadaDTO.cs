using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class RetornoBuscaAvancadaDTO {
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public string IdX { get; set; }
        public string Nome { get; set; }
        public int IdTestemunho { get; set; }
        public string TextoTestemunho { get; set; }
    }
}
