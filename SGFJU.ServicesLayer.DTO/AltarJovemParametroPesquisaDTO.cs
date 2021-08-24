using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class AltarJovemParametroPesquisaDTO
    {
        public string NomeJovem { get; set; }
        public string DataNascimento { get; set; }
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBlocoJovem { get; set; }
        public string NomeBlocoJovem { get; set; }
        public int IdRegiaoJovem { get; set; }
        public string NomeRegiaoJovem { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgrejaJovem { get; set; }
        public IList<string> GruposSelecionadosPesquisa { get; set; }
        public string Sexo { get; set; }
        public char EhAltarJovem318 { get; set; }
        public string CodigoAltarJovem318 { get; set; }
    }
}
