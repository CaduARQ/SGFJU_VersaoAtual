using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class SituacaoIURDFJUMap : ClassMap<SituacaoIURDFJU>
    {
        public SituacaoIURDFJUMap()
        {
            this.Table("SGFJU_TBL_SITUACAO_IURD_FJU");
            this.Id(t => t.Code, "ID_SITUACAO_IURD_FJU").GeneratedBy.Identity();
            this.Map(t => t.EhObreiro);
            this.Map(t => t.AnosObreiro);
            this.Map(t => t.MesesObreiro);
            this.Map(t => t.MesAnoFoiLevantadoObreiro);
            this.Map(t => t.EhColaborador);
            this.Map(t => t.MesesColaborador);
            this.Map(t => t.AnosColaborador);
            this.Map(t => t.EstaCursandoCPO);
            this.Map(t => t.MesAnoInicioCPO);
            this.Map(t => t.EhPertencenteFJU);

            this.Map(t => t.EhCoordenadorFJU);
            this.Map(t => t.MesAnoCoordenandoFJU);
            this.Map(t => t.MesesCoordenandoFJU);
            this.Map(t => t.AnosCoordenandoFJU);

            this.Map(t => t.EhLiderTribo);
            this.References<Tribo>(t => t.TriboQueLidera)
                .Column("ID_TRIBO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.Map(t => t.PeriodoCoordenandoTribo);
            this.Map(t => t.AnosCoordenandoTribo);
            this.Map(t => t.MesesCoordenandoTribo);

            this.Map(t => t.EhLiderProjeto);
            this.References<Projeto>(t => t.ProjetoQueCoordena)
                .Column("ID_PROJETO")
                .Cascade
                .None()
                .Not
                .LazyLoad();
            this.Map(t => t.PeriodoCoordenandoProjeto);
            this.Map(t => t.MesesCoordenandoProjeto);
            this.Map(t => t.AnosCoordenandoProjeto);

            this.Map(t => t.PossuiCamisaProjeto);
            this.Map(t => t.NomeCamisaFJU);
            this.Map(t => t.TamanhoCamisa);
            this.Map(t => t.FoiObreiro);
            this.Map(t => t.MotivoSaiuObreiro);
            this.Map(t => t.FoiPastor);
            this.Map(t => t.MotivoSaidaPastor);
            this.Map(t => t.MesAnoSaidaObra);
            this.Map(t => t.DesejaSerObreiro);
            this.Map(t => t.MotivoDesejaSerObreiro);
            this.Map(t => t.DesejaFazerObraNoAltar);
            this.Map(t => t.PertenceAltarJovem);
            this.Map(t => t.PertenceIntellimen);
            this.Map(t => t.DesafiosConcluidos);
            this.Map(t => t.DesafioAtual);
            this.Map(t => t.NomeParceiroIntellimen);
            this.Map(t => t.TelefoneParceiroIntellimen);
    }
    }
}
