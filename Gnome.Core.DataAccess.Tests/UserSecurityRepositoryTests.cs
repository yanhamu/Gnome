using Dapper;
using Gnome.Tests.Common;
using System;
using System.Data.SqlClient;
using System.Linq;
using Xunit;

namespace Gnome.Core.DataAccess.Tests
{
    public class UserSecurityRepositoryTests : IDisposable
    {
        [Fact]
        public void Should_Create_New_Test()
        {
            var email = "test@test.com";
            var password = GenerateArray(32);
            var salt = GenerateArray(16);

            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                var repository = new UserSecurityRepository(connection);

                var user = repository.CreateNew(email, password, salt);

                Assert.Equal(email, user.Email);
                Assert.NotEqual(default(int), user.Id);
            }
        }

        [Fact]
        public void Should_Retrieve_User_Test()
        {
            var email = "test@test.com";
            var password = GenerateArray(32);
            var salt = GenerateArray(16);

            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                var repository = new UserSecurityRepository(connection);

                repository.CreateNew(email, password, salt);

                var user = repository.GetBy(email);

                Assert.NotEqual(default(int), user.Id);
                Assert.Equal(email, user.Email);
                Assert.True(password.SequenceEqual(user.Password));
                Assert.True(salt.SequenceEqual(user.Salt));
            }
        }

        private byte[] GenerateArray(int length)
        {
            var result = new byte[length];
            for (int i = 0; i < length; i++)
                result[i] = Convert.ToByte(i % 8);
            return result;
        }

        public void Dispose()
        {
            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Execute(Database.Clear_All);
            }
        }

    }
}