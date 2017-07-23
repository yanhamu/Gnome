using Gnome.Api.Services.Categories.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Categories;
using MediatR;

namespace Gnome.Api.Services.Categories
{
    public class CategoryHandler :
        IRequestHandler<ListCategories, CategoryNode>,
        IRequestHandler<GetCategory, Category>,
        IRequestHandler<UpdateCategory, Category>,
        IRequestHandler<CreateCategory, Category>
    {
        private readonly ICategoryTreeFactory treeFactory;
        private readonly IGenericRepository<Category> categoryRepository;

        public CategoryHandler(
            ICategoryTreeFactory treeFactory,
            IGenericRepository<Category> categoryRepository)
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
            return categoryRepository.Find(message.Id);
        }

        public Category Handle(UpdateCategory message)
        {
            var category = categoryRepository.Find(message.Id);
            category.Name = message.Name;
            category.ParentId = message.ParentId;
            category.Color = message.Color;

            categoryRepository.Save();

            return category;
        }

        public Category Handle(CreateCategory message)
        {
            var category = new Category()
            {
                Name = message.Name,
                ParentId = message.ParentId,
                UserId = message.UserId
            };

            var created =  categoryRepository.Create(category);
            categoryRepository.Save();
            return created;
        }
    }
}