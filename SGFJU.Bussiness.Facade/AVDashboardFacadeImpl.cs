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
    public class AVDashboardFacadeImpl : FacadeBaseImpl<Jovem>, AVDashboardFacade
    {
        public IList<TotaisArvoreVidaEstadoDTO> ListaTotaisArvoreVidaGeral() { 
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<AVDashboardRepository>().ListaTotaisArvoreVidaGeral();
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

        public TotaisArvoreVidaEstadoDTO ListaTotaisArvoreVidaPorEstado(EstadoDTO pEstadoDTO) { 
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<AVDashboardRepository>().ListaTotaisArvoreVidaPorEstado(pEstadoDTO);
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
    }
}
