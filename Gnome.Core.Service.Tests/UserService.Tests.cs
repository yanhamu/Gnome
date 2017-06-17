using Dapper;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Interfaces;
using Gnome.Tests.Common;
using System;
using System.Data.SqlClient;
using Xunit;

namespace Gnome.Core.Service.Tests
{
    public class UserServiceTests : IDisposable
    {
        [Fact]
        public void Should_Create_New_User_Test()
        {
            var email = "email@email.com";
            var password = "password";

            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                IUserService service = GetUserService(connection);

                var user = service.CreateNew(email, password);

                Assert.NotEqual(default(int), user.Id);
                Assert.Equal(email, user.Email);
            }
        }


        [Fact]
        public void Should_Retrieve_Existing_User_Test()
        {
            var email = "email@email.com";
            var password = "password";

            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                IUserService service = GetUserService(connection);

                service.CreateNew(email, password);
                var user = service.Verify(email, password);

                Assert.NotEqual(default(int), user.Id);
                Assert.Equal(email, user.Email);
            }
        }

        [Fact]
        public void Should_Not_Retrieve_User_With_Wrong_Password_Test()
        {
            var email = "email@email.com";
            var password = "password";

            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                IUserService service = GetUserService(connection);

                service.CreateNew(email, password);
                var user = service.Verify(email, "wrong password");

                Assert.Null(user);
            }
        }

        [Fact]
        public void Should_Verify_Email_Availability_Test()
        {
            var email = "email@email.com";
            var password = "password";

            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                IUserService service = GetUserService(connection);

                service.CreateNew(email, password);
                Assert.False(service.CheckEmailAvailability(email));
                Assert.True(service.CheckEmailAvailability("new@email.com"));
            }
        }

        public void Dispose()
        {
            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Execute(Database.Clear_All);
            }
        }

        private static IUserService GetUserService(SqlConnection connection)
        {
            var userRepository = new UserRepository(connection);
            var userSecurityRepository = new UserSecurityRepository(connection);
            var securityService = new UserSecurityService();
            IUserService service = new UserService(
                userRepository,
                userSecurityRepository,
                securityService);
            return service;
        }
    }
}
