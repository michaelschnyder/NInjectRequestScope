using System.Web.Http;

using Microsoft.Owin;

using NInjectRequestScope;

using Owin;
using Ninject.Web.WebApi.OwinHost;
using Ninject.Web.Common.OwinHost;
using Ninject;

using Ninject.Web.Common;

using NInjectRequestScope.WebApi.Services;

[assembly: OwinStartup(typeof(InRequestScopeStartup))]

namespace NInjectRequestScope
{
    public class InRequestScopeStartup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();

            httpConfiguration.MapHttpAttributeRoutes();

            // Update to the latest version to avoid exceptions
            // SO: http://stackoverflow.com/questions/28711963/ninject-activationexception-thrown-only-on-first-web-request-webapi-2-own-3-n

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(httpConfiguration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<NoDependencyServiceA>().To<NoDependencyServiceA>().InRequestScope();
            kernel.Bind<NoDependencyServiceB>().To<NoDependencyServiceB>().InRequestScope();

            // Bind this "Injectable Interfaces" all to the same type within the request scope
            // SO: http://stackoverflow.com/questions/10206049/is-it-possible-to-bind-different-interfaces-to-the-same-instance-of-a-class-impl

            kernel.Bind<ISupportDependencyServiceA, ISupportDependencyServiceB, CompositeMasterService>().To<CompositeMasterService>().InRequestScope();

            return kernel;
        }
    }
}
