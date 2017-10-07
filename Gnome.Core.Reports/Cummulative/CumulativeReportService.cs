using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.QueryBuilders;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Reports.Cummulative
{
    /// <summary>
    /// Returns cumulative sum of amount by day per each month.
    /// </summary>
    public class CumulativeReportService
    {
        private readonly ITransactionCategoryRowQueryBuilder queryBuilder;

        public CumulativeReportService(ITransactionCategoryRowQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public List<Aggregate> Report(TransactionSearchFilter filter, Guid userId)
        {
            return Fill(queryBuilder.Query(userId, filter), filter.DateFilter);
        }

        public List<Aggregate> Fill(IEnumerable<TransactionCategoryRow> orderedRows, ClosedInterval dateFilter)
        {
            var list = new List<Aggregate>();
            var amount = 0m;
            var rowEnumerator = orderedRows.GetEnumerator();
            rowEnumerator.MoveNext();

            for (DateTime date = dateFilter.From.Date; date <= dateFilter.To; date = date.AddDays(1))
            {
                if (date.Day == 1)
                    amount = 0m;

                while (rowEnumerator.Current.Row.Date <= date)
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
