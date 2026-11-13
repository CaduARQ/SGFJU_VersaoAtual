using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class RetornoBuscaAvancadaDTO {
        public int IdJovem { get; set; }
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
        public string ClassificacaoJovem { get; set; }
        public string DataNascimento { get; set; }
        public string SiglaEstado { get; set; }
        public string NomeArquivoFotoFormatado { get; set; }
        public string Whatsapp { get; set; }
        public string WhatsappSemFormatacao { get; set; }
        public string NomeArquivoFoto { get; set; }
    }
}
