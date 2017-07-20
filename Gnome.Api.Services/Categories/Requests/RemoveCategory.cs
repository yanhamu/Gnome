using MediatR;

namespace Gnome.Api.Services.Categories.Requests
{
    public class RemoveCategory : INotification
    {
        public int Id { get; }
        public bool RemoveChildren { get; }
        public int UserId { get; }

        public RemoveCategory(int id, bool removeChildren,
            int userId)
        {
            this.Id = id;
            this.RemoveChildren = removeChildren;
            this.UserId = userId;
        }
    }
}
