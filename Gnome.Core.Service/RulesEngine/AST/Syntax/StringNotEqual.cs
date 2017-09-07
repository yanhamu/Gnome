using Gnome.Core.Service.Transactions;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class StringNotEqual : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<string>[] strings;

        public StringNotEqual(ISyntaxNode<string>[] strings)
        {
            this.strings = strings;
        }

        public bool Evaluate(TransactionRow row)
        {
            return strings.Select(s => s.Evaluate(row)).Distinct().Count() == strings.Length;
        }
    }
}