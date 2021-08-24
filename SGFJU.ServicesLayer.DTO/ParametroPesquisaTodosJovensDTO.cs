using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ParametroPesquisaTodosJovensDTO {
        public string NomeJovem { get; set; }
        public int IdEstado { get; set; }
        public int IdBlocoJovem { get; set; }
        public int IdRegiaoJovem { get; set; }
        public int IdIgreja { get; set; }
        public string FotoEstaNoDiretorio { get; set; }
    }
}
