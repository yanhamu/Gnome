using System;

namespace Gnome.Core.Service.Search.Filters
{
    public class ClosedInterval
    {
        public DateTime From { get; }
        public DateTime To { get; }

        public ClosedInterval(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }

        public static ClosedInterval Create(Interval interval)
        {
            return new ClosedInterval(interval.From.Value, interval.To.Value);
        }
    }
}
