using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface UsuarioRepository : Repository<Usuario>
    {
        UsuarioDTO RetornaUsuario(UsuarioDTO usuarioParametro);
        void RegistraUsuario(Usuario usuarioNovo);
        Usuario Logar(string login, string password);
        bool LoginJaCadastrado(string pLogin);
        IList<UsuarioDTO> RetornaUsuariosEstado(Estado estadoParametro);
        IList<UsuarioDTO> RetornaUsuariosBloco(Bloco blocoParametro);
        IList<UsuarioDTO> RetornaUsuariosRegiao(Regiao regiaoParametro);
        IList<UsuarioDTO> PesquisaUsuariosPorParametro(PesquisaGeralDTO parametroPesquisa);
    }
}
