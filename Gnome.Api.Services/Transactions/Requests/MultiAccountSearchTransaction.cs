using Gnome.Api.Services.Transactions.Model;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions.Requests
{
    public class MultiAccountSearchTransaction : IRequest<SearchTransactionResult>
    {
        public MultiAccountTransactionSearchFilter Filter { get; }
        public Guid UserId { get; }

        public MultiAccountSearchTransaction(Guid userId, MultiAccountTransactionSearchFilter filter)
        {
            this.UserId = userId;
            this.Filter = filter;
        }
    }
}
