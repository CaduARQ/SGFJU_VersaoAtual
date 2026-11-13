using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class AcompanhamentoJovemDTO {
        public AcompanhamentoJovemDTO() {
            this.HistoricoAcompanhamento = new List<ItemAcompanhamentoHistoricoDTO>();
        }
        public int IdJovemEmAcompanhamento { get; set; }
        public string NomeJovemEmAcompanhamento { get; set; }
        public string NomeArquivoFoto { get; set; }
        public int IdObreiro { get; set; }
        public string NomeObreiro { get; set; }
        public string DataInicioAcompanhamento { get; set; }
        public string DataTerminoAcompanhamento { get; set; }
        public IgrejaDTO InformacoesIgreja { get; set; }
        public IList<ItemAcompanhamentoHistoricoDTO> HistoricoAcompanhamento { get; set; }
    }
}
