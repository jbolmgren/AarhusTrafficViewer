using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DataAccess;

namespace RequestHandlers
{
    public class TraficLocationRequestHandler : IRequestHandler<TraficLocationResponse>
    {
        private readonly TraficLocationRequestData _data;
        private readonly ITraficDataReader _traficDataReader;

        public TraficLocationRequestHandler(ITraficDataReader traficDataReader, TraficLocationRequestData data)
        {
            _traficDataReader = traficDataReader;
            _data = data;
        }

        public ValidationResult ValidateInput()
        {
            if (_data.Radius > 600)
                return new ValidationResult("Invalid Radius. Radius is not allowed to be greater than 600");
            if (_data.Radius <= 0)
                return new ValidationResult("Invalid Radius. Radius is not allowed to be less or equal to 0");

            return new ValidationResult();
        }

        public async Task<TraficLocationResponse> Execute()
        {
            var traficInfos = await _traficDataReader.SearchForTrafic(_data.Lat, _data.Lng, _data.Radius);
            return new TraficLocationResponse
                   {
                       TraficPositions = traficInfos.Select(ConvertToPosition).ToList(),
                       Count = traficInfos.Count
                   };
        }

        private TraficPosition ConvertToPosition(TraficInfo traficInfo)
        {
            return new TraficPosition();
        }
    }

    public class TraficLocationResponse
    {
        public IList<TraficPosition> TraficPositions { get; set; }
        public int Count { get; set; }
    }

    public class TraficPosition
    {
    }

    public class TraficLocationRequestData
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Radius { get; set; }
    }
}