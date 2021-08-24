using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class Contato : ValueObject<Contato>{
        public virtual string Whatsapp { get; set; }
        public virtual string TelefoneFixo { get; set; }
        public virtual string TelefoneEmergencia { get; set; }
        public virtual string NomeContatoEmergencia { get; set; }
    }
}
