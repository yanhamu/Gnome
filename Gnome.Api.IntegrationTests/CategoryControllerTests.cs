using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Categories.Requests;
using Gnome.Core.Model.Database;
using System;
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

        [Fact]
        public async void Should_Update_Category()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareCategory(CategoryFixture.Root);
            var toUpdate = CategoryFixture.Root;
            toUpdate.Name = "updated";

            var response = await client.Update(CategoryFixture.Root.Id, toUpdate);

            response.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Create_Category()
        {
            this.server.PrepareUser(UserFixture.User);
            this.server.PrepareCategory(CategoryFixture.Root);
            var toCreate = new CreateCategory(CategoryFixture.Root.Id, "new", default(Guid));

            var response = await client.Create(toCreate);

            response.HasStatusCode(HttpStatusCode.OK);
        }
    }
}
