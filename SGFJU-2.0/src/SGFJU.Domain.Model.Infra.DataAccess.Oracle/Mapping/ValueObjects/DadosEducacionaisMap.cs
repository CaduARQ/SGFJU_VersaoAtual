using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class DadosEducacionaisMap : ClassMap<DadosEducacionais>{
        public DadosEducacionaisMap(){
            this.Table("SGFJU_TBL_DADOSEDUCACIONAL");
            this.Id(t => t.Code, "ID_DADOSESCOLARES").GeneratedBy.Identity();
            this.Map(t => t.EstudaAtualmente);
            this.Map(t => t.GrauEscolaridade);
            this.Map(t => t.Grau);
            this.Map(t => t.NomeInstituicaoEnsino);
            this.Map(t => t.NomeCursoSuperior);
            this.Map(t => t.PeriodoAtualNivelFaculdade);
            this.Map(t => t.PossuiNivelSuperior);
            this.Map(t => t.PrevisaoConclusaoCurso);

            this.References<ModalidadeEnsinoSuperior>(t => t.ModalidadeCursadaEnsinoSuperior)
                .Column("ID_MODALIDADE_NIVEL_SUPERIOR")
                .Cascade
                .None()
                .Not
                .LazyLoad();

            this.Map(t => t.DesejaCursarNivelSuperior);
            this.Map(t => t.NomeCursoSuperiorDesejaCursar);
        }
    }
}
