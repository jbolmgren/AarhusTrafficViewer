using System;
using System.Threading.Tasks;
using API;
using Core;

namespace RequestHandlers
{
    public class TrafficLocationRequestHandler : IRequestHandler<TrafficLocationResponse>
    {
        public TrafficLocationRequestHandler(ITraficDataReader traficDataReader, TrafficLocationRequestData data)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResult ValidateInput()
        {
            throw new NotImplementedException();
        }

        public Task<TrafficLocationResponse> Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class TrafficLocationResponse
    {
    }
    
    public class TrafficLocationRequestData
    {
    }
}