using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class StringEquals : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<string> @string;
        private readonly ISyntaxNode<string> that;

        public StringEquals(ISyntaxNode<string> @string, ISyntaxNode<string> that)
        {
            this.@string = @string;
            this.that = that;
        }

        public bool Evaluate(TransactionRow row)
        {
            return @string.Evaluate(row) == that.Evaluate(row);
        }
    }
}
