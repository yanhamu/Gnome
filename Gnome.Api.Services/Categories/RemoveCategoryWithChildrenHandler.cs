using Gnome.Api.Services.Categories.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Categories;
using MediatR;
using System.Linq;

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

        public void Handle(RemoveCategory notification)
        {
            if (notification.RemoveChildren == false)
                return;

            var tree = treeFactory.Create(notification.UserId);

            var toDelete = tree.SubTree(notification.Id).Select(c => c.Id).ToList();
            categoryRepository.Remove(toDelete);
            categoryRepository.Save();
        }
    }
}
