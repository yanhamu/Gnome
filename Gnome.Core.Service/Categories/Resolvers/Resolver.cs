using Gnome.Core.Service.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Categories.Resolvers
{
    public class Resolver
    {
        private readonly CategoryTree tree;
        private Dictionary<CategoryNode, Category> categoryCache = new Dictionary<CategoryNode, Category>();

        public Resolver(CategoryTree tree)
        {
            this.tree = tree;
        }

        public List<Category> GetCategories(List<Guid> categories)
        {
            return categories.Select(c => CreateCategory(tree[c])).ToList();
        }

        private Category CreateCategory(CategoryNode categoryNode)
        {
            if (!categoryCache.ContainsKey(categoryNode))
                categoryCache.Add(categoryNode, new Category(categoryNode.Id, categoryNode.Name, categoryNode.Color));

            return categoryCache[categoryNode];
        }
    }
}