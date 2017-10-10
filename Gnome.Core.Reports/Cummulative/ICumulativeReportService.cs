using Gnome.Core.Service.Search.Filters;
using System;

namespace Gnome.Core.Reports.Cummulative
{
    public interface ICumulativeReportService
    {
        AggregateEnvelope Report(TransactionSearchFilter filter, Guid userId);
    }
}