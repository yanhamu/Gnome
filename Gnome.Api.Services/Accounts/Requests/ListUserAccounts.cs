using MediatR;
using System.Collections.Generic;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class ListUserAccounts : IRequest<List<Account>>
    {
        public int UserId { get; set; }

        public ListUserAccounts(int userId)
        {
            this.UserId = userId;
        }
    }
}
