using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class OperatorTokenProviderTests
    {
        [Fact]
        public void Should_Return_FieldToken()
        {
            var provider = new LiteralTokenProvider(OperatorKeywords.Empty, StopCahracters.Empty);
            var expression = "name";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(3, result.EndIndex);
            Assert.Equal("name", result.Token.Value);
            Assert.IsType<FieldToken>(result.Token);
        }

        [Fact]
        public void Should_Return_FieldToken_At_End()
        {
            var provider = new LiteralTokenProvider(OperatorKeywords.Empty, StopCahracters.Empty);
            var expression = "name";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(3, result.EndIndex);
            Assert.Equal("name", result.Token.Value);
            Assert.IsType<FieldToken>(result.Token);
        }

        [Fact]
        public void Should_Return_OperatorToken()
        {
            var provider = new LiteralTokenProvider(OperatorKeywords.Basic, StopCahracters.Empty);
            var expression = "contains";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(7, result.EndIndex);
            Assert.Equal("contains", result.Token.Value);
            Assert.IsType<OperatorToken>(result.Token);
        }

        [Fact]
        public void Should_Return_OperatorToken_When_Stop_Token_Appears()
        {
            var provider = new LiteralTokenProvider(OperatorKeywords.Basic, StopCahracters.Basic);
            var expression = "contains(";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(7, result.EndIndex);
            Assert.Equal("contains", result.Token.Value);
            Assert.IsType<OperatorToken>(result.Token);
        }

        [Fact]
        public void Should_Throw_ArgumentException_When_Invalid_Input()
        {
            var provider = new LiteralTokenProvider(OperatorKeywords.Empty, StopCahracters.Empty);
            var expression = " name";
            Assert.Throws<ArgumentException>(() => provider.GetToken(0, expression));
        }

        private static class OperatorKeywords
        {
            public static Dictionary<string, int> Empty { get; } = new Dictionary<string, int>();
            public static Dictionary<string, int> Basic { get; } = new Dictionary<string, int>() { { "contains", 10 } };
        }

        private static class StopCahracters
        {
            public static HashSet<char> Empty { get; } = new HashSet<char>();
            public static HashSet<char> Basic { get; } = new HashSet<char>() { '(' };
        }
    }
}
