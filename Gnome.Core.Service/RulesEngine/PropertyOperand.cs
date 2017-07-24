using Gnome.Core.Service.Transactions;
using System;

namespace Gnome.Core.Service.RulesEngine
{
    public class PropertyOperand<TPropertyType> : IOperand<string>
    {
        private readonly Func<TransactionRow, TPropertyType> selector;

        public PropertyOperand(Func<TransactionRow, TPropertyType> selector)
        {
            this.selector = selector;
        }

        public string GetValue(TransactionRow transaction)
        {
            return selector(transaction).ToString();
        }
    }
}
