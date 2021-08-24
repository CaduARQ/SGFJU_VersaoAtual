using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SGFJU.UI.App_Code.UI
{
    public class GenericController<TEntity> where TEntity : Entity<TEntity>
    {
        private FacadeBaseImpl<TEntity> __facade;
        protected DIContainer __diContainer;
        protected Serializer __serializer;
        protected string fullPathOfRegionsSerializeds = string.Empty;

        public GenericController()
        {
            __diContainer = new UnityDIContainer();
            __facade = new FacadeBaseImpl<TEntity>();
            __serializer = __diContainer.GetServiceImplementationToType<JSONSerializer>();
        }

        protected void SetFileNameToSerializeEntities(string fileName)
        {
            var directoryOfFileOfObjectsSerializeds = ConfigurationManager.AppSettings["DirectoryResources"];
            fullPathOfRegionsSerializeds = HttpContext.Current.Server.MapPath(directoryOfFileOfObjectsSerializeds + fileName);
        }

        public void Save(TEntity entity)
        {
            __facade.Save(entity);
        }

        public TEntity GetByID(int id)
        {
            return __facade.GetByID(id);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return __facade.ListAll();
        }

        public void Delete(int id)
        {
            __facade.Delete(id);
        }
    }
}