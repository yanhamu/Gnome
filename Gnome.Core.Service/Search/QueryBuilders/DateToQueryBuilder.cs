using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public class DateToQueryBuilder : IQueryBuilder<SingleAccountTransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SingleAccountTransactionSearchFilter filter)
        {
            if (filter.DateFilter == null || filter.DateFilter.To.HasValue == false)
                return null;

            return query.Where(t => t.Date <= filter.DateFilter.To);
        }
    }
}
