using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.Reports.AggregateReport
{
    public class AggregateReportService : IAggregateReportService
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;

        public AggregateReportService(ITransactionCategoryRowQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public async Task<AggregateEnvelope> CreateReport(TransactionSearchFilter filter, Guid userId, int numberOfDaysToAggregate)
        {
            var orderedRows = (await queryBuilder
                .Query(userId, FacilitateFilter(filter, numberOfDaysToAggregate)))
                .ToList();

            return new AggregateEnvelope(filter.DateFilter, Compute(filter.DateFilter, orderedRows, numberOfDaysToAggregate));
        }

        public List<Aggregate> Compute(ClosedInterval interval, List<TransactionCategoryRow> orderedRows, int numberOfDaysToAggregate)
        {
            var aggregates = new List<Aggregate>();
            for (DateTime date = interval.From; date <= interval.To; date = date.AddDays(1))
            {
                var sumForDay = GetSumForDay(date, numberOfDaysToAggregate, orderedRows);
                aggregates.Add(new Aggregate(new ClosedInterval(date.AddDays(-numberOfDaysToAggregate), date), sumForDay));
            }
            return aggregates;
        }

        private decimal GetSumForDay(DateTime date, int numberOfDaysToAggregate, List<TransactionCategoryRow> orderedRows)
        {
            var interval = new ClosedInterval(date.AddDays(-numberOfDaysToAggregate), date);
            return orderedRows.Where(r => IsInInterval(r.Row.Date, interval)).Sum(r => r.Row.Amount);
        }

        private bool IsInInterval(DateTime date, ClosedInterval interval)
        {
            return date >= interval.From && date <= interval.To;
        }

        private TransactionSearchFilter FacilitateFilter(TransactionSearchFilter filter, int numberOfDaysToAggregate)
        {
            var startDate = filter.DateFilter.From.AddDays(-numberOfDaysToAggregate).Date;
            var endDate = filter.DateFilter.To;
            var closedInterval = new ClosedInterval(startDate, endDate);

            return new TransactionSearchFilter(closedInterval, filter.Accounts, filter.IncludeExpressions, filter.ExcludeExpressions);
        }
    }
}