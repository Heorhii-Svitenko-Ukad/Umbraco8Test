using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MongoToUmbracoConverter.Services
{
    public class ApiWriter
    {
        private static readonly HttpClient HttpClient = new();

        private readonly ApiOptions _options;

        public ApiWriter(IOptions<ApiOptions> options)
        {
            _options = options.Value;
        }

        public async Task<HttpStatusCode> PutJsonAsync(string apiName, string json)
        {
            StringContent content = new(json, Encoding.UTF8, "application/json");

            return (await HttpClient.PutAsync(_options.ApiUrl + apiName, content)).StatusCode;
        }
    }
}
