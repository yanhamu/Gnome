using System;

namespace Gnome.Api.Model
{
    public class ClosedInterval
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Gnome.Core.Service.Search.Filters.ClosedInterval Create()
        {
            return new Gnome.Core.Service.Search.Filters.ClosedInterval(this.From, this.To);
        }
    }
}
