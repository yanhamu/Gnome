using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class TransactionQueryBuilderService : IQueryBuilderService<Transaction, SingleAccountTransactionSearchFilter>
    {
        private readonly IEnumerable<IQueryBuilder<SingleAccountTransactionSearchFilter>> queryBuilders;

        public TransactionQueryBuilderService(IEnumerable<IQueryBuilder<SingleAccountTransactionSearchFilter>> queryBuilders)
        {
            this.queryBuilders = queryBuilders;
        }

        public IQueryable<Transaction> Filter(IQueryable<Transaction> query, SingleAccountTransactionSearchFilter filter)
        {
            foreach (var builder in this.queryBuilders)
                query = builder.Build(query, filter);
            return query;
        }
    }
}