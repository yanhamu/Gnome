using Autofac;
using Gnome.Tests.Common;
using System;
using System.Linq;
using Xunit;

namespace Gnome.Core.DataAccess.Tests
{
    public class UserSecurityRepositoryTests : BaseDbTest
    {
        [Fact]
        public void Should_Create_New_Test()
        {
            var email = "test@test.com";
            var password = GenerateArray(32);
            var salt = GenerateArray(16);

            var repository = container.Resolve<UserSecurityRepository>();

            var user = repository.CreateNew(email, password, salt);

            Assert.Equal(email, user.Email);
            Assert.NotEqual(default(int), user.Id);
        }

        [Fact]
        public void Should_Retrieve_User_Test()
        {
            var email = "test@test.com";
            var password = GenerateArray(32);
            var salt = GenerateArray(16);

            var repository = container.Resolve<UserSecurityRepository>();

            repository.CreateNew(email, password, salt);

            var user = repository.GetBy(email);

            Assert.NotEqual(default(int), user.Id);
            Assert.Equal(email, user.Email);
            Assert.True(password.SequenceEqual(user.Password));
            Assert.True(salt.SequenceEqual(user.Salt));
        }

        private byte[] GenerateArray(int length)
        {
            var result = new byte[length];
            for (int i = 0; i < length; i++)
                result[i] = Convert.ToByte(i % 8);
            return result;
        }
    }
}