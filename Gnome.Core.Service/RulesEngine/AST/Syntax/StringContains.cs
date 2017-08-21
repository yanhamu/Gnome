using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class StringContains : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<string> @string;
        private readonly ISyntaxNode<string> value;

        public StringContains(ISyntaxNode<string> @string, ISyntaxNode<string> value)
        {
            this.@string = @string;
            this.value = value;
        }
        public bool Evaluate(TransactionRow row)
        {
            return @string.Evaluate(row).Contains(value.Evaluate(row));
        }
    }
}
