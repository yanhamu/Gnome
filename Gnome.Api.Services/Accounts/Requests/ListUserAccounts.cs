using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class ListUserAccounts : IRequest<List<Account>>
    {
        public Guid UserId { get; set; }

        public ListUserAccounts(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
