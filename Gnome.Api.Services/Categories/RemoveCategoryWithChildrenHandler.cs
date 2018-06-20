using Gnome.Api.Services.Categories.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Categories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Categories
{
    public class RemoveCategoryWithChildrenHandler : INotificationHandler<RemoveCategory>
    {
        private readonly CategoryRepository categoryRepository;
        private readonly ICategoryTreeFactory treeFactory;

        public RemoveCategoryWithChildrenHandler(
            CategoryRepository categoryRepository,
            ICategoryTreeFactory treeFactory)
        {
            this.categoryRepository = categoryRepository;
            this.treeFactory = treeFactory;
        }

        public async Task Handle(RemoveCategory notification, CancellationToken cancellationToken)
        {
            if (notification.RemoveChildren == false)
                return;

            var tree = await treeFactory.Create(notification.UserId);

            var toDelete = tree.SubTree(notification.Id).Select(c => c.Id).ToList();
            categoryRepository.Remove(toDelete);
            await categoryRepository.Save();
        }
    }
}
