using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine
{
    public class Rule
    {
        private readonly IExpression expression;
        public int CategoryId { get; }

        public Rule(IExpression expression, int categoryId)
        {
            this.expression = expression;
            this.CategoryId = categoryId;
        }

        public bool Match(TransactionRow transaction)
        {
            return expression.Evaluate(transaction);
        }
    }
}
