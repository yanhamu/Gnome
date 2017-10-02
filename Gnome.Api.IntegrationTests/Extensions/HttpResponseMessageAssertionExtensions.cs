using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Gnome.Api.IntegrationTests.Extensions
{
    public static class HttpResponseMessageAssertionExtensions
    {
        public static HttpResponseMessage HasStatusCode(this HttpResponseMessage response, HttpStatusCode statusCode)
        {
            Assert.Equal(statusCode, response.StatusCode);
            return response;
        }
        public static async Task<T> Deserialize<T>(this HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
