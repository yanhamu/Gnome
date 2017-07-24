using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;

namespace Gnome.Core.Reports.AggregateReport
{
    public interface IAggregateReportService
    {
        AggregateEnvelope CreateReport(int accountIds, Interval interval, int numberOfDaysToAggregate);
    }
}