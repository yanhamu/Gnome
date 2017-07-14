using Gnome.Core.DataAccess;
using Gnome.Core.Reports.AggregateReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Reports.AggregateReport
{
    public class Service
    {
        private readonly FioTransactionRepository fioTransactionRepository;

        public Service(FioTransactionRepository fioTransactionRepository)
        {
            this.fioTransactionRepository = fioTransactionRepository;
        }

        public AggregateEnvelope CreateReport(List<int> accountIds, Interval interval, int numberOfDaysToAggregate)
        {
            var report = new AggregateEnvelope();

            report.Requested = interval;
            report.Aggregates = GetAggregates(accountIds, interval, numberOfDaysToAggregate);

            return report;
        }

        private List<Aggregate> GetAggregates(List<int> accountIds, Interval interval, int numberOfDaysToAggregate)
        {
            var startDate = interval.From.AddDays(-numberOfDaysToAggregate).Date;
            var transactions = fioTransactionRepository.Retrieve(accountIds, startDate, interval.To);

            var groupedSums = transactions
                .Where(t => t.Amount < 0)
                .ToLookup(k => k.Date.Date, v => v.Amount)
                .ToDictionary(k => k.Key.Date, v => v.Sum(g => g));

            return GenerateAggregates(interval, numberOfDaysToAggregate, groupedSums);
        }

        private List<Aggregate> GenerateAggregates(Interval interval, int numberOfDaysToAggregate, Dictionary<DateTime, decimal> groupedSums)
        {
            var result = new List<Aggregate>();
            for (DateTime currentDate = interval.From; currentDate <= interval.To; currentDate = currentDate.AddDays(1))
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
            for (DateTime d = interval.From; d <= interval.To; d = d.AddDays(1))
            {
                if (groupedExpences.ContainsKey(d.Date))
                    sum += groupedExpences[d.Date];
            }

            return new Aggregate(interval.To, sum);
        }
    }
}