using Gnome.Core.Model;
using MediatR;

namespace Gnome.Api.Services.Categories.Requests
{
    public class UpdateCategory : IRequest<Category>
    {
        public int Id { get; }
        public int? ParentId { get; }
        public string Name { get; }
        public string Color { get; set; }

        public UpdateCategory(int id, int? parentId, string name, string color)
        {
            this.Id = id;
            this.ParentId = parentId;
            this.Name = name;
            this.Color = color;
        }
    }
}
