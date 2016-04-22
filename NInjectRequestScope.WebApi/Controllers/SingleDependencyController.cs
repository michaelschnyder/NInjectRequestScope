using System.Web.Http;

using NInjectRequestScope.WebApi.Services;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class SingleDependencyController : ApiController
    {
        private readonly NoDependencyServiceA serviceA;

        public SingleDependencyController(NoDependencyServiceA serviceA)
        {
            this.serviceA = serviceA;
        }

        [Route("test/singleDependency")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return this.Ok(new [] { new[] { this.serviceA.Id } });
        }
    }
}
