using System.Web.Http;

using NInjectRequestScope.WebApi.Services;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class InterfacedDependencyController : ApiController
    {
        private readonly ISupportDependencyServiceA rootCompositeWithA;

        private readonly ISupportDependencyServiceB rootCompositeWithB;

        public InterfacedDependencyController(ISupportDependencyServiceA rootCompositeWithA, ISupportDependencyServiceB rootCompositeWithB)
        {
            this.rootCompositeWithA = rootCompositeWithA;
            this.rootCompositeWithB = rootCompositeWithB;
        }

        [Route("test/interfacedRootComposite")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return this.Ok(new [] { new[] { this.rootCompositeWithA.Id, this.rootCompositeWithB.Id } });
        }
    }
}
