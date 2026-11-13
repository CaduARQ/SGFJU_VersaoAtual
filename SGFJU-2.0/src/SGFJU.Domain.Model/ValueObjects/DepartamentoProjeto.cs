using SGFJU.Domain.Model.Entities;
using System.Collections.Generic;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class DepartamentoProjeto : ValueObject<DepartamentoProjeto>
    {
        public DepartamentoProjeto()
        {
            this.JovensLigadosAoDepartamento = new List<Jovem>();
        }
        public virtual string NomeDepartamentoProjeto { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual IList<Jovem> JovensLigadosAoDepartamento
        { get; set; }
    }
}