using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.UI.App_Code.Controllers
{
    public class BlocosController : ApiController
    {
        // GET: api/Blocos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Blocos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Blocos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Blocos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Blocos/5
        public void Delete(int id)
        {
        }
    }
}
