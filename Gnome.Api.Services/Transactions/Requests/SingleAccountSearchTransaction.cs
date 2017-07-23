using Gnome.Core.Service.Search.Filters;
using MediatR;

namespace Gnome.Api.Services.Transactions.Requests
{
    public class SingleAccountSearchTransaction : IRequest<SearchTransactionResult>
    {
        public SingleAccountTransactionSearchFilter Filter { get; }
        public int UserId { get; }

        public SingleAccountSearchTransaction(SingleAccountTransactionSearchFilter filter, int userId)
        {
            this.Filter = filter;
            this.UserId = userId;
        }
    }
}