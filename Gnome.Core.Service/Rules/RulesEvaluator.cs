using Gnome.Core.Model.Database;
using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Categories.Resolvers;
using Gnome.Core.Service.RulesEngine;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.RowFactories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Rules
{
    public class RulesEvaluator
    {
        private readonly IAbstractTransactionFactory transactionFactory;
        private readonly ICategoryTreeFactory categoryTreeFactory;
        private readonly ICachedEvaluatorFactory cachedEvaluatorFactory;

        public RulesEvaluator(
            IAbstractTransactionFactory transactionFactory,
            ICategoryTreeFactory categoryTreeFactory,
            ICachedEvaluatorFactory cachedEvaluatorFactory)
        {
            this.transactionFactory = transactionFactory;
            this.categoryTreeFactory = categoryTreeFactory;
            this.cachedEvaluatorFactory = cachedEvaluatorFactory;
        }

        public void Evaluate(Transaction transaction, Guid userId)
        {
            var row = transactionFactory.Create(transaction);
            var resolver = new Resolver(categoryTreeFactory.Create(userId));
            var categoryRow = this.Create(row, resolver.GetCategories(row.Categories));

            var cachedEvaluator = cachedEvaluatorFactory.Create(userId);
            var rules = default(List<Rule>); // todo get rules

            rules.Where(r => cachedEvaluator.Evaluate(r.ExpressionId, categoryRow)).ToList().ForEach(r => Process(categoryRow, r));

            foreach (var rule in rules)
            {
                cachedEvaluator.Evaluate(rule.ExpressionId, categoryRow);
            }
        }

        private void Process(TransactionCategoryRow categoryRow, Rule rule)
        {
            //TODO make action
            throw new NotImplementedException();
        }

        private TransactionCategoryRow Create(TransactionRow row, List<Transactions.Category> categories)
        {
            return new TransactionCategoryRow(row, categories);
        }
    }
}