using Gnome.Core.Service.Search.Filters;
using System.Collections.Generic;

namespace Gnome.Core.Reports.AggregateReport.Model
{
    public class AggregateEnvelope
    {
        public Interval Requested { get; set; }
        public List<Aggregate> Aggregates { get; set; }

        public AggregateEnvelope()
        {
            Aggregates = new List<Aggregate>();
        }
    }
}
