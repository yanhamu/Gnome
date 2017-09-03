using Gnome.Core.Reports.AggregateReport;
using Gnome.Core.Reports.AggregateReport.Model;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports
{
    public class GetSingleAccountAggregateReport : IRequest<AggregateEnvelope>
    {
        public Interval Interval { get; set; }
        public int DaysPerAggregate { get; set; }
        public Guid AccountId { get; set; }

        public GetSingleAccountAggregateReport(Interval interval, int daysPerAggregate, Guid accountId)
        {
            this.Interval = interval;
            this.DaysPerAggregate = daysPerAggregate;
            this.AccountId = accountId;
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
            return service.CreateReport(message.AccountId, message.Interval, message.DaysPerAggregate);
        }
    }
}
