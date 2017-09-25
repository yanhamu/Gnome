using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine
{
    public interface ICachedEvaluatorFactory
    {
        CachedEvaluator Create(List<Guid> ids);
    }
}