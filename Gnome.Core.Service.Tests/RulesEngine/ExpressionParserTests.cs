using Gnome.Core.Service.RulesEngine;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine
{
    public class ExpressionParserTests
    {
        private readonly ExpressionParser parser;

        public ExpressionParserTests()
        {
            this.parser = new ExpressionParser();
        }

        [Fact]
        public void Should_Parse_Simple_Expression()
        {
            var e = "comment contains 'hello world'";
            var expression = parser.Parse(e);

            Assert.IsType<Contains>(expression.GetType());
            var contains = ((Contains)expression);
            Assert.IsType<FieldOperand>(contains.LeftOperand.GetType());
            Assert.IsType<ConstantOperand<string>>(contains.RightOperand.GetType());
        }
    }
}
