using Gnome.Core.Model;
using MediatR;
using System;

namespace Gnome.Api.Services.Categories.Requests
{
    public class GetCategory : IRequest<Category>
    {
        public int Id { get; }
        public Guid UserId { get; }
        public GetCategory(int categoryId, Guid userId)
        {
            this.UserId = userId;
            this.Id = categoryId;
        }
    }
}
