using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class TransactionControllerTests : BaseControllerTests
    {
        public TransactionControllerTests() : base("api/transactions") { }

        [Fact]
        public async void Should_Create_Transaction()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareAccount(AccountFixtures.Fio);
            this.server.PrepareCategory(CategoryFixture.Root);

            var response = await client.Create(new CreateTransaction()
            {
                AccountId = AccountFixtures.Fio.Id,
                Amount = 100m,
                Date = new DateTime(2017, 01, 01),
                Type = "fio",
                Data = "{}"
            });

            response.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Query_Transaction_With_Include_Expression()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareCategory(CategoryFixture.Root);
            this.server.PrepareAccount(AccountFixtures.Fio);
            this.server.PrepareTransaction(TransactionFixtures.Income);
            this.server.PrepareTransaction(TransactionFixtures.Expense);
            this.server.PrepareExpression(ExpressionFixtures.VariableSymbol);

            client.SetBaseUrl($"api/transactions/query");

            var response = await client.Create(new TransactionSearchFilter(
                new ClosedInterval(DateTime.Now, DateTime.Now),
                new List<Guid>() { AccountFixtures.Fio.Id },
                new List<Guid>() { ExpressionFixtures.VariableSymbol.Id },
                new List<Guid>()));

            response.HasStatusCode(HttpStatusCode.OK);
        }
    }
}