using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class TodosJovensDTO
    {
        public int IdJovem { get; set; }
        public string IdX { get; set; }
        public string NomeJovem { get; set; }
        public string DataNascimento { get; set; }
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public string SiglaEstado { get; set; }
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
        public string FotoEstaNoDiretorio { get; set; }
        public string EstadoCivil { get; set; }
        public string Endereco { get; set; }
        public string DataIngressouFJU { get; set; }
        public string ProjetoJovemPertence { get; set; }
        public string ComoConheceuFJU { get; set; }
        public string EhBatizadoAguas { get; set; }
        public string DataBatismoAguas { get; set; }
        public string FoiNaIurd { get; set; }
        public string EhBatizadoEspiritoSanto { get; set; }
        public string DataBatismoEspiritoSanto { get; set; }
        public bool EstaSendoAcompanhadoAV { get; set; }
        public int IdObreiroAcompanha { get; set; }
        public string NomeObreiroAcompanha { get; set; }
        public string ClassificacaoJovem { get; set; }
        public bool FichaEstaExpirada { get; set; }
    }
}
