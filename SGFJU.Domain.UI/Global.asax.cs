using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace SGFJU.Domain.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            /*For Indented formatting:*/
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            /*Response as default json format
             * example (http://localhost:9090/WebApp/api/user/)
             */
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            /*Response as json format depend on request type
             * http://localhost:9090/WebApp/api/user/?type=json
             */
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
            new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            /*Response as xml format depend on request type
             * http://localhost:9090/WebApp/api/user/?type=xml
             */
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
            new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
        }

        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e) {
            /*
            if (HttpContext.Current != null && HttpContext.Current.Session != null) {
                if (Session["UsuarioLogado"] == null)
                    Response.Redirect("formLogin.aspx");
            }*/
        }

        protected void Session_End(Object sender, EventArgs e){
            //System.Web.HttpContext.Current.Response.Redirect("formLogin.aspx");
        }
    }
}
