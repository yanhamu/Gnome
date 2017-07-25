using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class SkipTokenProviderTests
    {
        [Fact]
        public void Should_Return_SkipToken()
        {
            var provider = new SkipTokenProvider();
            var expression = "name = 'tata' and amount < 43 and comment contains 'vyber'";
            var result = provider.GetToken(4, expression);

            Assert.Equal(" ", result.Token.Value);
            Assert.IsType<SkipToken>(result.Token);
            Assert.Equal(4, result.StartIndex);
            Assert.Equal(4, result.EndIndex);
        }

        [Fact]
        public void Should_Return_SkipToken_With_Multiple_Spaces()
        {
            var provider = new SkipTokenProvider();
            var expression = "name = 'tata'   and amount < 43 and comment contains 'vyber'";
            var result = provider.GetToken(13, expression);

            Assert.Equal("   ", result.Token.Value);
            Assert.IsType<SkipToken>(result.Token);
            Assert.Equal(13, result.StartIndex);
            Assert.Equal(15, result.EndIndex);
        }

        [Fact]
        public void Should_Return_SkipToken_At_End()
        {
            var provider = new SkipTokenProvider();
            var expression = "name = 'tata' ";
            var result = provider.GetToken(13, expression);

            Assert.Equal(" ", result.Token.Value);
            Assert.IsType<SkipToken>(result.Token);
            Assert.Equal(13, result.StartIndex);
            Assert.Equal(13, result.EndIndex);
        }

        [Fact]
        public void Should_Throw_ArgumentException_At_Invalid_Input()
        {
            var provider = new SkipTokenProvider();
            var expression = "name = 'tata' ";
            Assert.Throws<ArgumentException>(() => provider.GetToken(0, expression));
        }
    }
}
