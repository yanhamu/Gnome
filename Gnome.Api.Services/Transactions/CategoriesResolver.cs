using Gnome.Core.Service.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Transactions
{
    public class CategoriesResolver
    {
        private readonly CategoryTree tree;
        private readonly ILookup<Guid, Guid> transactionCategories;
        private Dictionary<CategoryNode, Model.Category> categoryCache = new Dictionary<CategoryNode, Model.Category>();

        public CategoriesResolver(CategoryTree tree, ILookup<Guid, Guid> transactionCategories)
        {
            this.tree = tree;
            this.transactionCategories = transactionCategories;
        }

        public List<Model.Category> GetCategories(Guid transactionId)
        {
            return transactionCategories[transactionId].Select(c => CreateCategory(tree[c])).ToList();
        }

        private Model.Category CreateCategory(CategoryNode categoryNode)
        {
            if (!categoryCache.ContainsKey(categoryNode))
                categoryCache.Add(categoryNode, new Model.Category(categoryNode.Id, categoryNode.Name, categoryNode.Color));

            return categoryCache[categoryNode];
        }
    }
}
