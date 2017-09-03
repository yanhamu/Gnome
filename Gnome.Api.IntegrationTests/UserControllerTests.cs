using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class UserControllerTests
    {
        [Fact]
        public void Should_Register_New_User()
        {
            var _server = new TestServer(new WebHostBuilder()
        .UseStartup<Startup>());
            var _client = _server.CreateClient();
        }
    }
}
