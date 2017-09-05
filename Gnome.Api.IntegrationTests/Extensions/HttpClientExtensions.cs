using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gnome.Api.IntegrationTests.Extensions
{
    public static class HttpClientExtensions
    {
       
        public static async Task<HttpResponseMessage> List(this HttpClient client, string url)
        {
            return await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
        }
    }
}
