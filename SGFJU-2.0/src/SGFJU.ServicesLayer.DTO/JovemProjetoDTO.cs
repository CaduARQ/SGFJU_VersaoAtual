using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class JovemProjetoDTO
    {
        public int idProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public string TempoProjeto { get; set; }
        public int AnosProjeto { get; set; }
        public int MesesProjeto { get; set; }
        public char PertenceuOutroProjeto { get; set; }
        public int idProjetoAnterior { get; set; }
        public string NomeProjetoAnterior { get; set; }
    }
}
