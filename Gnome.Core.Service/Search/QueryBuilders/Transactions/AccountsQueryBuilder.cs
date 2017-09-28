using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class AccountsQueryBuilder : IQueryBuilder<MultiAccountTransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, MultiAccountTransactionSearchFilter filter)
        {
            return query.Where(t => filter.Accounts.Contains(t.AccountId));
        }
    }
}
