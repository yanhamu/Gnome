using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Queries.Requests;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class QueryControllerTests : BaseControllerTests
    {
        public QueryControllerTests() : base("api/queries") { }

        [Fact]
        public async void Should_Create_Query()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareAccount(AccountFixtures.Fio);
            this.server.PrepareExpression(ExpressionFixtures.VariableSymbol);

            var response = await client.Create(new CreateQuery()
            {
                Accounts = new List<Guid>() { AccountFixtures.Fio.Id },
                Name = "test",
                IncludeExpressions = new List<Guid>() { ExpressionFixtures.VariableSymbol.Id }
            });

            response.HasStatusCode(HttpStatusCode.OK);

            var model = await response.Deserialize<Model>();

            Assert.Equal("test", model.Name);
        }
    }
}
