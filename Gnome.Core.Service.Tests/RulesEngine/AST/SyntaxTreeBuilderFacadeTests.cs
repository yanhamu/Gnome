using Gnome.Core.Service.RulesEngine.AST;
using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine.AST
{
    public class SyntaxTreeBuilderFacadeTests
    {
        private readonly ISyntaxTreeBuilderFacade builder;

        public SyntaxTreeBuilderFacadeTests()
        {
            this.builder = new SyntaxTreeBuilderFacade();
        }

        [Fact]
        public void Should_Build_Simple_Numeric_Syntax_Tree()
        {
            Assert.True(builder.Build("1 = 1").Evaluate(null));
            Assert.True(builder.Build("1 < 2").Evaluate(null));
            Assert.True(builder.Build("2 <= 2").Evaluate(null));
            Assert.True(builder.Build("2 >= 2").Evaluate(null));
            Assert.True(builder.Build("2 > 1").Evaluate(null));
            Assert.True(builder.Build("1 != 2").Evaluate(null));

            Assert.False(builder.Build("1 != 1").Evaluate(null));
            Assert.False(builder.Build("1 > 2").Evaluate(null));
            Assert.False(builder.Build("1 >= 2").Evaluate(null));
            Assert.False(builder.Build("2 <= 1").Evaluate(null));
            Assert.False(builder.Build("2 < 1").Evaluate(null));
            Assert.False(builder.Build("1 = 2").Evaluate(null));
        }

        [Fact]
        public void Should_Build_Numeric_Syntax_Tree()
        {
            Assert.True(builder.Build("(1 = 1 and 2 = 2) or 1 = 2").Evaluate(null));
            Assert.False(builder.Build("(1 = 1 or 2 = 2) and 1 = 2").Evaluate(null));
            Assert.False(builder.Build("((1 = 1 or 2 = 2) and (1 = 2))").Evaluate(null));
            Assert.True(builder.Build("((1 = 1 and 2 = 2) or (1 = 2))").Evaluate(null));
            Assert.True(builder.Build("((1 = 1 or 2 = 1) or (1 = 2))").Evaluate(null));
            Assert.True(builder.Build("((1 != 1 or 2 != 1) or (1 = 2))").Evaluate(null));
        }

        [Fact]
        public void Should_Build_Simple_String_Syntax_Tree()
        {
            Assert.True(builder.Build("'Alice' = 'Alice'").Evaluate(null));
            Assert.True(builder.Build("'Alice' != 'Bob'").Evaluate(null));

            Assert.False(builder.Build("'Alice' != 'Alice'").Evaluate(null));
            Assert.False(builder.Build("'Alice' = 'Bob'").Evaluate(null));

            Assert.True(builder.Build("'red green blue' contains 'green'").Evaluate(null));
        }

        [Fact]
        public void Should_Build_Syntax_Tree_With_Fields()
        {
            Assert.True(builder.Build("address contains 'Penn'").Evaluate(Fixture.TransactionRow));
            Assert.True(builder.Build("order > 99 and order < 101 and order = 100").Evaluate(Fixture.TransactionRow));

            Assert.False(builder.Build("address contains 'Down'").Evaluate(Fixture.TransactionRow));
            Assert.False(builder.Build("order >= 101").Evaluate(Fixture.TransactionRow));
        }
    }
}