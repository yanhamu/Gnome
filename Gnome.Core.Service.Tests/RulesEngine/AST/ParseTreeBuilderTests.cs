using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class ParseTreeBuilderTests
    {
        [Fact]
        public void Should_Return_Simple_Tree()
        {
            var tokens = new List<IToken>()
            {
                new NumberToken("10"),
                new OperatorToken("="),
                new FieldToken("amount")
            };

            var builder = new ParseTreeBuilder();
            var tree = builder.Build(tokens);

            Assert.Equal("=", tree.Content.Value);
            Assert.IsType<NumberToken>(tree.Content);

            var numberTokenNode = tree.Children.Single(c => c.Content.Value == "10");
            Assert.IsType<NumberToken>(numberTokenNode);

            var literalTokenNode = tree.Children.Single(c => c.Content.Value == "amount");
            Assert.IsType<NumberToken>(literalTokenNode);
        }
    }
}
