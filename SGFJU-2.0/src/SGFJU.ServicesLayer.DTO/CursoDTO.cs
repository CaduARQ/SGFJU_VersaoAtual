using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class CursoDTO
    {
        public int Code { get; set; }
        public string NomeCurso { get; set; }
        public int IdProjetoRelacionado { get; set; }
        public string NomeProjeto { get; set; }
        public string MensagemRespostaRequisicao { get; set; }
    }
}
