using MediatR;
using System;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class RemoveAccount : INotification
    {
        public Guid Id { get; }

        public RemoveAccount(Guid accountId)
        {
            this.Id = accountId;
        }
    }
}
