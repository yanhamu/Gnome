using Gnome.Api.Services.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class UserControllerTests
    {
        private TestServer server;
        private HttpClient client;

        public UserControllerTests()
        {
            server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact]
        public async void Should_Register_New_User()
        {
            var newUser = new RegisterUser()
            {
                Email = "email@email.com",
                Password = "secret"
            };

            var response = await client.Post(newUser, "/api/users");

            response.HasStatusCode(HttpStatusCode.NoContent);
        }
    }
}