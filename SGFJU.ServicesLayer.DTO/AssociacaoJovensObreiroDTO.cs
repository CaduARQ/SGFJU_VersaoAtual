using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class AssociacaoJovensObreiroDTO
    {
        public IList<JovemAcompanhamentoDTO> JovensAcompanhados { get; set; }
        public ObreiroDTO ObreiroQueAcompanha { get; set; }
    }
}
