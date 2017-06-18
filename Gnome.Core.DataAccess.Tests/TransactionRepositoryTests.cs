using Autofac;
using Gnome.Tests.Common;
using MongoDB.Driver;
using System.Linq;
using Xunit;

namespace Gnome.Core.DataAccess.Tests
{
    public class TransactionRepositoryTests : BaseMongoTest
    {
        [Fact]
        public void Should_Retrieve_100_Transactions()
        {
            var repository = container.Resolve<TransactionRepository>();

            var transactions = repository.Retrieve(100);

            Assert.True(transactions.Count() == 100);
        }
    }
}