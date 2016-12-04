using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DataAccess;
using Core.Mapper;

namespace RequestHandlers.RequestHandlers
{
    public class TraficLocationRequestHandler : IRequestHandler<TraficLocationResponse>
    {
        private readonly TraficLocationRequestData _data;
        private readonly IAutoMapper _mapper;
        private readonly ITraficDataReader _traficDataReader;

        public TraficLocationRequestHandler(ITraficDataReader traficDataReader, TraficLocationRequestData data, IAutoMapper mapper)
        {
            _traficDataReader = traficDataReader;
            _data = data;
            _mapper = mapper;
        }

        public ValidationResult ValidateInput()
        {
            if (_data.RadiusInMeters > 1000)
                return new ValidationResult("Invalid Radius. Radius is not allowed to be greater than 600");
            if (_data.RadiusInMeters <= 0)
                return new ValidationResult("Invalid Radius. Radius is not allowed to be less or equal to 0");

            return new ValidationResult();
        }

        public async Task<TraficLocationResponse> Execute()
        {
            var traficInfos = await _traficDataReader.SearchForTrafic(_data.Lat, _data.Lng, _data.RadiusInMeters);
            _mapper.AddProfile(new TraficInfoMappingProfile());
            return new TraficLocationResponse
                   {
                       TraficPositions = traficInfos.Select(_mapper.Map<TraficInfo,TraficInfoViewModel>).ToList(),
                       Count = traficInfos.Count
                   };
        }
    }

    internal class TraficInfoMappingProfile : IMappingProfile
    {
        public void Configure(IMapperConfigurationExpression conf)
        {
            conf.CreateMap<TraficInfo, TraficInfoViewModel>();
            conf.CreateMap<Position, PositionViewModel>();
        }
    }


    public class TraficLocationResponse
    {
        public IList<TraficInfoViewModel> TraficPositions { get; set; }
        public int Count { get; set; }
    }

    public class TraficInfoViewModel
    {
        public PositionViewModel StartPosition { get; set; }
        public PositionViewModel EndPosition { get; set; }
        public int AverageSpeed { get; set; }
        public int CarCount { get; set; }
        public DateTime RecordTime { get; set; }
    }

    public class PositionViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class TraficLocationRequestData
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int RadiusInMeters { get; set; }
    }
}