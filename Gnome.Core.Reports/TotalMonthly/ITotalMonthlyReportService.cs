using Gnome.Core.Service.Search.Filters;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Reports.TotalMonthly
{
    public interface ITotalMonthlyReportService
    {
        Task<AggregateEnvelope> Report(TransactionSearchFilter filter, Guid userId);
    }
}
