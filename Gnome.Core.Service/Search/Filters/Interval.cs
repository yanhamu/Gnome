using System;

namespace Gnome.Core.Service.Search.Filters
{
    public class Interval
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public Interval() { }
        public Interval(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
    }
}