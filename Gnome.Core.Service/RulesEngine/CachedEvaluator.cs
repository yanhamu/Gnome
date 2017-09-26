using Gnome.Core.Model.Database;
using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.AST.Syntax;
using Gnome.Core.Service.Transactions;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine
{
    public class CachedEvaluator
    {
        private ISyntaxTreeBuilderFacade treeBuilder;
        private readonly Dictionary<Guid, ISyntaxNode<bool>> cache = new Dictionary<Guid, ISyntaxNode<bool>>();

        public CachedEvaluator(ISyntaxTreeBuilderFacade treeBuilder)
        {
            this.treeBuilder = treeBuilder;
        }

        public CachedEvaluator Initialize(List<Expression> expressions)
        {
            foreach (var e in expressions)
            {
                if (cache.ContainsKey(e.Id))
                    throw new ArgumentException("Duplicit expressions are not allowed");

                cache.Add(e.Id, treeBuilder.Build(e.ExpressionString));
            }
            return this;
        }

        public bool Evaluate(Guid expressionId, TransactionCategoryRow transaction)
        {
            return cache[expressionId].Evaluate(transaction.Row);
        }
    }
}
