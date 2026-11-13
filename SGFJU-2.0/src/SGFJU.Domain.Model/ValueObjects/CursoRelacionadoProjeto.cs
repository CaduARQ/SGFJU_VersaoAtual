using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class CursoRelacionadoProjeto : ValueObject<CursoRelacionadoProjeto>
    {
        public virtual string NomeCurso { get; set; }
        public virtual Projeto ProjetoRelacionado { get; set; }
        public virtual Jovem Jovem { get; set; }
    }
}
