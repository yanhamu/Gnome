using Gnome.Core.Reports.AggregateReport.Model;
using System.Collections.Generic;

namespace Gnome.Core.Reports.AggregateReport
{
    public interface IAggregateReportService
    {
        AggregateEnvelope CreateReport(List<int> accountIds, Interval interval, int numberOfDaysToAggregate);
    }
}