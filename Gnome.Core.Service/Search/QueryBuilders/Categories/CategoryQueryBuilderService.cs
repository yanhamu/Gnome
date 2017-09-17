using Gnome.Core.Model;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Categories
{
    public class CategoryQueryBuilderService : IQueryBuilderService<CategoryTransaction, SingleAccountTransactionSearchFilter>
    {
        public IQueryable<CategoryTransaction> Filter(IQueryable<CategoryTransaction> query, SingleAccountTransactionSearchFilter filter)
        {
            if (filter.DateFilter == null)
                return query;

            var interval = filter.DateFilter;

            if (interval.From.HasValue)
                query = query.Where(i => i.Transaction.Date >= interval.From);
            if (interval.To.HasValue)
                query = query.Where(i => i.Transaction.Date <= interval.To);

            return query;
        }
    }
}