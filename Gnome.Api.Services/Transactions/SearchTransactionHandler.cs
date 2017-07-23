using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Search;
using Gnome.Core.Service.Transactions.RowFactories;
using MediatR;
using System.Linq;

namespace Gnome.Api.Services.Transactions
{
    public class SearchTransactionHandler : IRequestHandler<SingleAccountSearchTransaction, SearchTransactionResult>
    {
        private readonly ITransactionRepository repository;
        private readonly IQueryBuilderService queryBuilder;
        private readonly IAbstractTransactionFactory rowFactory;

        public SearchTransactionHandler(
            ITransactionRepository repository,
            IQueryBuilderService queryBuilder,
            IAbstractTransactionFactory transactionRowFactory)
        {
            this.repository = repository;
            this.queryBuilder = queryBuilder;
            this.rowFactory = transactionRowFactory;
        }

        public SearchTransactionResult Handle(SingleAccountSearchTransaction message)
        {
            var query = repository.Query;
            query = queryBuilder.Filter(query, message.Filter);
            var rows = query.ToList()
                .Select(t => rowFactory.Create(t));

            var result = new SearchTransactionResult()
            {
                Rows = rows.ToList()
            };

            return result;
        }
    }
}