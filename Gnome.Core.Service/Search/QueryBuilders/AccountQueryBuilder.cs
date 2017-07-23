using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public class AccountQueryBuilder : IQueryBuilder
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SearchFilter filter)
        {
            if (filter.AccountsFilter == null)
                return query;

            return query.Where(t => filter.AccountsFilter.AccountIds.Contains(t.AccountId));
        }
    }
}
