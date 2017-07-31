using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class NumberTokenProviderTests
    {
        [Fact]
        public void Should_Return_Number_Token_When_Integer_Is_Passed()
        {
            var provider = new NumberTokenProvider(new HashSet<char>());
            var expression = "32";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(1, result.EndIndex);
            Assert.IsType<NumberToken>(result.Token);
            Assert.Equal("32", result.Token.Value);
        }

        [Fact]
        public void Should_Return_Number_Token_When_Decimal_Is_Passed()
        {
            var provider = new NumberTokenProvider(new HashSet<char>());
            var expression = "32.23";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(4, result.EndIndex);
            Assert.Equal("32.23", result.Token.Value);
            Assert.IsType<NumberToken>(result.Token);
        }

        [Fact]
        public void Should_Return_Number_Token_When_Stop_Character_Is_Passed()
        {
            var provider = new NumberTokenProvider(new HashSet<char>() { '#' });
            var expression = "32.23#";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(4, result.EndIndex);
            Assert.Equal("32.23", result.Token.Value);
            Assert.IsType<NumberToken>(result.Token);
        }

        [Fact]
        public void Should_Throw_Argument_Exception_When_Invalid_Input_Is_Passed()
        {
            var provider = new NumberTokenProvider(new HashSet<char>());
            var expression = " 32.23";
            Assert.Throws<ArgumentException>(() => provider.GetToken(0, expression));

        }
    }
}
