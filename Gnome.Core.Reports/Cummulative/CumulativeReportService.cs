using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.QueryBuilders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnome.Core.Reports.Cummulative
{
    /// <summary>
    /// Returns cumulative sum of amount by day per each month.
    /// </summary>
    public class CumulativeReportService : ICumulativeReportService
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;

        public CumulativeReportService(ITransactionCategoryRowQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public async Task<AggregateEnvelope> Report(TransactionSearchFilter filter, Guid userId)
        {
            var results = Compute(await queryBuilder.Query(userId, filter), filter.DateFilter);
            return new AggregateEnvelope(filter.DateFilter, results);
        }

        public List<Aggregate> Compute(IEnumerable<TransactionCategoryRow> orderedRows, ClosedInterval dateFilter)
        {
            var list = new List<Aggregate>();
            var amount = 0m;
            var rowEnumerator = orderedRows.GetEnumerator();
            rowEnumerator.MoveNext();

            for (DateTime date = dateFilter.From.Date; date <= dateFilter.To; date = date.AddDays(1))
            {
                if (date.Day == 1)
                    amount = 0m;

                while (rowEnumerator.Current != null && rowEnumerator.Current.Row.Date <= date)
                {
                    amount += rowEnumerator.Current.Row.Amount;
                    if (rowEnumerator.MoveNext() == false)
                        break;
                }

                list.Add(new Aggregate(new ClosedInterval(date, date), amount));
            }
            return list;
        }
    }
}
