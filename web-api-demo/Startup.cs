using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(web_api_demo.Startup))]

namespace web_api_demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
