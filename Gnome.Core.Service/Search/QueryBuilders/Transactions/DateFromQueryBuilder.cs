using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class DateFromQueryBuilder : IQueryBuilder<SingleAccountTransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SingleAccountTransactionSearchFilter filter)
        {
            if (filter.DateFilter == null || filter.DateFilter.From.HasValue == false)
                return query;

            return query.Where(t => t.Date >= filter.DateFilter.From);
        }
    }
}
