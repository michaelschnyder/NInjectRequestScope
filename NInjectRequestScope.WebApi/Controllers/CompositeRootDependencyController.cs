using System.Web.Http;

using NInjectRequestScope.WebApi.Services;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class CompositeRootDependencyController : ApiController
    {
        private readonly CompositeMasterService compositeMasterService;

        public CompositeRootDependencyController(CompositeMasterService compositeMasterService)
        {
            this.compositeMasterService = compositeMasterService;
        }

        [Route("test/compositeRoot")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return this.Ok(new []
                {
                    new[] { this.compositeMasterService.DependencyServiceA.Id, this.compositeMasterService.SubService.DependencyServiceA.Id },
                    new[] { this.compositeMasterService.DependencyServiceB.Id, this.compositeMasterService.SubService.DependencyServiceB.Id }
                });
        }
    }
}
