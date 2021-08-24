using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.UI.App_Code.Controllers
{
    public class EstadosController : ApiController
    {
        protected Serializer __serializer;

        public EstadosController()
        {
            __serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
        }
        // GET: api/Estados
        public IEnumerable<Estado> Get()
        {
            var facade = new FacadeBaseImpl<Estado>();
            List<Estado> todosOsEstados = null;
            var caminhoPastaArquivosSerializadosEstados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var nomeArquivoEstadosSerializados = ConfigurationManager.AppSettings["StatesSerializedFileName"];
            var arquivoEstadosSerializados = System.Web.Hosting.HostingEnvironment.MapPath(caminhoPastaArquivosSerializadosEstados + "\\" + nomeArquivoEstadosSerializados);

            if (System.IO.File.Exists(arquivoEstadosSerializados))
                return __serializer.Deserialized<IList<Estado>>(arquivoEstadosSerializados);
            else
            {
                todosOsEstados = facade.ListAll() as List<Estado>;
                (__serializer as JSONSerializer).SerializeToJSON(todosOsEstados, arquivoEstadosSerializados);
            }
            return todosOsEstados;
        }

        // GET: api/Estados/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Estados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Estados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Estados/5
        public void Delete(int id)
        {
        }
    }
}
