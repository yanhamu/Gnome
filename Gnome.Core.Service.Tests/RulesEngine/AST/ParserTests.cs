using Gnome.Core.Service.RulesEngine.AST;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Linq;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class ParserTests
    {
        private Parser parser;

        public ParserTests()
        {
            this.parser = new Parser(new Lexer());
        }

        [Fact]
        public void SimpleTest()
        {
            var expression = "1 = 2 and 2 = 3";
            var tokens = string.Join(" ", parser.Parse(expression).Select(t => t.ToString()));

            Assert.Equal("1 2 = 2 3 = and", tokens);
        }

        [Fact]
        public void ComplexTest()
        {
            var expression = "";
            
        }
    }
}
