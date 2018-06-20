using Gnome.Core.Model.Database;
using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Categories.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests.Categories.Resolvers
{
    public class ResolverTests
    {
        public static Guid RootId = new Guid("41567245-3621-4283-8d8a-8ccb0179b234");

        [Fact]
        public void Should_Resolve_Categories()
        {
            var tree = GetCategoryTree();
            var resolver = new Resolver(tree);

            var categories = resolver.GetCategories(new List<Guid>() { RootId });
            Assert.Equal(RootId, categories.First().Id);
            Assert.StrictEqual(1, categories.Count);

            var cachedCategories = resolver.GetCategories(new List<Guid>() { RootId });
            Assert.Equal(RootId, cachedCategories.First().Id);
            Assert.StrictEqual(1, cachedCategories.Count);
        }

        private CategoryTree GetCategoryTree()
        {
            var root = new CategoryNode(new Category() { Id = RootId });
            var categories = new List<CategoryNode>() { root }.ToDictionary(k => k.Id, v => v);
            return new CategoryTree(categories, root);
        }
    }
}
