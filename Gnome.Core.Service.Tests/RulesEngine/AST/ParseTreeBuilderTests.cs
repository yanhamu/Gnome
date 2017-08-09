using Gnome.Core.Service.RulesEngine.AST;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class ParseTreeBuilderTests
    {
        [Fact]
        public void Should_Return_Simple_Tree()
        {
            var builder = new ParseTreeBuilder();
            var tokenizer = new Gnome.Core.Service.RulesEngine.Tokenizer.Tokenizer();
            var expression = "1 = 2 and 3 = 4";
            var tokens = tokenizer.GetTokens(expression).ToList();
            var root = builder.Build(tokens);
            var result = new TokenStringBuilder().Build(root);

            Assert.Equal("( ( 1 = 2 ) and ( 3 = 4 ) )", result);
        }
    }
}
