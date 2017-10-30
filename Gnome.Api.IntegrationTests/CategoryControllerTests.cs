using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Core.Model.Database;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class CategoryControllerTests : BaseControllerTests
    {
        public CategoryControllerTests() : base("api/categories") { }

        [Fact]
        public async void Should_Get_Category()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareCategory(CategoryFixture.Root);
            var response = await client.Get(CategoryFixture.Root.Id);
            response.HasStatusCode(HttpStatusCode.OK);

            var category = await response.Deserialize<Category>();

            Assert.Equal(CategoryFixture.Root.Id, category.Id);
        }

        [Fact]
        public async void Should_List_Categories()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareCategory(CategoryFixture.Root);
            var response = await client.List();
            response.HasStatusCode(HttpStatusCode.OK);
        }
    }
}
