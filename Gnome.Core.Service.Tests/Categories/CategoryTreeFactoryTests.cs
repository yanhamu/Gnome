using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Categories;
using NSubstitute;
using System;
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
            var categories = GetCategories();

            repository.GetAll(Arg.Any<int>())
                .Returns(categories);

            var factory = new CategoryTreeFactory(repository);

            var tree = factory.Create(0);

            Assert.Equal(categories[0].Id, tree.Root.Id);
            Assert.Contains(tree.Root.Children.Select(c => c.Id), p => p == 1 || p == 2);
            Assert.Equal(3, tree[1].Children.First().Id);

            Assert.Same(tree[3].ParentId, tree[1]);
            Assert.Same(tree[2].ParentId, tree[0]);
            Assert.Same(tree[1].ParentId, tree[0]);
        }

        [Fact]
        public void Should_Throw_Exception_No_Root()
        {
            var repository = Substitute.For<ICategoryRepository>();
            var categories = GetCategories();
            categories[0].ParentId = 1; // circular reference

            repository.GetAll(Arg.Any<int>())
                .Returns(categories);

            Assert.Throws<ArgumentException>(() => new CategoryTreeFactory(repository).Create(0));
        }

        [Fact]
        public void Should_Throw_Exception_Multiple_Roots()
        {
            var repository = Substitute.For<ICategoryRepository>();
            var categories = GetCategories();
            categories[1].ParentId = null; // second root

            repository.GetAll(Arg.Any<int>())
                .Returns(categories);

            Assert.Throws<ArgumentException>(() => new CategoryTreeFactory(repository).Create(0));
        }

        public List<Category> GetCategories()
        {
            return new List<Category> {
                new Category(){ Id = 0, ParentId = null, Name = "root" },
                new Category(){ Id = 1, ParentId = 0, Name = "root-child" },
                new Category(){ Id = 2, ParentId = 0, Name = "next-root-child" },
                new Category(){ Id = 3, ParentId = 1, Name = "child-child" }
            };
        }
    }
}
