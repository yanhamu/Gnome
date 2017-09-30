using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class DateToQueryBuilder : IQueryBuilder<TransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, TransactionSearchFilter filter)
        {
            if (filter.DateFilter == null || filter.DateFilter.To.HasValue == false)
                return query;

            return query.Where(t => t.Date <= filter.DateFilter.To);
        }
    }
}
