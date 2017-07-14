using System;

namespace Gnome.Core.Reports.AggregateReport.Model
{
    public class Aggregate
    {
        public DateTime Date { get; set; }
        public decimal Expences { get; set; }

        public Aggregate(DateTime date, decimal expences)
        {
            this.Date = date.Date;
            this.Expences = expences;
        }
    }
}
