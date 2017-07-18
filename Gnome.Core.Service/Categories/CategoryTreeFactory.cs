using Gnome.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Categories
{
    public class CategoryTreeFactory
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryTreeFactory(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CategoryTree Create(int userId)
        {
            var categories = categoryRepository.GetAll(userId);
            var parentChildren = categories
                .Where(c => c.ParentId.HasValue)
                .ToLookup(k => k.ParentId.Value, v => v.Id);

            var categoryNodes = new Dictionary<int, CategoryNode>();
            var root = default(CategoryNode);

            foreach (var currentCategory in categories)
            {
                var categoryNode = new CategoryNode(currentCategory);
                categoryNodes.Add(categoryNode.Id, categoryNode);

                if (currentCategory.ParentId.HasValue == false)
                    root = categoryNode;
            }

            SetRelations(root, parentChildren, categoryNodes);

            return new CategoryTree(categoryNodes, root);
        }

        private void SetRelations(CategoryNode parent, ILookup<int, int> parentChildren, Dictionary<int, CategoryNode> categories)
        {
            var children = parentChildren[parent.Id];
            foreach (var childId in children)
            {
                categories[childId].SetParent(parent);
                SetRelations(categories[childId], parentChildren, categories);
            }
        }
    }
}