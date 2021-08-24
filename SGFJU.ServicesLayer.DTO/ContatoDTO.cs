using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ContatoDTO
    {
        public int Code { get; set; }
        public string Whatsapp { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneEmergencia { get; set; }
        public string NomeContatoEmergencia { get; set; }
    }
}
