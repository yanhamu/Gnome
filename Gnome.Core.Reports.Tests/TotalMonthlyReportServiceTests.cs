using Gnome.Core.Reports.TotalMonthly;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Reports.Tests
{
    public class TotalMonthlyReportServiceTests
    {
        [Fact]
        public void Should_Return_Full_DataSeries()
        {
            var service = new TotalMonthlyReportService(null);
            var from = new DateTime(2017, 1, 1);
            var to = new DateTime(2017, 2, 28);
            var filter = new ClosedInterval(from, to);
            var rows = GetRows(filter);

            var result = service.Compute(rows, filter);

            Assert.Equal(2, result.Count);

            var first = result[0];
            Assert.Equal(GetFullMonthInterval(from), first.Interval);
            Assert.Equal(31m, first.Expences);

            var second = result[1];
            Assert.Equal(GetFullMonthInterval(to), second.Interval);
            Assert.Equal(28m, second.Expences);
        }

        private ClosedInterval GetFullMonthInterval(DateTime date)
        {
            var from = new DateTime(2017, date.Month, 1);
            var to = from.AddMonths(1).AddDays(-1);
            return new ClosedInterval(from, to);
        }

        private IEnumerable<TransactionCategoryRow> GetRows(ClosedInterval filter)
        {
            for (DateTime date = filter.From; date <= filter.To; date = date.AddDays(1))
                yield return CreateRow(date);
        }

        private TransactionCategoryRow CreateRow(DateTime date)
        {
            var row = new TransactionRow(
                    default(Guid),
                    default(Guid),
                    date,
                    1,
                    default(string),
                    default(List<Guid>));
            var categories = new List<Category>();

            return new TransactionCategoryRow(row, categories);

        }
    }
}