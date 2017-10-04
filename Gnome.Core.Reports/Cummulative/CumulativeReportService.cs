using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions.QueryBuilders;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Reports.Cummulative
{
    public class CumulativeReportService
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;

        public CumulativeReportService(ITransactionCategoryRowQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public List<Aggregate> Report(TransactionSearchFilter filter, Guid userId)
        {
            throw new NotImplementedException();
        }

        private bool SameMonth(Aggregate currentAggregate, Service.Transactions.TransactionCategoryRow transaction)
        {
            return transaction.Row.Date.Year == currentAggregate.Interval.From.Year
                && transaction.Row.Date.Month == currentAggregate.Interval.From.Month;
        }

        private bool SameDay(Aggregate currentAggregate, Service.Transactions.TransactionCategoryRow transaction)
        {
            return transaction.Row.Date.Year == currentAggregate.Interval.From.Year
                && transaction.Row.Date.Month == currentAggregate.Interval.From.Month
                && transaction.Row.Date.Day == currentAggregate.Interval.From.Day;
        }

        private ClosedInterval GetInterval(DateTime date)
        {
            return new ClosedInterval(date, date);
        }
    }
}
