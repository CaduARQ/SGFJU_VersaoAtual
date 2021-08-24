using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class DadosEducacionais : ValueObject<DadosEducacionais> {
        public virtual char EstudaAtualmente { get; set; }
        public virtual string GrauEscolaridade { get; set; }
        public virtual string Grau { get; set; }
        public virtual string NomeInstituicaoEnsino { get; set; }
        public virtual string NomeCursoSuperior { get; set; }
        public virtual string PeriodoAtualNivelFaculdade { get; set; }
        public virtual char PossuiNivelSuperior { get; set; }
        public virtual string PrevisaoConclusaoCurso { get; set; }
        public virtual ModalidadeEnsinoSuperior ModalidadeCursadaEnsinoSuperior { get; set; }
        public virtual char DesejaCursarNivelSuperior { get; set; }
        public virtual string NomeCursoSuperiorDesejaCursar { get; set; }
    }
}
