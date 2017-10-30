using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class CategoryTransactionControllerTests : BaseControllerTests
    {
        public CategoryTransactionControllerTests() : base("") { }

        [Fact]
        public async void Should_AssignAndRemove_CategoryTransaction()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareCategory(CategoryFixture.Root);
            server.PrepareTransaction(TransactionFixtures.Expense);

            client.SetBaseUrl($"api/categories/{CategoryFixture.Root.Id.ToString()}/transaction{TransactionFixtures.Expense.Id.ToString()}");
            var assignResponse = await client.Create(new { });
            assignResponse.HasStatusCode(HttpStatusCode.NoContent);

            var removeResponse = await client.Remove();
            removeResponse.HasStatusCode(HttpStatusCode.NoContent);
        }
    }
}