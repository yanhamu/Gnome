using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Reports.TotalMonthly
{
    public class TotalMonthlyReportService : ITotalMonthlyReportService
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;

        public TotalMonthlyReportService(ITransactionCategoryRowQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public AggregateEnvelope Report(TransactionSearchFilter filter, Guid userId)
        {
            var results = Compute(queryBuilder.Query(userId, filter), filter.DateFilter);
            return new AggregateEnvelope(filter.DateFilter, results);
        }

        public List<Aggregate> Compute(IEnumerable<TransactionCategoryRow> rows, ClosedInterval dateFilter)
        {
            var list = new List<Aggregate>();
            var dict = InitializeDictionary(dateFilter);
            foreach (var row in rows)
            {
                var interval = GetInterval(row.Row.Date);
                dict[interval] += row.Row.Amount;
            }

            return dict
                .Select(kv => new Aggregate(kv.Key, kv.Value))
                .OrderBy(a => a.Interval.From)
                .ToList();
        }

        private Dictionary<ClosedInterval, decimal> InitializeDictionary(ClosedInterval dateFilter)
        {
            var dict = new Dictionary<ClosedInterval, decimal>();
            for (DateTime date = dateFilter.From; date <= dateFilter.To; date = date.AddMonths(1))
                dict.Add(GetInterval(date), 0m);
            return dict;
        }

        private ClosedInterval GetInterval(DateTime date)
        {
            var from = new DateTime(date.Year, date.Month, 1);
            var to = from.AddMonths(1).AddDays(-1);
            return new ClosedInterval(from, to);
        }
    }
}