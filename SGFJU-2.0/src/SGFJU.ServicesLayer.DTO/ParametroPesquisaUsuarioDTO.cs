using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ParametroPesquisaUsuarioDTO
    {
        public int IdLogUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string DescricaoAcaoUsuario { get; set; }
        public string DataAcaoUsuario { get; set; }
        public string HorarioAcaoUsuario { get; set; }
        public string SiglaEstadoUsuario { get; set; }
    }
}
