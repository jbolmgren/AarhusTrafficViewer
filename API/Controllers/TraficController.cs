using System.Threading.Tasks;
using System.Web.Http;
using Core;
using Core.DataAccess;
using Core.Mapper;
using RequestHandlers.RequestHandlers;

namespace API.Controllers
{
    [RoutePrefix("api/trafic")]
    public class TraficController : ApiController
    {
        private readonly IResponseGenerator _generator;
        private readonly IAutoMapper _mapper;
        private readonly ITraficDataReader _traficDataReader;

        public TraficController(IResponseGenerator generator, ITraficDataReader traficDataReader, IAutoMapper mapper)
        {
            _generator = generator;
            _traficDataReader = traficDataReader;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        public async Task<TraficLocationResponse> LoadLocation([FromUri] TraficLocationRequestData data)
        {
            return await _generator.Create(new TraficLocationRequestHandler(_traficDataReader, data, _mapper));
        }
    }
}