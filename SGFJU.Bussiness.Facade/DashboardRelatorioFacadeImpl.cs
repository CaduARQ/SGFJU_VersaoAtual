using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public class DashboardRelatorioFacadeImpl : FacadeBaseImpl<DashboardRelatorio>, DashboardRelatorioFacade {
        public IList<RelatorioTotaisGeralDTO> RetornaTotaisNacional(){
            try {
                return this.__diContainer.GetServiceImplementationToType<DashboardRelatorioRepository>().RetornaTotaisNacional();
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public RelatorioTotaisGeralDTO RetornaRelatorioTotaisEstado(Estado estadoParametro) {
            try {
                return this.__diContainer.GetServiceImplementationToType<DashboardRelatorioRepository>().RetornaRelatorioTotaisEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public RelatorioTotaisGeralDTO RetornaRelatorioTotaisPorbloco(Bloco blocoParametro) {
            try {
                return this.__diContainer.GetServiceImplementationToType<DashboardRelatorioRepository>().RetornaRelatorioTotaisPorbloco(blocoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<RelatorioBlocoTotaisGeraisDTO> RetornaTotaisBlocosPorEstado(Estado estadoParametro) { 
            try {
                return this.__diContainer.GetServiceImplementationToType<DashboardRelatorioRepository>().RetornaTotaisBlocosPorEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public void AtualizarDashboard(Estado estadoParametro) { 
            try {
                this.__diContainer.GetServiceImplementationToType<DashboardRelatorioRepository>().AtualizarDashboard(estadoParametro);
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
