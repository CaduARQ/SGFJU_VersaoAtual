using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public class FacadeRelatorioReuniaoFJUIgrejaImpl : FacadeBaseImpl<RelatorioReuniaoFJUIgreja>, FacadeRelatorioReuniaoFJUIgreja
    {
        public RespostaProcessamentoFechamentoRelatorioEstadoDTO ProcessarFechamentoRelatorioEstado(FechamentoRelatorioEstadoDTO parametroFechamentoRelatorio) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .ProcessarFechamentoRelatorioEstado(parametroFechamentoRelatorio);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public RespostaProcessamentoFechamentoRelatorioBlocoDTO ProcessarFechamentoRelatorioBloco(ProcessaFechamentoRelatorioBlocoDTO parametroFechamentoRelatorioBloco) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .ProcessarFechamentoRelatorioBloco(parametroFechamentoRelatorioBloco);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgreja(RelatorioReuniaoFJUIgrejaDTO relatorio) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .ProcessarRelatorioIgreja(relatorio);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgrejas(IList<RelatorioReuniaoFJUIgrejaDTO> relatorios) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .ProcessarRelatorioIgrejas(relatorios);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<RelatorioReuniaoFJUIgrejaDTO> ListaRelatorioIgrejasEstadoPorPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo parametrosPesquisa){
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .ListaRelatorioIgrejasEstadoPorPeriodo(parametrosPesquisa);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public bool RelatorioDaIgrejaJaLancadoNoPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo periodoEmQuestao) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .RelatorioDaIgrejaJaLancadoNoPeriodo(periodoEmQuestao);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public RespostaProcessamentoRelatorioDTO AtualizaRelatorioPeriodo(RelatorioReuniaoFJUIgrejaDTO relatorioASerAtualizado) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .AtualizaRelatorioPeriodo(relatorioASerAtualizado);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public bool RelatorioNoPeriodoJaEstaProcessado(ParametroPesquisaRelatorioIgrejasPeriodo parametrosVerificacao) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .RelatorioNoPeriodoJaEstaProcessado(parametrosVerificacao);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public RelatorioConsolidadoEstadualSemanal RetornaRelatorioConsolidadoEstadoPorPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo parametros) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<RelatorioReuniaoFJUIgrejaRepository>()
                           .RetornaRelatorioConsolidadoEstadoPorPeriodo(parametros);
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
