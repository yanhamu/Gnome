using Gnome.Core.Model.Database;
using Gnome.Core.Service.RulesEngine;
using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.AST.Syntax;
using Gnome.Core.Service.Transactions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine
{
    public class CachedEvaluatorTests
    {
        [Fact]
        public void Should_Evaluate_True()
        {
            var builder = GetTreeBuilderFacade(true);
            var expressionId = new Guid("183f9ace-428e-4f6e-8f11-03bc660064ed");
            var transaction = new TransactionCategoryRow(null, new List<Service.Transactions.Category>());

            var evaluator = new CachedEvaluator(builder, Expressions);

            Assert.True(evaluator.Evaluate(expressionId, transaction));
        }

        [Fact]
        public void Should_Throw_Exception_When_NonExisting_Expression_Passed()
        {
            var builder = GetTreeBuilderFacade(true);
            var expressionId = new Guid("ff177a45-709a-48e6-96f9-6cc243d7bc3d");
            var transaction = default(TransactionCategoryRow);

            var evaluator = new CachedEvaluator(builder, Expressions);

            Assert.Throws<KeyNotFoundException>(() => evaluator.Evaluate(expressionId, transaction));
        }

        private ISyntaxTreeBuilderFacade GetTreeBuilderFacade(bool evaluationResult)
        {
            var node = Substitute.For<ISyntaxNode<bool>>();
            node.Evaluate(Arg.Any<TransactionRow>()).Returns(evaluationResult);

            var builder = Substitute.For<ISyntaxTreeBuilderFacade>();
            builder.Build(Arg.Any<string>()).Returns(node);
            return builder;
        }

        public List<Expression> Expressions => new List<Expression>() {
            new Expression(){
                Id = new Guid("183f9ace-428e-4f6e-8f11-03bc660064ed"),
                ExpressionString = "1 = 1",
                Name = "all true",
                UserId = new Guid("c4a3f3a9-c60e-4637-91bf-ff745654e735")
            }
        };
    }
}