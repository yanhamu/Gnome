using Gnome.Core.Model.Database;
using MediatR;
using System;

namespace Gnome.Api.Services.Categories.Requests
{
    public class GetCategory : IRequest<Category>
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public GetCategory(Guid categoryId, Guid userId)
        {
            this.UserId = userId;
            this.Id = categoryId;
        }
    }
}
