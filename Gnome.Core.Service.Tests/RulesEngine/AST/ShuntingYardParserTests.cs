using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class ShuntingYardParserTests
    {
        private ShuntingYardParser parser;

        public ShuntingYardParserTests()
        {
            this.parser = new ShuntingYardParser(new Lexer());
        }

        [Fact]
        public void Should_Return_Tokens()
        {
            var expression = "1 = 2 and 2 = 3";
            var tokens = string.Join(" ", parser.Parse(expression).Select(t => t.ToString()));

            Assert.Equal("1 2 = 2 3 = and", tokens);
        }

        [Fact]
        public void Should_Return_Tokens_When_Parentheses_Passed()
        {
            var expression = "1 = 2 and (2 = 3 or 4 < 5)";
            var tokens = string.Join(" ", parser.Parse(expression).Select(t => t.ToString()));
            Assert.Equal("1 2 = 2 3 = 4 5 < or and", tokens);
        }

        [Fact]
        public void Should_Return_Tokens_When_Parentheses_Are_Present()
        {
            var expression = "(1 != 2 and x contains 'test') or 4 < 5";
            var tokens = string.Join(" ", parser.Parse(expression).Select(t => t.ToString()));
            Assert.Equal("1 2 != x 'test' contains and 4 5 < or", tokens);
        }

        [Fact]
        public void Should_Return_Tokens_When_Negative_Operator_Is_Passed()
        {
            var expression = "(1 != 2 and x contains 'test') or not y";
            var tokens = string.Join(" ", parser.Parse(expression).Select(t => t.ToString()));
            Assert.Equal("1 2 != x 'test' contains and y not or", tokens);
        }
    }
}
