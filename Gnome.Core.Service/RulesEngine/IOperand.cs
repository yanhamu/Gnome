using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine
{
    public interface IOperand<T>
    {
        T GetValue(TransactionRow transaction);
    }
}