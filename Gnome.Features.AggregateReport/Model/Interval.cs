using System;
using System.Collections.Generic;
using System.Text;

namespace Gnome.Features.AggregateReport.Model
{
    public class Interval
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Interval(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
