using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class SituacaoIURDFJU : ValueObject<SituacaoIURDFJU>
    {
        public virtual char EhObreiro { get; set; }
        public virtual int AnosObreiro { get; set; }
        public virtual int MesesObreiro { get; set; }
        public virtual string MesAnoFoiLevantadoObreiro { get; set; } //
        public virtual char EhColaborador { get; set; }
        public virtual int AnosColaborador { get; set; }
        public virtual int MesesColaborador { get; set; }
        public virtual char EstaCursandoCPO { get; set; }
        public virtual string MesAnoInicioCPO { get; set; }
        public virtual char EhPertencenteFJU { get; set; }
        public virtual char EhCoordenadorFJU { get; set; }
        public virtual string MesAnoCoordenandoFJU { get; set; }
        public virtual char EhLiderTribo { get; set; }
        public virtual Tribo TriboQueLidera { get; set; }
        public virtual string PeriodoCoordenandoTribo { get; set; }
        public virtual char EhLiderProjeto { get; set; }
        public virtual Projeto ProjetoQueCoordena { get; set; }
        public virtual string PeriodoCoordenandoProjeto { get; set; }
        public virtual char PossuiCamisaProjeto { get; set; }
        public virtual string NomeCamisaFJU { get; set; }
        public virtual string TamanhoCamisa { get; set; }
        public virtual char FoiObreiro { get; set; }
        public virtual string MotivoSaiuObreiro { get; set; }
        public virtual char FoiPastor { get; set; }
        public virtual string MotivoSaidaPastor { get; set; }
        public virtual string MesAnoSaidaObra { get; set; } //
        public virtual char DesejaSerObreiro { get; set; }
        public virtual string MotivoDesejaSerObreiro { get; set; }
        public virtual char DesejaFazerObraNoAltar { get; set; }
        public virtual char PertenceAltarJovem { get; set; }
        public virtual char PertenceIntellimen { get; set; }
        public virtual char DesafiosConcluidos { get; set; }
        public virtual int DesafioAtual { get; set; }
        public virtual string NomeParceiroIntellimen { get; set; }
        public virtual string TelefoneParceiroIntellimen { get; set; }
        public virtual int MesesCoordenandoFJU { get; set; }
        public virtual int AnosCoordenandoFJU { get; set; }
        public virtual int MesesCoordenandoTribo { get; set; }
        public virtual int AnosCoordenandoTribo { get; set; }
        public virtual int MesesCoordenandoProjeto { get; set; }
        public virtual int AnosCoordenandoProjeto { get; set; }
    }
}
