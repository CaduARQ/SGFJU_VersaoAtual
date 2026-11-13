using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Repositories;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public class FacadeJovemImpl : FacadeBaseImpl<Jovem>, FacadeJovem
    {

        public void SalvarJovem(Jovem                         novoJovem, 
                                IList<JovemIdioma>            idiomasFaladosJovem,
                                IList<JovemHabilidadeProjeto> habilidadesPossuidasPeloJovem,
                                JovemProjeto                  projetoAQualJovemPertence,                                
                                Testemunho                    testemunhoDoJovem) {
            try
            {
                this.__diContainer
                    .GetServiceImplementationToType<JovemRepository>().SalvarJovem(novoJovem, 
                                                                                   idiomasFaladosJovem,
                                                                                   habilidadesPossuidasPeloJovem,
                                                                                   projetoAQualJovemPertence,
                                                                                   testemunhoDoJovem);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public void AtualizarJovem(Jovem                         novoJovem,                            
                                   IList<JovemIdioma>            idiomasFaladosJovem,
                                   IList<JovemIdioma>            idiomasParaExcluirDoJovem,
                                   IList<JovemHabilidadeProjeto> habilidadesPossuidasPeloJovem,
                                   IList<JovemHabilidadeProjeto> habilidadesParaExcluirDoJovem,
                                   JovemProjetoContainer         projetoAQualJovemPertence,
                                   Testemunho                    testemunhoDoJovem){
            try
            {
                this.__diContainer
                    .GetServiceImplementationToType<JovemRepository>().AtualizarJovem(novoJovem, 
                                                                                      idiomasFaladosJovem,
                                                                                      idiomasParaExcluirDoJovem,
                                                                                      habilidadesPossuidasPeloJovem,
                                                                                      habilidadesParaExcluirDoJovem,
                                                                                      projetoAQualJovemPertence,
                                                                                      testemunhoDoJovem);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public void TransferirJovem(TodosJovensDTO jovemParaTranferir) {
            try
            {
                this.__diContainer
                    .GetServiceImplementationToType<JovemRepository>().TransferirJovem(jovemParaTranferir);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public void TransferirJovensEntreIgrejas(int idIgrejaOrigem, int idIgrejaDestino, bool tranferirTodos, IList<TodosJovensDTO> jovensParaTransferir, int idUsuarioTranferiu) {
            try {
                this.__diContainer
                    .GetServiceImplementationToType<JovemRepository>().TransferirJovensEntreIgrejas(idIgrejaOrigem, idIgrejaDestino, tranferirTodos, jovensParaTransferir, idUsuarioTranferiu);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<HistoricoTransferenciaDTO> ObterHistoricoTransferenciasRealizadas() { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>()
                           .ObterHistoricoTransferenciasRealizadas();
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<HistoricoTransferenciaDTO> ObterHistoricoTransferenciasRealizadasPorParametro(ParametroPesquisaHistoricoTransferenciaDTO parametroPesquisa) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>()
                           .ObterHistoricoTransferenciasRealizadasPorParametro(parametroPesquisa);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public void ExcluirInformacoesJovem(Jovem jovemParaExcluir) { 
            try
            {
                this.__diContainer
                    .GetServiceImplementationToType<JovemRepository>().ExcluirInformacoesJovem(jovemParaExcluir);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public Jovem Loggar(string login, byte[] password)
        {
            throw new NotImplementedException();
        }

        public IList<Jovem> ObterJovensPorBloco(Bloco blocoParametro)
        {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterJovensPorBloco(blocoParametro);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<Jovem> ObterJovensPorEstado(Estado estadoParametro)
        {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterJovensPorEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<Jovem> ObterJovensPorRegiao(Regiao regiaoParametro)
        {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterJovensPorRegiao(regiaoParametro);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<Jovem> ObterPorParametro(ParametroPesquisaDetalhadaDTO parametroPesquisaDetalhada)
        {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterPorParametro(parametroPesquisaDetalhada);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<TodosJovensDTO> ObterJovensPorParametro(ParametroPesquisaTodosJovensDTO parametrosPesquisa) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterJovensPorParametro(parametrosPesquisa);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public Testemunho ObterTestemunhoDoJovem(Jovem jovemParametro) {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterTestemunhoDoJovem(jovemParametro);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public JovemDTO ObterJovemInformacoesDetalhadas(Jovem jovemParametro) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterJovemInformacoesDetalhadas(jovemParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<JovemDTO> ObterJovensPorHabilidade(ParametroPesquisaHabilidadeProjetoDTO parametrosPesquisa) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterJovensPorHabilidade(parametrosPesquisa);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<JovemDTO> ObterPastoresPorEstado(Estado estadoParametro) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterPastoresPorEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<JovemDTO> ObterObreirosPorIgreja(Igreja igrejaParametro) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ObterObreirosPorIgreja(igrejaParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<TodosJovensDTO> ListaJovensConsultaGeral(ConsultaGeralDTO parametrosConsultaGeral) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().ListaJovensConsultaGeral(parametrosConsultaGeral);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public RespostaAprovacaoCompraCamisa SolicitarAutorizacaoCompraCamisa(IList<AutorizacaoCompraCamisaDTO> pSolicitacoesAutorizacaoCompra) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().SolicitarAutorizacaoCompraCamisa(pSolicitacoesAutorizacaoCompra);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<JovemAutorizacaoCamisaDTO> PesquisaAutorizacoesCamisaFJUPorParametro(ConsultaGeralDTO parametrosConsultaGeral) {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().PesquisaAutorizacoesCamisaFJUPorParametro(parametrosConsultaGeral);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public bool JaExistemSolicitacoesCadastradas(int pIdJovem) {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().JaExistemSolicitacoesCadastradas(pIdJovem);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public RespostaAprovacaoCompraCamisa VerificaCodigoArcacenter(AutorizacaoCompraCamisaDTO codigoArcaCenter) {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().VerificaCodigoArcacenter(codigoArcaCenter);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public RespostaAprovacaoCompraCamisa DarBaixaCamisa(AutorizacaoCompraCamisaDTO codigoAutorizacaASerDadoBaixa) {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().DarBaixaCamisa(codigoAutorizacaASerDadoBaixa);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public void ExcluirAutorizacaoCamisa(AutorizacaoCompraCamisaDTO autorizacaoParaExcluir) { 
            try {
                this.__diContainer
                       .GetServiceImplementationToType<JovemRepository>().ExcluirAutorizacaoCamisa(autorizacaoParaExcluir);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AutorizacaoCompraCamisaDTO> RetornaHistoricoSolicitacoesCamisa(JovemDTO pJovem) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().RetornaHistoricoSolicitacoesCamisa(pJovem);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public bool AindaPodeSolicitarCamisa(int pIdJovem) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<JovemRepository>().AindaPodeSolicitarCamisa(pIdJovem);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public void AlteraClassificacaoJovem(JovemDTO jovemParametro) { 
            try {
                this.__diContainer
                    .GetServiceImplementationToType<JovemRepository>()
                    .AlteraClassificacaoJovem(jovemParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
    }
}
