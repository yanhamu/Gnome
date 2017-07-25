using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class LiteralTokenProviderTests
    {
        [Fact]
        public void Should_Return_Literal_Token()
        {
            var provider = new LiteralTokenProvider();
            var expression = "name ";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(3, result.EndIndex);
            Assert.Equal("name", result.Token.Value);
            Assert.IsType<LiteralToken>(result.Token);
        }

        [Fact]
        public void Should_Return_Literal_Token_At_End()
        {
            var provider = new LiteralTokenProvider();
            var expression = "name";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(3, result.EndIndex);
            Assert.Equal("name", result.Token.Value);
            Assert.IsType<LiteralToken>(result.Token);
        }

        [Fact]
        public void Should_Throw_ArgumentException_When_Invalid_Input()
        {
            var provider = new LiteralTokenProvider();
            var expression = " name";
            Assert.Throws<ArgumentException>(() => provider.GetToken(0, expression));
        }
    }
}
