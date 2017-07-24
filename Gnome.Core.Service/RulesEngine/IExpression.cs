using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine
{
    public interface IExpression
    {
        bool Evaluate(TransactionRow transaction);
    }
}
