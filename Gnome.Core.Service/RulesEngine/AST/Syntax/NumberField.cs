using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class NumberField : ISyntaxNode<decimal>
    {
        private readonly string fieldName;

        public NumberField(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public decimal Evaluate(TransactionRow row)
        {
            return decimal.Parse(row[fieldName]);
        }
    }
}