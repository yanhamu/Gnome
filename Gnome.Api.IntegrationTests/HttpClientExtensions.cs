using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gnome.Api.IntegrationTests
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> Post<T>(this HttpClient client, T content, string url)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(
                jsonContent,
                Encoding.UTF8,
                "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = stringContent
            };

            return await client.SendAsync(request);
        }
    }
}
