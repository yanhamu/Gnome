using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class NodeStringBuilderTests
    {
        [Fact]
        public void Should_Return_Simple_String()
        {
            var builder = new TokenStringBuilder();

            var root = new Node(null) { Token = new OperatorToken("=") };
            root.AddChild(new Node(root) { Token = new NumberToken("1") });
            root.AddChild(new Node(root) { Token = new NumberToken("2") });

            Assert.Equal("( ( 1 ) = ( 2 ) )", builder.Build(root));
        }
    }
}
