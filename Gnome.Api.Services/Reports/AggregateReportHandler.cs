using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Reports;
using Gnome.Core.Reports.AggregateReport;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports
{
    public class AccountAggregateReportHandler : IRequestHandler<GetAggregateReport, AggregateEnvelope>
    {
        private readonly IAggregateReportService service;
        private readonly IQueryRepository queryRepository;

        public AccountAggregateReportHandler(
            IAggregateReportService service,
            IQueryRepository queryRepository)
        {
            this.service = service;
            this.queryRepository = queryRepository;
        }

        public AggregateEnvelope Handle(GetAggregateReport message)
        {
            var query = queryRepository.Find(message.QueryId);
            var filter = new TransactionSearchFilter()
            {

            };
            throw new NotImplementedException();
            //TODO implement
            return service.CreateReport(filter, message.UserId, message.DaysPerAggregate);
        }
    }
}
