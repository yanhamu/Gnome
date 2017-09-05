using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.Services.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class UserControllerTests
    {
        private TestServer server;
        private HttpClientWrapper client;

        public UserControllerTests()
        {
            server = new TestServer(new WebHostBuilder()
                .UseStartup<Configuration.Startup>());
            client = server.CreateClientWrapper()
                .SetBaseUrl("/api/users");
        }

        [Fact]
        public async void Should_Register_New_User()
        {
            var newUser = new RegisterUser()
            {
                Email = "email@email.com",
                Password = "secret"
            };

            var response = await client.Create(newUser);

            response.HasStatusCode(HttpStatusCode.NoContent);
        }
    }
}