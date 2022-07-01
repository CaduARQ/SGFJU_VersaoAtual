using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Acao : Entity<Acao>
    {
        public Acao() {
            this._despesasAcao = new List<Despesa>();
        }
        public virtual string NomeAcao { get; set; }
        public virtual DateTime DataAcao { get; set; }
        public virtual string HoraInicio { get; set; }
        public virtual string HoraFim { get; set; }
        public virtual Estado EstadoAcao { get; set; }
        public virtual TipoAcao TipoAcao { get; set; }

        //-----------------------------------------------------------------------------------
        private IList<Despesa> _despesasAcao;
        public virtual IList<Despesa> DespesasAcao
        { get { return this._despesasAcao; } protected set { this._despesasAcao = value; } }
        public virtual void addDespesaDaAcao(Despesa despesa)
        {
            despesa.AcoesQueTiveramEstaDespesa.Add(this);
            this._despesasAcao.Add(despesa);
        }
        public virtual void addDespesasDaAcao(IList<Despesa> despesasAcao)
        {
            foreach (var despesa in despesasAcao)
            {
                despesa.AcoesQueTiveramEstaDespesa.Add(this);
                this._despesasAcao.Add(despesa);
            }
        }
        //-----------------------------------------------------------------------------------
    }
}
