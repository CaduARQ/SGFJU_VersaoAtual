using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class EnderecoDTO
    {
        public int Code { get; set; }
        public string NomeEstado { get; set; }
        public string DescricaoEndereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int idTipoDeMoradia { get; set; }
        public string DescricaoTipoDeMoradia { get; set; }
    }
}
