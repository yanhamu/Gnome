using Gnome.Core.Model.Database;
using MediatR;
using System;

namespace Gnome.Api.Services.Categories.Requests
{
    public class UpdateCategory : IRequest<Category>
    {
        public Guid Id { get; }
        public Guid? ParentId { get; }
        public string Name { get; }
        public string Color { get; set; }

        public UpdateCategory(Guid id, Guid? parentId, string name, string color)
        {
            this.Id = id;
            this.ParentId = parentId;
            this.Name = name;
            this.Color = color;
        }
    }
}
