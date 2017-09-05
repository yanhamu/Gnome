using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gnome.Api.IntegrationTests.Extensions
{
    public class HttpClientWrapper
    {
        private readonly HttpClient client;
        public string Url { get; set; }

        public HttpClientWrapper(HttpClient client)
        {
            this.client = client;
        }

        public async Task<HttpResponseMessage> Create<T>(T content)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(
                jsonContent,
                Encoding.UTF8,
                "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, Url)
            {
                Content = stringContent
            };

            return await client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> List()
        {
            return await client.GetAsync(Url);
        }

    }
}
