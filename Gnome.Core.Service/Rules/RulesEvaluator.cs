using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.RulesEngine;
using Gnome.Core.Service.TransactionCategories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Rules
{
    public class RulesEvaluator : IRulesEvaluator
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

        public List<Rule> GetSuitableRules(Guid transactionId, Guid userId)
        {
            var categoryRow = transactionCategoryService.Get(transactionId, userId);
            var cachedEvaluator = cachedEvaluatorFactory.Create(userId);
            return ruleRepository
                .GetRules(userId)
                .Where(r => cachedEvaluator.Evaluate(r.ExpressionId, categoryRow))
                .ToList();
        }
    }
}