using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class TokenizerTests
    {
        [Fact]
        public void Should_Return_Tokens()
        {
            var e = "comment contains  'hello world' ";
            var tokenizer = new Gnome.Core.Service.RulesEngine.Tokenizer.Tokenizer();
            var enumerator = new List<IToken>() {
                new LiteralToken("comment"),
                new SkipToken(" "),
                new LiteralToken("contains"),
                new SkipToken("  "),
                new StringToken("'hello world'"),
                new SkipToken(" ")
            }.GetEnumerator();

            enumerator.MoveNext();
            foreach (var token in tokenizer.GetTokens(e))
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