using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Rules.Actions
{
    public class ActionFactory : IActionFactory
    {
        private readonly IEnumerable<Action> actions;

        public ActionFactory(IEnumerable<Action> actions)
        {
            this.actions = actions;
        }
        public Action Create(Rule rule, Guid transactionId)
        {
            return new AssignCategory(rule);
        }
    }
}