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
            IFioAccountRepository accountRepository
            )
        {
            this.queryBuilder = queryBuilder;
            this.accountRepository = accountRepository;
        }

        public AggregateEnvelope CreateReport(Guid accountId, Interval interval, int numberOfDaysToAggregate)
        {
            var report = new AggregateEnvelope();

            report.Requested = interval;
            report.Aggregates = GetAggregates(accountId, interval, numberOfDaysToAggregate);

            return report;
        }

        private List<Aggregate> GetAggregates(Guid accountId, Interval interval, int numberOfDaysToAggregate)
        {
            var startDate = interval.From.Value.AddDays(-numberOfDaysToAggregate).Date;
            var userId = accountRepository.Find(accountId).UserId;

            var filter = new SingleAccountTransactionSearchFilter()
            {
                AccountId = accountId,
                DateFilter = new Interval(startDate, interval.To ?? DateTime.UtcNow.Date)
            };

            var query = queryBuilder.Query(userId, filter);

            var groupedSums = query
                .Select(t => new { t.Row.Date, t.Row.Amount })
                .ToLookup(k => k.Date, v => v.Amount)
                .ToDictionary(k => k.Key.Date, v => v.Sum(s => s));

            return GenerateAggregates(interval, numberOfDaysToAggregate, groupedSums);
        }

        private List<Aggregate> GenerateAggregates(Interval interval, int numberOfDaysToAggregate, Dictionary<DateTime, decimal> groupedSums)
        {
            var result = new List<Aggregate>();
            for (DateTime currentDate = interval.From.Value; currentDate <= interval.To; currentDate = currentDate.AddDays(1))
            {
                var aggregateInterval = new Interval(currentDate.AddDays(-numberOfDaysToAggregate).Date, currentDate.Date);
                var aggregate = CreateAggregate(groupedSums, aggregateInterval);
                result.Add(aggregate);
            }

            result.Reverse();

            return result;
        }

        private Aggregate CreateAggregate(Dictionary<DateTime, decimal> groupedExpences, Interval interval)
        {
            var sum = 0m;
            for (DateTime d = interval.From.Value; d <= interval.To; d = d.AddDays(1))
            {
                if (groupedExpences.ContainsKey(d.Date))
                    sum += groupedExpences[d.Date];
            }

            return new Aggregate(interval.To.Value, sum);
        }
    }
}