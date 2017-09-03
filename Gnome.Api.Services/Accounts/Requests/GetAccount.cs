using MediatR;
using System;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class GetAccount : IRequest<Account>
    {
        public Guid AccountId { get; set; }
        public GetAccount(Guid accountId)
        {
            this.AccountId = accountId;
        }
    }
}
