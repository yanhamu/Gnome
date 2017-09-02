using MediatR;
using System;

namespace Gnome.Api.Services.Categories.Requests
{
    public class RemoveCategory : INotification
    {
        public int Id { get; }
        public bool RemoveChildren { get; }
        public Guid UserId { get; }

        public RemoveCategory(
            int id,
            bool removeChildren,
            Guid userId)
        {
            this.Id = id;
            this.RemoveChildren = removeChildren;
            this.UserId = userId;
        }
    }
}
