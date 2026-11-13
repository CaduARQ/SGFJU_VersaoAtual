using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class RespostaRequisicaoHabilidadeDTO
    {
        public bool HabilidadeExcluidaComSucesso { get; set; }
        public bool HabilidadeJaAdicionada { get; set; }
        public string MensagemRespostaRequisicao { get; set; }
    }
}
