using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Categories
{
    public class CategoryTreeFactory : ICategoryTreeFactory
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryTreeFactory(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryTree> Create(Guid userId)
        {
            var categories = await categoryRepository.GetAll(userId);

            CheckRoot(categories);

            var parentChildren = categories
                .Where(c => c.ParentId.HasValue)
                .ToLookup(k => k.ParentId.Value, v => v.Id);

            var categoryNodes = new Dictionary<Guid, CategoryNode>();
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

        private void CheckRoot(List<Category> categories)
        {
            if (categories.Where(c => c.ParentId.HasValue == false).Count() != 1)
                throw new ArgumentException("there is no single root");
        }

        private void SetRelations(CategoryNode parent, ILookup<Guid, Guid> parentChildren, Dictionary<Guid, CategoryNode> categories)
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