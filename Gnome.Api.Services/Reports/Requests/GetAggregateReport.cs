using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class GetAggregateReport : IRequest<AggregateEnvelope>
    {
        public ClosedInterval DateFilter { get; set; }
        public Guid QueryId { get; set; }
        public Guid UserId { get; set; }
        public int DaysPerAggregate { get; set; }

        public GetAggregateReport(Guid queryId, ClosedInterval dateFilter, Guid userId, int daysPerAggregate)
        {
            this.DaysPerAggregate = daysPerAggregate;
            this.QueryId = queryId;
            this.DateFilter = dateFilter;
            this.UserId = userId;
        }
    }
}
