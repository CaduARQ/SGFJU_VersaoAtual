using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class InstituicaoEnsino : Entity<InstituicaoEnsino> {
        public InstituicaoEnsino() {
            this._palestrasRealizadasInstituicaoEnsino = new List<Palestra>();
        }
        public virtual int IdInstituicaoEnsino { get; set; }
        public virtual string NomeInstituicaoEnsino { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Contato { get; set; }
        public virtual string NomeContato { get; set; }
        public virtual string FuncaoContatoInstituicaoEnsino { get; set; }

        public virtual char HelpJaEsteveNaInstituicao { get; set; }
        public virtual DateTime? DataInicioAtividades { get; set; }
        public virtual DateTime? DataUltimaAtividadeRealizada { get; set; }
        public virtual int QuantidadeAlunos { get; set; }
        public virtual int QuantidadeAlunosAtendidosCantinho { get; set; }
        public virtual char OcorreuAlgumIncidente { get; set; }
        public virtual string ObservacoesInstituicaoEnsino { get; set; }
        public virtual Igreja IgrejaInstituicao { get; set; }
        public virtual PerfilInstituicaoEnsino PerfilInstituicao { get; set; }
        public virtual TipoInstituicaoEnsino TipoInstituicao { get; set; }
        public virtual ClassificacaoInstituicaoEnsino ClassificacaoInstituicao { get; set; }

        //-------------------------------------------------------------------------------------------------
        private IList<Palestra> _palestrasRealizadasInstituicaoEnsino;
        public virtual IList<Palestra> PalestrasRealizadasInstituicaoEnsino
        { get { return this._palestrasRealizadasInstituicaoEnsino; } protected set { this._palestrasRealizadasInstituicaoEnsino = value; } }
        public virtual void addPalestraRealizadasNaInstituicao(Palestra palestraRealizadaInstituicaoEnsino) {
            palestraRealizadaInstituicaoEnsino.InstituicaoEnsinoOndeAconteceu.Add(this);
            this._palestrasRealizadasInstituicaoEnsino.Add(palestraRealizadaInstituicaoEnsino);
        }
        public virtual void addPalestrasRealizadasNaInstituicao(IList<Palestra> palestraRealizadaInstituicaoEnsino) {
            foreach (var palestra in palestraRealizadaInstituicaoEnsino) {
                palestra.InstituicaoEnsinoOndeAconteceu.Add(this);
                this._palestrasRealizadasInstituicaoEnsino.Add(palestra);
            }
        }
        //-------------------------------------------------------------------------------------------------
    }
}
