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

        public CachedEvaluator(ISyntaxTreeBuilderFacade treeBuilder, List<Expression> expressions)
        {
            this.treeBuilder = treeBuilder;

            expressions.ForEach(e => cache.Add(e.Id, treeBuilder.Build(e.ExpressionString)));
        }

        public bool Evaluate(Guid expressionId, TransactionCategoryRow transaction)
        {
            return cache[expressionId].Evaluate(transaction.Row);
        }
    }
}
