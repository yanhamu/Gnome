using System;
using System.Collections.Generic;
using Gnome.Core.Model.Database;

namespace Gnome.Core.Service.Rules
{
    public interface IRulesEvaluator
    {
        List<Rule> GetSuitableRules(Guid transactionId, Guid userId);
    }
}