using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.Services.Users;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class UserControllerTests : BaseControllerTests
    {
        public UserControllerTests() : base("/api/users") { }

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