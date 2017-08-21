using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class NumberMore
    {
        private readonly ISyntaxNode<decimal> number;
        private readonly ISyntaxNode<decimal> than;

        public NumberMore(ISyntaxNode<decimal> number, ISyntaxNode<decimal> than)
        {
            this.number = number;
            this.than = than;
        }

        public bool Evaluate(TransactionRow row)
        {
            return number.Evaluate(row) > than.Evaluate(row);
        }
    }
}
