using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Accounts;
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

            var account = new Account()
            {
                Name = "test account",
                Token = "secret token"
            };

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
            var content = await result.Content.ReadAsStringAsync();
            var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Account>>(content);
        }
    }
}