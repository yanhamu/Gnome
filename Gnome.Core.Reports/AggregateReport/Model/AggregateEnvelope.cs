using Gnome.Core.Service.Search.Filters;
using System.Collections.Generic;

namespace Gnome.Core.Reports.AggregateReport.Model
{
    public class AggregateEnvelope
    {
        public ClosedInterval Requested { get; }
        public List<Aggregate> Aggregates { get; }

        public AggregateEnvelope(ClosedInterval interval, List<Aggregate> aggregates)
        {
            Aggregates = aggregates;
            Requested = interval;
        }
    }
}
