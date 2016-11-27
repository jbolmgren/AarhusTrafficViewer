using System;
using System.Net;

namespace RequestHandlers
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public ApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}