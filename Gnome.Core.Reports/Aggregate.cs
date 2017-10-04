using Gnome.Core.Service.Search.Filters;

namespace Gnome.Core.Reports
{
    public class Aggregate
    {
        public ClosedInterval Interval { get; }
        public decimal Expences { get; }

        public Aggregate(ClosedInterval interval, decimal expences)
        {
            this.Interval = interval;
            this.Expences = expences;
        }
    }
}
