using MediatR;
using System;

namespace Gnome.Api.Services.Transactions
{
    public class SearchTransactionHandler : IRequestHandler<SearchTransaction, SearchTransactionResult>
    {
        public SearchTransactionResult Handle(SearchTransaction message)
        {
            throw new NotImplementedException();
        }
    }
}