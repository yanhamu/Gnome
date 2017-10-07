using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class GetAggregateReport : IRequest<AggregateEnvelope>
    {
        public TransactionSearchFilter Filter { get; set; }
        public int DaysPerAggregate { get; set; }
        public Guid UserId { get; set; }

        public GetAggregateReport(TransactionSearchFilter filter, Guid userId, int daysPerAggregate)
        {
            this.DaysPerAggregate = daysPerAggregate;
            this.Filter = filter;
            this.UserId = userId;
        }
    }
}
