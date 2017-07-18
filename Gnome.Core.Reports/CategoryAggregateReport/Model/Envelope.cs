using System.Collections.Generic;

namespace Gnome.Core.Reports.CategoryAggregateReport.Model
{
    public class Envelope
    {
        public List<Aggregate> Aggregates { get; set; }

        public Envelope(List<Aggregate> aggregates)
        {
            this.Aggregates = aggregates;
        }
    }
}
