using Gnome.Core.Model.Database;
using System;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class ExpressionFixtures
    {
        private static Expression variableSymbol;
        public static Expression VariableSymbol
        {
            get
            {
                if (variableSymbol == null)
                    variableSymbol = new Expression()
                    {
                        Id = new Guid("ba26c2ff-bdfa-4ed6-9672-368b94d4b611"),
                        ExpressionString = "variablesymbol = '111'",
                        Name = "by Variable symbol",
                        UserId = UserFixture.User.Id
                    };
                return variableSymbol;
            }
        }
    }
}
