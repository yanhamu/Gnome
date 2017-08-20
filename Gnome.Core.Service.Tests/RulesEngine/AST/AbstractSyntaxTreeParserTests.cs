using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class AbstractSyntaxTreeParserTests
    {
        [Fact]
        public void Should_Return_Simple_Tree()
        {
            var tokens = new List<IToken>() { new NumberToken("1"), new NumberToken("2"), new OperatorToken("+", 10) };

            var treeBuilder = new AbstractSyntaxTreeParser();
            var root = treeBuilder.Build(tokens);

            Assert.Equal(tokens[2], root.Token);
            Assert.Equal(tokens[0], root.Children.First.Value.Token);
            Assert.Equal(tokens[1], root.Children.Last.Value.Token);
        }
    }
}