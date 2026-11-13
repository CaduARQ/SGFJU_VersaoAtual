using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ParametroPesquisaInstituicaoEnsinoDTO
    {
        public int IdInstituicaoEnsino { get; set; }
        public int IdEstado { get; set; }
        public int IdBloco { get; set; }
        public int IdRegiao { get; set; }
        public int IdIgreja { get; set; }
        public int IdTipoInstituicao { get; set; }
        public int IdPerfilInstituicao { get; set; }
        public int IdClassificacaoInstituicao { get; set; }
        public string FuncaoContatoInstituicaoEnsino { get; set; }
    }
}
