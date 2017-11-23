using Gnome.Core.Model.Database;
using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.Rules.Actions
{
    public abstract class Action
    {
        public string Type { get; }

        public bool IsSuitable(string type)
        {
            return this.Type == type;
        }

        public Action(Rule rule)
        {
            this.Type = rule.ActionType;
            this.Initialize(rule.ActionData);
        }

        protected abstract void Initialize(string actionData);
        protected abstract string GetData();
        public abstract void Process(TransactionCategoryRow transaction);
    }
}