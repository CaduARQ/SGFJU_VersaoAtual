using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{    
    public class PesquisaGeralDTO  {
        public int IdJovem { get; set; }
        public int IdEstado { get; set; }
        public int IdBloco { get; set; }
        public int IdRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string Nome { get; set; }
    }
}
