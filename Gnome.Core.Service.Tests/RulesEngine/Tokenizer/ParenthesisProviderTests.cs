using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class ParenthesisProviderTests
    {
        [Fact]
        public void Should_Return_OpenBracketToken()
        {
            var provider = new ParenthesisTokenProvider();
            var expression = "(";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(0, result.EndIndex);
            Assert.IsType<OpenParenthesisToken>(result.Token);
            Assert.Equal("(", result.Token.Value);
        }

        [Fact]
        public void Should_Return_ClosingBracketToken()
        {
            var provider = new ParenthesisTokenProvider();
            var expression = ")";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(0, result.EndIndex);
            Assert.IsType<ClosingParenthesisToken>(result.Token);
            Assert.Equal(")", result.Token.Value);
        }

        [Fact]
        public void Should_Throw_ArgumentException_When_Invalid_Input_Is_Passed()
        {
            var provider = new ParenthesisTokenProvider();
            var expression = " ";
            Assert.Throws<ArgumentException>(() => provider.GetToken(0, expression));
        }
    }
}
