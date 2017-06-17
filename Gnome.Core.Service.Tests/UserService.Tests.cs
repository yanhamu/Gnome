using Autofac;
using Gnome.Core.Service.Interfaces;
using Gnome.Tests.Common;
using Xunit;

namespace Gnome.Core.Service.Tests
{
    public class UserServiceTests : BaseTest
    {
        [Fact]
        public void Should_Create_New_User_Test()
        {
            var email = "email@email.com";
            var password = "password";

            var service = container.Resolve<IUserService>();

            var userId = service.CreateNew(email, password);

            Assert.NotEqual(default(int), userId);
        }


        [Fact]
        public void Should_Retrieve_Existing_User_Test()
        {
            var email = "email@email.com";
            var password = "password";

            var service = container.Resolve<IUserService>();

            service.CreateNew(email, password);
            var user = service.Verify(email, password);

            Assert.NotEqual(default(int), user.Id);
            Assert.Equal(email, user.Email);
        }

        [Fact]
        public void Should_Not_Retrieve_User_With_Wrong_Password_Test()
        {
            var email = "email@email.com";
            var password = "password";

            var service = container.Resolve<IUserService>();

            service.CreateNew(email, password);
            var user = service.Verify(email, "wrong password");

            Assert.Null(user);
        }

        [Fact]
        public void Should_Verify_Email_Availability_Test()
        {
            var email = "email@email.com";
            var password = "password";

            var service = container.Resolve<IUserService>();

            service.CreateNew(email, password);
            Assert.False(service.CheckEmailAvailability(email));
            Assert.True(service.CheckEmailAvailability("new@email.com"));
        }
    }
}
