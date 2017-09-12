using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Expressions.Requests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class ExpressionControllerTests
    {
        private TestServer server;
        private HttpClientWrapper client;

        public ExpressionControllerTests()
        {
            server = new TestServer(new WebHostBuilder()
                .UseStartup<Configuration.Startup>());
            client = server.CreateClientWrapper()
                .SetBaseUrl("api/expressions");
        }

        [Fact]
        public async void Should_Store_Expression()
        {
            server.PrepareUser(UserFixture.User);

            var expression = new CreateExpression()
            {
                Expression = "1 = 1"
            };

            var result = await client.Create(expression);
            result.HasStatusCode(HttpStatusCode.OK);
        }
    }
}
