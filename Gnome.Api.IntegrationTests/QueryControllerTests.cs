using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareExpression(ExpressionFixtures.VariableSymbol);

            var response = await client.Create(new CreateQuery()
            {
                Accounts = new List<Guid>() { AccountFixtures.Fio.Id },
                Name = "test",
                IncludeExpressions = new List<Guid>() { ExpressionFixtures.VariableSymbol.Id }
            });

            response.HasStatusCode(HttpStatusCode.OK);

            var model = await response.Deserialize<QueryModel>();

            Assert.Equal("test", model.Name);
        }

        [Fact]
        public async void Should_List_Query()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareAccount(AccountFixtures.Fio);
            this.server.PrepareQuery(QueryFixture.QueryAll);

            var response = await client.List();
            response.HasStatusCode(HttpStatusCode.OK);
            var modelList = await response.Deserialize<List<QueryModel>>();
            var model = modelList.First();

            Assert.Equal(QueryFixture.QueryAll.Name, model.Name);
            Assert.Contains(model.Accounts, a => a == AccountFixtures.Fio.Id);
            Assert.Empty(model.IncludeExpressions);
            Assert.Empty(model.ExcludeExpressions);
            Assert.Equal(QueryFixture.QueryAll.Id, model.QueryId);
        }

        [Fact]
        public async void Should_Remove_Query()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareAccount(AccountFixtures.Fio);
            this.server.PrepareQuery(QueryFixture.QueryAll);

            var response = await client.Remove(QueryFixture.QueryAll.Id);
            response.HasStatusCode(HttpStatusCode.NoContent);
        }

        [Fact]
        public async void Should_Update_Query()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareAccount(AccountFixtures.Fio);
            this.server.PrepareQuery(QueryFixture.QueryAll);

            var updateQuery = new UpdateQuery()
            {
                Id = QueryFixture.QueryAll.Id,
                Name = "new name",
                Accounts = new List<Guid>() { AccountFixtures.Fio.Id }
            };

            var response = await client.Update(QueryFixture.QueryAll.Id, updateQuery);
            response.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Get_Query()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareAccount(AccountFixtures.Fio);
            this.server.PrepareQuery(QueryFixture.QueryAll);

            var response = await client.Get(QueryFixture.QueryAll.Id);
            response.HasStatusCode(HttpStatusCode.OK);
        }
    }
}
