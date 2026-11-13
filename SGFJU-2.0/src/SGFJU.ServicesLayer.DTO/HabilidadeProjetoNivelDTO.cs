using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class HabilidadeProjetoNivelDTO
    {
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public int IdDepartamento { get; set; }
        public string NomeDepartamento { get; set; }
        public int IdHabilidade { get; set; }
        public string NomeHabilidade { get; set; }
        public int IdNivel { get; set; }
        public bool EhHabilidadeExtra { get; set; }
    }
}
