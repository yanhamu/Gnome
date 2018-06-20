using Gnome.Core.DataAccess;
using Gnome.Core.Service.RulesEngine.AST;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<CachedEvaluator> Create(List<Guid> expressionIds)
        {
            var expressions = await expressionRepository.Query
                .Where(e => expressionIds.Contains(e.Id))
                .ToListAsync();
            return new CachedEvaluator(treeBuilder, expressions);
        }

        public async Task<CachedEvaluator> Create(Guid userId)
        {
            var expressions = await expressionRepository.Query
                .Where(e => e.UserId == userId)
                .ToListAsync();
            return new CachedEvaluator(treeBuilder, expressions);
        }
    }
}