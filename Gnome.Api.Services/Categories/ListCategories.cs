using Gnome.Core.Service.Categories;
using MediatR;

namespace Gnome.Api.Services.Categories
{
    public class ListCategories : IRequest<CategoryNode>
    {
        public int UserId { get; set; }

        public ListCategories(int userId)
        {
            this.UserId = userId;
        }
    }
}
