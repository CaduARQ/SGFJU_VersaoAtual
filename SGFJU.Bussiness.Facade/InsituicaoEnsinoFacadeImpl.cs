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
    public class InsituicaoEnsinoFacadeImpl : FacadeBaseImpl<InstituicaoEnsino>, InsituicaoEnsinoFacade
    {
        public IList<InstituicaoEnsinoDTO> ListarPorParametro(ParametroPesquisaInstituicaoEnsinoDTO parametroPesquisa)
        {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<InstituicaoEnsinoRepository>()
                           .ListarPorParametro(parametroPesquisa);
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

        public RespostaRequisicaoDTO ExcluirInstituicaoEnsino(InstituicaoEnsinoDTO instituicaoASerExcluida)
        {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<InstituicaoEnsinoRepository>()
                           .ExcluirInstituicaoEnsino(instituicaoASerExcluida);
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
