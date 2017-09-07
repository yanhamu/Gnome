using Gnome.Core.Service.Transactions;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public class NumberLess : ISyntaxNode<bool>
    {
        private readonly ISyntaxNode<decimal>[] numbers;

        public NumberLess(ISyntaxNode<decimal>[] numbers)
        {
            this.numbers = numbers;
        }

        public bool Evaluate(TransactionRow row)
        {
            return Enumerable
                .Range(0, numbers.Length - 1)
                .All(i => numbers[i].Evaluate(row) < numbers[i + 1].Evaluate(row));
        }
    }
}