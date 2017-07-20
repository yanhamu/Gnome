using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Categories;
using MediatR;

namespace Gnome.Api.Services.Categories
{
    public class CategoryHandler :
        IRequestHandler<ListCategories, CategoryNode>,
        IRequestHandler<GetCategory, Category>
    {
        private readonly ICategoryTreeFactory treeFactory;
        private readonly CategoryRepository categoryRepository;

        public CategoryHandler(
            ICategoryTreeFactory treeFactory,
            CategoryRepository categoryRepository)
        {
            this.treeFactory = treeFactory;
            this.categoryRepository = categoryRepository;
        }

        public CategoryNode Handle(ListCategories message)
        {
            var tree = treeFactory.Create(message.UserId);
            return tree.Root;
        }

        public Category Handle(GetCategory message)
        {
            return categoryRepository.GetById(message.Id);
        }
    }
}
