using Gnome.Core.DataAccess;
using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Reports.AggregateReport
{
    public class Service : IAggregateReportService
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;
        private readonly IAccountRepository accountRepository;

        public Service(
            ITransactionCategoryRowQueryBuilder queryBuilder,
            IAccountRepository accountRepository)
        {
            this.queryBuilder = queryBuilder;
            this.accountRepository = accountRepository;
        }

        public AggregateEnvelope CreateReport(List<Guid> accounts, Interval interval, int numberOfDaysToAggregate)
        {
            var aggregates = GetAggregates(accounts, interval, numberOfDaysToAggregate);
            return new AggregateEnvelope(interval, aggregates);
        }

        private List<Aggregate> GetAggregates(List<Guid> accounts, Interval interval, int numberOfDaysToAggregate)
        {
            var filter = GetFilter(accounts, interval, numberOfDaysToAggregate);
            var userId = accountRepository.Find(accounts).UserId;

            var sumsPerDay = queryBuilder
                .Query(userId, filter)
                .Select(t => new { t.Row.Date, t.Row.Amount })
                .ToLookup(k => k.Date, v => v.Amount)
                .ToDictionary(k => k.Key.Date, v => v.Sum(s => s));

            var generator = new AggregateGenerator(sumsPerDay);

            return generator.Generate(ClosedInterval.Create(interval), numberOfDaysToAggregate);
        }

        private TransactionSearchFilter GetFilter(List<Guid> accounts, Interval interval, int numberOfDaysToAggregate)
        {
            var startDate = interval.From.HasValue
                ? interval.From.Value.AddDays(-numberOfDaysToAggregate).Date
                : default(DateTime);
            var endDate = interval.To ?? DateTime.UtcNow.Date;

            return new TransactionSearchFilter()
            {
                Accounts = accounts,
                DateFilter = new ClosedInterval(startDate, endDate)
            };
        }
    }
}