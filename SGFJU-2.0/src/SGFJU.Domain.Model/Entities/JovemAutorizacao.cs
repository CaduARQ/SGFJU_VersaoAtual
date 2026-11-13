using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class JovemAutorizacao : Entity<JovemAutorizacao> {
        public virtual Jovem JovemAutorizado { get; set; }
        public virtual string NomeAutorizadorCompraCamisa { get; set; }
        public virtual DateTime? DataAutorizacaoCompraCamisa { get; set; }
        public virtual string CodigoAutorizacaoCompraCamisa { get; set; }
        public virtual string NomeCamisaAutorizada { get; set; }
        public virtual string OrigemCompraCamisa { get; set; }
        public virtual char CamisaJaRetirada { get; set; }
    }
}
