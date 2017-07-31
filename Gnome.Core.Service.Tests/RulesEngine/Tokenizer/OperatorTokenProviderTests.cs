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
            var provider = new OperatorTokenProvider(new HashSet<string>());
            var expression = "name ";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(3, result.EndIndex);
            Assert.Equal("name", result.Token.Value);
            Assert.IsType<FieldToken>(result.Token);
        }

        [Fact]
        public void Should_Return_FieldToken_At_End()
        {
            var provider = new OperatorTokenProvider(new HashSet<string>());
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
            var provider = new OperatorTokenProvider(new HashSet<string>() { "contains" });
            var expression = "contains";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(3, result.EndIndex);
            Assert.Equal("contains", result.Token.Value);
            Assert.IsType<OperatorToken>(result.Token);
        }

        [Fact]
        public void Should_Throw_ArgumentException_When_Invalid_Input()
        {
            var provider = new OperatorTokenProvider(new HashSet<string>());
            var expression = " name";
            Assert.Throws<ArgumentException>(() => provider.GetToken(0, expression));
        }
    }
}
