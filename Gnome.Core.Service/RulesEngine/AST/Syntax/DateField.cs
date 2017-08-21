using Gnome.Core.Service.Transactions;
using System;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class DateField : ISyntaxNode<DateTime>
    {
        private readonly string fieldName;

        public DateField(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public DateTime Evaluate(TransactionRow row)
        {
            return DateTime.Parse(row[fieldName]);
        }
    }
}