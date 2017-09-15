using Gnome.Core.Service.Search.Filters;
using System.Collections.Generic;

namespace Gnome.Core.Reports.AggregateReport.Model
{
    public class AggregateEnvelope
    {
        public Interval Requested { get; }
        public List<Aggregate> Aggregates { get; }

        public AggregateEnvelope(Interval interval, List<Aggregate> aggregates)
        {
            Aggregates = aggregates;
            Requested = interval;
        }
    }
}
