using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public class DateFromQueryBuilder : IQueryBuilder
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SearchFilter filter)
        {
            if (filter.DateFilter == null || filter.DateFilter.From.HasValue == false)
                return query;

            return query.Where(t => t.Date >= filter.DateFilter.From);
        }
    }
}
