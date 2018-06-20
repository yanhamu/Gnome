using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnome.Core.Service.RulesEngine
{
    public interface ICachedEvaluatorFactory
    {
        Task<CachedEvaluator> Create(List<Guid> ids);
        Task<CachedEvaluator> Create(Guid userId);
    }
}