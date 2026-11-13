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
    public class DashboardRelatorioBlocoFacadeImpl : FacadeBaseImpl<DashboardRelatorioBloco>, DashboardRelatorioBlocoFacade
    {
        public void AtualizarDashboard(Estado estadoParametro)
        {
            throw new NotImplementedException();
        }

        public RelatorioBlocoTotaisGeraisDTO RetornaRelatorioTotaisPorbloco(Bloco blocoParametro) {
            try {
                return this.__diContainer.GetServiceImplementationToType<DashboardRelatorioBlocoRepository>().RetornaRelatorioTotaisPorbloco(blocoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<RelatorioBlocoTotaisGeraisDTO> RetornaTotaisBlocosNacional() {
            try {
                return this.__diContainer.GetServiceImplementationToType<DashboardRelatorioBlocoRepository>().RetornaTotaisBlocosNacional();
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
                return this.__diContainer.GetServiceImplementationToType<DashboardRelatorioBlocoRepository>().RetornaTotaisBlocosPorEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
    }
}
