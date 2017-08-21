using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class String : ISyntaxNode<string>
    {
        private readonly string value;

        public String(string value)
        {
            this.value = value;
        }

        public string Evaluate(TransactionRow row)
        {
            return value;
        }
    }
}
