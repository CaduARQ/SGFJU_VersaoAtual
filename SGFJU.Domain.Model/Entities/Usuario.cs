using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Usuario : Entity<Usuario>
    {
        public virtual string NomeUsuario { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual string NomeArquivoPerfil { get; set; }
        public virtual Estado EstadoUsuario { get; set; }
        public virtual PerfilUsuario PerfilUsuario { get; set; }
        public virtual Bloco BlocoUsuario { get; set; }
        public virtual Regiao RegiaoUsuario { get; set; }
        public virtual Igreja IgrejaUsuario { get; set; }
    }
}
