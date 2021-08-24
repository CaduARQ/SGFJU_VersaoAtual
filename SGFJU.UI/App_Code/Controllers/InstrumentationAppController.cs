using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGFJU.UI.App_Code.Controllers
{
    public class InstrumentationAppController : ApiController
    {
        // GET: api/InstrumentationApp
        public IEnumerable<string> Get()
        {
            System.Web.HttpContext.Current.Session.Clear();
            return new string[] { "LimpouSessao" };
        }

        // GET: api/InstrumentationApp/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/InstrumentationApp
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/InstrumentationApp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/InstrumentationApp/5
        public void Delete(int id)
        {
        }
        
    }
}
