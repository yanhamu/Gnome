using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public class DateToQueryBuilder : IQueryBuilder
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SearchFilter filter)
        {
            if (filter.DateFilter == null || filter.DateFilter.To.HasValue == false)
                return null;

            return query.Where(t => t.Date <= filter.DateFilter.To);
        }
    }
}
