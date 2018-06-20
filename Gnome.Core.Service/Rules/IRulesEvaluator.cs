using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Rules
{
    public interface IRulesEvaluator
    {
        Task<List<Rule>> GetSuitableRules(Guid transactionId, Guid userId);
    }
}