using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class TranfereJovensEntreIgrejasDTO {
        public int IdIgrejaOrigem { get; set; }
        public int IdIgrejaDestino { get; set; }
        public bool TransferirTodos { get; set; }
        public IList<TodosJovensDTO> JovensParaTransferir { get; set; }
    }
}
