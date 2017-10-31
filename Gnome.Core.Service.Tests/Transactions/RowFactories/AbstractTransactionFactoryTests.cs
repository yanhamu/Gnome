using Gnome.Core.Model.Database;
using Gnome.Core.Service.Transactions.RowFactories;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.Transactions.RowFactories
{
    public class AbstractTransactionFactoryTests
    {
        [Fact]
        public void Should_Throw_Exception()
        {
            var factory = new AbstractTransactionFactory();

            Assert.Throws<ArgumentException>(() => factory.Create(new Transaction() { Type = "random" }));
        }

        [Fact]
        public void Should_Create_TransactionRow()
        {
            var factory = new AbstractTransactionFactory();
            var transaction = new Transaction()
            {
                Id = new Guid("008fd303-e315-4988-be7f-184e56d8be1c"),
                AccountId = new Guid("29211dac-410d-40de-808c-fe1ce4a31bd8"),
                Amount = 50000m,
                Data = "{variablesymbol:'111', nonexisting:'symbol'}",
                Date = new DateTime(2017, 1, 1),
                Type = "fio",
                CategoryData = "[]"
            };
            var row = factory.Create(transaction);

            Assert.Equal(transaction.Id, row.Id);
            Assert.Equal(transaction.Id.ToString(), row["id"]);
            Assert.Equal(transaction.Date.Date.ToString(), row["date"]);
            Assert.Equal(transaction.Amount.ToString(), row["amount"]);
            Assert.Equal(transaction.Type.ToString(), row["type"]);
            Assert.Equal(transaction.AccountId.ToString(), row["accountId"]);
            Assert.Equal(transaction.AccountId, row.AccountId);
            Assert.Equal(transaction.Amount, row.Amount);
            Assert.Equal("111", row["variablesymbol"]);
            Assert.Null(row["nonexisting"]);

            Assert.Throws<ArgumentException>(() => row["amount"] = "unknown");
        }
    }
}
