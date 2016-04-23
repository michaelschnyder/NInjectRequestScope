using System.Web.Http;

using NInjectRequestScope.WebApi.Services;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class InterfacedAndDirectDependencyController : ApiController
    {
        private readonly ISupportDependencyServiceA rootCompositeWithA;

        private readonly ISupportDependencyServiceB rootCompositeWithB;

        private readonly CompositeMasterService compositeMasterService;

        public InterfacedAndDirectDependencyController(ISupportDependencyServiceA rootCompositeWithA, ISupportDependencyServiceB rootCompositeWithB, CompositeMasterService compositeMasterService)
        {
            this.rootCompositeWithA = rootCompositeWithA;
            this.rootCompositeWithB = rootCompositeWithB;
            this.compositeMasterService = compositeMasterService;
        }

        [Route("test/interfacedAndDirectRootComposite")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return this.Ok(new [] { new[] { this.rootCompositeWithA.Id, this.rootCompositeWithB.Id, this.compositeMasterService.Id } });
        }
    }
}
