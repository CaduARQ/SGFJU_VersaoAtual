using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class SituacaoIURDFJUDTO
    {
        public int Code { get; set; }
        public char EhObreiro { get; set; }
        public int AnosObreiro { get; set; }
        public int MesesObreiro { get; set; }
        public char EhColaborador { get; set; }
        public int AnosColaborador { get; set; }        
        public int MesesColaborador { get; set; }
        public char EstaCursandoCPO { get; set; }
        public string MesAnoInicioCPO { get; set; }
        public char EhPertencenteFJU { get; set; }
        public char EhCoordenadorFJU { get; set; }
        public string MesAnoCoordenandoFJU { get; set; }
        public string MesAnoFoiLevantadoObreiro { get; set; }
        public string MesAnoSaiuObra { get; set; }
        public char EhLiderTribo { get; set; }
        public int idTriboQueLidera { get; set; }
        public string PeriodoCoordenandoTribo { get; set; }
        public char EhLiderProjeto { get; set; }
        public int idProjetoQueCoordena { get; set; }
        public string PeriodoCoordenandoProjeto { get; set; }
        public char PossuiCamisaProjeto { get; set; }
        public string NomeCamisaFJU { get; set; }
        public string TamanhoCamisa { get; set; }
        public char FoiObreiro { get; set; }
        public string MotivoSaiuObreiro { get; set; }
        public char FoiPastor { get; set; }
        public string MotivoSaidaPastor { get; set; }
        public char DesejaSerObreiro { get; set; }
        public string MotivoDesejaSerObreiro { get; set; }
        public char DesejaFazerObraNoAltar { get; set; }
        public char PertenceAltarJovem { get; set; }
        public char PertenceIntellimen { get; set; }
        public char DesafiosConcluidos { get; set; }
        public int DesafioAtual { get; set; }
        public string NomeParceiroIntellimen { get; set; }
        public string TelefoneParceiroIntellimen { get; set; }        
        public int MesesCoordenandoFJU { get; set; }        
        public int AnosCoordenandoFJU { get; set; }
        public int MesesCoordenandoTribo { get; set; }        
        public int AnosCoordenandoTribo { get; set; }
        public int MesesCoordenandoProjeto { get; set; }
        public int AnosCoordenandoProjeto { get; set; }
    }
}
