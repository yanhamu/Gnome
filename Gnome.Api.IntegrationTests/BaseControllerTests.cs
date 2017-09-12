using Gnome.Api.IntegrationTests.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Gnome.Api.IntegrationTests
{
    public class BaseControllerTests
    {
        protected TestServer server;
        protected HttpClientWrapper client;

        public BaseControllerTests(string baseUrl)
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Configuration.Startup>());
            client = server.CreateClientWrapper().SetBaseUrl(baseUrl);
        }
    }
}