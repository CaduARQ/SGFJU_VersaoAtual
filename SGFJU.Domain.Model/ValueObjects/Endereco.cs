using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class Endereco : ValueObject<Endereco>{
        public virtual string NomeEstado { get; set; }
        public virtual string DescricaoEndereco { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Bairro { get; set; }
        public virtual TipoMoradia TipoDeMoradia { get; set; }
    }
}
