using Gnome.Core.Model;
using MediatR;

namespace Gnome.Api.Services.Categories
{
    public class GetCategory : IRequest<Category>
    {
        public int Id { get; }
        public int UserId { get; }
        public GetCategory(int categoryId, int userId)
        {
            this.UserId = userId;
            this.Id = categoryId;
        }
    }
}
