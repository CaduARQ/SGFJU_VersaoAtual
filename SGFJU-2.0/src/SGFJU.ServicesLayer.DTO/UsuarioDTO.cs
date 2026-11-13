using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string IdUsuarioX { get; set; }
        public string NomeUsuario { get; set; }
        public string Login { get; set; }
        public string NomePerfil { get; set; }
        // Somente entrada (cadastro/troca de senha). Nunca é serializada na resposta.
        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
        public string Pwd { get; set; }
        public bool EhADM { get; set; }
        public string PathImagemUsuario { get; set; }
        public int IdEstadoUsuarioLogado { get; set; }
        public int IdEstadoUsuario { get; set; }
        public int IdPerfilUsuario { get; set; }
        public int IdBloco { get; set; }
        public string NomeBlocoUsuario { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiaoUsuario { get; set; }
        public int IdIgreja { get; set; }
        public string NomeEstadoUsuarioLogado { get; set; }
        public string NomeEstadoUsuario { get; set; }
        public string SiglaEstadoUsuario { get; set; }
    }
}
