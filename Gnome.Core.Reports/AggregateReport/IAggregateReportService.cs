using Gnome.Core.Service.Search.Filters;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Reports.AggregateReport
{
    public interface IAggregateReportService
    {
        Task<AggregateEnvelope> CreateReport(TransactionSearchFilter filter, Guid userId, int numberOfDaysToAggregate);
    }
}