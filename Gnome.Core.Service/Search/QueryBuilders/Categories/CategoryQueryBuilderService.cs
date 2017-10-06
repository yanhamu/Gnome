using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Categories
{
    public class CategoryQueryBuilderService : IQueryBuilderService<CategoryTransaction, TransactionSearchFilter>
    {
        public IQueryable<CategoryTransaction> Filter(IQueryable<CategoryTransaction> query, TransactionSearchFilter filter)
        {
            if (filter.DateFilter == null)
                return query;

            var interval = filter.DateFilter;

            query = query.Where(i => i.Transaction.Date >= interval.From);
            query = query.Where(i => i.Transaction.Date <= interval.To);

            return query;
        }
    }
}