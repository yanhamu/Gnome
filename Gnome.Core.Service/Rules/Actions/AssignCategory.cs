using Gnome.Core.Model.Database;
using Gnome.Core.Service.Transactions;
using Newtonsoft.Json;
using System;

namespace Gnome.Core.Service.Rules.Actions
{
    public class AssignCategory : Action
    {
        public Guid CategoryId { get; private set; }

        public AssignCategory(Rule rule) : base(rule) { }

        protected override void Initialize(string actionData)
        {
            this.CategoryId = JsonConvert.DeserializeObject<Guid>(actionData);
        }

        protected override string GetData()
        {
            return JsonConvert.SerializeObject(this.CategoryId);
        }

        public override void Process(TransactionCategoryRow transaction)
        {
            throw new NotImplementedException();
        }
    }
}