using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Common.UnityContainer;
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
    public class FacadeEstadoImpl : FacadeBaseImpl<Estado>, EstadoFacade
    {
        public FacadeEstadoImpl()
        {
            this.__diContainer = new UnityDIContainer();
        }
        public IList<Bloco> obterBlocosDoEstado(Estado estadoParametro)
        {
            try
            {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().obterBlocosDoEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public IList<RegiaoDTO> ObterRegioesPorEstado(Estado estadoParametro) {
            try
            {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().ObterRegioesPorEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public IList<Igreja> obterIgrejasDaRegiao(Regiao regiaoParametro)
        {
            try
            {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().obterIgrejasDaRegiao(regiaoParametro);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public IList<Regiao> obterRegioesDoBloco(Bloco blocoParametro)
        {
            try
            {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().obterRegioesDoBloco(blocoParametro);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public IList<Regiao> obterTodasRegioesDoEstado(Estado estadoParametro) {
            try {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().obterTodasRegioesDoEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public IList<IgrejaDTO> obterTodasIgrejasDoEstado(Estado estadoParametro) { 
            try {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().obterTodasIgrejasDoEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public ResultadoExclusaoBlocoDTO PodeExcluirBloco(Bloco bloco) {
            try {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().PodeExcluirBloco(bloco);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public ResultadoExclusaoRegiaoDTO PodeExcluirRegiao(Regiao regiao)
        {
            try {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().PodeExcluirRegiao(regiao);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public ResultadoExclusaoIgrejaDTO PodeExcluirIgreja(Igreja igreja) {
            try {
                return this.__diContainer.GetServiceImplementationToType<EstadoRepository>().PodeExcluirIgreja(igreja);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }

        public void ExcluirIgrejaDoEstado(Igreja igrejaParaExclusao) {
            try {
                this.__diContainer.GetServiceImplementationToType<EstadoRepository>().ExcluirIgrejaDoEstado(igrejaParaExclusao);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        
        public void ExcluirBlocoDoEstado(Bloco blocoParaExclusao) {
            try {
                this.__diContainer.GetServiceImplementationToType<EstadoRepository>().ExcluirBlocoDoEstado(blocoParaExclusao);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public void ExcluirRegiaoDoEstado(Regiao regiaoParaExclusao) {
            try {
                this.__diContainer.GetServiceImplementationToType<EstadoRepository>().ExcluirRegiaoDoEstado(regiaoParaExclusao);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }

        public IList<IgrejaCoordenadorDTO> RetornaInformacoesIgrejasEstado(Estado estadoParametro) { 
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<EstadoRepository>()
                            .RetornaInformacoesIgrejasEstado(estadoParametro);
                                    
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public bool IgrejaPossuiCoordenador(IgrejaCoordenador igrejaCoordenadorParametro) { 
            try {
                return this.__diContainer
                            .GetServiceImplementationToType<EstadoRepository>()
                            .IgrejaPossuiCoordenador(igrejaCoordenadorParametro);
                                    
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }

        public void AtualizarIgreja(IgrejaDTO igrejaAAtualizar) { 
            try {
                this.__diContainer
                    .GetServiceImplementationToType<EstadoRepository>()
                    .AtualizarIgreja(new Igreja { Id = igrejaAAtualizar.IdIgreja, NomeIgreja = igrejaAAtualizar.NomeIgreja });
                                    
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }

        public bool JaExisteIgrejaNaRegiao(IgrejaDTO igrejaAVerificar) { 
            try {
                return this.__diContainer
                       .GetServiceImplementationToType<EstadoRepository>()
                       .JaExisteIgrejaNaRegiao(igrejaAVerificar);
                                    
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public IList<IgrejaDTO> PesquisarIgrejasPorParametro(IgrejaDTO parametros) { 
            try {
                return this.__diContainer
                       .GetServiceImplementationToType<EstadoRepository>()
                       .PesquisarIgrejasPorParametro(parametros);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public bool TranfereIgrejaDeRegiao(IgrejaDTO igrejaASerTransferida, RegiaoDTO regiaoDestino) { 
            try {
                return this.__diContainer
                       .GetServiceImplementationToType<EstadoRepository>()
                       .TranfereIgrejaDeRegiao(igrejaASerTransferida, regiaoDestino);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
        public bool TranfereRegiaoDeBloco(RegiaoDTO regiaoASerTransferida, BlocoDTO blocoDestino) { 
            try {
                return this.__diContainer
                       .GetServiceImplementationToType<EstadoRepository>()
                       .TranfereRegiaoDeBloco(regiaoASerTransferida, blocoDestino);
            }
            catch (DomainException exceptionFacade) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(exceptionFacade);
                throw new FacadeException(mensagemErroExcecao, exceptionFacade);
            }
            catch (Exception excGeneral) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excGeneral);
                throw new FacadeException(mensagemErroExcecao, excGeneral);
            }
        }
    }
}
