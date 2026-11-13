using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ObreiroDTO {
        public ObreiroDTO() {
            this.JovensQueObreiroAcompanha = new List<JovemDTO>();
        }

        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public int IdObreiro { get; set; }
        public string IdObreiroX { get; set; }
        public string NomeObreiro { get; set; }
        public int AnosObreiro { get; set; }
        public int MesesObreiro { get; set; }
        public string MesAnoFoiLevantadoObreiro { get; set; }
        public string PesquisarPorEstadoOuBloco { get; set; }
        public string NomeArquivoFoto { get; set; }
        public string NomeArquivoFotoFormatado { get; set; }
        public string FotoEstaNoDiretorio { get; set; }
        public IList<JovemDTO> JovensQueObreiroAcompanha { get; set; }
    }
}
