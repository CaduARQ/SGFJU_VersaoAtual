using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class RespostaAprovacaoCompraCamisa
    {
        public bool SolicitacaoBemSucedida { get; set; }
        public string RespostaSoliciticao { get; set; }
        public string CodigoAutorizacaoSGFJU { get; set; }
        public bool EhSolicitacaoSGFJU { get; set; }
        public IList<AutorizacaoCompraCamisaDTO> AutorizacoesConcedidas { get; set; }
    }
}
