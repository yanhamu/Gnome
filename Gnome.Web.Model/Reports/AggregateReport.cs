using System;
using System.Collections.Generic;

namespace Gnome.Web.Model.Reports
{
    public class AggregateReport
    {
        public string RandomString { get; set; }
        public Interval Requested { get; set; }
        public List<Aggregate> Aggregates { get; set; }

        public AggregateReport()
        {
            Aggregates = new List<Aggregate>();
        }
    }

    public class Aggregate
    {
        public DateTime Date { get; set; }
        public decimal Expences { get; set; }
    }
}
