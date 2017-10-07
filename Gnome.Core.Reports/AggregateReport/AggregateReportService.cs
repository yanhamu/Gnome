using Gnome.Core.DataAccess;
using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Reports.AggregateReport
{
    public class AggregateReportService : IAggregateReportService
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;
        private readonly IAccountRepository accountRepository;

        public AggregateReportService(
            ITransactionCategoryRowQueryBuilder queryBuilder,
            IAccountRepository accountRepository)
        {
            this.queryBuilder = queryBuilder;
            this.accountRepository = accountRepository;
        }

        public AggregateEnvelope CreateReport(TransactionSearchFilter filter, Guid userId, int numberOfDaysToAggregate)
        {
            var orderedRows = queryBuilder
                .Query(userId, FacilitateFilter(filter, numberOfDaysToAggregate))
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

            return new TransactionSearchFilter()
            {
                Accounts = filter.Accounts,
                DateFilter = new ClosedInterval(startDate, endDate),
                IncludeExpressions = filter.IncludeExpressions,
                ExcludeExpressions = filter.ExcludeExpressions
            };
        }
    }
}