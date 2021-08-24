using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public class FacadeArvoreVidaImpl : FacadeBaseImpl<Jovem>, FacadeArvoreVida
    {
        public void AssociaJovensAObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanha)
        {
            try {
                this.__diContainer
                    .GetServiceImplementationToType<ArvoreVidaRepository>().AssociaJovensAObreiro(JovensAcompanhados, ObreiroQueAcompanha);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<TodosJovensDTO> ListaJovensAcompanhadosPorObreiro(ObreiroDTO obreiro) {
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().ListaJovensAcompanhadosPorObreiro(obreiro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public void RegistraHistoricoJovem(JovemHistorico historicoDoJovem) {
            try {
                this.__diContainer
                    .GetServiceImplementationToType<ArvoreVidaRepository>().RegistraHistoricoJovem(historicoDoJovem);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public ObreiroDTO RetornaObreiroQueAcompanhaJovem(Jovem jovemParametro) {
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().RetornaObreiroQueAcompanhaJovem(jovemParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<ObreiroDTO> PesquisaObreiroPorParametro(ParametroPesquisaObreiroDTO parametroPesquisaObreiro) {
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().PesquisaObreiroPorParametro(parametroPesquisaObreiro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<TodosJovensDTO> ListaJovensIgrejaObreiroSemAcompanhamento(ObreiroDTO obreiroParametro) {
            try
            {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().ListaJovensIgrejaObreiroSemAcompanhamento(obreiroParametro);
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

        public AcompanhamentoJovemDTO RetornaHistoricoAcompanhamentoJovem(JovemDTO jovemParametro){
            try { 
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().RetornaHistoricoAcompanhamentoJovem(jovemParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public void DesassociaJovensDeObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanhava) {
            try { 
                this.__diContainer
                     .GetServiceImplementationToType<ArvoreVidaRepository>().DesassociaJovensDeObreiro(JovensAcompanhados, ObreiroQueAcompanhava);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<TodosJovensDTO> ListaJovensEmAcompanhamentoPorParametro(PesquisaGeralDTO parametroPesquisa) {
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().ListaJovensEmAcompanhamentoPorParametro(parametroPesquisa);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public DataValidaHistoricoDTO EhDataHistoricoAcompanhamentoValida(string pDataHistorico, int pIdJovem) {
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().EhDataHistoricoAcompanhamentoValida(pDataHistorico, pIdJovem);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public ObreiroDTO ObterObreiroPorIDX(IdXDTO idxObreiroParametro) {
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().ObterObreiroPorIDX(idxObreiroParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<ObreiroDTO> ListaObreirosComRamosPorParametro(PesquisaGeralDTO parametrosPesquisa) { 
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().ListaObreirosComRamosPorParametro(parametrosPesquisa);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.Message, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }

        public IList<ObreiroDTO> ListarObreirosSemRamosAVPorParametro(PesquisaGeralDTO parametrosPesquisa)
        { 
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<ArvoreVidaRepository>().ListarObreirosSemRamosAVPorParametro(parametrosPesquisa);
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
