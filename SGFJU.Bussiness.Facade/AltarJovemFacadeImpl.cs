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
    public class AltarJovemFacadeImpl : FacadeBaseImpl<Jovem>, AltarJovemFacade {

        public IList<AltarJovemDTO> ObterJovensAltarJovemPorParametro(AltarJovemParametroPesquisaDTO parametros) {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterJovensAltarJovemPorParametro(parametros);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AltarJovemDTO> ObterTodosBR()
        {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterTodosBR();
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorEstado(EstadoDTO estado){
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterTodosJovensAltarJovemPorEstado(new Estado { Id = estado.IdEstado });
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorBloco(BlocoDTO bloco){
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterTodosJovensAltarJovemPorBloco(new Bloco { Id = bloco.idBloco });
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemAgua(){
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterTodosJovensAltarJovemAgua();
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemOleo(){
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterTodosJovensAltarJovemOleo();
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemSal(){
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterTodosJovensAltarJovemSal();
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<AltarJovemDTO> ObterTodosJovensAltarJovemLuz(){
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<AltarJovemRepository>().ObterTodosJovensAltarJovemLuz();
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral)
            {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
    }
}
