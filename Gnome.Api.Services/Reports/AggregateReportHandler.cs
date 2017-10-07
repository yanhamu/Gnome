using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.Reports;
using Gnome.Core.Reports.AggregateReport;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public class AccountAggregateReportHandler : IRequestHandler<GetAggregateReport, AggregateEnvelope>
    {
        private readonly IAggregateReportService service;

        public AccountAggregateReportHandler(IAggregateReportService service)
        {
            this.service = service;
        }

        public AggregateEnvelope Handle(GetAggregateReport message)
        {
            return service.CreateReport(message.Filter, message.UserId, message.DaysPerAggregate);
        }
    }
}
