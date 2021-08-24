using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    interface FacadeUsuario : Facade<Usuario>
    {
        UsuarioDTO RetornaUsuario(UsuarioDTO usuarioParametro);
        void RegistraUsuario(Usuario usuarioNovo);
        Usuario Loggar(string login, string password);
        bool LoginJaCadastrado(string pLogin);
        IList<UsuarioDTO> RetornaUsuariosEstado(Estado estadoParametro);
        IList<UsuarioDTO> RetornaUsuariosBloco(Bloco blocoParametro);
        IList<UsuarioDTO> RetornaUsuariosRegiao(Regiao regiaoParametro);
        IList<LogUsuarioDTO> ObterTodasAcoesSGFJU(string arquivoJSONLogUsuario);
        IList<UsuarioDTO> PesquisaUsuariosPorParametro(PesquisaGeralDTO parametroPesquisa);
    }
}
