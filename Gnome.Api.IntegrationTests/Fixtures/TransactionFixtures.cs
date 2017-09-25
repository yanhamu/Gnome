using Gnome.Core.Model.Database;
using System;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class TransactionFixtures
    {
        private static Transaction income;
        public static Transaction Income
        {
            get
            {
                if (income == null)
                    income = new Transaction()
                    {
                        Id = new Guid("008fd303-e315-4988-be7f-184e56d8be1c"),
                        AccountId = AccountFixtures.Fio.Id,
                        Amount = 50000m,
                        Data = "{}",
                        Date = new DateTime(2017, 1, 1),
                        Type = "fio"
                    };
                return income;
            }
        }

        private static Transaction expense;
        public static Transaction Expense
        {
            get
            {
                if (expense == null)
                    expense = new Transaction()
                    {
                        Id = new Guid("d1bf4d5c-d965-4394-8516-d34524942776"),
                        AccountId = AccountFixtures.Fio.Id,
                        Amount = 1000m,
                        Data = "{}",
                        Date = new DateTime(2017, 1, 2),
                        Type = "fio"
                    };
                return expense;
            }
        }
    }
}
