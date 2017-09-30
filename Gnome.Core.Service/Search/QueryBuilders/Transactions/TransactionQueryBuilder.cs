using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class TransactionQueryBuilder : IQueryBuilderService<Transaction, TransactionSearchFilter>
    {
        private readonly IEnumerable<IQueryBuilder<TransactionSearchFilter>> queryBuilders;

        public TransactionQueryBuilder(IEnumerable<IQueryBuilder<TransactionSearchFilter>> queryBuilders)
        {
            this.queryBuilders = queryBuilders;
        }

        public IQueryable<Transaction> Filter(IQueryable<Transaction> query, TransactionSearchFilter filter)
        {
            foreach (var builder in this.queryBuilders)
                query = builder.Build(query, filter);
            return query;
        }
    }
}