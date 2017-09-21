using Gnome.Api.IntegrationTests.Configuration;
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
        public bool IsAuthenticated { get; set; }

        public HttpClientWrapper(HttpClient client)
        {
            this.client = client;
        }

        public HttpClientWrapper SetAuthentication(bool isAuthenticated)
        {
            this.IsAuthenticated = isAuthenticated;
            return this;
        }

        public HttpClientWrapper SetBaseUrl(string url)
        {
            this.Url = url;
            return this;
        }

        public async Task<HttpResponseMessage> Create<T>(T content)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(
                jsonContent,
                Encoding.UTF8,
                "application/json");

            var request = CreateRequest(HttpMethod.Post);
            request.Content = stringContent;

            return await client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> List()
        {
            var request = CreateRequest(HttpMethod.Get);
            return await client.SendAsync(request);
        }

        private HttpRequestMessage CreateRequest(HttpMethod method)
        {
            var request = new HttpRequestMessage(method, Url);
            if (this.IsAuthenticated)
                request.Headers.Add(TestIdentityMiddleware.AUTH_HEADER_FLAG, "yeah");
            return request;
        }
    }
}
