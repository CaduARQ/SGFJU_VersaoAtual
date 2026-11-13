using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Despesa : Entity<Despesa>
    {
        public Despesa()
        {
            this.AcoesQueTiveramEstaDespesa = new List<Acao>();
        }
        public virtual string Descricao { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual string NumeroDoCupom { get; set; }
        public virtual string NomeArquivoNota { get; set; }        
        public virtual Estado EstadoDespesa { get; set; }
        public virtual TipoDespesa TipoDaDespesa { get; set; }
        public virtual IList<Acao> AcoesQueTiveramEstaDespesa
        { get; set; }
    }
}
