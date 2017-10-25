using Gnome.Core.Model.Database;
using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Categories.Resolvers;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.RowFactories;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Rules
{
    public class RulesEvaluator
    {
        private readonly IAbstractTransactionFactory transactionFactory;
        private readonly TransactionEvaluator evaluator;
        private readonly ICategoryTreeFactory categoryTreeFactory;

        public RulesEvaluator(
            IAbstractTransactionFactory transactionFactory,
            TransactionEvaluator evaluator,
            ICategoryTreeFactory categoryTreeFactory)
        {
            this.transactionFactory = transactionFactory;
            this.evaluator = evaluator;
            this.categoryTreeFactory = categoryTreeFactory;
        }

        public void Evaluate(Transaction transaction, Guid userId)
        {
            var row = transactionFactory.Create(transaction);
            var resolver = new Resolver(categoryTreeFactory.Create(userId));
            var categoryRow = this.Create(row, resolver.GetCategories(row.Categories));
            var filter = default(TransactionSearchFilter);
            // todo implement
            // foreach rule
            if (evaluator.Satisfies(categoryRow, filter))
            {
                // perform action
            }
        }

        private TransactionCategoryRow Create(TransactionRow row, List<Transactions.Category> categories)
        {
            return new TransactionCategoryRow() { Row = row, Categories = categories };
        }
    }
}
