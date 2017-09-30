using Gnome.Api.Services.Transactions.Model;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions.Requests
{
    public class SearchTransaction : IRequest<SearchTransactionResult>
    {
        public TransactionSearchFilter Filter { get; }
        public Guid UserId { get; }

        public SearchTransaction(TransactionSearchFilter filter, Guid userId)
        {
            this.Filter = filter;
            this.UserId = userId;
        }
    }
}