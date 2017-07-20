using Gnome.Core.Service.Categories;
using MediatR;

namespace Gnome.Api.Services.Categories.Requests
{
    public class ListCategories : IRequest<CategoryNode>
    {
        public int UserId { get; }

        public ListCategories(int userId)
        {
            this.UserId = userId;
        }
    }
}
