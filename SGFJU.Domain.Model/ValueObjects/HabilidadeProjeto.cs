using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class HabilidadeProjeto : ValueObject<HabilidadeProjeto>
    {
        public HabilidadeProjeto()
        {
            this.HabilidadesJovemPossui = new List<JovemHabilidadeProjeto>();
        }
        public virtual string NomeHabilidade { get; set; }
        public virtual Projeto ProjetoRelacionado { get; set; }
        public virtual DepartamentoProjeto DepartamentoRelacionado { get; set; }
        public virtual IList<JovemHabilidadeProjeto> HabilidadesJovemPossui
        { get; set; }
        
    }
}
