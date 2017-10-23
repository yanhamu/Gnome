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
            var firstBranch = new NumberEqual(new Number(120m), new NumberField("amount"));
            var secondBranch = new DateLess(new DateField("date"), new Date(new DateTime(2011, 1, 1)));
            return new And(firstBranch, secondBranch);
        }

        private static TransactionRow GetTransaction()
        {
            return new TransactionRow(
                new Guid("1edf80c2-f7e4-4612-befb-1ea79d7cda5d"),
                new Guid("1d000171-4e13-445f-bd70-5fa5c4e42fc1"),
                new DateTime(2010, 1, 1),
                120.0m,
                "fio",
                null);
        }
    }
}