using System.Web.Http;

using NInjectRequestScope.WebApi.Services;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class CompositeDependencyWithSinglesController : ApiController
    {
        private CompositeSubService composite;
        private readonly NoDependencyServiceA serviceA;

        private readonly NoDependencyServiceB serviceB;

        public CompositeDependencyWithSinglesController(CompositeSubService composite, NoDependencyServiceA serviceA, NoDependencyServiceB serviceB)
        {
            this.composite = composite;
            this.serviceA = serviceA;
            this.serviceB = serviceB;
        }

        [Route("test/compositeDependencyWithSingleDependency")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return this.Ok(new []
            {
                new [] { this.composite.DependencyServiceA.Id, this.serviceA.Id },
                new [] { this.composite.DependencyServiceB.Id, this.serviceB.Id },
                new [] { this.composite.Id }
            });
        }
    }
}
