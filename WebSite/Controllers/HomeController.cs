using System.Web.Http;

namespace WebSite.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("")]
        [HttpGet]
        public string Home()
        {
            return "Welcome World";
        }

        [Route("Hallo")]
        [HttpGet]
        public string HalloWorld()
        {
            return "Hallo World";
        }
    }
}
