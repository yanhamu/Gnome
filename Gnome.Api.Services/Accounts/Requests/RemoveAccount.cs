using MediatR;
using System;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class RemoveAccount : INotification
    {
        public Guid AccountId { get; }

        public RemoveAccount(Guid accountId)
        {
            this.AccountId = accountId;
        }
    }
}
