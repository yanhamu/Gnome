using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine
{
    public class ConstantOperand<T> : IOperand<T>
    {
        private readonly T value;

        public ConstantOperand(T value)
        {
            this.value = value;
        }

        public T GetValue(TransactionRow transaction)
        {
            return value;
        }
    }
}
