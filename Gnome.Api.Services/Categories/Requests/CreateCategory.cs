using Gnome.Core.Model;
using MediatR;
using System;

namespace Gnome.Api.Services.Categories.Requests
{
    public class CreateCategory : IRequest<Category>
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public CreateCategory(Guid parentId, string name, Guid userId)
        {
            this.ParentId = parentId;
            this.Name = name;
            this.UserId = userId;
        }

        public CreateCategory() { }
    }
}
