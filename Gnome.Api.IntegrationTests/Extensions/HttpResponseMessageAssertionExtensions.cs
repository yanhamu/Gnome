using System.Net;
using System.Net.Http;
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
    }
}
