using Gnome.Core.Service.Transactions;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class StringContains : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<string> value;
        private readonly ISyntaxNode<string> shouldContain;

        public StringContains(ISyntaxNode<string>[] strings)
        {
            this.value = strings.ElementAt(0);
            this.shouldContain = strings.ElementAt(1);
        }
        public bool Evaluate(TransactionRow row)
        {
            return value.Evaluate(row).Contains(shouldContain.Evaluate(row));
        }
    }
}
