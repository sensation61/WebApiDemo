using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(web_api_demo.Startup))]

namespace web_api_demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //HttpConfiguration configuration = new HttpConfiguration();
            //// I'm not sure it this is the proper way to use webapiconfig

            //WebApiConfig.Register(configuration);

            //app.UseWebApi(configuration);
            //app.UseCors(CorsOptions.AllowAll);
            //ConfigureAuth(app);

            //ConfigureAuth(app);
            //app.UseCors

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888


            //HttpConfiguration config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            //ConfigureAuth(app);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);
        }
    }
}
