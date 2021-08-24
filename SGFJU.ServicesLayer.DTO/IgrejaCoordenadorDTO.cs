using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class IgrejaCoordenadorDTO
    {
        public int IdIgrejaCoordenador { get; set; }
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBlocoJovem { get; set; }
        public string NomeBlocoJovem { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiaoJovem { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public int IdCoordenadorFJU { get; set; }
        public string NomeCoordenador { get; set; }
        public string NomeTipoCoordenador { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string NomeArquivoFoto { get; set; }
        public int IdEstadoCivil { get; set; }
        public string NomeConjuge { get; set; }
        public char PossuiFilhos { get; set; }
        public int QuantidadeFilhos { get; set; }        
        public char ConjugeEhObreiro { get; set; } //
        public char NamoraAtualmente { get; set; } //
        public char GostaDeAlguem { get; set; } //
        public string NomePretendente { get; set; } //
        public string MesAnoFoiLevantadoObreiro { get; set; }

        public char DesejaFazerObraNoAltar { get; set; }
        public char FoiPastor { get; set; }
        public string MotivoSaidaPastor { get; set; }
        public string MesAnoSaiuObra { get; set; }
        public int TotalMesesCoordenandoFJU { get; set; }
        public int TotalAnosCoordenandoFJU { get; set; }
        public string PeriodoCoordenando { get; set; }
        public int MesesCoordenandoIgrejaAtualFJU { get; set; } 
        public int AnosCoordenandoIgrejaAtualFJU { get; set; } 
        public int QuantidadeJovensEncontroAnterior { get; set; }
        public int QuantidadeJovensEncontroAtual { get; set; }
        public char FoiEntrevistadoEstadualFJU { get; set; } 
        public string MesAnoEntrevistaEstadual { get; set; }
        public string NomeEstadualEntrevistou { get; set; }
        public string DataEntradaCoordenador { get; set; } 
        public string DataSaidaCoordenador { get; set; } 
        public string DataTrocaCoordenador { get; set; }
        public string NomePastorEfetuouTroca { get; set; } 
        public string MotivoTrocaCoordenador { get; set; } 
        public string NomeNovoCoordenador { get; set; }
        public string NomeArquivoFotoFormatado { get; set; }
        
    }
}
