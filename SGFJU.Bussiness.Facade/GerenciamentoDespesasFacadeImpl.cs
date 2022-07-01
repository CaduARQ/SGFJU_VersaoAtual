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
    public class GerenciamentoDespesasFacadeImpl : FacadeBaseImpl<Despesa>, GerenciamentoDespesasFacade
    {
        public IList<DespesaDTO> ListaDespesasPorParametro(ParametroDespesasDTO parametrosPesquisa) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<GerenciamentoDespesasRepository>()
                           .ListaDespesasPorParametro(parametrosPesquisa);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<DespesaDTO> ListarDespesasRegistradasHojePorEstado(EstadoDTO estadoDespesas = null) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<GerenciamentoDespesasRepository>()
                           .ListarDespesasRegistradasHojePorEstado(estadoDespesas);
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
