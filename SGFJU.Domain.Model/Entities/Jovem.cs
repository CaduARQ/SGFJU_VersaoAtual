using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGFJU.Domain.Model.Entities
{
    public class Jovem : Entity<Jovem>
    {        
        public Jovem()
        {
            this._cursosRelacionados = new List<CursoRelacionadoProjeto>();
            this._departamentosProjetoJovemFazParte = new List<DepartamentoProjeto>();
            this._reunioesFJUAssistidasPeloJovem = new List<ReuniaoFJU>();
            this._livrosLidoPeloJovem = new List<Livro>();

            this.ProjetosAosQuaisJovemEstaLigado = new List<JovemProjeto>();
            this.IdiomasQueOJovemFala = new List<JovemIdioma>();
            this.HabilidadesJovemPossui = new List<JovemHabilidadeProjeto>();            
        }
        public virtual string Nome { get; set; }
        public virtual string NomeArquivoFoto { get; set; }
        public virtual string NomeArquivoAutorizacao { get; set; }
        public virtual char ArquivoAutorizacaoOk { get; set; }
        public virtual string NomeConjuge { get; set; }
        public virtual DateTime? DataCasamento { get; set; }
        public virtual char PossuiFilhos { get; set; }
        public virtual int QuantidadeFilhos { get; set; }
        public virtual char ConjugeEhIURD { get; set; }
        //------------
        public virtual char ConjugeEhObreiro { get; set; } //
        public virtual char NamoraAtualmente { get; set; } //
        public virtual char GostaDeAlguem { get; set; } //
        public virtual string NomePretendente { get; set; } //
        //------------
        public virtual char PossuiTituloEleitor { get; set; }
        public virtual char PertenceGrupoMulheresIURD { get; set; }
        public virtual string NomeGrupoMulheresIURD { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual DateTime DataPreenchimentoFormulario { get; set; }
        public virtual DateTime? DataUltimaAtualizacao { get; set; }
        public virtual DateTime? DataIngressoObra { get; set; }
        public virtual string TextoSugestao { get; set; }
        public virtual char Sexo { get; set; }
        public virtual char ClassificacaoJovem { get; set; }
        public virtual DateTime? DataMudancaClassificacaoJovem { get; set; }
        public virtual string DescricaoMudancaClassificacaoJovem { get; set; }
        public virtual string AutorizadorMudancaClassificacaoJovem { get; set; }
        public virtual bool EhPastor { get; set; }        
        public virtual char EhAltarJovem318 { get; set; }
        public virtual string CodigoAltarJovem318 { get; set; }
        public virtual Endereco EnderecoJovem { get; set; }
        public virtual RedeSocial RedeSocialJovem { get; set; }
        public virtual Contato ContatoJovem { get; set; }
        public virtual TipoEstadoCivil EstadoCivilJovem { get; set; }
        public virtual SituacaoIURDFJU SituacaoJovemIURDFJU { get; set; }
        public virtual DadosProfissionais DadosProfissionaisJovem { get; set; }
        public virtual DadosEducacionais DadosEducacionaisJovem { get; set; }
        public virtual DadosEspirituais DadosEspirituaisJovem { get; set; }
        public virtual Igreja IgrejaAQualJovemPertence { get; set; }
        public virtual string SiglaEstadoJovem { get; set; }
        public virtual char EhAtendenteWhatsappHelp { get; set; }
        public virtual char EhPalestranteHelp { get; set; }

        //Curso Relacionado Projeto HasMany ----------------------------------------------------------
        private IList<CursoRelacionadoProjeto> _cursosRelacionados;
        public virtual IEnumerable<CursoRelacionadoProjeto> CursosRelacionados
        { get { return _cursosRelacionados; } }
        public virtual void AddCursoRelacionado(CursoRelacionadoProjeto cursoRelacionado)
        {
            cursoRelacionado.Jovem = this;
            _cursosRelacionados.Add(cursoRelacionado);
        }
        public virtual void AddCursosRelacionados(IList<CursoRelacionadoProjeto> cursosRelacionadosJovemPossui)
        {
            foreach (CursoRelacionadoProjeto cursoRelacionado in cursosRelacionadosJovemPossui)
            {
                cursoRelacionado.Jovem = this;
                _cursosRelacionados.Add(cursoRelacionado);
            }
        }
        public virtual void RemoveCursoRelacionado(CursoRelacionadoProjeto cursoRelacionadosJovemPossui) {
            var indiceCursoExcluir = _cursosRelacionados.IndexOf(cursoRelacionadosJovemPossui);
            _cursosRelacionados.RemoveAt(indiceCursoExcluir);
        }
        /*método abaixo depois mudar*/
        public virtual void RemoveCursoRelacionado(int indiceCursoExcluir){            
            _cursosRelacionados.RemoveAt(indiceCursoExcluir);
        }


        //propriedades utilizadas no relacionamento ManyToMany 
        public virtual IList<JovemProjeto> ProjetosAosQuaisJovemEstaLigado
        { get; set; }
        public virtual IList<JovemIdioma> IdiomasQueOJovemFala
        { get; set; }
        public virtual IList<JovemHabilidadeProjeto> HabilidadesJovemPossui
        { get; set; }
        public virtual IList<IgrejaCoordenador> IgrejaQueCoordena
        { get; set; }
        //Linha abixo se refere à implementação de solução do árvore da vida
        public virtual IList<JovemObreiro> ObreiroQueAcompanha
        { get; set; }

        public virtual IList<JovemHistorico> HistoricoAcompanhamentoJovem
        { get; set; }
        //-------------------------------------------------------------------------------------------------        
        private IList<DepartamentoProjeto> _departamentosProjetoJovemFazParte;
        public virtual IEnumerable<DepartamentoProjeto> DepartamentosProjetoJovemFazParte
        { get { return this._departamentosProjetoJovemFazParte; } }
        public virtual void addDepartamentoProjetoJovemFazParte(DepartamentoProjeto departamentoProjeto){
            departamentoProjeto.JovensLigadosAoDepartamento.Add(this);
            this._departamentosProjetoJovemFazParte.Add(departamentoProjeto);
        }
        public virtual void addDepartamentosProjetoJovemFazParte(IList<DepartamentoProjeto> departamentosJovemFazParte) {
            foreach (var departamento in departamentosJovemFazParte) {
                departamento.JovensLigadosAoDepartamento.Add(this);
                this._departamentosProjetoJovemFazParte.Add(departamento);
            }
        }
        //-------------------------------------------------------------------------------------------------
        private IList<Livro> _livrosLidoPeloJovem;
        public virtual IList<Livro> LivrosLidosPeloJovem
        { get { return this._livrosLidoPeloJovem; } protected set { this._livrosLidoPeloJovem = value; } }
        public virtual void addLivroLidoPeloJovem(Livro livroLido) {
            livroLido.JovensQueLeram.Add(this);
            this._livrosLidoPeloJovem.Add(livroLido);
        }
        public virtual void addLivrosLidoPeloJovem(IList<Livro> livrosLido){
            foreach (var livro in livrosLido)
            {
                livro.JovensQueLeram.Add(this);
                this._livrosLidoPeloJovem.Add(livro);
            }
        }
        //-------------------------------------------------------------------------------------------------
        private IList<ReuniaoFJU> _reunioesFJUAssistidasPeloJovem;
        public virtual IList<ReuniaoFJU> ReunioesFJUAssistidasPeloJovem
        { get { return this._reunioesFJUAssistidasPeloJovem; } protected set { this._reunioesFJUAssistidasPeloJovem = value; } }
        public virtual void addReuniaoFJUAssistidaPeloJovem(ReuniaoFJU reuniaoFJU) {
            reuniaoFJU.JovensQueAssistem.Add(this);
            this._reunioesFJUAssistidasPeloJovem.Add(reuniaoFJU);
        }
        public virtual void addReunioesFJUAssistidaPeloJovem(IList<ReuniaoFJU> reunioesAssistidas) {
            foreach (var reuniao in reunioesAssistidas){
                reuniao.JovensQueAssistem.Add(this);
                this._reunioesFJUAssistidasPeloJovem.Add(reuniao);
            }
        }

        public virtual void removeReuniaoFJUAssistidaPeloJovem(ReuniaoFJU reuniaoAExcluir){
            var indiceReuniaoExcluir = _reunioesFJUAssistidasPeloJovem.IndexOf(reuniaoAExcluir);
            this._reunioesFJUAssistidasPeloJovem.RemoveAt(indiceReuniaoExcluir);
        }
        /*se método abaixo der certo excluir o de cima*/
        public virtual void removeReuniaoFJUAssistidaPeloJovem(int indiceReuniaoAExcluir)
        {
            this._reunioesFJUAssistidasPeloJovem.RemoveAt(indiceReuniaoAExcluir);
        }

        public virtual void removeLivroLidoPeloJovem(int indiceLivroRemover) {
            this._livrosLidoPeloJovem.RemoveAt(indiceLivroRemover);
        }
    }
}
