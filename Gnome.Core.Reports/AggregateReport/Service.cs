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
        private readonly IFioAccountRepository accountRepository;

        public Service(
            ITransactionCategoryRowQueryBuilder queryBuilder,
            IFioAccountRepository accountRepository)
        {
            this.queryBuilder = queryBuilder;
            this.accountRepository = accountRepository;
        }

        public AggregateEnvelope CreateReport(Guid accountId, Interval interval, int numberOfDaysToAggregate)
        {
            var aggregates = GetAggregates(accountId, interval, numberOfDaysToAggregate);
            return new AggregateEnvelope(interval, aggregates);
        }

        private List<Aggregate> GetAggregates(Guid accountId, Interval interval, int numberOfDaysToAggregate)
        {
            var filter = GetFilter(accountId, interval, numberOfDaysToAggregate);
            var userId = accountRepository.Find(accountId).UserId;

            var sumsPerDay = queryBuilder
                .Query(userId, filter)
                .Select(t => new { t.Row.Date, t.Row.Amount })
                .ToLookup(k => k.Date, v => v.Amount)
                .ToDictionary(k => k.Key.Date, v => v.Sum(s => s));

            var generator = new AggregateGenerator(sumsPerDay);

            return generator.Generate(ClosedInterval.Create(interval), numberOfDaysToAggregate);
        }

        private SingleAccountTransactionSearchFilter GetFilter(Guid accountId, Interval interval, int numberOfDaysToAggregate)
        {
            var startDate = interval.From.Value.AddDays(-numberOfDaysToAggregate).Date;
            return new SingleAccountTransactionSearchFilter()
            {
                AccountId = accountId,
                DateFilter = new Interval(startDate, interval.To ?? DateTime.UtcNow.Date)
            };
        }
    }
}