using Gnome.Core.Service.RulesEngine.Tokenizer;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.Tokenizer
{
    public class OperandProviderTests
    {
        [Fact]
        public void Should_Provider_Number_Token()
        {
            var provider = new OperandProvider();
            var expression = "name = 'tata' and amount < 43 and comment contains 'vyber'";
            var result = provider.GetToken(0, expression);

            Assert.Equal(0, result.StartIndex);
            Assert.Equal(3, result.EndIndex);
            Assert.Equal("name", result.Token.Value);
            Assert.IsType<OperandToken>(result.Token);
        }
    }
}
