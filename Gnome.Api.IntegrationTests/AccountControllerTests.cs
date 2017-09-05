using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Accounts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class AccountControllerTests
    {
        private TestServer server;
        private HttpClientWrapper client;

        public AccountControllerTests()
        {
            server = new TestServer(new WebHostBuilder()
                .UseStartup<Configuration.Startup>());
            client = server.CreateClientWrapper()
                .SetBaseUrl("api/accounts");
        }

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

            var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<Account>>(await (result.Content.ReadAsStringAsync()));
        }
    }
}