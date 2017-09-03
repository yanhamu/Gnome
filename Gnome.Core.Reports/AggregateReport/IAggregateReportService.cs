using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using System;

namespace Gnome.Core.Reports.AggregateReport
{
    public interface IAggregateReportService
    {
        AggregateEnvelope CreateReport(Guid accountIds, Interval interval, int numberOfDaysToAggregate);
    }
}