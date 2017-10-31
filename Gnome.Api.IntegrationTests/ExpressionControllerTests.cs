using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Expressions.Requests;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class ExpressionControllerTests : BaseControllerTests
    {
        public ExpressionControllerTests() : base("api/expressions") { }

        [Fact]
        public async void Should_Store_Expression()
        {
            server.PrepareUser(UserFixture.User);

            var expression = new CreateExpression() { Expression = "1 = 1" };

            var result = await client.Create(expression);
            result.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Get_Expression()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareExpression(ExpressionFixtures.VariableSymbol);

            var response = await client.Get(ExpressionFixtures.VariableSymbol.Id);

            response.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_List_Expressions()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareExpression(ExpressionFixtures.VariableSymbol);

            var response = await client.List();

            response.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Remove_Expression()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareExpression(ExpressionFixtures.VariableSymbol);

            var response = await client.Remove(ExpressionFixtures.VariableSymbol.Id);

            response.HasStatusCode(HttpStatusCode.NoContent);
        }

        [Fact]
        public async void Should_Update_Expression()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareExpression(ExpressionFixtures.VariableSymbol);

            var toUpdate = ExpressionFixtures.VariableSymbol;
            toUpdate.Name = "updated";
            var response = await client.Update(ExpressionFixtures.VariableSymbol.Id, toUpdate);

            response.HasStatusCode(HttpStatusCode.OK);
        }
    }
}
