using Gnome.Core.Model;
using MediatR;
using System;

namespace Gnome.Api.Services.Categories.Requests
{
    public class CreateCategory : IRequest<Category>
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public CreateCategory(int parentId, string name, Guid userId)
        {
            this.ParentId = parentId;
            this.Name = name;
            this.UserId = userId;
        }

        public CreateCategory() { }
    }
}
