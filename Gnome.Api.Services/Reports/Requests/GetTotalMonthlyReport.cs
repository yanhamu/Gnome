using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class GetTotalMonthlyReport : IRequest<AggregateEnvelope>
    {
        public ClosedInterval DateFilter { get; set; }
        public Guid ReportId { get; }
        public Guid UserId { get; }

        public GetTotalMonthlyReport(Guid reportId, ClosedInterval dateFilter, Guid userId)
        {
            this.DateFilter = dateFilter;
            this.ReportId = reportId;
            this.UserId = userId;
        }
    }
}