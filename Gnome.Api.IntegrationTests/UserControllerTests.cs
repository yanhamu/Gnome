using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
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

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");

            var content = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Email = "email@email.com",
                Password = "secret"
            });

            request.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}