using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MongoToUmbracoConverter.Services
{
    public class ApiWriter : IDisposable
    {
        private readonly HttpClient _client;

        public ApiWriter()
        {
            _client = new HttpClient();
        }

        public async Task<HttpStatusCode> PutJsonAsync(Uri address, string json)
        {
            StringContent content = new(json, Encoding.UTF8, "application/json");

            return (await _client.PutAsync(address, content)).StatusCode;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
