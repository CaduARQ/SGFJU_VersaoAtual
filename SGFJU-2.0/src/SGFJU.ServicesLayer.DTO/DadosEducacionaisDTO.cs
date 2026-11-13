using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class DadosEducacionaisDTO
    {
        public int Code { get; set; }
        public char EstudaAtualmente { get; set; }
        public string GrauEscolaridade { get; set; }
        public string Grau { get; set; }
        public string NomeInstituicaoEnsino { get; set; }
        public string NomeCursoSuperior { get; set; }
        public string PeriodoAtualNivelFaculdade { get; set; }
        public char PossuiNivelSuperior { get; set; }
        public string PrevisaoConclusaoCurso { get; set; }
        public int idModalidadeCursadaEnsinoSuperior { get; set; }
        public char DesejaCursarNivelSuperior { get; set; }
        public string NomeCursoSuperiorDesejaCursar { get; set; }
    }
}
