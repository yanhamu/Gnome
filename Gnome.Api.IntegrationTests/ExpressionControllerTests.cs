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

            var expression = new CreateExpression()
            {
                Expression = "1 = 1"
            };

            var result = await client.Create(expression);
            result.HasStatusCode(HttpStatusCode.OK);
        }
    }
}
