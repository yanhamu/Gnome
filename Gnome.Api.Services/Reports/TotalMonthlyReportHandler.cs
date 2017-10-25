using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Reports;
using Gnome.Core.Reports.TotalMonthly;
using Gnome.Core.Service.Query;
using Gnome.Core.Service.Search.Filters;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public class TotalMonthlyReportHandler : IRequestHandler<GetTotalMonthlyReport, AggregateEnvelope>
    {
        private readonly IReportRepository reportRepository;
        private readonly IQueryService queryService;
        private readonly ITotalMonthlyReportService reportService;

        public TotalMonthlyReportHandler(
            IReportRepository reportRepository,
            IQueryService queryService,
            ITotalMonthlyReportService reportService)
        {
            this.reportRepository = reportRepository;
            this.queryService = queryService;
            this.reportService = reportService;
        }

        public AggregateEnvelope Handle(GetTotalMonthlyReport message)
        {
            var report = reportRepository.Find(message.ReportId);
            var query = queryService.Get(report.QueryId);
            var filter = new TransactionSearchFilter(message.DateFilter, query.Accounts, query.IncludeExpressions, query.ExcludeExpressions);

            return reportService.Report(filter, message.UserId);
        }
    }
}
