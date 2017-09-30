using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Reports.AggregateReport
{
    public interface IAggregateReportService
    {
        AggregateEnvelope CreateReport(List<Guid> accounts, Interval interval, int numberOfDaysToAggregate);
    }
}