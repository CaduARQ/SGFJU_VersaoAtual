using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class ItemPatrimonio : Entity<ItemPatrimonio>
    {
        public ItemPatrimonio()
        {
            //this.HistoricoDoPatrimonio = new List<PatrimonioHistorico>();
        }
        public virtual string NomeItemPatrimonio { get; set; }
        public virtual string DescricaoPatrimonio { get; set; }
        public virtual string Modelo { get; set; }
        public virtual string Marca { get; set; }
        public virtual DateTime? DataCompra { get; set; }
        public virtual string LocalCompra { get; set; }
        public virtual decimal ValorUnitario { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual string NomeArquivoPDFNotaFiscal { get; set; }
        public virtual string NomeArquivoCartaDoacao { get; set; }
        public virtual string NomeArquivoImagemItem1 { get; set; }
        public virtual string NomeArquivoImagemItem2 { get; set; }
        public virtual string NomeArquivoImagemItem3 { get; set; }
        public virtual string NomeArquivoImagemItem4 { get; set; }
        public virtual string NomeArquivoImagemItem5 { get; set; }
        public virtual CategoriaItemPatrimonio CategoriaItem { get; set; }
        public virtual Estado EstadoItemPatrimonio { get; set; }
        public virtual IList<PatrimonioHistorico> HistoricoDoPatrimonio
        { get; set; }
    }
}
