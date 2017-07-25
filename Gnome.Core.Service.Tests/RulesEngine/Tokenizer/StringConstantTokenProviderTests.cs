using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class StringConstantTokenProviderTests
    {
        [Fact]
        public void Should_Provide_Token()
        {
            var provider = new StringConstantOperandProvider();
            var expression = "name = 'tata' and amount < 43 and comment contains 'vyber'";
            var result = provider.GetToken(7, expression);

            Assert.Equal(7, result.StartIndex);
            Assert.Equal(12, result.EndIndex);
            Assert.IsType<StringConstantOperandToken>(result.Token);
            Assert.Equal("'tata'", result.Token.Value);
        }

        [Fact]
        public void Should_Provide_Token_With_Apostrophes()
        {
            var provider = new StringConstantOperandProvider();
            var expression = "name = 'asdf' and amount < 43 and comment contains 'tomas''scan''t ''''work like that'''''";
            var result = provider.GetToken(51, expression);
            Assert.Equal(51, result.StartIndex);
            Assert.Equal(89, result.EndIndex);
            Assert.IsType<StringConstantOperandToken>(result.Token);
            Assert.Equal("'tomas''scan''t ''''work like that'''''", result.Token.Value);
        }

        [Fact]
        public void Should_Throw_ArgumentException_NoEnding()
        {
            var provider = new StringConstantOperandProvider();
            var expression = "name = 'asdf' and amount < 43 and comment contains 'vyber";
            Assert.Throws<ArgumentException>(() => provider.GetToken(55, expression));
        }

        [Fact]
        public void Should_Throw_ArgumentException_WrongBeginning()
        {
            var provider = new StringConstantOperandProvider();
            var expression = "name = 'asdf' and amount < 43 and comment contains 'vyber";
            Assert.Throws<ArgumentException>(() => provider.GetToken(1, expression));
        }
    }
}
