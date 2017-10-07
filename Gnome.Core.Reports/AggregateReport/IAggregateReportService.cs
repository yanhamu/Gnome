using Gnome.Core.Service.Search.Filters;
using System;

namespace Gnome.Core.Reports.AggregateReport
{
    public interface IAggregateReportService
    {
        AggregateEnvelope CreateReport(TransactionSearchFilter filter, Guid userId, int numberOfDaysToAggregate);
    }
}