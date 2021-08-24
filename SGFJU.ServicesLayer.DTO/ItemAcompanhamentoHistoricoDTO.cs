using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ItemAcompanhamentoHistoricoDTO
    {
        public int IdHistorico { get; set; }
        public int IdJovem { get; set; }
        public int IdObreiroqueAcompanha { get; set; }
        public int IdStatusAcompanhamento { get; set; }
        public string DescricaoStatusAcompanhamento { get; set; }
        public string TextoHistorico { get; set; }
        public string DataHistorico { get; set; }
        public string MesDataHistorico { get; set; }
    }
}
