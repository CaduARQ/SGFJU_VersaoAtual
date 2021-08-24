using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class RespostaRequisicaoIdiomaDTO {
        public bool IdiomaExcluidoComSucesso { get; set; }
        public bool IdiomaJaAdicionado { get; set; }
        public string MensagemRespostaRequisicao { get; set; }
    }
}
