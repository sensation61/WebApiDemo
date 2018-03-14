using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Http.ExceptionHandling;

using web_api_demo.Filte.Handler;
using web_api_demo.Filter.ActionFilter;


namespace web_api_demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes

            var cors = new EnableCorsAttribute("http://localhost:5985", "*", "*");
            config.EnableCors(cors);


            config.MapHttpAttributeRoutes();
                       
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region  Project AuthorizeAttribute

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            #endregion

            #region  Project DebugExceptionFilter

            config.Filters.Add(new DebugActionFilter());

            config.Services.Replace(typeof(IExceptionHandler), new DebugExceptionFilter());
            
            #endregion


            //config.Formatters.Clear();

            #region Request Accept Header Format Json And XML

            //List<MediaTypeFormatter> formatList = new List<MediaTypeFormatter>();

            //var jsonFormatter = new JsonMediaTypeFormatter();
            //jsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "application/json; charset=utf-8", System.StringComparison.OrdinalIgnoreCase, true, new MediaTypeHeaderValue("application/json")));
            //jsonFormatter.UseDataContractJsonSerializer = true;
            //formatList.Add(jsonFormatter);

            //var xmlFormatter = new XmlMediaTypeFormatter();
            //xmlFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "application/xml; charset=utf-8", System.StringComparison.OrdinalIgnoreCase, true, new MediaTypeHeaderValue("application/json")));
            //xmlFormatter.UseXmlSerializer = true;
            //formatList.Add(xmlFormatter);

            //config.Formatters.AddRange(formatList);

            //QueryString result multiple support Json and Xml
            //config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            //config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

            #endregion

            #region Request QueryStringMapping parameter Format Json And XML

            //List<MediaTypeFormatter> formatList = new List<MediaTypeFormatter>();

            //var jsonFormatter = new JsonMediaTypeFormatter();
            //jsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            //jsonFormatter.UseDataContractJsonSerializer = true;
            //formatList.Add(jsonFormatter);

            //var xmlFormatter = new XmlMediaTypeFormatter();
            //xmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
            //xmlFormatter.UseXmlSerializer = true;
            //formatList.Add(xmlFormatter);

            //config.Formatters.AddRange(formatList);

            #endregion

            //config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "application/json; charset=utf-8", System.StringComparison.CurrentCultureIgnoreCase, true, new MediaTypeHeaderValue("application/json")));
            //config.Formatters.XmlFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "application/xml; charset=utf-8", System.StringComparison.CurrentCultureIgnoreCase, true, new MediaTypeHeaderValue("application/json")));
        }
    }
}
