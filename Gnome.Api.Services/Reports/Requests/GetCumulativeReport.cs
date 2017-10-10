using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class GetCumulativeReport : IRequest<AggregateEnvelope>
    {
        public ClosedInterval DateFilter { get; set; }
        public Guid QueryId { get; }
        public Guid UserId { get; }

        public GetCumulativeReport(Guid queryId, ClosedInterval dateFilter, Guid userId)
        {
            this.DateFilter = dateFilter;
            this.QueryId = queryId;
            this.UserId = userId;
        }
    }
}