using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public class BuscaAvancadaTestemunhoFacadeImpl : FacadeBaseImpl<Jovem>, BuscaAvancadaTestemunhoFacade {
        public IList<RetornoBuscaAvancadaDTO> BuscaAvancadaTestemunhoPorParametro(BuscaAvancadaParametroDTO parametrosBuscaAvancada) {
			try {
                return this.__diContainer
                           .GetServiceImplementationToType<BuscaAvancadaTestemunhoRepository>()
                           .BuscaAvancadaTestemunhoPorParametro(parametrosBuscaAvancada);
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
