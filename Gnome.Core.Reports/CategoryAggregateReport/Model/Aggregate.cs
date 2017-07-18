using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Reports.CategoryAggregateReport.Model
{
    public class Aggregate
    {
        public DateTime Date { get; set; }
        public List<CategoryAggregate> Categories { get; set; }

        public Aggregate(DateTime date, IEnumerable<CategoryAggregate> categoryAggregates)
        {
            this.Date = date;
            this.Categories = categoryAggregates.ToList();
        }
    }
}