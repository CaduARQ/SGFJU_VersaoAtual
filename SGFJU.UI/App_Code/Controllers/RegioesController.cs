using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.UI.App_Code.Controllers
{
    public class RegioesController : ApiController
    {
        // GET: api/Regioes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Regioes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Regioes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Regioes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Regioes/5
        public void Delete(int id)
        {
        }
    }
}
