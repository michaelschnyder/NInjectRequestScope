using System.Web.Http;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NInjectRequestScope.SelfHost.Startup))]

namespace NInjectRequestScope.SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();

            httpConfiguration.MapHttpAttributeRoutes();

            app.UseWebApi(httpConfiguration);
        }
    }
}
