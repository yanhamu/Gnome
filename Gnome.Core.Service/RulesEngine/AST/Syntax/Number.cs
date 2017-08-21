using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class Number : ISyntaxNode<decimal>
    {
        public Number(decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; set; }

        public decimal Evaluate(TransactionRow row)
        {
            return Value;
        }
    }
}
