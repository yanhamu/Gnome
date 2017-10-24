using Gnome.Api.Services.Transactions.Model;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.Service.Transactions.QueryBuilders;
using MediatR;
using System.Linq;

namespace Gnome.Api.Services.Transactions
{
    public class SearchTransactionHandler :
        IRequestHandler<SearchTransaction, SearchTransactionResult>
    {
        private ITransactionCategoryRowQueryBuilder queryBuilder;

        public SearchTransactionHandler(ITransactionCategoryRowQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public SearchTransactionResult Handle(SearchTransaction message)
        {
            var rows = queryBuilder
                .Query(message.UserId, message.Filter)
                .OrderByDescending(t => t.Row.Date)
                .ToList();

            var pagination = PaginationResult.CreateFromTotal(message.PageFilter.PageSize, message.PageFilter.Page, rows.Count);
            var result = rows
                .Skip(pagination.PageSize * (pagination.CurrentPage - 1))
                .Take(pagination.PageSize)
                .ToList();

            return new SearchTransactionResult(result, pagination);
        }
    }
}