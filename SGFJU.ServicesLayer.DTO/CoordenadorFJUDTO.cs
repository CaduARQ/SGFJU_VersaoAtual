using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class CoordenadorFJUDTO
    {
        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }
        public int IdBloco { get; set; }
        public string NomeBloco { get; set; }
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string NomeIgreja { get; set; }
        public string NomeTipoCoordenador { get; set; }
        public string Nome { get; set; }
        public string NomeArquivoFoto { get; set; }
        public string NomeConjuge { get; set; }
        public string DataCasamento { get; set; }
        public char PossuiFilhos { get; set; }
        public int QuantidadeFilhos { get; set; }
        public char ConjugeEhObreiro { get; set; }
        public string DataNascimento { get; set; }
        public int IdEstadoCivil { get; set; }
        public string DescricaoEstadoCivilJovem { get; set; }
        public bool GostaDeAlguem { get; set; }
        public string NomePretendente { get; set; }
        public bool NamoraAtualmente { get; set; }
        public int TotalMesesCoordenandoFJU { get; set; }
        public int TotalAnosCoordenandoFJU { get; set; }
        public int MesesCoordenandoFJUNaPresenteIgreja { get; set; }
        public int AnosCoordenandoFJUNaPresenteIgreja { get; set; }
        public string MesAnoEntrouObreiro { get; set; }
        public char FoiPastor { get; set; }
        public string MotivoSaidaPastor { get; set; }
        public string MesAnoSaidaObraAltar { get; set; }
        public int QuantidadeJovensChegou { get; set; }
        public int QuantidadeJovensAtual { get; set; }
        public int QuantidadeJovensSaiu { get; set; }
        public DateTime DataEntrouCoordenacaoFJU { get; set; }
        public DateTime DataSaiuCoordenacaoFJU { get; set; }
        public bool JaFoiEntrevistadoPeloEstadualFJU { get; set; }
        public string MesAnoEntrevistaComEstadual { get; set; }
        public string NomeEstadualFJUEntrevisou { get; set; }
        public string NomePastorEfetuouTroca { get; set; }
        public string MotivoSaidaCoordenacao { get; set; }
    }
}
