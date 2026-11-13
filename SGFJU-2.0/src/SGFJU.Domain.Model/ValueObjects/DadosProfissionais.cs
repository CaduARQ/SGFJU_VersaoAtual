using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class DadosProfissionais : ValueObject<DadosProfissionais> {
        public virtual char TrabalhaAtualmente { get; set; }
        public virtual string NomeEmpresa { get; set; }
        public virtual string Profissao { get; set; }
        public virtual string EnderecoEmpresa { get; set; }
    }
}
