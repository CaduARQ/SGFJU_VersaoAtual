using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.Repositories;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public class FacadeBaseImpl<TEntity> where TEntity : Entity<TEntity>
    {
        protected UnityDIContainer __diContainer;
        private string __diretorioBase = "";
        private Serializer __serializer;

        public FacadeBaseImpl()
        {
            this.__diContainer = new UnityDIContainer();
            this.__diretorioBase = "~/Serializeds";//ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            __serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
        }

        public void Save(TEntity entity)
        {
            try
            {
                this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().Save(entity);
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
        public void SaveBatch(IList<TEntity> entities) {
            try {
                this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().SaveBatch(entities);
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
        public void SaveValueObject<TValueObject>(TValueObject valueObject) where TValueObject : class {
            try {
                this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().SaveValueObject(valueObject);
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public TEntity GetByID(int id)
        {
            try
            {
                return this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().GetByID(id);
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
        public IList<TEntity> ListAll()
        {
            try
            {
                //(new RepositoryImpl<TEntity>()).ListAll(); 
                return this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().ListAll();
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
        public IList<TValueObject> ListAllValueObjects<TValueObject>() where TValueObject : class {
            try {
                return this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().ListAllValueObjects<TValueObject>();
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public IList<TValueObject> ListAllValueObjectsFromJson<TValueObject>(string caminhoArquivoJson) where TValueObject : class {            
            var dataSourceRetorno = new List<TValueObject>();
            if (System.IO.File.Exists(caminhoArquivoJson))
                dataSourceRetorno = __serializer.Deserialized<IList<TValueObject>>(caminhoArquivoJson) as List<TValueObject>;
            else
            {
                dataSourceRetorno = this.ListAllValueObjects<TValueObject>() as List<TValueObject>;
                (__serializer as JSONSerializer).SerializeToJSON(dataSourceRetorno, caminhoArquivoJson);
            }
            return dataSourceRetorno;
        }
        public IList<TDTORetorno> ListAllDTOFromJson<TValueObjectToList, TDTORetorno>(string caminhoArquivoJson) where TValueObjectToList : class
                                                                                                           where TDTORetorno : class
        {
            var dataSource = new List<TValueObjectToList>();
            var dataSourceRetorno = new List<TDTORetorno>();

            if (System.IO.File.Exists(caminhoArquivoJson))
                dataSourceRetorno = __serializer.Deserialized<IList<TDTORetorno>>(caminhoArquivoJson) as List<TDTORetorno>;
            else
            {
                dataSource = this.ListAllValueObjects<TValueObjectToList>() as List<TValueObjectToList>;
                (__serializer as JSONSerializer).SerializeToJSON(dataSource, caminhoArquivoJson);
            }
            return dataSourceRetorno;
        }
        public IList<TResultSetDTO> ListAllObjectsFromTypeAsDTO<TEntitySet, TResultSetDTO>(Func<TEntitySet, TResultSetDTO> expressToTranformEntityToDTO, string pathFileJSON) where TResultSetDTO : class
                                                                                                                                                                              where TEntitySet : class {           
            try {
                var entitySet = this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().ListAllValueObjects<TEntitySet>();
                return entitySet.Select(expressToTranformEntityToDTO).ToList();
            }
            catch (DomainException exceptionFacade) {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
        public void Delete(int id)
        {
            try
            {
                this.__diContainer.GetServiceImplementationToType<Repository<TEntity>>().Delete(id);
            }
            catch (DomainException exceptionFacade)
            {
                throw new FacadeException(exceptionFacade.MensagemExcecaoDetalhada, exceptionFacade);
            }
            catch (Exception excGeneral) {
                throw new FacadeException(excGeneral.Message, excGeneral);
            }
        }
    }
}
