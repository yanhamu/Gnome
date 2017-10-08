using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class GetCumulativeReport : IRequest<AggregateEnvelope>
    {
        public TransactionSearchFilter Filter { get; }
        public Guid UserId { get; }

        public GetCumulativeReport(TransactionSearchFilter filter, Guid userId)
        {
            this.Filter = filter;
            this.UserId = userId;
        }
    }
}