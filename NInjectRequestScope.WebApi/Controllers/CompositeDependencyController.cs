using System.Web.Http;

using NInjectRequestScope.WebApi.Services;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class CompositeDependencyController : ApiController
    {
        private CompositeSubService composite;

        public CompositeDependencyController(CompositeSubService composite)
        {
            this.composite = composite;
        }

        [Route("test/compositeDependency")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return this.Ok(new[]
            {
                new [] { this.composite.DependencyServiceA.Id },
                new [] { this.composite.DependencyServiceB.Id },
                new [] { this.composite.Id }
            });
        }
    }
}
