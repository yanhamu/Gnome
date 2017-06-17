using Autofac;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using Gnome.Tests.Common;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests
{
    public class AccountServiceTests : BaseTest
    {
        [Fact]
        public void Should_Create_New_Account_Tests()
        {
            User user = PrepareUser();
            var account = CreateAccount(user.Id);

            var service = container.Resolve<IAccountService>();
            var id = service.Create(account);

            var created = service.Get(id);

            Assert.Equal(user.Id, created.UserId);
            Assert.Equal(account.Token, created.Token);
            Assert.Equal(account.Name, created.Name);
        }

        [Fact]
        public void Should_Retrieve_Account()
        {
            User user = PrepareUser();
            var account = CreateAccount(user.Id);

            var service = container.Resolve<IAccountService>();
            var id = service.Create(account);

            var retrievedAccount = service.Get(id);

            Assert.Equal(user.Id, retrievedAccount.UserId);
            Assert.NotEqual(default(int), retrievedAccount.Id);
            Assert.Equal(account.Name, retrievedAccount.Name);
            Assert.Equal(account.Token, retrievedAccount.Token);
        }

        [Fact]
        public void Should_Update_Account()
        {
            User user = PrepareUser();
            var account = CreateAccount(user.Id);

            var service = container.Resolve<IAccountService>();
            var id = service.Create(account);

            account.Name = "changed";
            account.Token = "changed";
            service.Update(id, account);
            var retrievedAccount = service.Get(id);

            Assert.Equal(user.Id, retrievedAccount.UserId);
            Assert.NotEqual(default(int), retrievedAccount.Id);
            Assert.Equal(account.Name, retrievedAccount.Name);
            Assert.Equal(account.Token, retrievedAccount.Token);
        }

        [Fact]
        public void Should_Remove_Account()
        {
            User user = PrepareUser();
            var account = CreateAccount(user.Id);

            var service = container.Resolve<IAccountService>();
            var id = service.Create(account);
            service.Remove(id);

            var retrievedAccount = service.Get(id);
            Assert.Null(retrievedAccount);
        }

        [Fact]
        public void Should_List_Accounts()
        {
            User user = PrepareUser();
            var account = CreateAccount(user.Id);
            var service = container.Resolve<IAccountService>();

            service.Create(account);
            service.Create(account);
            service.Create(account);

            var accounts = service.List(user.Id);

            Assert.True(accounts.All(a => a.Name == account.Name));
            Assert.True(accounts.All(a => a.Token == account.Token));
            Assert.True(accounts.All(a => a.Id != default(int)));
        }

        private Account CreateAccount(int userId)
        {
            var accountName = "fio account";
            var accountToken = "token";
            return new Account(0, userId, accountName, accountToken);
        }

        private User PrepareUser()
        {
            var email = "email@email.com";
            var password = "password";
            var userService = container.Resolve<IUserService>();
            var user = userService.CreateNew(email, password);
            return user;
        }
    }
}
