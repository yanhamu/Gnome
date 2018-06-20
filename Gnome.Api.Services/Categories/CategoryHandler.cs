using Gnome.Api.Services.Categories.Requests;
using Gnome.Core.DataAccess;

using Gnome.Core.Model.Database;
using Gnome.Core.Service.Categories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<CategoryNode> Handle(ListCategories message, CancellationToken cancellationToken)
        {
            var tree = await treeFactory.Create(message.UserId);
            return tree.Root;
        }

        public Task<Category> Handle(GetCategory message, CancellationToken cancellationToken)
        {
            return categoryRepository.Find(message.Id);
        }

        public async Task<Category> Handle(UpdateCategory message, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.Find(message.Id);
            category.Name = message.Name;
            category.ParentId = message.ParentId;
            category.Color = message.Color;

            await categoryRepository.Save();

            return category;
        }

        public async Task<Category> Handle(CreateCategory message, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Name = message.Name,
                ParentId = message.ParentId,
                UserId = message.UserId
            };

            var created = categoryRepository.Create(category);
            await categoryRepository.Save();
            return created;
        }
    }
}