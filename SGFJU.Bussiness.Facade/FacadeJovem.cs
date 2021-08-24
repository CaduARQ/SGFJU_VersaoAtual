using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface FacadeJovem : Facade<Jovem>{
        Jovem Loggar(string login, byte[] password);
        void SalvarJovem(Jovem                         novoJovem,
                         IList<JovemIdioma>            idiomasFaladosJovem,
                         IList<JovemHabilidadeProjeto> habilidadesPossuidasPeloJovem,
                         JovemProjeto                  projetoAQualJovemPertence,
                         Testemunho                    testemunhoDoJovem);
        void AtualizarJovem(Jovem                         novoJovem,                            
                            IList<JovemIdioma>            idiomasFaladosJovem,
                            IList<JovemIdioma>            idiomasParaExcluirDoJovem,
                            IList<JovemHabilidadeProjeto> habilidadesPossuidasPeloJovem,
                            IList<JovemHabilidadeProjeto> habilidadesParaExcluirDoJovem,
                            JovemProjetoContainer         projetoAQualJovemPertence,
                            Testemunho                    testemunhoDoJovem);
        void TransferirJovem(TodosJovensDTO jovemParaTranferir);
        void TransferirJovensEntreIgrejas(int idIgrejaOrigem, int idIgrejaDestino, bool tranferirTodos, IList<TodosJovensDTO> jovensParaTransferir, int idUsuarioTranferiu);
        IList<HistoricoTransferenciaDTO> ObterHistoricoTransferenciasRealizadas();
        IList<HistoricoTransferenciaDTO> ObterHistoricoTransferenciasRealizadasPorParametro(ParametroPesquisaHistoricoTransferenciaDTO parametroPesquisa);
        void ExcluirInformacoesJovem(Jovem jovemParaExcluir);
        IList<Jovem> ObterPorParametro(ParametroPesquisaDetalhadaDTO parametroPesquisaDetalhada);
        IList<TodosJovensDTO> ObterJovensPorParametro(ParametroPesquisaTodosJovensDTO parametrosPesquisa);
        IList<Jovem> ObterJovensPorEstado(Estado estadoParametro);
        IList<Jovem> ObterJovensPorBloco(Bloco blocoParametro);
        IList<Jovem> ObterJovensPorRegiao(Regiao regiaoParametro);
        Testemunho ObterTestemunhoDoJovem(Jovem jovemParametro);
        JovemDTO ObterJovemInformacoesDetalhadas(Jovem jovemParametro);
        IList<JovemDTO> ObterJovensPorHabilidade(ParametroPesquisaHabilidadeProjetoDTO parametrosPesquisa);
        IList<JovemDTO> ObterPastoresPorEstado(Estado estadoParametro);
        IList<JovemDTO> ObterObreirosPorIgreja(Igreja igrejaParametro);
        IList<TodosJovensDTO> ListaJovensConsultaGeral(ConsultaGeralDTO parametros);
        RespostaAprovacaoCompraCamisa SolicitarAutorizacaoCompraCamisa(IList<AutorizacaoCompraCamisaDTO> pSolicitacoesAutorizacaoCompra);
        IList<JovemAutorizacaoCamisaDTO> PesquisaAutorizacoesCamisaFJUPorParametro(ConsultaGeralDTO parametrosConsultaGeral);
        RespostaAprovacaoCompraCamisa VerificaCodigoArcacenter(AutorizacaoCompraCamisaDTO codigoArcaCenter);
        RespostaAprovacaoCompraCamisa DarBaixaCamisa(AutorizacaoCompraCamisaDTO codigoAutorizacaASerDadoBaixa);
        bool AindaPodeSolicitarCamisa(int pIdJovem);
        void AlteraClassificacaoJovem(JovemDTO jovemParametro);
    }
}
