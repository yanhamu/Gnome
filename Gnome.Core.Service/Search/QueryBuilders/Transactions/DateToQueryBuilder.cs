using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class DateToQueryBuilder : IQueryBuilder<SingleAccountTransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SingleAccountTransactionSearchFilter filter)
        {
            if (filter.DateFilter == null || filter.DateFilter.To.HasValue == false)
                return query;

            return query.Where(t => t.Date <= filter.DateFilter.To);
        }
    }
}
