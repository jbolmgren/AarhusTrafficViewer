using System;
using System.Threading.Tasks;
using API;
using Core;

namespace RequestHandlers
{
    public class TraficLocationRequestHandler : IRequestHandler<TraficLocationResponse>
    {
        public TraficLocationRequestHandler(ITraficDataReader traficDataReader, TraficLocationRequestData data)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResult ValidateInput()
        {
            throw new NotImplementedException();
        }

        public Task<TraficLocationResponse> Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class TraficLocationResponse
    {
    }
    
    public class TraficLocationRequestData
    {
    }
}