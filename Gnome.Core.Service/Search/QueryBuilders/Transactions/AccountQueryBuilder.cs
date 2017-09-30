using Gnome.Core.Model.Database;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders.Transactions
{
    public class AccountQueryBuilder : IQueryBuilder<TransactionSearchFilter>
    {
        public IQueryable<Transaction> Build(IQueryable<Transaction> query, TransactionSearchFilter filter)
        {
            if (filter.Accounts.Count > 1)
                return query.Where(t => filter.Accounts.Contains(t.AccountId));

            var accountId = filter.Accounts.First();
            return query.Where(t => t.AccountId == accountId);
        }
    }
}
