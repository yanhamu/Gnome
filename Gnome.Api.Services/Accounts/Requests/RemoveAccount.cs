using MediatR;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class RemoveAccount : INotification
    {
        public RemoveAccount(int accountId)
        {
            this.Id = accountId;
        }

        public int Id { get; }
    }
}
