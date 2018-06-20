using Gnome.Core.Service.Search.Filters;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Reports.Cummulative
{
    public interface ICumulativeReportService
    {
        Task<AggregateEnvelope> Report(TransactionSearchFilter filter, Guid userId);
    }
}