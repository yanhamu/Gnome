using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Reports;
using Gnome.Core.Reports.AggregateReport;
using Gnome.Core.Service.Query;
using Gnome.Core.Service.Search.Filters;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public class AccountAggregateReportHandler : IRequestHandler<GetAggregateReport, AggregateEnvelope>
    {
        private readonly IAggregateReportService service;
        private readonly IQueryService queryService;
        private readonly IReportRepository reportRepository;

        public AccountAggregateReportHandler(
            IAggregateReportService service,
            IQueryService queryService,
            IReportRepository reportRepository)
        {
            this.service = service;
            this.queryService = queryService;
            this.reportRepository = reportRepository;
        }

        public AggregateEnvelope Handle(GetAggregateReport message)
        {
            var report = reportRepository.Find(message.ReportId);
            var query = queryService.Get(report.QueryId);
            var filter = new TransactionSearchFilter(message.DateFilter, query.Accounts, query.IncludeExpressions, query.ExcludeExpressions);
            return service.CreateReport(filter, message.UserId, message.DaysPerAggregate);
        }
    }
}
