using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class StringField : ISyntaxNode<string>
    {
        private readonly string fieldName;

        public StringField(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public string Evaluate(TransactionRow row)
        {
            return row[fieldName];
        }
    }
}
