using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public class AccountQueryBuilder : IQueryBuilder<SingleAccountSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SingleAccountSearchFilter filter)
        {
            return query.Where(t => t.AccountId == filter.AccountId);
        }
    }
}
