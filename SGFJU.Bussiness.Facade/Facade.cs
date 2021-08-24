using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface Facade<TEntity> where TEntity : Entity<TEntity>
    {
        void Save(TEntity entity);
        void SaveBatch(IList<TEntity> entities);
        void SaveValueObject<TValueObject>(TValueObject valueObject) where TValueObject : class;
        TEntity GetByID(int id);
        IList<TEntity> ListAll();
        IList<TValueObject> ListAllValueObjects<TValueObject>() where TValueObject : class;
        IList<TValueObject> ListAllValueObjectsFromJson<TValueObject>(string caminhoArquivoJson) where TValueObject : class;
        IList<TDTORetorno> ListAllDTOFromJson<TValueObjectToList, TDTORetorno>(string caminhoArquivoJson) where TValueObjectToList : class
                                                                                                         where TDTORetorno        : class   ;
        IList<TResultSetDTO> ListAllObjectsFromTypeAsDTO<TEntitySet, TResultSetDTO>(Func<TEntitySet, TResultSetDTO> expressToTranformEntityToDTO, string pathFileJSON) where TResultSetDTO : class
                                                                                                                                                                       where TEntitySet : class;
        void Delete(int id);
    }
}
