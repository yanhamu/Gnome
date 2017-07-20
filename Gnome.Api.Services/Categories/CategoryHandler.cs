using Gnome.Core.Service.Categories;
using MediatR;

namespace Gnome.Api.Services.Categories
{
    public class CategoryHandler : IRequestHandler<ListCategories, CategoryNode>
    {
        private readonly ICategoryTreeFactory treeFactory;

        public CategoryHandler(ICategoryTreeFactory treeFactory)
        {
            this.treeFactory = treeFactory;
        }

        public CategoryNode Handle(ListCategories message)
        {
            var tree = treeFactory.Create(message.UserId);
            return tree.Root;
        }
    }
}
