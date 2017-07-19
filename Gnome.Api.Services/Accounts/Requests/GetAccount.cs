using MediatR;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class GetAccount : IRequest<Account>
    {
        public int AccountId { get; set; }
        public GetAccount(int accountId)
        {
            this.AccountId = accountId;
        }
    }
}
