using System;
using System.Collections.Generic;
using System.Text;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;

namespace SGFJU.Domain.Model.Repositories
{
    public interface Repository<TEntity> where TEntity : Entity<TEntity>
    {
        void Save(TEntity aggregateRoot);
        void SaveBatch(IList<TEntity> entities);
        TEntity GetByID(int id);
        IList<TEntity> ListAll();
        void Delete(int id);
        void SaveValueObject<TValueObject>(TValueObject valueObject) where TValueObject : class;
        IList<TValueObject> ListAllValueObjects<TValueObject>() where TValueObject : class;
    }
}
