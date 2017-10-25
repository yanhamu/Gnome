using Gnome.Core.DataAccess;
using Gnome.Core.Service.RulesEngine.AST;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine
{
    public class CachedEvaluatorFactory : ICachedEvaluatorFactory
    {
        private readonly ISyntaxTreeBuilderFacade treeBuilder;
        private readonly IExpressionRepository expressionRepository;

        public CachedEvaluatorFactory(ISyntaxTreeBuilderFacade treeBuilder, IExpressionRepository expressionRepository)
        {
            this.treeBuilder = treeBuilder;
            this.expressionRepository = expressionRepository;
        }

        public CachedEvaluator Create(List<Guid> ids)
        {
            var expressions = expressionRepository.Query
                .Where(e => ids.Contains(e.Id))
                .ToList();
            return new CachedEvaluator(treeBuilder).Initialize(expressions);
        }
    }
}