using Gnome.Api.Services.Categories.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Categories;
using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Categories
{
    public class RemoveWithoutChildrenHandler : INotificationHandler<RemoveCategory>
    {
        private readonly ICategoryTreeFactory treeFactory;
        private readonly CategoryRepository categoryRepository;
        private readonly IMediator mediator;

        public RemoveWithoutChildrenHandler(
            CategoryRepository categoryRepository,
            ICategoryTreeFactory treeFactory,
            IMediator mediator)
        {
            this.categoryRepository = categoryRepository;
            this.treeFactory = treeFactory;
            this.mediator = mediator;
        }

        public void Handle(RemoveCategory notification)
        {
            if (notification.RemoveChildren)
                return;

            var tree = treeFactory.Create(notification.UserId);
            var node = tree[notification.Id];

            foreach (var child in node.Children)
                mediator.Send(new UpdateCategory(child.Id, node.ParentId, child.Name, child.Color));

            categoryRepository.Remove(new List<Guid>() { node.Id });
        }
    }
}
