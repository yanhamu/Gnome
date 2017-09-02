using Gnome.Api.Services.Transactions.Model;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions.Requests
{
    public class SingleAccountSearchTransaction : IRequest<SearchTransactionResult>
    {
        public SingleAccountTransactionSearchFilter Filter { get; }
        public Guid UserId { get; }

        public SingleAccountSearchTransaction(SingleAccountTransactionSearchFilter filter, Guid userId)
        {
            this.Filter = filter;
            this.UserId = userId;
        }
    }
}