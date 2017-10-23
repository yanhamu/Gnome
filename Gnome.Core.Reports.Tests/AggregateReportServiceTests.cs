using Gnome.Core.Reports.AggregateReport;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gnome.Core.Reports.Tests
{
    public class AggregateReportServiceTests
    {
        [Fact]
        public void Should_Return_Full_Service()
        {
            var service = new AggregateReportService(null);

            var start = new DateTime(2017, 1, 3);
            var end = start.AddDays(6);

            var interval = new ClosedInterval(start, end);
            var aggregates = service.Compute(interval, GetRows(), 3);

            Assert.Equal(27, aggregates.Sum(a => a.Expences));
        }

        private List<TransactionCategoryRow> GetRows()
        {
            return Enumerable.Range(1, 9).Select(i => CreateRow(i)).ToList();
        }

        private TransactionCategoryRow CreateRow(int i)
        {
            return new TransactionCategoryRow()
            {
                Row = new TransactionRow(default(Guid), default(Guid), new DateTime(2017, 1, i), 1, default(string), null)
            };
        }
    }
}
