using Gnome.Api.Services.Transactions.Model;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.Service.Transactions.QueryBuilders;
using MediatR;
using System;
using System.Linq;

namespace Gnome.Api.Services.Transactions
{
    public class SearchTransactionHandler :
        IRequestHandler<SingleAccountSearchTransaction, SearchTransactionResult>,
        IRequestHandler<MultiAccountSearchTransaction, SearchTransactionResult>
    {
        private ITransactionCategoryRowQueryBuilder queryBuilder;

        public SearchTransactionHandler(ITransactionCategoryRowQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public SearchTransactionResult Handle(SingleAccountSearchTransaction message)
        {
            var rows = queryBuilder.Query(message.UserId, message.Filter).ToList();
            return new SearchTransactionResult(rows);
        }

        public SearchTransactionResult Handle(MultiAccountSearchTransaction message)
        {
            //TODO implement
            throw new NotImplementedException();
        }
    }
}