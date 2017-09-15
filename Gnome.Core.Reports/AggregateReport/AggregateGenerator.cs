using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Reports.AggregateReport
{
    public class AggregateGenerator
    {
        private readonly Dictionary<DateTime, decimal> groupedExpenses;

        public AggregateGenerator(Dictionary<DateTime, decimal> groupedExpences)
        {
            this.groupedExpenses = groupedExpences;
        }

        public List<Aggregate> Generate(ClosedInterval interval, int numberOfDaysToAggregate)
        {
            var result = new List<Aggregate>();
            for (var currentDate = interval.From; currentDate <= interval.To; currentDate = currentDate.AddDays(1))
            {
                var closedInterval = new ClosedInterval(currentDate.AddDays(-numberOfDaysToAggregate).Date, currentDate.Date);
                result.Add(this.Create(closedInterval));
            }

            result.Reverse();

            return result;
        }

        public Aggregate Create(ClosedInterval interval)
        {
            var sum = 0m;
            for (var d = interval.From; d <= interval.To; d = d.AddDays(1))
            {
                if (this.groupedExpenses.ContainsKey(d.Date))
                    sum += groupedExpenses[d.Date];
            }

            return new Aggregate(interval, sum);
        }
    }
}