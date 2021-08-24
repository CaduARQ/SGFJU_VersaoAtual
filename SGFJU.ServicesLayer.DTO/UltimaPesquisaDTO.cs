using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class UltimaPesquisaDTO<TTYpeDTO> where TTYpeDTO: class {

        public bool ExisteUltimaPesquisa { get; set; }
        public IList<TTYpeDTO> ResultSetUltimaPesquisa { get; set; }
    }
}
