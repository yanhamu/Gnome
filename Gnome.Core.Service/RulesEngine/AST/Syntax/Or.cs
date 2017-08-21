using Gnome.Core.Service.Transactions;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class Or : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<bool>[] operators;

        public Or(params ISyntaxNode<bool>[] operators)
        {
            this.operators = operators;
        }

        public bool Evaluate(TransactionRow row)
        {
            return operators.Any(o => o.Evaluate(row));
        }
    }
}
