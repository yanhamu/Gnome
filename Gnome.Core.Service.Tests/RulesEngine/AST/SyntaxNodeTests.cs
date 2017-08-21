using Gnome.Core.Service.RulesEngine.AST.Syntax;
using Gnome.Core.Service.Transactions;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class SyntaxNodeTests
    {
        [Fact]
        public void Should_Evaluate_True()
        {
            var transactionRow = GetTransaction();
            var expression = GetExpression();
            Assert.True(expression.Evaluate(transactionRow));
        }

        private ISyntaxNode<bool> GetExpression()
        {
            var firstBranch = new NumberEquals(new Number(120m), new NumberField("amount"));
            var secondBranch = new DateLess(new DateField("date"), new Date(new DateTime(2011, 1, 1)));
            return new And(firstBranch, secondBranch);
        }

        private static TransactionRow GetTransaction()
        {
            var guid = new Guid("1edf80c2-f7e4-4612-befb-1ea79d7cda5d");
            var transactionRow = new TransactionRow(guid, new DateTime(2010, 1, 1), 120.0m, "fio");
            return transactionRow;
        }
    }
}