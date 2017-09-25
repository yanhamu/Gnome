using Gnome.Core.Service.RulesEngine;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Transactions.QueryBuilders
{
    public class ExpressionQueryBuilder : ITransactionCategoryRowQueryBuilder
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;
        private readonly CachedEvaluatorFactory evaluatorFactory;

        public ExpressionQueryBuilder(
            ITransactionCategoryRowQueryBuilder queryBuilder,
            CachedEvaluatorFactory evaluatorFactory)
        {
            this.queryBuilder = queryBuilder;
            this.evaluatorFactory = evaluatorFactory;
        }

        public IEnumerable<TransactionCategoryRow> Query(Guid userId, SingleAccountTransactionSearchFilter filter)
        {
            var evaluator = evaluatorFactory.Create(filter.ExcludeExpressions.Union(filter.IncludeExpressions).ToList());

            var transactions = queryBuilder.Query(userId, filter);

            if (filter.ExcludeExpressions.Any() && filter.IncludeExpressions.Any())
            {
                return transactions
                    .Where(t => filter.IncludeExpressions.Any(e => evaluator.Evaluate(e, t)))
                    .Where(t => !filter.ExcludeExpressions.Any(e => evaluator.Evaluate(e, t)));
            }
            else if (!filter.ExcludeExpressions.Any() && filter.IncludeExpressions.Any())
            {
                return transactions
                    .Where(t => filter.IncludeExpressions.Any(e => evaluator.Evaluate(e, t)));
            }
            else if (filter.ExcludeExpressions.Any() && !filter.IncludeExpressions.Any())
            {
                return transactions
                    .Where(t => filter.ExcludeExpressions.Any(e => evaluator.Evaluate(e, t)));
            }
            else
            {
                return transactions;
            }
        }
    }
}