using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ItemPatrimonioDTO
    {
        public int IdItemPatrimonio { get; set; }
        public int IdEstado { get; set; }
        public string NomeItemPatrimonio { get; set; }
        public string DescricaoPatrimonio { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string DataCompra { get; set; }
        public string LocalCompra { get; set; }
        public string ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public string NomeArquivoPDFNotaFiscal { get; set; }
        public string NomeArquivoCartaDoacao { get; set; }
        public string NomeArquivoImagemItem1 { get; set; }
        public string NomeArquivoImagemItem2 { get; set; }
        public string NomeArquivoImagemItem3 { get; set; }
        public string NomeArquivoImagemItem4 { get; set; }
        public string NomeArquivoImagemItem5 { get; set; }
        public int CodigoCategoriaItem { get; set; }
        public string DescricaoCategoriaItem { get; set; }
        public IList<PatrimonioHistoricoDTO> HistoricoDoPatrimonio
        { get; set; }
    }
}
