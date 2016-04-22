using System.Web.Http;

namespace NInjectRequestScope.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("api/status")]
        public IHttpActionResult Status()
        {
            return this.Ok();
        }
    }
}
