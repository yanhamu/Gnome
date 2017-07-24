using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class AccountQueryBuilder : IQueryBuilder<SingleAccountTransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, SingleAccountTransactionSearchFilter filter)
        {
            return query.Where(t => t.AccountId == filter.AccountId);
        }
    }
}
