using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class AutorizacaoCompraCamisaDTO
    {
        public int IdJovem { get; set; }
        public int IdAutorizacao { get; set; }
        public string NomeAutorizadorCompraCamisa { get; set; }
        public string DataAutorizacaoCompraCamisa { get; set; }
        public string CodigoAutorizacaoCompraCamisa { get; set; }
        public string OrigemCompraCamisa { get; set; }
        public string NomeCamisaAutorizada { get; set; }
        public string CodigoCamisaAutorizada { get; set; }
        public string QuemEstaSolicitando { get; set; }
    }
}
