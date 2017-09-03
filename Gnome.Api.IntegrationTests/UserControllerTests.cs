using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class UserControllerTests
    {
        [Fact]
        public async void Should_Register_New_User()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = server.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "api/users");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                { "email", "email@email.com" },
                { "password", "secret" }
            });

            var response = await client.SendAsync(request);
            Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}