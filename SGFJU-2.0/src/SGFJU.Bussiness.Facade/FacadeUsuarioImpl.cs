using Newtonsoft.Json;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Repositories;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public class FacadeUsuarioImpl : FacadeBaseImpl<Usuario>, FacadeUsuario
    {
        private const string NOME_CLASSE = "";

        public UsuarioDTO RetornaUsuario(UsuarioDTO usuarioParametro) { 
            try {
                return base.__diContainer.GetServiceImplementationToType<UsuarioRepository>().RetornaUsuario(usuarioParametro);
            }
            catch (DomainException exceptionFacade) {                
                string NOME_METODO = "RegistraUsuario";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exceptionFacade.Message;
                throw new FacadeException(exceptionFacade.InnerException.Message, exceptionFacade);                
            }
            catch (Exception excGeneral) {                
                string NOME_METODO = "RegistraUsuario";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + excGeneral.Message;
                throw new FacadeException(excGeneral.InnerException.Message, excGeneral);
            }
        }
        public void RegistraUsuario(Usuario usuarioNovo) { 
            try {
                base.__diContainer.GetServiceImplementationToType<UsuarioRepository>().RegistraUsuario(usuarioNovo);
            }
            catch (DomainException exceptionFacade) {                
                string NOME_METODO = "RegistraUsuario";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exceptionFacade.Message;
                throw new FacadeException(exceptionFacade.InnerException.Message, exceptionFacade);                
            }
            catch (Exception excGeneral) {                
                string NOME_METODO = "RegistraUsuario";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + excGeneral.Message;
                throw new FacadeException(excGeneral.InnerException.Message, excGeneral);
            }
        }
        public Usuario Loggar(string login, string password) {
            try {
                return base.__diContainer.GetServiceImplementationToType<UsuarioRepository>().Logar(login, password);
            }
            catch (DomainException exceptionFacade) {                
                string NOME_METODO = "Logar";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + exceptionFacade.Message;
                throw new FacadeException(exceptionFacade.InnerException.Message, exceptionFacade);                
            }
            catch (Exception excGeneral) {                
                string NOME_METODO = "Logar";
                var mensagemDetalhada = $"{NOME_CLASSE}.{NOME_METODO} - " + excGeneral.Message;
                throw new FacadeException(excGeneral.InnerException.Message, excGeneral);
            }
        }
        public bool LoginJaCadastrado(string pLogin) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<UsuarioRepository>().LoginJaCadastrado(pLogin);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<UsuarioDTO> RetornaUsuariosEstado(Estado estadoParametro) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<UsuarioRepository>().RetornaUsuariosEstado(estadoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<UsuarioDTO> RetornaUsuariosBloco(Bloco blocoParametro) {
            try
            {
                return this.__diContainer
                           .GetServiceImplementationToType<UsuarioRepository>().RetornaUsuariosBloco(blocoParametro);
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
        public IList<UsuarioDTO> RetornaUsuariosRegiao(Regiao regiaoParametro) {
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<UsuarioRepository>().RetornaUsuariosRegiao(regiaoParametro);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<LogUsuarioDTO> ObterTodasAcoesSGFJU(string arquivoJSONLogUsuario) {
            try {
                var objectSerialized = File.ReadAllText(arquivoJSONLogUsuario);
                var arrayObjetos = objectSerialized.Split('|');
                var listaRetorno = new List<LogUsuarioDTO>();
                foreach (var stringObjeto in arrayObjetos) {
                    var objtDeserializado = JsonConvert.DeserializeObject<LogUsuarioDTO>(stringObjeto);

                    if(objtDeserializado != null)
                        listaRetorno.Add(objtDeserializado);
                }
                return listaRetorno;
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<UsuarioDTO> PesquisaUsuariosPorParametro(PesquisaGeralDTO parametroPesquisa) { 
            try {
                return this.__diContainer
                           .GetServiceImplementationToType<UsuarioRepository>().PesquisaUsuariosPorParametro(parametroPesquisa);
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
