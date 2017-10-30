using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class AccountControllerTests : BaseControllerTests
    {
        public AccountControllerTests() : base("api/accounts") { }

        [Fact]
        public async void Should_Create_Account()
        {
            server.PrepareUser(UserFixture.User);

            var account = new Account(default(Guid), "test account", "secret token");
            var result = await client.Create(account);
            result.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_List_Accounts()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareAccount(AccountFixtures.Csob);

            var result = await client.List();
            result.HasStatusCode(HttpStatusCode.OK);
            var listAccounts = await result.Deserialize<List<Account>>();

            Assert.Equal(2, listAccounts.Count);
        }

        [Fact]
        public async void Should_Update_Account()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);

            var updated = AccountFixtures.Fio;
            updated.Name = "updated fio";

            var result = await client.Update(AccountFixtures.Fio.Id, updated);
            result.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Remove_Account()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);

            var updated = AccountFixtures.Fio;
            updated.Name = "updated fio";

            var result = await client.Remove(AccountFixtures.Fio.Id);
            result.HasStatusCode(HttpStatusCode.NoContent);
        }

        [Fact]
        public async void Should_Perform_CRUD_on_Accounts()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareAccount(AccountFixtures.Csob);

            var toCreateAccount = new Account(default(Guid), "test account", "secret token");
            var createResult = await client.Create(toCreateAccount);
            var createdAccount = await createResult.Deserialize<Account>();

            createResult.HasStatusCode(HttpStatusCode.OK);

            var getResult = await client.Get(createdAccount.Id);
            getResult.HasStatusCode(HttpStatusCode.OK);

            var updateAccount = await getResult.Deserialize<Account>();
            updateAccount.Name = "updated name";
            var updateResult = await client.Update(updateAccount.Id, updateAccount);
            updateResult.HasStatusCode(HttpStatusCode.OK);

            var removeAccount = await updateResult.Deserialize<Account>();
            var removeResult = await client.Remove(removeAccount.Id);
            removeResult.HasStatusCode(HttpStatusCode.NoContent);
        }
    }
}