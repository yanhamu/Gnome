using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine
{
    public class Equals : IExpression
    {
        public IOperand<string> LeftOperand { get; }
        public IOperand<string> RightOperand { get; }

        public bool Evaluate(TransactionRow transaction)
        {
            return LeftOperand.GetValue(transaction) == RightOperand.GetValue(transaction);
        }
    }
}
