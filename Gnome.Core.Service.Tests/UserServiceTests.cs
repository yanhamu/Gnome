using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Interfaces;
using NSubstitute;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void Should_Verify_Existing_User()
        {
            var securityRepository = Substitute.For<IUserSecurityRepository>();
            var securityService = Substitute.For<IUserSecurityService>();

            securityRepository.GetBy(Arg.Any<string>()).Returns(new Model.Database.UserSecurity());
            securityService.Verify(Arg.Any<string>(), Arg.Any<byte[]>(), Arg.Any<byte[]>()).Returns(true);

            var service = new UserService(null, securityRepository, securityService);
            var user = service.Verify("existing@user.email", "password");
            Assert.NotNull(user);
        }

        [Fact]
        public void Should_Verify_Existing_User_With_Wrong_Password()
        {
            var securityRepository = Substitute.For<IUserSecurityRepository>();
            var securityService = Substitute.For<IUserSecurityService>();

            securityRepository.GetBy(Arg.Any<string>()).Returns(new UserSecurity());
            securityService.Verify(Arg.Any<string>(), Arg.Any<byte[]>(), Arg.Any<byte[]>()).Returns(false);

            var service = new UserService(null, securityRepository, securityService);
            var user = service.Verify("existing@user.email", "password");
            Assert.Null(user);
        }

        [Fact]
        public void Should_Verify_NonExisting_User()
        {
            var securityRepository = Substitute.For<IUserSecurityRepository>();

            securityRepository.GetBy(Arg.Any<string>()).Returns(default(UserSecurity));

            var service = new UserService(null, securityRepository, null);
            var user = service.Verify("existing@user.email", "password");
            Assert.Null(user);
        }

        [Fact]
        public void Should_Fail_To_Throw_Exception()
        {
            var securityRepository = Substitute.For<IUserSecurityRepository>();
            var securityService = Substitute.For<IUserSecurityService>();

            securityRepository.CreateNew(
                Arg.Any<string>(),
                Arg.Any<byte[]>(),
                Arg.Any<byte[]>(),
                default(Guid)).Returns(default(Gnome.Core.Model.Database.UserSecurity));

            var userService = new UserService(null, securityRepository, securityService);

            Assert.Throws<InvalidOperationException>(() => userService.CreateNew(null, null, default(Guid)));

        }
    }
}
