using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.RulesEngine;
using Gnome.Core.Service.TransactionCategories;
using Gnome.Core.Service.Transactions;
using System;
using System.Linq;

namespace Gnome.Core.Service.Rules
{
    public class RulesEvaluator
    {
        private readonly ICachedEvaluatorFactory cachedEvaluatorFactory;
        public readonly IRuleRepository ruleRepository;
        private readonly ITransactionCategoryService transactionCategoryService;

        public RulesEvaluator(
            ICachedEvaluatorFactory cachedEvaluatorFactory,
            IRuleRepository ruleRepository,
            ITransactionCategoryService transactionCategoryService)
        {
            this.cachedEvaluatorFactory = cachedEvaluatorFactory;
            this.ruleRepository = ruleRepository;
            this.transactionCategoryService = transactionCategoryService;
        }

        public void Evaluate(Guid transactionId, Guid userId)
        {
            var categoryRow = transactionCategoryService.Get(transactionId, userId);
            var cachedEvaluator = cachedEvaluatorFactory.Create(userId);
            var rules = ruleRepository.Query.Where(r => r.UserId == userId).ToList();

            rules.Where(r => cachedEvaluator.Evaluate(r.ExpressionId, categoryRow))
                .ToList()
                .ForEach(r => Process(categoryRow, r));

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
    }
}