using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class AcaoComDespesasDTO
    {
        public int IdEstadoAcao { get; set; }
        public  string NomeAcao { get; set; }
        public  string DataAcao { get; set; }
        public  string HoraInicio { get; set; }
        public  string HoraFim { get; set; }
        public int IdTipoAcao { get; set; }
        public string DescricaoTipoAcao { get; set; }
        public IList<DespesaDTO> DespesasRelacionadas { get; set; }
    }
}
