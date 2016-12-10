using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AarhusDataAccessImpl
{

    public interface IHttpJsonClient
    {
        Task<T> LoadJson<T>(string url) where T : class;
    }

    public class HttpJsonClientImpl : IHttpJsonClient
    {
        private readonly IJsonConverter _jsonConverter;

        public HttpJsonClientImpl(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }


        public async Task<T> LoadJson<T>(string url) where T : class
        {
            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(url);
            }
            var data = await response.Content.ReadAsStringAsync();
            return _jsonConverter.Deserialize<T>(data);
        }
    }
}