using Gnome.Core.Service.Search.Filters;
using MediatR;

namespace Gnome.Api.Services.Transactions.Requests
{
    public class SearchTransaction : IRequest<SearchTransactionResult>
    {
        public SearchFilter Filter { get; }
        public int UserId { get; }

        public SearchTransaction(SearchFilter filter, int userId)
        {
            this.Filter = filter;
            this.UserId = userId;
        }
    }
}