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
        private readonly List<Expression> expressions;
        private SyntaxTreeBuilderFacade treeBuilder;
        private readonly Dictionary<Guid, ISyntaxNode<bool>> cache = new Dictionary<Guid, ISyntaxNode<bool>>();

        public CachedEvaluator(List<Expression> expressions, SyntaxTreeBuilderFacade treeBuilder)
        {
            this.expressions = expressions;
            this.treeBuilder = treeBuilder;
        }

        public void Initialize()
        {
            foreach (var e in expressions)
            {
                if (cache.ContainsKey(e.Id))
                    throw new ArgumentException("Duplicit expressions are not allowed");

                cache.Add(e.Id, treeBuilder.Build(e.ExpressionString));
            }
        }

        public bool Evaluate(Guid expressionId, TransactionCategoryRow transaction)
        {
            return cache[expressionId].Evaluate(transaction.Row);
        }
    }
}
