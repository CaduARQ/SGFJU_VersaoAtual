using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class JovemAutorizacaoCamisaDTO
    {
        public int IdJovem { get; set; }
        public string IdX { get; set; }
        public string NomeJovem { get; set; }
        public string DataNascimento { get; set; }
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBlocoJovem { get; set; }
        public string NomeBlocoJovem { get; set; }
        public int IdRegiaoJovem { get; set; }
        public string NomeRegiaoJovem { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgrejaJovem { get; set; }
        public string Whatsapp { get; set; }
        public string WhatsappSemFormatacao { get; set; }
        public string NomeArquivoFoto { get; set; }
        public string NomeArquivoFotoFormatado { get; set; }
        public string NomeAutorizadorCompraCamisa { get; set; }
        public string DataAutorizacaoCompraCamisa { get; set; }
        public string CodigoAutorizacaoCompraCamisa { get; set; }
        public string OrigemCompraCamisa { get; set; }
        public string NomeCamisaAutorizada { get; set; }
    }
}
