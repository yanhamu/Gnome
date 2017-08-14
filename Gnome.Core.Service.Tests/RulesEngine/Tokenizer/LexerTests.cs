using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class LexerTests
    {
        [Fact]
        public void Should_Return_Three_Tokens()
        {
            var expression = "a != b";
            var lexer = new Lexer();
            var enumerator = new List<IToken>() {
                new FieldToken("a"),
                new SkipToken(" "),
                new OperatorToken("!=",20),
                new SkipToken(" "),
                new FieldToken("b")
            }.GetEnumerator();

            enumerator.MoveNext();
            foreach (var token in lexer.GetTokens(expression))
            {
                var expected = enumerator.Current;
                var actual = token;

                AssertToken(expected, actual);
                enumerator.MoveNext();
            }
        }

        [Fact]
        public void Should_Return_Tokens()
        {
            var e = "comment contains  'hello world' and( x = 32.5) ";
            var lexer = new Lexer();
            var enumerator = new List<IToken>() {
                new FieldToken("comment"),
                new SkipToken(" "),
                new OperatorToken("contains", 20),
                new SkipToken("  "),
                new StringToken("hello world"),
                new SkipToken(" "),
                new OperatorToken("and", 10),
                new OpenParenthesisToken(),
                new SkipToken(" "),
                new FieldToken("x"),
                new SkipToken(" "),
                new OperatorToken("=", 20),
                new SkipToken(" "),
                new NumberToken("32.5"),
                new ClosingParenthesisToken(),
                new SkipToken(" ")
            }.GetEnumerator();

            enumerator.MoveNext();
            foreach (var token in lexer.GetTokens(e))
            {
                var expected = enumerator.Current;
                var actual = token;

                AssertToken(expected, actual);
                enumerator.MoveNext();
            }
        }

        private void AssertToken(IToken expected, IToken actual)
        {
            Assert.IsType(expected.GetType(), actual);
            Assert.Equal(expected.Value, actual.Value);
        }
    }
}