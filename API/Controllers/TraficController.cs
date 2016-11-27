using System.Threading.Tasks;
using System.Web.Http;
using Core;
using RequestHandlers;

namespace API.Controllers
{
    [RoutePrefix("api/trafic")]
    public class TraficController : ApiController
    {
        private readonly IResponseGenerator _generator;
        private readonly ITraficDataReader _traficDataReader;

        public TraficController(IResponseGenerator generator, ITraficDataReader traficDataReader)
        {
            _generator = generator;
            _traficDataReader = traficDataReader;
        }

        [Route("location")]
        [HttpGet]
        public async Task<TraficLocationResponse> LoadLocation(TraficLocationRequestData data)
        {
            return await _generator.Create(new TraficLocationRequestHandler(_traficDataReader, data));
        }
    }
}