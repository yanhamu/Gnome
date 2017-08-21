using Gnome.Core.Service.Transactions;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class And : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<bool>[] operators;

        public And(params ISyntaxNode<bool>[] operators)
        {
            this.operators = operators;
        }

        public bool Evaluate(TransactionRow row)
        {
            return this.operators.All(o => o.Evaluate(row) == true);
        }
    }
}