using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using SGFJU.Domain.Model;

namespace SGFJU.Bussiness.Facade
{
    public class FacadeCoordenadorImpl : FacadeBaseImpl<IgrejaCoordenador>, FacadeCoordenador {
        public void RegistraCoordenador(IgrejaCoordenador novoCoordenador) {
            try {
                this.__diContainer
                    .GetServiceImplementationToType<CoordenadorRepository>().RegistraCoordenador(novoCoordenador: novoCoordenador);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public void AssociaObreiroComoCoordenador(IgrejaCoordenador novoCoordenador) {
            try {
                this.__diContainer
                    .GetServiceImplementationToType<CoordenadorRepository>().AssociaObreiroComoCoordenador(novoCoordenador: novoCoordenador);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public void AtualizarCoordenador(IgrejaCoordenador coordenadorParaAtualizacao) {
            try {
                this.__diContainer
                    .GetServiceImplementationToType<CoordenadorRepository>().AtualizarCoordenador(coordenadorParaAtualizacao: coordenadorParaAtualizacao);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<IgrejaCoordenadorDTO> PesquisarCoordenadorPorParametro(IgrejaCoordenadorParametroDTO parametroPesquisaCoordenador) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<CoordenadorRepository>().PesquisarCoordenadorPorParametro(parametroPesquisaCoordenador);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<IgrejaCoordenadorDTO> ListarCoordenadoresPorEstado(EstadoDTO estadoParametro) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<CoordenadorRepository>().ListarCoordenadoresPorEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public void TrocarCoordenador(IgrejaCoordenador coordenadorParaTrocar) {
            try {
                this.__diContainer.GetServiceImplementationToType<CoordenadorRepository>().TrocarCoordenador(coordenadorParaTrocar);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IgrejaCoordenadorDTO ObterCoordenadorInformacoesDetalhadas(IgrejaCoordenadorDTO parametroCoordenador) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<CoordenadorRepository>().ObterCoordenadorInformacoesDetalhadas(parametroCoordenador);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IgrejaCoordenador ObterIgrejaCoordenadorPorID(int idIgrejaCoordenador) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<CoordenadorRepository>().ObterIgrejaCoordenadorPorID(idIgrejaCoordenador);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public void InformarIgrejaSemCoordenador(Igreja igrejaSemCoordenador) {
            try {
                this.__diContainer
                    .GetServiceImplementationToType<CoordenadorRepository>().InformarIgrejaSemCoordenador(igrejaSemCoordenador);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorPorEstado(EstadoDTO estadoParametro) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<CoordenadorRepository>().ObterPanoramaGeralCoordenadorPorEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorNacional() { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<CoordenadorRepository>().ObterPanoramaGeralCoordenadorNacional();
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
