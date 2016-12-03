using System;
using System.Net;
using System.Threading.Tasks;
using API.Core;
using Core;

namespace API.Core
{
    public class ResponseGenerator : IResponseGenerator
    {

        public async Task<TResult> Create<TResult>(IRequestHandler<TResult> requestHandler)
        {
            var validationResult = requestHandler.ValidateInput();
            if (!validationResult.IsValid)
                throw new ApiException(HttpStatusCode.BadRequest, validationResult.Message);
            try
            {
                return await requestHandler.Execute();
            }
            catch (Exception e)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Houston, We have a problem! :'(");
            }
            
        }

    }
}