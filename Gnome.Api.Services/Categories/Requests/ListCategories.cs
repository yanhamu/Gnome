using Gnome.Core.Service.Categories;
using MediatR;
using System;

namespace Gnome.Api.Services.Categories.Requests
{
    public class ListCategories : IRequest<CategoryNode>
    {
        public Guid UserId { get; }

        public ListCategories(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
