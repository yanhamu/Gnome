using Gnome.Core.Service.Search.Filters;
using System;

namespace Gnome.Core.Reports.TotalMonthly
{
    public interface ITotalMonthlyReportService
    {
        AggregateEnvelope Report(TransactionSearchFilter filter, Guid userId);
    }
}
