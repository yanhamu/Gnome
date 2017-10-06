using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class DateFromQueryBuilder : IQueryBuilder<TransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, TransactionSearchFilter filter)
        {
            return query.Where(t => t.Date >= filter.DateFilter.From);
        }
    }
}
