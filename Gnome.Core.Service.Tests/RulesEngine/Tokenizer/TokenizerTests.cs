using Gnome.Core.Service.RulesEngine.Tokenizer;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class TokenizerTests
    {
        [Fact]
        public void Should_Return_Tokens()
        {
            var e = "comment contains 'hello world'";
            var tokenizer = new Gnome.Core.Service.RulesEngine.Tokenizer.Tokenizer();
            var tokens = tokenizer.Tokenize(e);
            
            AssertToken<OperandToken>(tokens[0], "comment");
            AssertToken<OperatorToken>(tokens[1], "contains");
            AssertToken<StringConstantOperandToken>(tokens[2], "hello world");
        }

        private void AssertToken<T>(IToken token, string expexted)
        {
            Assert.IsType<T>(token);
            Assert.Equal(expexted, token.Value);
        }
    }
}
