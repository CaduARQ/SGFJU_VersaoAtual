using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class JovemDTO
    {
        public JovemDTO()
        {
            this.CursosRelacionados = new List<CursoDTO>();
            this.ProjetosAosQuaisJovemEstaLigado = new List<JovemProjetoDTO>();
            this.IdiomasQueOJovemFala = new List<IdiomaNivelDTO>();
            this.HabilidadesJovemPossui = new List<HabilidadeProjetoNivelDTO>();
            this.DepartamentosProjetoJovemFazParte = new List<DepartamentoProjetoDTO>();
            this.LivrosLidosPeloJovem = new List<LivroDTO>();
            this.ReunioesFJUAssistidasPeloJovem = new List<ReuniaoFJUDTO>();
            this.AutorizacoesCompraCamisa = new List<AutorizacaoCompraCamisaDTO>();
        }

        public int Id { get; set; }
        public string IdX { get; set; }
        public string Nome { get; set; }
        public string NomeArquivoFoto { get; set; }
        public string NomeArquivoFotoFormatado { get; set; }
        public string NomeAutorizadorCompraCamisa { get; set; }
        public string DataAutorizacaoCompraCamisa { get; set; }
        public string CodigoAutorizacaoCompraCamisa { get; set; }
        public string OrigemCompraCamisa { get; set; }
        public string NomeConjuge { get; set; }
        public string DataCasamento { get; set; }
        public char PossuiFilhos { get; set; }
        public int QuantidadeFilhos { get; set; }
        public char ConjugeEhIURD { get; set; }
        public char ConjugeEhObreiro { get; set; } //
        public char NamoraAtualmente { get; set; } //
        public char GostaDeAlguem { get; set; } //
        public string NomePretendente { get; set; } //
        public char PossuiTituloEleitor { get; set; }
        public char PertenceGrupoMulheresIURD { get; set; }
        public string NomeGrupoMulheresIURD { get; set; }
        public string DataNascimento { get; set; }
        public string DataCadastro { get; set; }
        public string DataUltimaAtualizacao { get; set; }
        public string DataPreenchimentoFormulario { get; set; }
        public string TextoSugestao { get; set; }
        public char Sexo { get; set; }
        public char ClassificacaoJovem { get; set; }
        public string DataMudancaClassificacaoJovem { get; set; }
        public string DescricaoMudancaClassificacaoJovem { get; set; }
        public string AutorizadorMudancaClassificacaoJovem { get; set; }
        public char EhAltarJovem318 { get; set; }
        public string CodigoAltarJovem318 { get; set; }
        public char EhAtendenteWhatsappHelp { get; set; }
        public string NomePerfilCadastro { get; set; }
        public string PeriodoPerfilFJU { get; set; }
        public string PossuiCoordenacaoFJU { get; set; }
        public string NomeCoordenacao { get; set; }
        public string PeriodoCoordenacao { get; set; }
        public string TipoJovem { get; set; }
        public EnderecoDTO EnderecoJovem { get; set; }
        public RedeSocialDTO RedeSocialJovem { get; set; }
        public ContatoDTO ContatoJovem { get; set; }
        public int idEstadoCivilJovem { get; set; }
        public string DescricaoEstadoCivilJovem { get; set; }
        public SituacaoIURDFJUDTO SituacaoJovemIURDFJU { get; set; }
        public DadosProfissionaisDTO DadosProfissionaisJovem { get; set; }
        public DadosEducacionaisDTO DadosEducacionaisJovem { get; set; }
        public DadosEspirituaisDTO DadosEspirituaisJovem { get; set; }
        public TestemunhoDTO TestemunhoJovem { get; set; }
        public IgrejaDTO IgrejaAQualJovemPertence { get; set; }
        public AcompanhamentoJovemDTO ArvoreVidaAcompanhamento { get; set; }
        public bool EhPastor { get; set; }
        public IList<CursoDTO> CursosRelacionados
        { get; set; }
        public IList<JovemProjetoDTO> ProjetosAosQuaisJovemEstaLigado
        { get; set; }
        public IList<IdiomaNivelDTO> IdiomasQueOJovemFala
        { get; set; }
        public IList<HabilidadeProjetoNivelDTO> HabilidadesJovemPossui
        { get; set; }        
        public IList<DepartamentoProjetoDTO> DepartamentosProjetoJovemFazParte
        { get; set; }
        public IList<LivroDTO> LivrosLidosPeloJovem
        { get; set; }        
        public IList<ReuniaoFJUDTO> ReunioesFJUAssistidasPeloJovem
        { get; set; }
        public IList<AutorizacaoCompraCamisaDTO> AutorizacoesCompraCamisa
        { get; set; }
    }
}
