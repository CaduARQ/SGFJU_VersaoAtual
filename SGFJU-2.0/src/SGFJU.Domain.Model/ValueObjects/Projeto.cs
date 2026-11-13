using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class Projeto : ValueObject<Projeto>
    {
        private IList<DepartamentoProjeto> _departamentos;

        public Projeto() {
            this._departamentos = new List<DepartamentoProjeto>();
            this.ProjetosAosQuaisJovemEstaLigado = new List<JovemProjeto>();
        }

        public virtual IEnumerable<DepartamentoProjeto> Departamentos
        { get { return _departamentos; } }

        public virtual void AddDepartamentoAoProjeto(DepartamentoProjeto departamento)
        {
            departamento.Projeto = this;
            this._departamentos.Add(departamento);
        }

        public virtual string NomeProjeto { get; set; }

        public virtual IList<JovemProjeto> ProjetosAosQuaisJovemEstaLigado
        { get; set; }
    }
}
