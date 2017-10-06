using Gnome.Core.Reports.Cummulative;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Reports.Tests
{
    public class CumulativeReportServiceTests
    {
        [Fact]
        public void Should_Return_Full_DataSeries()
        {
            var service = new CumulativeReportService(null);
            var from = new DateTime(2017, 1, 1);
            var to = new DateTime(2017, 2, 28);

            var orderedRows = GetRows(from, to);
            var filter = new ClosedInterval(from, to);
            var result = service.Fill(orderedRows, filter);

            //TODO improve and add sparse list tests
        }

        private List<TransactionCategoryRow> GetRows(DateTime from, DateTime to)
        {
            var list = new List<TransactionCategoryRow>();
            for (DateTime date = from; date <= to; date = date.AddDays(1))
                list.Add(CreateRow(date, 1));
            return list;
        }

        private TransactionCategoryRow CreateRow(DateTime when, decimal amount)
        {
            return new TransactionCategoryRow() { Row = new TransactionRow(default(Guid), default(Guid), when, amount, null) };
        }
    }
}
