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

            repository.GetAll(Arg.Any<Guid>())
                .Returns(categories);

            var factory = new CategoryTreeFactory(repository);

            var tree = factory.Create(Guid.NewGuid());

            Assert.Equal(categories[0].Id, tree.Root.Id);
            Assert.Contains(tree.Root.Children.Select(c => c.Id), p => p == Guids.Guid2 || p == Guids.Guid3);
            Assert.Equal(Guids.Guid4, tree[Guids.Guid2].Children.First().Id);

            Assert.Equal(tree[Guids.Guid4].ParentId, tree[Guids.Guid2].Id);
            Assert.Equal(tree[Guids.Guid3].ParentId, tree[Guids.Guid1].Id);
            Assert.Equal(tree[Guids.Guid2].ParentId, tree[Guids.Guid1].Id);
        }

        [Fact]
        public void Should_Throw_Exception_No_Root()
        {
            var repository = Substitute.For<ICategoryRepository>();
            var categories = GetCategories();
            categories[0].ParentId = Guids.Guid2; // circular reference

            repository.GetAll(Arg.Any<Guid>())
                .Returns(categories);

            Assert.Throws<ArgumentException>(() => new CategoryTreeFactory(repository).Create(Guid.NewGuid()));
        }

        [Fact]
        public void Should_Throw_Exception_Multiple_Roots()
        {
            var repository = Substitute.For<ICategoryRepository>();
            var categories = GetCategories();
            categories[1].ParentId = null; // second root

            repository.GetAll(Arg.Any<Guid>())
                .Returns(categories);

            Assert.Throws<ArgumentException>(() => new CategoryTreeFactory(repository).Create(Guid.NewGuid()));
        }

        public List<Category> GetCategories()
        {
            return new List<Category> {
                new Category(){ Id  = Guids.Guid1, ParentId = null, Name = "root" },
                new Category(){ Id  = Guids.Guid2, ParentId = Guids.Guid1, Name = "root-child" },
                new Category(){ Id  = Guids.Guid3, ParentId = Guids.Guid1, Name = "next-root-child" },
                new Category(){ Id  = Guids.Guid4, ParentId = Guids.Guid2, Name = "child-child" }
            };
        }

        public static class Guids
        {
            public static Guid Guid1 = new Guid("008da3b1-5b67-48aa-955b-22d98acfbf78");
            public static Guid Guid2 = new Guid("23961bd1-4e26-41f7-982d-4de426f2477c");
            public static Guid Guid3 = new Guid("aef2ecba-31ab-4dc1-95fd-c3e2288f0709");
            public static Guid Guid4 = new Guid("79e029ef-814f-4f04-a76a-e6737fd701e8");
        }
    }
}
