namespace Gnome.Api.IntegrationTests.Extensions
{
    public static class HttpClientWrapperExtensions
    {
        public static HttpClientWrapper SetBaseUrl(this HttpClientWrapper client, string url)
        {
            client.Url = url;
            return client;
        }
    }
}