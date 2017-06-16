using Xunit;

namespace Gnome.Core.Service.Tests
{
    public class UserSecurityServiceTests
    {
        [Fact]
        public void CreateAndVerifyPassword()
        {
            var password = "Admin123";

            var service = new UserSecurityService();

            var salt = service.GetSalt();
            var hashedPassword = service.CreatePassword(password, salt);

            var another = service.CreatePassword(password, salt);

            Assert.True(service.Verify(password, service.CreatePassword(password, salt), salt));
            Assert.False(service.Verify(password, service.CreatePassword("wrong", salt), salt));
        }
    }
}
