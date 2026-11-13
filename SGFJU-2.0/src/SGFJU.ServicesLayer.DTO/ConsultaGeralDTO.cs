using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class ConsultaGeralDTO
    {
        public ConsultaGeralDTO() {
            this.ParametrosHabilidade = new List<HabilidadeProjetoNivelDTO>();
        }

        public int IdEstado { get; set; }
        public int IdBlocoJovem { get; set; }
        public int IdRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int IdadeInicial { get; set; }
        public int IdadeFinal { get; set; }
        public int AnoNascimento { get; set; }
        public int IdProjeto { get; set; }
        public int IdDepartamento { get; set; }
        public int IdHabilidade { get; set; }
        public int IdNivel { get; set; }
        public string CodigoAutorizacaoSGFJU { get; set; }
        public char EhParaListarFichasExpiradas { get; set; }
        //
        public int IdTipoEstadoCivil { get; set; }
        public int IdTipoMoradia { get; set; }
        public char ConjugeEhIURD { get; set; }
        public char TrabalhaAtualmente { get; set; }
        public char EstudaAtualmente { get; set; }
        public char PossuiTituloEleitor { get; set; }
        public string Profissao { get; set; }
        public string Escolaridade { get; set; }
        public char EhMembroIURD { get; set; }
        public char JaSeAfastou { get; set; }
        public char TemFamiliaresIURD { get; set; }
        public char FoiObreiro { get; set; }
        public char FoiPastor { get; set; }
        public char DesejaSerObreiro { get; set; }
        public char PertenceIntellimen { get; set; }
        public char DesafiosConcluidos { get; set; }
        public int IdReuniaoFJU { get; set; }
        public char PertenceGrupoMulheresIURD { get; set; }
        public char EhSeguidorOficialFJU { get; set; }
        public char EhSeguidorYoutube { get; set; }
        public char EhSeguidorTelegram { get; set; }
        public char EhAssinanteUNIVER { get; set; }
        public char EhLeitorBlogBM { get; set; }
        public char EhLeitorUniversalorg { get; set; }
        public char PossuiBiblia { get; set; }
        public char PossuiBibliaNoCelular { get; set; }
        public char LeuTodaBiblia { get; set; }
        public char PossuiCelularComInternet { get; set; }
        public char PossuiComputador { get; set; }
        public char PossuiNivelSuperior { get; set; }
        public string NomeCursoSuperior { get; set; }
        public int idModalidadeCursadaEnsinoSuperior { get; set; }
        public char DesejaCursarNivelSuperior { get; set; }
        public char SofreuComDepressao { get; set; }
        public char SofreuAutomutilacao { get; set; }
        public char SofreuVicio { get; set; }
        public char TentouSuicidio { get; set; }
        public int IdIdiomaFalado { get; set; }
        public int IdNivelIdiomaFalado { get; set; }

        public char ClassificacaoJovem { get; set; }
        public char Sexo { get; set; }

        public char EhAltarJovem318 { get; set; }
        public string CodigoAltarJovem318 { get; set; }
        //
        public char EhObreiro { get; set; }
        public char EhColaborador { get; set; }
        public char EhCPO { get; set; }
        public char EhMembroFJU { get; set; }
        public char EhCoordenadorFJU { get; set; }
        public char EhLiderTribo { get; set; }
        public char EhLiderProjeto { get; set; }
        public char EhBatizadoAguas { get; set; }
        public char EhBatizadoEspiritoSanto { get; set; }
        public char EhAltarJovem { get; set; }
        public char DesejaFazerObraAltar { get; set; }
        public string CodigosHabilidades { get; set; }
        public string DataNascimento { get; set; }
        public string DataCadastro { get; set; }
        public string DataUltimaAtualizacao { get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }        
        public RangeParametroDataDTO RangeDataNascimento { get; set; }
        public RangeParametroDataDTO RangeDataCadastro { get; set; }
        public RangeParametroDataDTO RangeDataUltimaAtualizacao { get; set; }
        public List<HabilidadeProjetoNivelDTO> ParametrosHabilidade { get; set; }
        public IList<int> DepartamentosSelecionados { get; set; }
        public IList<int> TonsDeVozSelecionados { get; set; }
        public IList<int> HabilidadesEsporteSelecionadas { get; set; }
        public IList<int> IdsNivelHabilidadesEsporteSelecionadas { get; set; }
        public IList<int> IdsProjetosSelecionadosParaPesquisa { get; set; }
        //
    }
}
