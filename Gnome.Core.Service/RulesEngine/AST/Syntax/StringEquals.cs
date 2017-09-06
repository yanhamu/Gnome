using Gnome.Core.Service.Transactions;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class StringEquals : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<string>[] strings;

        public StringEquals(ISyntaxNode<string>[] strings)
        {
            this.strings = strings;
        }

        public bool Evaluate(TransactionRow row)
        {
            var oneToRuleThenAll = strings.First().Evaluate(row);
            return strings.All(s => s.Evaluate(row) == oneToRuleThenAll);
        }
    }
}
