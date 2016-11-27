using System.Net;
using System.Threading.Tasks;
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
            return await requestHandler.Execute();
        }

    }
}