using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class InstituicaoEnsino : Entity<InstituicaoEnsino> {
        public virtual int IdInstituicaoEnsino { get; set; }
        public virtual string NomeInstituicaoEnsino { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Contato { get; set; }
        public virtual string NomeContato { get; set; }
        public virtual string FuncaoContatoInstituicaoEnsino { get; set; }
        public virtual Igreja IgrejaInstituicao { get; set; }
        public virtual PerfilInstituicaoEnsino PerfilInstituicao { get; set; }
        public virtual TipoInstituicaoEnsino TipoInstituicao { get; set; }
        public virtual ClassificacaoInstituicaoEnsino ClassificacaoInstituicao { get; set; }
    }
}
