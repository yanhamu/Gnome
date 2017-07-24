using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine
{
    public class FieldOperand : IOperand<string>
    {
        private readonly string field;

        public FieldOperand(string field)
        {
            this.field = field;
        }

        public string GetValue(TransactionRow transaction)
        {
            return transaction.Fields.ContainsKey(field)
                ? transaction.Fields[field]
                : null;
        }
    }
}
