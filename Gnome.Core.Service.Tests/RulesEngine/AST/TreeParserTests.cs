using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class TreeParserTests
    {
        [Fact]
        public void Should_Return_Simple_Tree()
        {
            var tokens = new List<IToken>() {
                new NumberToken("1"),
                new NumberToken("2"),
                new OperatorToken("+", 10) };

            var treeBuilder = new TreeParser();
            var root = treeBuilder.Build(tokens);

            Assert.Equal(tokens[2], root.Value);
            Assert.Equal(tokens[0], root.Children.First.Value.Value);
            Assert.Equal(tokens[1], root.Children.Last.Value.Value);
        }

        [Fact]
        public void Should_Return_Advanced_Tree()
        {
            var tokens = new List<IToken>()
            {
                new NumberToken("1"),
                new NumberToken("1"),
                new OperatorToken("=", 10),
                new NumberToken("2"),
                new NumberToken("2"),
                new OperatorToken("=", 10),
                new OperatorToken("and",5)
            };

            var treeBuilder = new TreeParser();
            var root = treeBuilder.Build(tokens);

            Assert.Equal(tokens[6], root.Value);
            Assert.Equal(tokens[2], root.Children.ElementAt(0).Value);
            Assert.Equal(tokens[5], root.Children.ElementAt(1).Value);
        }
    }
}