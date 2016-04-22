using System.Web.Http;

using NInjectRequestScope.WebApi.Services;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class MultipleDependencyController : ApiController
    {
        private readonly NoDependencyServiceA serviceA;

        private readonly NoDependencyServiceB serviceB;

        public MultipleDependencyController(NoDependencyServiceA serviceA, NoDependencyServiceB serviceB)
        {
            this.serviceA = serviceA;
            this.serviceB = serviceB;
        }
        
        [Route("test/multipleDependency")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return this.Ok(new[]
            {
                new [] { this.serviceA.Id },
                new [] { this.serviceB.Id },
            });
        }
    }
}
