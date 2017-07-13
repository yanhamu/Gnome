using System.Collections.Generic;

namespace Gnome.Features.AggregateReport.Model
{
    public class AggregateReportModel
    {
        public Interval Requested { get; set; }
        public List<Aggregate> Aggregates { get; set; }

        public AggregateReportModel()
        {
            Aggregates = new List<Aggregate>();
        }
    }
}
