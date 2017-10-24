using Gnome.Core.Model.Database;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class CategoryTransactionFixture
    {
        private static CategoryTransaction categoryTransaction;

        public static CategoryTransaction CategoryTransaction
        {
            get
            {
                if (categoryTransaction == null)
                    categoryTransaction = new CategoryTransaction()
                    {
                        CategoryId = CategoryFixture.UnAssigned.Id,
                        TransactionId = TransactionFixtures.Expense.Id
                    };
                return categoryTransaction;
            }
        }
    }
}