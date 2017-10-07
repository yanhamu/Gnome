using Gnome.Core.Reports.AggregateReport;
using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports
{
    public class GetSingleAccountAggregateReport : IRequest<AggregateEnvelope>
    {
        public TransactionSearchFilter Filter { get; set; }
        public int DaysPerAggregate { get; set; }
        public Guid UserId { get; set; }

        public GetSingleAccountAggregateReport(TransactionSearchFilter filter, Guid userId, int daysPerAggregate)
        {
            this.DaysPerAggregate = daysPerAggregate;
            this.Filter = filter;
            this.UserId = userId;
        }
    }

    public class SingleAccountAggregateReportHandler : IRequestHandler<GetSingleAccountAggregateReport, AggregateEnvelope>
    {
        private readonly IAggregateReportService service;

        public SingleAccountAggregateReportHandler(IAggregateReportService service)
        {
            this.service = service;
        }

        public AggregateEnvelope Handle(GetSingleAccountAggregateReport message)
        {
            return service.CreateReport(message.Filter, message.UserId, message.DaysPerAggregate);
        }
    }
}
