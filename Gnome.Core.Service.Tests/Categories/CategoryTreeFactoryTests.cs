using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Categories;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests.Categories
{
    public class CategoryTreeFactoryTests
    {
        [Fact]
        public void Should_Create_Category_Tree()
        {
            var repository = Substitute.For<ICategoryRepository>();

            repository.GetAll(Arg.Any<int>())
                .Returns(TEST_CATEGORIES);

            var factory = new CategoryTreeFactory(repository);

            var tree = factory.Create(0);

            Assert.Equal(TEST_CATEGORIES[0].Id, tree.Root.Id);
            Assert.Contains(tree.Root.Children.Select(c => c.Id), p => p == 1 || p == 2);
            Assert.Equal(3, tree[1].Children.First().Id);

            Assert.Same(tree[3].Parent, tree[1]);
            Assert.Same(tree[2].Parent, tree[0]);
            Assert.Same(tree[1].Parent, tree[0]);
        }

        public List<Category> TEST_CATEGORIES = new List<Category> {
            new Category(){ Id = 0, ParentId = null, Name = "root" },
            new Category(){ Id = 1, ParentId = 0, Name = "root-child" },
            new Category(){ Id = 2, ParentId = 0, Name = "next-root-child" },
            new Category(){ Id = 3, ParentId = 1, Name = "child-child" },
        };
    }
}
