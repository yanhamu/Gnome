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

        public override bool Equals(object that)
        {
            if (that is ClosedInterval c)
                return c.From == this.From && c.To == this.To;
            return false;
        }

        public override int GetHashCode()
        {
            return (this.From.ToString() + this.To.ToString()).GetHashCode();
        }

        public static bool operator ==(ClosedInterval a, ClosedInterval b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ClosedInterval a, ClosedInterval b)
        {
            return !a.Equals(b);
        }
    }
}
