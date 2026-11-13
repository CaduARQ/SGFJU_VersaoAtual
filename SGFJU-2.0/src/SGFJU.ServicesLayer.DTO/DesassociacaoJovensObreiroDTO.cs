using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class DesassociacaoJovensObreiroDTO
    {
        public IList<JovemAcompanhamentoDTO> JovensAcompanhados { get; set; }
        public ObreiroDTO ObreiroQueAcompanhava { get; set; }
        public bool DesassociaTodos { get; set; }
    }
}
