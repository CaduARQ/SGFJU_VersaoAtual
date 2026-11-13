using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class DadosProfissionaisDTO
    {
        public int Code { get; set; }
        public char TrabalhaAtualmente { get; set; }
        public string NomeEmpresa { get; set; }
        public string Profissao { get; set; }
        public string EnderecoEmpresa { get; set; }
    }
}
