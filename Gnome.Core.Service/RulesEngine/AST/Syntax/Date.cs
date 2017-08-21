using Gnome.Core.Service.Transactions;
using System;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class Date : ISyntaxNode<DateTime>
    {
        private readonly DateTime datetime;

        public Date(DateTime datetime)
        {
            this.datetime = datetime;
        }

        public DateTime Evaluate(TransactionRow row)
        {
            return datetime;
        }
    }
}
