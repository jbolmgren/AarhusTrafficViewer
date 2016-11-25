using System.Web.Http;

namespace API.Controllers
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
