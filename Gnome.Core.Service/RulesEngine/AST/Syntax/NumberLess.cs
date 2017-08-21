using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class NumberLess : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<decimal> number;
        private readonly ISyntaxNode<decimal> than;

        public NumberLess(ISyntaxNode<decimal> number, ISyntaxNode<decimal> than)
        {
            this.number = number;
            this.than = than;
        }

        public bool Evaluate(TransactionRow row)
        {
            return number.Evaluate(row) < than.Evaluate(row);
        }
    }
}
