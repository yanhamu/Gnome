using Gnome.Core.Service.RulesEngine;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using System.Linq;

namespace Gnome.Core.Service.Rules
{
    public class TransactionEvaluator
    {
        private readonly CachedEvaluator cachedEvaluator;

        public TransactionEvaluator(CachedEvaluator cachedEvaluator) //TODO implement
        {
            this.cachedEvaluator = cachedEvaluator;
        }

        public bool Satisfies(TransactionCategoryRow transaction, TransactionSearchFilter searchFilter)
        {
            if (!searchFilter.Accounts.Contains(transaction.Row.AccountId))
                return false;

            if (searchFilter.ExcludeExpressions.Any(e => cachedEvaluator.Evaluate(e, transaction)))
                return false;

            if (searchFilter.IncludeExpressions.Any(e => cachedEvaluator.Evaluate(e, transaction)))
                return true;
            return false;
        }
    }
}